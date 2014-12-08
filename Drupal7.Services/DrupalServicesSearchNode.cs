using System;
using CookComputing.XmlRpc;
namespace Drupal7.Services
{
	/// <summary>
	/// https://www.drupal.org/project/services_search
	/// </summary>
	public sealed partial class DrupalServices
	{
		private AsyncCallback SearchNodeOperationCompleted;

		public event DrupalAsyncCompletedEventHandler<XmlRpcStruct[]> SearchNodeCompleted;

		public XmlRpcStruct[] SearchNode(string keys)
		{
			return this.SearchNode(keys, true, new string[]{ });
		}

		public XmlRpcStruct[] SearchNode(string keys, string[] fields)
		{
			return this.SearchNode(keys, false, fields);
		}

		/// <summary>
		/// Return search results for nodes.
		/// </summary>
		/// <param name="keys">The keywords to search for within the nodes.</param>
		/// <param name="simple">
		/// When set to TRUE, only the fields indicated in $stdkeys will be returned.
		/// This can be helpful to limit the size of the search results.
		/// </param>
		/// <param name="fields">
		/// An array of the node properties that should be returned. When $simple
		/// is not set, a full node object is returned with each result. You can
		/// limit the properties of these objects to only the ones you need by
		/// specifying them in this array. Again, this gives the opportunity to
		/// limit your result set.
		/// </param>
		/// <returns>
		/// An array of search results. If $simple is TRUE, this array will contain
		/// only results and no node objects. If $simple is FALSE the array will
		/// contain both results and full node objects, possibly limited by the
		/// properties indicated in $fields.
		/// </returns>
		public XmlRpcStruct[] SearchNode(string keys, bool simple, string[] fields)
		{
			keys = keys ?? "";
			fields = fields ?? new string[0];

			this.InitRequest();
			XmlRpcStruct[] res = null;
			try {
				res = drupalServiceSystem.SearchNodeRetrieve(new object(), keys, simple, fields);
			} catch (Exception ex) {
				this.HandleException(ex, "SearchNode");
			}
			return res;
		}

		public void SearchNodeAsync(string keys, bool simple, string[] fields, object asyncState)
		{
			keys = keys ?? "";
			fields = fields ?? new string[0];

			if (this.SearchNodeOperationCompleted == null) {
				this.SearchNodeOperationCompleted = new AsyncCallback(this.OnSearchNodeCompleted);
			}
			drupalServiceSystem.BeginSearchNodeRetrieve(new object(), keys, simple, fields, this.SearchNodeOperationCompleted, asyncState);
		}

		void OnSearchNodeCompleted(IAsyncResult asyncResult)
		{
			if (this.SearchNodeCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				XmlRpcStruct[] result = null;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndSearchNodeRetrieve(asyncResult);
					this.SearchNodeCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct[]>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.SearchNodeCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct[]>(result, ex, asyncResult.AsyncState));
				}
			}
		}
	}
}

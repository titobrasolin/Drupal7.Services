using System;
using CookComputing.XmlRpc;
namespace Drupal7.Services
{
	/// <summary>
	/// https://www.drupal.org/project/services_views
	/// </summary>
	public sealed partial class DrupalServices
	{
		private AsyncCallback ViewsRetrieveOperationCompleted;

		public event DrupalAsyncCompletedEventHandler<XmlRpcStruct> ViewsRetrieveCompleted;

		public XmlRpcStruct ViewsRetrieve (string view_name, string display_id, XmlRpcStruct args, int offset, int limit, object return_type, XmlRpcStruct filters)
		{
			this.InitRequest ();
			XmlRpcStruct res = null;
			try {
				res = drupalServiceSystem.ViewsRetrieve (view_name, display_id, args, offset, limit, return_type, filters);
			} catch (Exception ex) {
				this.HandleException (ex, "ViewsRetrieve");
			}
			return res;
		}

		public void ViewsRetrieveAsync (string view_name, string display_id, XmlRpcStruct args, int offset, int limit, object return_type, XmlRpcStruct filters, object asyncState)
		{
			if (this.ViewsRetrieveOperationCompleted == null) {
				this.ViewsRetrieveOperationCompleted = new AsyncCallback (this.OnViewsRetrieveCompleted);
			}
			drupalServiceSystem.BeginViewsRetrieve (view_name, display_id, args, offset, limit, return_type, filters, this.ViewsRetrieveOperationCompleted, asyncState);
		}

		void OnViewsRetrieveCompleted (IAsyncResult asyncResult)
		{
			if (this.ViewsRetrieveCompleted != null) {
				XmlRpcAsyncResult clientResult = (XmlRpcAsyncResult)asyncResult;
				XmlRpcStruct result = null;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndViewsRetrieve (asyncResult);
					this.ViewsRetrieveCompleted (this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct> (result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.ViewsRetrieveCompleted (this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct> (result, ex, asyncResult.AsyncState));
				}
			}
		}
	}
}

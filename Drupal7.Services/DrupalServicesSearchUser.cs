using System;
using CookComputing.XmlRpc;
namespace Drupal7.Services
{
	public struct DrupalUserSearchResult
	{
		public string title;
		public string link;
	}

	/// <summary>
	/// https://www.drupal.org/project/services_search
	/// </summary>
	public sealed partial class DrupalServices
	{
		private AsyncCallback SearchUserOperationCompleted;

		public event DrupalAsyncCompletedEventHandler<DrupalUserSearchResult[]> SearchUserCompleted;

		/// <summary>
		/// The keywords to search for within the users.
		/// </summary>
		/// <param name="keys">Return search results for users.</param>
		/// <returns>An array of search results.</returns>
		public DrupalUserSearchResult[] SearchUser(string keys)
		{
			keys = keys ?? "";

			this.InitRequest();
			DrupalUserSearchResult[] res = null;
			try {
				res = drupalServiceSystem.SearchUserRetrieve(new object(), keys);
			} catch (Exception ex) {
				this.HandleException(ex, "SearchUser");
			}
			return res;
		}

		public void SearchUserAsync(string keys, object asyncState)
		{
			keys = keys ?? "";

			if (this.SearchUserOperationCompleted == null) {
				this.SearchUserOperationCompleted = new AsyncCallback(this.OnSearchUserCompleted);
			}
			drupalServiceSystem.BeginSearchUserRetrieve(new object(), keys, this.SearchUserOperationCompleted, asyncState);
		}

		void OnSearchUserCompleted(IAsyncResult asyncResult)
		{
			if (this.SearchUserCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				DrupalUserSearchResult[] result = null;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndSearchUserRetrieve(asyncResult);
					this.SearchUserCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalUserSearchResult[]>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.SearchUserCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalUserSearchResult[]>(result, ex, asyncResult.AsyncState));
				}
			}
		}
	}
}

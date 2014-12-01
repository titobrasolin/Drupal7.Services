using System;
using CookComputing.XmlRpc;
namespace Drupal7.Services
{
	/// <summary>
	/// https://www.drupal.org/project/services_menu
	/// </summary>
	public sealed partial class DrupalServices
	{
		private AsyncCallback MenuRetrieveOperationCompleted;
		
		public event DrupalAsyncCompletedEventHandler<object> MenuRetrieveCompleted;

		public object MenuRetrieve (string menu_name)
		{
			this.InitRequest ();
			object res = null;
			try {
				res = drupalServiceSystem.MenuRetrieve (menu_name);
			} catch (Exception ex) {
				this.HandleException (ex, "MenuRetrieve");
			}
			return res;
		}
		
		public void MenuRetrieveAsync (string menu_name, object asyncState)
		{
			if (this.MenuRetrieveOperationCompleted == null) {
				this.MenuRetrieveOperationCompleted = new AsyncCallback (this.OnMenuRetrieveCompleted);
			}
			drupalServiceSystem.BeginMenuRetrieve (menu_name, this.MenuRetrieveOperationCompleted, asyncState);
		}

		void OnMenuRetrieveCompleted (IAsyncResult asyncResult)
		{
			if (this.MenuRetrieveCompleted != null) {
				XmlRpcAsyncResult clientResult = (XmlRpcAsyncResult)asyncResult;
				object result = null;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndMenuRetrieve (asyncResult);
					this.MenuRetrieveCompleted (this, new DrupalAsyncCompletedEventArgs<object> (result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.MenuRetrieveCompleted (this, new DrupalAsyncCompletedEventArgs<object> (result, ex, asyncResult.AsyncState));
				}
			}
		}
	}
}

using System;
using CookComputing.XmlRpc;
namespace Drupal7.Services
{
	/// <summary>
	/// https://www.drupal.org/project/services_tools
	/// </summary>
	public sealed partial class DrupalServices
	{
		private AsyncCallback DefinitionIndexOperationCompleted;
		
		public event DrupalAsyncCompletedEventHandler<XmlRpcStruct> DefinitionIndexCompleted;

		public XmlRpcStruct DefinitionIndex()
		{
			this.InitRequest();
			XmlRpcStruct res = null;
			try {
				res = drupalServiceSystem.DefinitionIndex();
			} catch (Exception ex) {
				this.HandleException(ex, "DefinitionIndex");
			}
			return res;
		}
		
		public void DefinitionIndexAsync(object asyncState)
		{
			if (this.DefinitionIndexOperationCompleted == null) {
				this.DefinitionIndexOperationCompleted = new AsyncCallback(this.OnDefinitionIndexCompleted);
			}
			drupalServiceSystem.BeginDefinitionIndex(this.DefinitionIndexOperationCompleted, asyncState);
		}

		void OnDefinitionIndexCompleted(IAsyncResult asyncResult)
		{
			if (this.DefinitionIndexCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				XmlRpcStruct result = null;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndDefinitionIndex(asyncResult);
					this.DefinitionIndexCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.DefinitionIndexCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct>(result, ex, asyncResult.AsyncState));
				}
			}
		}
	}
}

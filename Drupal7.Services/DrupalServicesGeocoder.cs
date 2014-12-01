using System;
using CookComputing.XmlRpc;
namespace Drupal7.Services
{
	/// <summary>
	/// https://www.drupal.org/project/geocoder
	/// </summary>
	public sealed partial class DrupalServices
	{
		private AsyncCallback GeocoderRetrieveOperationCompleted;
		private AsyncCallback GeocoderIndexOperationCompleted;
		
		public event DrupalAsyncCompletedEventHandler<string> GeocoderRetrieveCompleted;
		public event DrupalAsyncCompletedEventHandler<XmlRpcStruct> GeocoderIndexCompleted;

		public string GeocoderRetrieve(string handler, string data, string output)
		{
			this.InitRequest ();
			string res = "";
			try {
				res = drupalServiceSystem.GeocoderRetrieve (handler, data, output);
			} catch (Exception ex) {
				this.HandleException (ex, "GeocoderRetrieve");
			}
			return res;
		}
		
		public void GeocoderRetrieveAsync (string handler, string data, string output, object asyncState)
		{
			if (this.GeocoderRetrieveOperationCompleted == null) {
				this.GeocoderRetrieveOperationCompleted = new AsyncCallback (this.OnGeocoderRetrieveCompleted);
			}
			drupalServiceSystem.BeginGeocoderRetrieve (handler, data, output, this.GeocoderRetrieveOperationCompleted, asyncState);
		}

		void OnGeocoderRetrieveCompleted (IAsyncResult asyncResult)
		{
			if (this.GeocoderRetrieveCompleted != null) {
				XmlRpcAsyncResult clientResult = (XmlRpcAsyncResult)asyncResult;
				string result = "";
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndGeocoderRetrieve (asyncResult);
					this.GeocoderRetrieveCompleted (this, new DrupalAsyncCompletedEventArgs<string> (result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.GeocoderRetrieveCompleted (this, new DrupalAsyncCompletedEventArgs<string> (result, ex, asyncResult.AsyncState));
				}
			}
		}

		public XmlRpcStruct GeocoderIndex ()
		{
			this.InitRequest ();
			XmlRpcStruct res = null;
			try {
				res = drupalServiceSystem.GeocoderIndex ();
			} catch (Exception ex) {
				this.HandleException (ex, "GeocoderIndex");
			}
			return res;
		}

		public void GeocoderIndexAsync (object asyncState)
		{
			if (this.GeocoderIndexOperationCompleted == null) {
				this.GeocoderIndexOperationCompleted = new AsyncCallback (this.OnGeocoderIndexCompleted);
			}
			drupalServiceSystem.BeginGeocoderIndex (this.GeocoderIndexOperationCompleted, asyncState);
		}

		void OnGeocoderIndexCompleted (IAsyncResult asyncResult)
		{
			if (this.GeocoderIndexCompleted != null) {
				XmlRpcAsyncResult clientResult = (XmlRpcAsyncResult)asyncResult;
				XmlRpcStruct result = null;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndGeocoderIndex (asyncResult);
					this.GeocoderIndexCompleted (this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct> (result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.GeocoderIndexCompleted (this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct> (result, ex, asyncResult.AsyncState));
				}
			}
		}
	}
}

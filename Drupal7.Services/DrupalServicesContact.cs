using System;
using CookComputing.XmlRpc;
namespace Drupal7.Services
{
	[XmlRpcMissingMapping(MappingAction.Ignore)]
	public struct DrupalContact
	{
		public string cid;
		public string category;
		public string recipients;
		public string reply;
		public string weight;
		public string selected;
	}

	/// <summary>
	/// https://www.drupal.org/project/services_contact
	/// </summary>
	public sealed partial class DrupalServices
	{
		private AsyncCallback ContactIndexOperationCompleted;
		private AsyncCallback ContactSiteOperationCompleted;
		private AsyncCallback ContactPersonalOperationCompleted;

		public event DrupalAsyncCompletedEventHandler<DrupalContact[]> ContactIndexCompleted;
		public event DrupalAsyncCompletedEventHandler<bool> ContactSiteCompleted;
		public event DrupalAsyncCompletedEventHandler<bool> ContactPersonalCompleted;

		public DrupalContact[] ContactIndex()
		{
			this.InitRequest();
			DrupalContact[] res = null;
			try {
				res = drupalServiceSystem.ContactIndex();
			} catch (Exception ex) {
				this.HandleException(ex, "ContactIndex");
			}
			return res;
		}

		public void ContactIndexAsync(object asyncState)
		{
			if (this.ContactIndexOperationCompleted == null) {
				this.ContactIndexOperationCompleted = new AsyncCallback(this.OnContactIndexCompleted);
			}
			drupalServiceSystem.BeginContactIndex(this.ContactIndexOperationCompleted, asyncState);
		}

		void OnContactIndexCompleted(IAsyncResult asyncResult)
		{
			if (this.ContactIndexCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				DrupalContact[] result = null;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndContactIndex(asyncResult);
					this.ContactIndexCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalContact[]>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.ContactIndexCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalContact[]>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public bool ContactSite(string name, string mail, string subject, int cid, string message, bool copy)
		{
			this.InitRequest();
			bool res = false;
			try {
				res = drupalServiceSystem.ContactSite(name, mail, subject, cid, message, copy);
			} catch (Exception ex) {
				this.HandleException(ex, "ContactSite");
			}
			return res;
		}

		public void ContactSiteAsync(string name, string mail, string subject, int cid, string message, bool copy, object asyncState)
		{
			if (this.ContactSiteOperationCompleted == null) {
				this.ContactSiteOperationCompleted = new AsyncCallback(this.OnContactSiteCompleted);
			}
			drupalServiceSystem.BeginContactSite(name, mail, subject, cid, message, copy, this.ContactSiteOperationCompleted, asyncState);
		}

		void OnContactSiteCompleted(IAsyncResult asyncResult)
		{
			if (this.ContactSiteCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				bool result = false;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndContactSite(asyncResult);
					this.ContactSiteCompleted(this, new DrupalAsyncCompletedEventArgs<bool>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.ContactSiteCompleted(this, new DrupalAsyncCompletedEventArgs<bool>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public bool ContactPersonal(string name, string mail, string to, string subject, string message, bool copy)
		{
			this.InitRequest();
			bool res = false;
			try {
				res = drupalServiceSystem.ContactPersonal(name, mail, to, subject, message, copy);
			} catch (Exception ex) {
				this.HandleException(ex, "ContactPersonal");
			}
			return res;
		}

		public void ContactPersonalAsync(string name, string mail, string to, string subject, string message, bool copy, object asyncState)
		{
			if (this.ContactPersonalOperationCompleted == null) {
				this.ContactPersonalOperationCompleted = new AsyncCallback(this.OnContactPersonalCompleted);
			}
			drupalServiceSystem.BeginContactPersonal(name, mail, to, subject, message, copy, this.ContactPersonalOperationCompleted, asyncState);
		}

		void OnContactPersonalCompleted(IAsyncResult asyncResult)
		{
			if (this.ContactPersonalCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				bool result = false;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndContactPersonal(asyncResult);
					this.ContactPersonalCompleted(this, new DrupalAsyncCompletedEventArgs<bool>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.ContactPersonalCompleted(this, new DrupalAsyncCompletedEventArgs<bool>(result, ex, asyncResult.AsyncState));
				}
			}
		}
	}
}

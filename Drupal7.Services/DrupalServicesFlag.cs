using System;
using CookComputing.XmlRpc;
namespace Drupal7.Services
{
	/// <summary>
	/// https://www.drupal.org/project/flag_service
	/// </summary>
	public sealed partial class DrupalServices
	{
		private AsyncCallback FlagIsFlaggedOperationCompleted;

		public event DrupalAsyncCompletedEventHandler<bool> FlagIsFlaggedCompleted;
				
		public bool FlagIsFlagged(string flag_name, int content_id)
		{
			this.InitRequest();
			bool result = false;
			try {
				result = drupalServiceSystem.FlagIsFlagged(flag_name, content_id);
			} catch (Exception ex) {
				this.HandleException(ex, "FlagIsFlagged");
			}
			return result;
		}

		public void FlagIsFlaggedAsync(string flag_name, int content_id, object asyncState)
		{
			if (this.FlagIsFlaggedOperationCompleted == null) {
				this.FlagIsFlaggedOperationCompleted = new AsyncCallback(this.OnFlagIsFlaggedCompleted);
			}
			drupalServiceSystem.BeginFlagIsFlagged(flag_name, content_id, this.FlagIsFlaggedOperationCompleted, asyncState);
		}

		public bool FlagIsFlagged(string flag_name, int content_id, int uid)
		{
			this.InitRequest();
			bool result = false;
			try {
				result = drupalServiceSystem.FlagIsFlagged(flag_name, content_id, uid);
			} catch (Exception ex) {
				this.HandleException(ex, "FlagIsFlagged");
			}
			return result;
		}

		public void FlagIsFlaggedAsync(string flag_name, int content_id, int uid, object asyncState)
		{
			if (this.FlagIsFlaggedOperationCompleted == null) {
				this.FlagIsFlaggedOperationCompleted = new AsyncCallback(this.OnFlagIsFlaggedCompleted);
			}
			drupalServiceSystem.BeginFlagIsFlagged(flag_name, content_id, uid, this.FlagIsFlaggedOperationCompleted, asyncState);
		}

		void OnFlagIsFlaggedCompleted(IAsyncResult asyncResult)
		{
			if (this.FlagIsFlaggedCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				bool result = false;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndFlagIsFlagged(asyncResult);
					this.FlagIsFlaggedCompleted(this, new DrupalAsyncCompletedEventArgs<bool>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.FlagIsFlaggedCompleted(this, new DrupalAsyncCompletedEventArgs<bool>(result, ex, asyncResult.AsyncState));
				}
			}
		}
	}
}

using System;
using CookComputing.XmlRpc;
namespace Drupal7.Services
{
	/// <summary>
	/// https://www.drupal.org/project/services
	/// </summary>
	public sealed partial class DrupalServices
	{
		private AsyncCallback SystemConnectOperationCompleted;
		private AsyncCallback SystemGetVariableOperationCompleted;
		private AsyncCallback SystemSetVariableOperationCompleted;
		private AsyncCallback SystemDelVariableOperationCompleted;

		public event DrupalAsyncCompletedEventHandler<DrupalSessionObject> SystemConnectCompleted;
		public event DrupalAsyncCompletedEventHandler<object> SystemGetVariableCompleted;
		// public event DrupalAsyncCompletedEventHandler<...> SystemSetVariableCompleted;
		// public event DrupalAsyncCompletedEventHandler<...> SystemDelVariableCompleted;

		/// <summary>
		/// Returns the details of currently logged in user.
		/// </summary>
		/// <returns>Object with session id, session name and a user object.</returns>
		public DrupalSessionObject SystemConnect()
		{
			this.InitRequest();
			DrupalSessionObject res = default(DrupalSessionObject);
			try {
				res = drupalServiceSystem.SystemConnect();
			} catch (Exception ex) {
				this.HandleException(ex, "SystemConnect");
			}
			return res;
		}

		public void SystemConnectAsync(object asyncState)
		{
			if (this.SystemConnectOperationCompleted == null) {
				this.SystemConnectOperationCompleted = new AsyncCallback(this.OnSystemConnectCompleted);
			}
			drupalServiceSystem.BeginSystemConnect(this.SystemConnectOperationCompleted, asyncState);
		}

		void OnSystemConnectCompleted(IAsyncResult asyncResult)
		{
			if (this.SystemConnectCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				DrupalSessionObject result = default(DrupalSessionObject);
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndSystemConnect(asyncResult);
					this.SystemConnectCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalSessionObject>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.SystemConnectCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalSessionObject>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public object SystemGetVariable(string name, object @default)
		{
			this.InitRequest();
			object res = null;
			try {
				res = drupalServiceSystem.SystemGetVariable(name, @default);
			} catch (Exception ex) {
				this.HandleException(ex, "SystemGetVariable");
			}
			return res;
		}

		public void SystemGetVariableAsync(string name, object @default, object asyncState)
		{
			if (this.SystemGetVariableOperationCompleted == null) {
				this.SystemGetVariableOperationCompleted = new AsyncCallback(this.OnSystemGetVariableCompleted);
			}
			drupalServiceSystem.BeginSystemGetVariable(name, @default, this.SystemGetVariableOperationCompleted, asyncState);
		}

		void OnSystemGetVariableCompleted(IAsyncResult asyncResult)
		{
			if (this.SystemGetVariableCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				object result = null;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndSystemGetVariable(asyncResult);
					this.SystemGetVariableCompleted(this, new DrupalAsyncCompletedEventArgs<object>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.SystemGetVariableCompleted(this, new DrupalAsyncCompletedEventArgs<object>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		/// <summary>
		/// Sets a persistent variable.
		///
		/// Case-sensitivity of the variable_* functions depends on the database
		/// collation used. To avoid problems, always use lower case for persistent
		/// variable names.
		/// </summary>
		/// <param name="name">The name of the variable to set.</param>
		/// <param name="value">
		/// The value to set. This can be any PHP data type; these functions take care
		/// of serialization as necessary.
		/// </param>
		public void SystemSetVariable(string name, object @value)
		{
			this.InitRequest();
			try {
				drupalServiceSystem.SystemSetVariable(name, @value);
			} catch (Exception ex) {
				this.HandleException(ex, "SystemSetVariable");
			}
		}

		public void SystemSetVariableAsync(string name, object @value, object asyncState)
		{
			if (this.SystemSetVariableOperationCompleted == null) {
				this.SystemSetVariableOperationCompleted = new AsyncCallback(this.OnSystemSetVariableCompleted);
			}
			drupalServiceSystem.BeginSystemSetVariable(name, @value, this.SystemSetVariableOperationCompleted, asyncState);
		}

		void OnSystemSetVariableCompleted(IAsyncResult asyncResult)
		{
			// TODO OnSystemSetVariableCompleted
		}

		public void SystemDelVariable(string name)
		{
			this.InitRequest();
			try {
				drupalServiceSystem.SystemDelVariable(name);
			} catch (Exception ex) {
				this.HandleException(ex, "SystemDelVariable");
			}
		}

		public void SystemDelVariableAsync(string name, object asyncState)
		{
			if (this.SystemDelVariableOperationCompleted == null) {
				this.SystemDelVariableOperationCompleted = new AsyncCallback(this.OnSystemDelVariableCompleted);
			}
			drupalServiceSystem.BeginSystemDelVariable(name, this.SystemDelVariableOperationCompleted, asyncState);
		}

		void OnSystemDelVariableCompleted(IAsyncResult asr)
		{
			// TODO OnSystemDelVariableCompleted
		}
	}
}

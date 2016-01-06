using System;
using CookComputing.XmlRpc;
using System.Collections;


namespace Drupal7.Services
{
	public struct DrupalUserToken
	{
		public string token;
	}

	[XmlRpcMissingMapping(MappingAction.Ignore)]
	public struct DrupalUser
	{
		public object uid;
		public object login;
		public string access;
		public string init;
		public string signature;
		public string name;
		public string signature_format;
		public string theme;
		public string timezone;
		public object data;
		public string created;
		public object picture;
		public string status;
		public XmlRpcStruct rdf_mapping;
		public XmlRpcStruct roles;
		public string language;
		public string mail;
	}

	/// <summary>
	/// https://www.drupal.org/project/services
	/// </summary>
	public sealed partial class DrupalServices
	{
		private AsyncCallback UserRetrieveOperationCompleted;
		private AsyncCallback UserCreateOperationCompleted;
		private AsyncCallback UserUpdateOperationCompleted;
		private AsyncCallback UserDeleteOperationCompleted;
		private AsyncCallback UserIndexOperationCompleted;
		private AsyncCallback UserLoginOperationCompleted;
		private AsyncCallback UserLogoutOperationCompleted;
		private AsyncCallback UserRegisterOperationCompleted;
		private AsyncCallback UserTokenOperationCompleted;
		
		public event DrupalAsyncCompletedEventHandler<IDictionary> UserRetrieveCompleted;
		public event DrupalAsyncCompletedEventHandler<DrupalUser> UserCreateCompleted;
		public event DrupalAsyncCompletedEventHandler<DrupalUser> UserUpdateCompleted;
		public event DrupalAsyncCompletedEventHandler<bool> UserDeleteCompleted;
		public event DrupalAsyncCompletedEventHandler<IDictionary[]> UserIndexCompleted;
		public event DrupalAsyncCompletedEventHandler<DrupalSessionObject> UserLoginCompleted;
		public event DrupalAsyncCompletedEventHandler<bool> UserLogoutCompleted;
		public event DrupalAsyncCompletedEventHandler<DrupalUser> UserRegisterCompleted;
		public event DrupalAsyncCompletedEventHandler<DrupalUserToken> UserTokenCompleted;

		public IDictionary UserRetrieve(int uid)
		{
			this.InitRequest();
			var res = default(XmlRpcStruct);
			try {
				res = drupalServiceSystem.UserRetrieve(uid);
			} catch (Exception ex) {
				this.HandleException(ex, "UserRetrieve");
			}
			return res;
		}
		
		public void UserRetrieveAsync(int uid, object asyncState)
		{
			if (this.UserRetrieveOperationCompleted == null) {
				this.UserRetrieveOperationCompleted = new AsyncCallback(this.OnUserRetrieveCompleted);
			}
			drupalServiceSystem.BeginUserRetrieve(uid, this.UserRetrieveOperationCompleted, asyncState);
		}

		void OnUserRetrieveCompleted(IAsyncResult asyncResult)
		{
			if (this.UserRetrieveCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				var result = default(XmlRpcStruct);
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndUserRetrieve(asyncResult);
					this.UserRetrieveCompleted(this, new DrupalAsyncCompletedEventArgs<IDictionary>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.UserRetrieveCompleted(this, new DrupalAsyncCompletedEventArgs<IDictionary>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public DrupalUser UserCreate(XmlRpcStruct account)
		{
			this.InitRequest();
			DrupalUser res = default(DrupalUser);
			try {
				res = drupalServiceSystem.UserCreate(account);
			} catch (Exception ex) {
				this.HandleException(ex, "UserCreate");
			}
			return res;
		}
		
		public void UserCreateAsync(XmlRpcStruct account, object asyncState)
		{
			if (this.UserCreateOperationCompleted == null) {
				this.UserCreateOperationCompleted = new AsyncCallback(this.OnUserCreateCompleted);
			}
			drupalServiceSystem.BeginUserCreate(account, this.UserCreateOperationCompleted, asyncState);
		}

		void OnUserCreateCompleted(IAsyncResult asyncResult)
		{
			if (this.UserCreateCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				DrupalUser result = default(DrupalUser);
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndUserCreate(asyncResult);
					this.UserCreateCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalUser>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.UserCreateCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalUser>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public DrupalUser UserUpdate(int uid, XmlRpcStruct account)
		{
			this.InitRequest();
			DrupalUser res = default(DrupalUser);
			try {
				res = drupalServiceSystem.UserUpdate(uid, account);
			} catch (Exception ex) {
				this.HandleException(ex, "UserUpdate");
			}
			return res;
		}
		
		public void UserUpdateAsync(int uid, XmlRpcStruct account, object asyncState)
		{
			if (this.UserUpdateOperationCompleted == null) {
				this.UserUpdateOperationCompleted = new AsyncCallback(this.OnUserUpdateCompleted);
			}
			drupalServiceSystem.BeginUserUpdate(uid, account, this.UserUpdateOperationCompleted, asyncState);
		}

		void OnUserUpdateCompleted(IAsyncResult asyncResult)
		{
			if (this.UserUpdateCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				DrupalUser result = default(DrupalUser);
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndUserUpdate(asyncResult);
					this.UserUpdateCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalUser>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.UserUpdateCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalUser>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public bool UserDelete(int uid)
		{
			this.InitRequest();
			bool res = false;
			try {
				res = drupalServiceSystem.UserDelete(uid);
			} catch (Exception ex) {
				this.HandleException(ex, "UserDelete");
			}
			return res;
		}
		
		public void UserDeleteAsync(int uid, object asyncState)
		{
			if (this.UserDeleteOperationCompleted == null) {
				this.UserDeleteOperationCompleted = new AsyncCallback(this.OnUserDeleteCompleted);
			}
			drupalServiceSystem.BeginUserDelete(uid, this.UserDeleteOperationCompleted, asyncState);
		}

		void OnUserDeleteCompleted(IAsyncResult asyncResult)
		{
			if (this.UserDeleteCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				bool result = false;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndUserDelete(asyncResult);
					this.UserDeleteCompleted(this, new DrupalAsyncCompletedEventArgs<bool>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.UserDeleteCompleted(this, new DrupalAsyncCompletedEventArgs<bool>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public IDictionary[] UserIndex(int page, string fields, XmlRpcStruct parameters, int page_size)
		{
			this.InitRequest();
			if (string.IsNullOrEmpty(fields)) {
				fields = "*";
			}
			if (parameters == null) {
				parameters = new XmlRpcStruct();
			}
			var res = default(XmlRpcStruct[]);
			try {
				res = drupalServiceSystem.UserIndex(page, fields, parameters, page_size);
			} catch (Exception ex) {
				this.HandleException(ex, "UserIndex");
			}
			return res;
		}

		public void UserIndexAsync(int page, string fields, XmlRpcStruct parameters, int page_size, object asyncState)
		{
			if (this.UserIndexOperationCompleted == null) {
				this.UserIndexOperationCompleted = new AsyncCallback(this.OnUserIndexCompleted);
			}
			drupalServiceSystem.BeginUserIndex(page, fields, parameters, page_size, this.UserIndexOperationCompleted, asyncState);
		}

		void OnUserIndexCompleted(IAsyncResult asyncResult)
		{
			if (this.UserIndexCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				var result = default(XmlRpcStruct[]);
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndUserIndex(asyncResult);
					this.UserIndexCompleted(this, new DrupalAsyncCompletedEventArgs<IDictionary[]>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.UserIndexCompleted(this, new DrupalAsyncCompletedEventArgs<IDictionary[]>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public DrupalSessionObject UserLogin(string username, string password)
		{
			this.InitRequest();
			DrupalSessionObject res = default(DrupalSessionObject);
			try {
				res = drupalServiceSystem.UserLogin(username, password);
			} catch (Exception ex) {
				this.HandleException(ex, "UserLogin");
			}
			return res;
		}

		public void UserLoginAsync(string username, string password, object asyncState)
		{
			if (this.UserLoginOperationCompleted == null) {
				this.UserLoginOperationCompleted = new AsyncCallback(this.OnUserLoginCompleted);
			}
			drupalServiceSystem.BeginUserLogin(username, password, this.UserLoginOperationCompleted, asyncState);
		}

		void OnUserLoginCompleted(IAsyncResult asyncResult)
		{
			if (this.UserLoginCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				DrupalSessionObject result = default(DrupalSessionObject);
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndUserLogin(asyncResult);
					this.UserLoginCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalSessionObject>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.UserLoginCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalSessionObject>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public bool UserLogout()
		{
			this.InitRequest();
			bool res = false;
			try {
				res = drupalServiceSystem.UserLogout();
			} catch (Exception ex) {
				this.HandleException(ex, "UserLogout");
			}
			return res;
		}
		
		public void UserLogoutAsync(object asyncState)
		{
			if (this.UserLogoutOperationCompleted == null) {
				this.UserLogoutOperationCompleted = new AsyncCallback(this.OnUserLogoutCompleted);
			}
			drupalServiceSystem.BeginUserLogout(this.UserLogoutOperationCompleted, asyncState);
		}

		void OnUserLogoutCompleted(IAsyncResult asyncResult)
		{
			if (this.UserLogoutCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				bool result = false;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndUserLogout(asyncResult);
					this.UserLogoutCompleted(this, new DrupalAsyncCompletedEventArgs<bool>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.UserLogoutCompleted(this, new DrupalAsyncCompletedEventArgs<bool>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public DrupalUser UserRegister(XmlRpcStruct account)
		{
			this.InitRequest();
			DrupalUser res = default(DrupalUser);
			try {
				res = drupalServiceSystem.UserRegister(account);
			} catch (Exception ex) {
				this.HandleException(ex, "UserRegister");
			}
			return res;
		}

		public void UserRegisterAsync(XmlRpcStruct account, object asyncState)
		{
			if (this.UserRegisterOperationCompleted == null) {
				this.UserRegisterOperationCompleted = new AsyncCallback(this.OnUserRegisterCompleted);
			}
			drupalServiceSystem.BeginUserRegister(account, this.UserRegisterOperationCompleted, asyncState);
		}

		void OnUserRegisterCompleted(IAsyncResult asyncResult)
		{
			if (this.UserRegisterCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				DrupalUser result = default(DrupalUser);
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndUserRegister(asyncResult);
					this.UserRegisterCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalUser>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.UserRegisterCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalUser>(result, ex, asyncResult.AsyncState));
				}
			}
		}
		
		public DrupalUserToken UserToken()
		{
			this.InitRequest();
			DrupalUserToken res = default(DrupalUserToken);
			try {
				res = drupalServiceSystem.UserToken();
			} catch (Exception ex) {
				this.HandleException(ex, "UserToken");
			}
			return res;
		}
		
		public void UserTokenAsync(object asyncState)
		{
			if (this.UserTokenOperationCompleted == null) {
				this.UserTokenOperationCompleted = new AsyncCallback(this.OnUserTokenCompleted);
			}
			drupalServiceSystem.BeginUserToken(this.UserUpdateOperationCompleted, asyncState);
		}

		void OnUserTokenCompleted(IAsyncResult asyncResult)
		{
			if (this.UserTokenCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				DrupalUserToken result = default(DrupalUserToken);
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndUserToken(asyncResult);
					this.UserTokenCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalUserToken>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.UserTokenCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalUserToken>(result, ex, asyncResult.AsyncState));
				}
			}
		}
	}
}

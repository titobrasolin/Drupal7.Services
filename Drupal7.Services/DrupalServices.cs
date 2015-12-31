using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Threading;
using CookComputing.XmlRpc;

namespace Drupal7.Services
{
	[XmlRpcMissingMapping(MappingAction.Ignore)]
	public struct DrupalSessionObject
	{
		public string sessid;
		public string session_name;
		public string token;
		public DrupalUser user;
	}

	public sealed partial class DrupalServices
	{
		public delegate void HandledExceptionDelegate(Exception ex, string functionName);
		public event HandledExceptionDelegate HandledException;

		string _password;
		string _username;
		public string Username {
			get { return _username; }
		}

		bool _isLoggedIn = false;
		public bool IsLoggedIn {
			get { return _isLoggedIn; }
		}

		IServiceSystem drupalServiceSystem;

		public DrupalServices(string url)
		{
			drupalServiceSystem = XmlRpcProxyGen.Create<IServiceSystem>();
			drupalServiceSystem.Url = url;
		}

		public string Url {
			get { return drupalServiceSystem.Url; }
			set { drupalServiceSystem.Url = value; }
		}

		DrupalSessionObject _sessionData;

        public DrupalSessionObject SessionData
        {
            get { return _sessionData; }
        }

        int _errorCode = 0;

		public int ErrorCode { 
			get { return _errorCode; }
		}

		string _errorMessage = "";

		public string ErrorMessage { 
			get { return _errorMessage; }
		}
		
		private void OnHandledException(Exception ex, string functionName)
		{
			if (this.HandledException != null) {
				this.HandledException(ex, functionName);
			}
		}

		private void HandleException(Exception ex, string functionName)
		{
			var xmlRpcFaultException = ex as XmlRpcFaultException;
			if (xmlRpcFaultException != null) {
				_errorCode = xmlRpcFaultException.FaultCode;
				_errorMessage = xmlRpcFaultException.Message;
			} else {
				_errorCode = 0;
				_errorMessage = ex.Message;
			}
			this.OnHandledException(ex, functionName);
		}

		private void InitRequest()
		{
			_errorCode = 0;
			_errorMessage = "";
			
			if (string.IsNullOrEmpty(_sessionData.token)) {
				drupalServiceSystem.Headers.Remove("X-CSRF-Token");
			} else {
				drupalServiceSystem.Headers["X-CSRF-Token"] = _sessionData.token;
			}
		}

		public bool ReLogin()
		{
			return Login(_username, _password);
		}

		public bool Login(string username, string password)
		{
			_username = username;
			_password = password;

			_sessionData = this.UserLogin(_username, _password);
			_isLoggedIn = (_sessionData.user.name == _username);
			if (!_isLoggedIn) {
				this.HandleException(new Exception("Unable to login."), "Login");
			}
			return _isLoggedIn;
		}
		
		public bool Logout()
		{
			_isLoggedIn = _isLoggedIn && !this.UserLogout();
			if (_isLoggedIn) {
				this.HandleException(new Exception("Unable to logout."), "Logout");
			} else {
				_sessionData = default(DrupalSessionObject);
			}	
			return !_isLoggedIn;
		}
		

		/// <summary>
		/// Convert the IDictionary into XmlRpcStruct.
		/// </summary>
		/// <param name="value">IDictionary value.</param>
		/// <returns>The XmlRpcStruct value.</returns>
		object ConvertAs (object value)
		{
			IDictionary old;
			XmlRpcStruct @new;

			old = value as IDictionary;
			if (old == null) {
				return value;
			}
			@new = new XmlRpcStruct();
			foreach (string key in old.Keys) {
				@new.Add(key, old[key] == null ? "" : ConvertAs(old[key]));
			}
			return @new;
		}
	}
}

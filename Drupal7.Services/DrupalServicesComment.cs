using System;
using CookComputing.XmlRpc;
namespace Drupal7.Services
{
	public struct DrupalComment
	{
		public string cid;
		public string pid;
		public string nid;
		public string uid;
		public string subject;
		public string hostname;
		public string created;
		public string changed;
		public string status;
		public string thread;
		public string name;
		public string mail;
		public string homepage;
		public string language;
		public string node_type;
		public string registered_name;
		public string u_uid;
		public string signature;
		public string signature_format;
		public string picture;
		public string @new;
		public string comment_body;
		public string rdf_mapping;
		public string rdf_data;
	}

	/// <summary>
	/// https://www.drupal.org/project/services
	/// </summary>
	public sealed partial class DrupalServices
	{
		private AsyncCallback CommentCreateOperationCompleted;
		private AsyncCallback CommentRetrieveOperationCompleted;
		private AsyncCallback CommentUpdateOperationCompleted;
		private AsyncCallback CommentDeleteOperationCompleted;
		private AsyncCallback CommentIndexOperationCompleted;
		private AsyncCallback CommentCountAllOperationCompleted;
		private AsyncCallback CommentCountNewOperationCompleted;

		public event DrupalAsyncCompletedEventHandler<XmlRpcStruct> CommentCreateCompleted;
		public event DrupalAsyncCompletedEventHandler<object> CommentRetrieveCompleted;
		public event DrupalAsyncCompletedEventHandler<object> CommentUpdateCompleted;
		public event DrupalAsyncCompletedEventHandler<bool> CommentDeleteCompleted;
		public event DrupalAsyncCompletedEventHandler<XmlRpcStruct[]> CommentIndexCompleted;
		public event DrupalAsyncCompletedEventHandler<int> CommentCountAllCompleted;
		public event DrupalAsyncCompletedEventHandler<int> CommentCountNewCompleted;

		public XmlRpcStruct CommentCreate(int nid, string comment_body)
		{
			XmlRpcStruct comment;

			comment = new XmlRpcStruct();
			comment["nid"] = nid;
			comment["comment_body"] = new XmlRpcStruct(){ {
					"und",
					new XmlRpcStruct(){ {
							"0",
							new XmlRpcStruct(){ {
									"value",
									comment_body
								} }
						} }
				} };

			return this.CommentCreate(comment);
		}

		public XmlRpcStruct CommentCreate(int nid, string comment_body, string subject)
		{
			XmlRpcStruct comment;

			comment = new XmlRpcStruct();
			comment["nid"] = nid;
			comment["comment_body"] = new XmlRpcStruct(){ {
					"und",
					new XmlRpcStruct(){ {
							"0",
							new XmlRpcStruct(){ {
									"value",
									comment_body
								} }
						} }
				} };
			comment["subject"] = subject;

			return this.CommentCreate(comment);
		}

		/// <summary>
		/// Adds a new comment to a node and returns the cid.
		/// </summary>
		/// <param name="comment">An object as would be returned from comment_load().</param>
		/// <returns>Unique identifier for the comment (cid) or errors if there was a problem.</returns>
		public XmlRpcStruct CommentCreate(XmlRpcStruct comment)
		{
			this.InitRequest();
			XmlRpcStruct res = null;
			try {
				res = drupalServiceSystem.CommentCreate(comment);
			} catch (Exception ex) {
				this.HandleException(ex, "CommentCreate");
			}
			return res;
		}

		public void CommentCreateAsync(XmlRpcStruct comment, object asyncState)
		{
			if (this.CommentCreateOperationCompleted == null) {
				this.CommentCreateOperationCompleted = new AsyncCallback(this.OnCommentCreateCompleted);
			}
			drupalServiceSystem.BeginCommentCreate(comment, this.CommentCreateOperationCompleted, asyncState);
		}

		void OnCommentCreateCompleted(IAsyncResult asyncResult)
		{
			if (this.CommentCreateCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				XmlRpcStruct result = null;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndCommentCreate(asyncResult);
					this.CommentCreateCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.CommentCreateCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public object CommentRetrieve(int cid)
		{
			this.InitRequest();
			object res = null;
			try {
				res = drupalServiceSystem.CommentRetrieve(cid);
			} catch (Exception ex) {
				this.HandleException(ex, "CommentRetrieve");
			}
			return res;
		}

		public void CommentRetrieveAsync(int cid, object asyncState)
		{
			if (this.CommentRetrieveOperationCompleted == null) {
				this.CommentRetrieveOperationCompleted = new AsyncCallback(this.OnCommentRetrieveCompleted);
			}
			drupalServiceSystem.BeginCommentRetrieve(cid, this.CommentRetrieveOperationCompleted, asyncState);
		}
		
		void OnCommentRetrieveCompleted(IAsyncResult asyncResult)
		{
			if (this.CommentRetrieveCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				object result = null;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndCommentRetrieve(asyncResult);
					this.CommentRetrieveCompleted(this, new DrupalAsyncCompletedEventArgs<object>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.CommentRetrieveCompleted(this, new DrupalAsyncCompletedEventArgs<object>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public object CommentUpdate(int cid, XmlRpcStruct comment)
		{
			this.InitRequest();
			object res = null;
			try {
				res = drupalServiceSystem.CommentUpdate(cid, comment);
			} catch (Exception ex) {
				this.HandleException(ex, "CommentUpdate");
			}
			return res;
		}

		public void CommentUpdateAsync(int cid, XmlRpcStruct comment, object asyncState)
		{
			if (this.CommentUpdateOperationCompleted == null) {
				this.CommentUpdateOperationCompleted = new AsyncCallback(this.OnCommentUpdateCompleted);
			}
			drupalServiceSystem.BeginCommentUpdate(cid, comment, this.CommentUpdateOperationCompleted, asyncState);
		}

		void OnCommentUpdateCompleted(IAsyncResult asyncResult)
		{
			if (this.CommentUpdateCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				object result = null;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndCommentUpdate(asyncResult);
					this.CommentUpdateCompleted(this, new DrupalAsyncCompletedEventArgs<object>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.CommentUpdateCompleted(this, new DrupalAsyncCompletedEventArgs<object>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public bool CommentDelete(int cid)
		{
			this.InitRequest();
			bool res = false;
			try {
				res = drupalServiceSystem.CommentDelete(cid);
			} catch (Exception ex) {
				this.HandleException(ex, "CommentDelete");
			}
			return res;
		}

		public void CommentDeleteAsync(int cid, object asyncState)
		{
			if (this.CommentDeleteOperationCompleted == null) {
				this.CommentDeleteOperationCompleted = new AsyncCallback(this.OnCommentDeleteCompleted);
			}
			drupalServiceSystem.BeginCommentDelete(cid, this.CommentDeleteOperationCompleted, asyncState);
		}

		void OnCommentDeleteCompleted(IAsyncResult asyncResult)
		{
			if (this.CommentDeleteCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				bool result = false;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndCommentDelete(asyncResult);
					this.CommentDeleteCompleted(this, new DrupalAsyncCompletedEventArgs<bool>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.CommentDeleteCompleted(this, new DrupalAsyncCompletedEventArgs<bool>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public XmlRpcStruct[] CommentIndex(int page, string fields, XmlRpcStruct parameters, int page_size)
		{
			this.InitRequest();
			XmlRpcStruct[] res = null;
			try {
				res = drupalServiceSystem.CommentIndex(page, fields, parameters, page_size);
			} catch (Exception ex) {
				this.HandleException(ex, "CommentIndex");
			}
			return res;
		}

		public void CommentIndexAsync(int page, string fields, XmlRpcStruct parameters, int page_size, object asyncState)
		{
			if (this.CommentIndexOperationCompleted == null) {
				this.CommentIndexOperationCompleted = new AsyncCallback(this.OnCommentIndexCompleted);
			}
			drupalServiceSystem.BeginCommentIndex(page, fields, parameters, page_size, this.CommentIndexOperationCompleted, asyncState);
		}

		void OnCommentIndexCompleted(IAsyncResult asyncResult)
		{
			if (this.CommentIndexCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				XmlRpcStruct[] result = null;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndCommentIndex(asyncResult);
					this.CommentIndexCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct[]>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.CommentIndexCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct[]>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public int CommentCountAll(int nid)
		{
			this.InitRequest();
			int res = -1;
			try {
				res = drupalServiceSystem.CommentCountAll(nid);
			} catch (Exception ex) {
				this.HandleException(ex, "CommentCountAll");
			}
			return res;
		}

		public void CommentCountAllAsync(int nid, object asyncState)
		{
			if (this.CommentCountAllOperationCompleted == null) {
				this.CommentCountAllOperationCompleted = new AsyncCallback(this.OnCommentCountAllCompleted);
			}
			drupalServiceSystem.BeginCommentCountAll(nid, this.CommentCountAllOperationCompleted, asyncState);
		}

		void OnCommentCountAllCompleted(IAsyncResult asyncResult)
		{
			if (this.CommentCountAllCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				int result = -1;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndCommentCountAll(asyncResult);
					this.CommentCountAllCompleted(this, new DrupalAsyncCompletedEventArgs<int>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.CommentCountAllCompleted(this, new DrupalAsyncCompletedEventArgs<int>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public int CommentCountNew(int nid, int timestamp)
		{
			this.InitRequest();
			int res = -1;
			try {
				res = drupalServiceSystem.CommentCountNew(nid, timestamp);
			} catch (Exception ex) {
				this.HandleException(ex, "CommentCountNew");
			}
			return res;
		}

		public void CommentCountNewAsync(int nid, int timestamp, object asyncState)
		{
			if (this.CommentCountNewOperationCompleted == null) {
				this.CommentCountNewOperationCompleted = new AsyncCallback(this.OnCommentCountNewCompleted);
			}
			drupalServiceSystem.BeginCommentCountNew(nid, timestamp, this.CommentCountNewOperationCompleted, asyncState);
		}

		void OnCommentCountNewCompleted(IAsyncResult asyncResult)
		{
			if (this.CommentCountNewCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				int result = -1;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndCommentCountNew(asyncResult);
					this.CommentCountNewCompleted(this, new DrupalAsyncCompletedEventArgs<int>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.CommentCountNewCompleted(this, new DrupalAsyncCompletedEventArgs<int>(result, ex, asyncResult.AsyncState));
				}
			}
		}
	}
}

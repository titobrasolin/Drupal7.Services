using System;
using CookComputing.XmlRpc;
namespace Drupal7.Services
{
	[XmlRpcMissingMapping(MappingAction.Ignore)]
	public struct DrupalCommentCid
	{
		public string cid;
		public string uri;
	}

	[XmlRpcMissingMapping(MappingAction.Ignore)]
	public class DrupalComment
	{
		public struct comment_body_t
		{
			public struct und_t
			{
				public string value;
				public string format;
				public string safe_value;
			}
			public und_t[] und;
		}

		public struct rdf_mapping_t
		{
			public struct title_t
			{
				public string[] predicates;
			}
			public struct created_t
			{
				public string[] predicates;
				public string callback;
				public string datatype;
			}
			public struct changed_t
			{
				public string[] predicates;
				public string callback;
				public string datatype;
			}
			public struct comment_body_t
			{
				public string[] predicates;
			}
			public struct pid_t
			{
				public string[] predicates;
				public string type;
			}
			public struct uid_t
			{
				public string[] predicates;
				public string type;
			}
			public struct name_t
			{
				public string[] predicates;
			}

			public string[] rdftype;
			public title_t title;
			public created_t created;
			public changed_t changed;
			public comment_body_t comment_body;
			public pid_t pid;
			public uid_t uid;
			public name_t name;
		}

		public struct rdf_data_t
		{
			public struct date_t
			{
				public string content;
				public string[] property;
				public string datatype;
			}
			public date_t date;
			public string pid_uri;
			public string nid_uri;
		}

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
		public int @new;
		public comment_body_t comment_body;
		public rdf_mapping_t rdf_mapping;
		public rdf_data_t rdf_data;
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

		public event DrupalAsyncCompletedEventHandler<DrupalCommentCid> CommentCreateCompleted;
		public event DrupalAsyncCompletedEventHandler<XmlRpcStruct> CommentRetrieveCompleted;
		public event DrupalAsyncCompletedEventHandler<object> CommentUpdateCompleted;
		public event DrupalAsyncCompletedEventHandler<bool> CommentDeleteCompleted;
		public event DrupalAsyncCompletedEventHandler<XmlRpcStruct[]> CommentIndexCompleted;
		public event DrupalAsyncCompletedEventHandler<int> CommentCountAllCompleted;
		public event DrupalAsyncCompletedEventHandler<int> CommentCountNewCompleted;

		XmlRpcStruct NewComment(int nid, string comment_body)
		{
			XmlRpcStruct comment;

			comment = new XmlRpcStruct();
			comment["nid"] = nid;
			comment["comment_body"] = new XmlRpcStruct() { {
					"und",
					new XmlRpcStruct() { {
							"0",
							new XmlRpcStruct() { {
									"value",
									comment_body
								}
							}
						}
					}
				}
			};
			return comment;
		}

		public int CommentCreate(int nid, string comment_body)
		{
			return this._CommentCreate(NewComment(nid, comment_body));
		}

		public int CommentCreate(int nid, string comment_body, string subject)
		{
			XmlRpcStruct comment = NewComment(nid, comment_body);

			comment["subject"] = subject;

			return _CommentCreate(comment);
		}

		public int CommentCreate(int nid, int pid, string comment_body)
		{
			XmlRpcStruct comment = NewComment(nid, comment_body);

			comment["pid"] = pid;

			return _CommentCreate(comment);
		}

		public int CommentCreate(int nid, int pid, string comment_body, string subject)
		{
			XmlRpcStruct comment = NewComment(nid, comment_body);

			comment["pid"] = pid;
			comment["subject"] = subject;

			return _CommentCreate(comment);
		}

		int _CommentCreate(XmlRpcStruct comment)
		{
			int cid = 0;
			int.TryParse(this.CommentCreate(comment).cid, out cid);
			return cid;
		}

		/// <summary>
		/// Adds a new comment to a node and returns the cid.
		/// </summary>
		/// <param name="comment">An object as would be returned from comment_load().</param>
		/// <returns>Unique identifier for the comment (cid) or errors if there was a problem.</returns>
		public DrupalCommentCid CommentCreate(XmlRpcStruct comment)
		{
			this.InitRequest();
			DrupalCommentCid res = default(DrupalCommentCid);
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
				DrupalCommentCid result = default(DrupalCommentCid);
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndCommentCreate(asyncResult);
					this.CommentCreateCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalCommentCid>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.CommentCreateCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalCommentCid>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public XmlRpcStruct CommentRetrieve(int cid)
		{
			this.InitRequest();
			XmlRpcStruct res = null;
			try {
				res = drupalServiceSystem.CommentRetrieve(cid) as XmlRpcStruct;
			} catch (Exception ex) {
				this.HandleException(ex, "CommentRetrieve");
			}
			return res;
		}

		public bool TryCommentRetrieve(int cid, out DrupalComment result)
		{
			result = null;
			this.InitRequest();
			try {
				result = drupalServiceSystem.CommentRetrieve2(cid);
			} catch (Exception ex) {
				this.HandleException(ex, "TryCommentRetrieve");
			}
			return (result != null) && (this.ErrorCode == 0);
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
				XmlRpcStruct result = null;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndCommentRetrieve(asyncResult) as XmlRpcStruct;
					this.CommentRetrieveCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.CommentRetrieveCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct>(result, ex, asyncResult.AsyncState));
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

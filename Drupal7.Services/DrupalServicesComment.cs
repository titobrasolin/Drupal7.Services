using System;
using System.Collections;
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
		public struct CommentBodyItem
		{
			public string value;
			public string format;
			public string safe_value;
		}
		public struct RdfMapping
		{
			public struct Title
			{
				public string[] predicates;
			}
			public struct Created
			{
				public string[] predicates;
				public string callback;
				public string datatype;
			}
			public struct Changed
			{
				public string[] predicates;
				public string callback;
				public string datatype;
			}
			public struct CommentBody
			{
				public string[] predicates;
			}
			public struct Pid
			{
				public string[] predicates;
				public string type;
			}
			public struct Uid
			{
				public string[] predicates;
				public string type;
			}
			public struct Name
			{
				public string[] predicates;
			}

			public string[] rdftype;
			public Title title;
			public Created created;
			public Changed changed;
			public CommentBody comment_body;
			public Pid pid;
			public Uid uid;
			public Name name;
		}

		[XmlRpcMissingMapping(MappingAction.Ignore)]
		public struct RdfData
		{
			public struct date_t
			{
				public string content;
				public string[] property;
				public string datatype;
			}
			public date_t date;
			public string pid_uri;
			// Can be missing if there's no parent.
			public string nid_uri;
		}
		
		public struct TranslationsItem
		{
			public string language;
			public string entity_type;
			public string source;
			public string status;
			public string changed;
			public string entity_id;
			public string uid;
			public string created;
			public string translate;
		}

		public struct Translations
		{
			public object data;
			public string original;
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
		public XmlRpcStruct comment_body;
		public Translations translations;
		public RdfMapping rdf_mapping;
		public RdfData rdf_data;
		
		public CommentBodyItem[] GetBodyItems()
		{
			CommentBodyItem[] result;
			if (this.comment_body == null) {
				return null;
			}
			var ary = this.comment_body[this.language] as object[];
			if (ary == null) {
				return null;
			}
			int len = ary.Length;
			result = new CommentBodyItem[len];
			XmlRpcStruct item;
			for (int i = 0; i < len; i++) {
				item = ary[i] as XmlRpcStruct;
				if (item != null) {
					result[i].value = item["value"] as string;
					result[i].format = item["format"] as string;
					result[i].safe_value = item["safe_value"] as string;
				}
			}
			return result;
		}
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


		public static IDictionary NewComment(int nid, string comment_body, string subject) {
			return NewComment(nid, comment_body, subject, "und");
		}

		static IDictionary NewComment(int nid, string comment_body, string subject, string language)
		{
			IDictionary comment;

			comment = new Hashtable();
			comment["nid"] = nid;
			comment["subject"] = subject;
			comment["comment_body"] = new Hashtable() { {
					language,
					new Hashtable() { {
							"0",
							new Hashtable() { {
									"value",
									comment_body
								}
							}
						}
					}
				}
			};
			comment["language"] = language;
			return comment;
		}

		/// <summary>
		/// Adds a new comment to a node and returns the cid.
		/// </summary>
		/// <param name="comment">An object as would be returned from comment_load().</param>
		/// <returns>Unique identifier for the comment (cid) or errors if there was a problem.</returns>
		public DrupalCommentCid CommentCreate(object comment)
		{
			this.InitRequest();
			DrupalCommentCid res = default(DrupalCommentCid);
			try {
				res = drupalServiceSystem.CommentCreate(ConvertAs(comment));
			} catch (Exception ex) {
				this.HandleException(ex, "CommentCreate");
			}
			return res;
		}

		public void CommentCreateAsync(object comment, object asyncState)
		{
			if (this.CommentCreateOperationCompleted == null) {
				this.CommentCreateOperationCompleted = new AsyncCallback(this.OnCommentCreateCompleted);
			}
			drupalServiceSystem.BeginCommentCreate(ConvertAs(comment), this.CommentCreateOperationCompleted, asyncState);
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

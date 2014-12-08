using System;
using CookComputing.XmlRpc;
namespace Drupal7.Services
{
	/// <summary>
	/// https://www.drupal.org/project/services
	/// </summary>
	public sealed partial class DrupalServices
	{
		private AsyncCallback TaxonomyVocabularyRetrieveOperationCompleted;
		private AsyncCallback TaxonomyVocabularyCreateOperationCompleted;
		private AsyncCallback TaxonomyVocabularyUpdateOperationCompleted;
		private AsyncCallback TaxonomyVocabularyDeleteOperationCompleted;
		private AsyncCallback TaxonomyVocabularyIndexOperationCompleted;
		private AsyncCallback TaxonomyVocabularyGetTreeOperationCompleted;
		
		public event DrupalAsyncCompletedEventHandler<XmlRpcStruct> TaxonomyVocabularyRetrieveCompleted;
		public event DrupalAsyncCompletedEventHandler<int> TaxonomyVocabularyCreateCompleted;
		public event DrupalAsyncCompletedEventHandler<int> TaxonomyVocabularyUpdateCompleted;
		public event DrupalAsyncCompletedEventHandler<int> TaxonomyVocabularyDeleteCompleted;
		public event DrupalAsyncCompletedEventHandler<XmlRpcStruct[]> TaxonomyVocabularyIndexCompleted;
		public event DrupalAsyncCompletedEventHandler<XmlRpcStruct[]> TaxonomyVocabularyGetTreeCompleted;

		public XmlRpcStruct TaxonomyVocabularyRetrieve(int vid)
		{
			this.InitRequest();
			XmlRpcStruct res = null;
			try {
				res = drupalServiceSystem.TaxonomyVocabularyRetrieve(vid);
			} catch (Exception ex) {
				this.HandleException(ex, "TaxonomyVocabularyRetrieve");
			}
			return res;
		}

		public void TaxonomyVocabularyRetrieveAsync(int vid, object asyncState)
		{
			if (this.TaxonomyVocabularyRetrieveOperationCompleted == null) {
				this.TaxonomyVocabularyRetrieveOperationCompleted = new AsyncCallback(this.OnTaxonomyVocabularyRetrieveCompleted);
			}
			drupalServiceSystem.BeginTaxonomyVocabularyRetrieve(vid, this.TaxonomyVocabularyRetrieveOperationCompleted, asyncState);
		}

		void OnTaxonomyVocabularyRetrieveCompleted(IAsyncResult asyncResult)
		{
			if (this.TaxonomyVocabularyRetrieveCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				XmlRpcStruct result = null;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndTaxonomyVocabularyRetrieve(asyncResult);
					this.TaxonomyVocabularyRetrieveCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.TaxonomyVocabularyRetrieveCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public int TaxonomyVocabularyCreate(XmlRpcStruct vocabulary)
		{
			this.InitRequest();
			int res = -1;
			try {
				res = drupalServiceSystem.TaxonomyVocabularyCreate(vocabulary);
			} catch (Exception ex) {
				this.HandleException(ex, "TaxonomyVocabularyCreate");
			}
			return res;
		}

		public void TaxonomyVocabularyCreateAsync(XmlRpcStruct vocabulary, object asyncState)
		{
			if (this.TaxonomyVocabularyCreateOperationCompleted == null) {
				this.TaxonomyVocabularyCreateOperationCompleted = new AsyncCallback(this.OnTaxonomyVocabularyCreateCompleted);
			}
			drupalServiceSystem.BeginTaxonomyVocabularyCreate(vocabulary, this.TaxonomyVocabularyRetrieveOperationCompleted, asyncState);
		}

		void OnTaxonomyVocabularyCreateCompleted(IAsyncResult asyncResult)
		{
			if (this.TaxonomyVocabularyCreateCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				int result = -1;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndTaxonomyVocabularyCreate(asyncResult);
					this.TaxonomyVocabularyCreateCompleted(this, new DrupalAsyncCompletedEventArgs<int>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.TaxonomyVocabularyCreateCompleted(this, new DrupalAsyncCompletedEventArgs<int>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public int TaxonomyVocabularyUpdate(int vid, XmlRpcStruct vocabulary)
		{
			this.InitRequest();
			int res = -1;
			try {
				res = drupalServiceSystem.TaxonomyVocabularyUpdate(vid, vocabulary);
			} catch (Exception ex) {
				this.HandleException(ex, "TaxonomyVocabularyUpdate");
			}
			return res;
		}

		public void TaxonomyVocabularyUpdateAsync(int vid, XmlRpcStruct vocabulary, object asyncState)
		{
			if (this.TaxonomyVocabularyUpdateOperationCompleted == null) {
				this.TaxonomyVocabularyUpdateOperationCompleted = new AsyncCallback(this.OnTaxonomyVocabularyUpdateCompleted);
			}
			drupalServiceSystem.BeginTaxonomyVocabularyUpdate(vid, vocabulary, this.TaxonomyVocabularyUpdateOperationCompleted, asyncState);
		}

		void OnTaxonomyVocabularyUpdateCompleted(IAsyncResult asyncResult)
		{
			if (this.TaxonomyVocabularyUpdateCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				int result = -1;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndTaxonomyVocabularyUpdate(asyncResult);
					this.TaxonomyVocabularyUpdateCompleted(this, new DrupalAsyncCompletedEventArgs<int>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.TaxonomyVocabularyUpdateCompleted(this, new DrupalAsyncCompletedEventArgs<int>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public int TaxonomyVocabularyDelete(int vid)
		{
			this.InitRequest();
			int res = -1;
			try {
				res = drupalServiceSystem.TaxonomyVocabularyDelete(vid);
			} catch (Exception ex) {
				this.HandleException(ex, "TaxonomyVocabularyDelete");
			}
			return res;
		}

		public void TaxonomyVocabularyDeleteAsync(int vid, object asyncState)
		{
			if (this.TaxonomyVocabularyDeleteOperationCompleted == null) {
				this.TaxonomyVocabularyDeleteOperationCompleted = new AsyncCallback(this.OnTaxonomyVocabularyDeleteCompleted);
			}
			drupalServiceSystem.BeginTaxonomyVocabularyDelete(vid, this.TaxonomyVocabularyDeleteOperationCompleted, asyncState);
		}

		void OnTaxonomyVocabularyDeleteCompleted(IAsyncResult asyncResult)
		{
			if (this.TaxonomyVocabularyDeleteCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				int result = -1;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndTaxonomyVocabularyDelete(asyncResult);
					this.TaxonomyVocabularyDeleteCompleted(this, new DrupalAsyncCompletedEventArgs<int>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.TaxonomyVocabularyDeleteCompleted(this, new DrupalAsyncCompletedEventArgs<int>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public XmlRpcStruct[] TaxonomyVocabularyIndex(int page, string fields, XmlRpcStruct parameters, int page_size)
		{
			this.InitRequest();
			XmlRpcStruct[] res = null;
			try {
				res = drupalServiceSystem.TaxonomyVocabularyIndex(page, fields, parameters, page_size);
			} catch (Exception ex) {
				this.HandleException(ex, "TaxonomyVocabularyIndex");
			}
			return res;
		}

		public void TaxonomyVocabularyIndexAsync(int page, string fields, XmlRpcStruct parameters, int page_size, object asyncState)
		{
			if (this.TaxonomyVocabularyIndexOperationCompleted == null) {
				this.TaxonomyVocabularyIndexOperationCompleted = new AsyncCallback(this.OnTaxonomyVocabularyIndexCompleted);
			}
			drupalServiceSystem.BeginTaxonomyVocabularyIndex(page, fields, parameters, page_size, this.TaxonomyVocabularyIndexOperationCompleted, asyncState);
		}

		void OnTaxonomyVocabularyIndexCompleted(IAsyncResult asyncResult)
		{
			if (this.TaxonomyVocabularyIndexCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				XmlRpcStruct[] result = null;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndTaxonomyVocabularyIndex(asyncResult);
					this.TaxonomyVocabularyIndexCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct[]>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.TaxonomyVocabularyIndexCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct[]>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public XmlRpcStruct[] TaxonomyVocabularyGetTree(int vid, int parent, int max_depth)
		{
			this.InitRequest();
			XmlRpcStruct[] res = null;
			try {
				res = drupalServiceSystem.TaxonomyVocabularyGetTree(vid, parent, max_depth);
			} catch (Exception ex) {
				this.HandleException(ex, "TaxonomyVocabularyGetTree");
			}
			return res;
		}

		public void TaxonomyVocabularyGetTreeAsync(int vid, int parent, int max_depth, object asyncState)
		{
			if (this.TaxonomyVocabularyGetTreeOperationCompleted == null) {
				this.TaxonomyVocabularyGetTreeOperationCompleted = new AsyncCallback(this.OnTaxonomyVocabularyGetTreeCompleted);
			}
			drupalServiceSystem.BeginTaxonomyVocabularyGetTree(vid, parent, max_depth, this.TaxonomyVocabularyGetTreeOperationCompleted, asyncState);
		}

		void OnTaxonomyVocabularyGetTreeCompleted(IAsyncResult asyncResult)
		{
			if (this.TaxonomyVocabularyGetTreeCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				XmlRpcStruct[] result = null;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndTaxonomyVocabularyGetTree(asyncResult);
					this.TaxonomyVocabularyGetTreeCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct[]>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.TaxonomyVocabularyGetTreeCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct[]>(result, ex, asyncResult.AsyncState));
				}
			}
		}
	}
}

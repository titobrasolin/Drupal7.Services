using System;
using System.Collections;
using CookComputing.XmlRpc;
namespace Drupal7.Services
{
	/// <summary>
	/// https://www.drupal.org/project/services
	/// </summary>
	public sealed partial class DrupalServices
	{
		private AsyncCallback TaxonomyTermRetrieveOperationCompleted;
		private AsyncCallback TaxonomyTermCreateOperationCompleted;
		private AsyncCallback TaxonomyTermUpdateOperationCompleted;
		private AsyncCallback TaxonomyTermDeleteOperationCompleted;
		private AsyncCallback TaxonomyTermIndexOperationCompleted;
		private AsyncCallback TaxonomyTermSelectNodesOperationCompleted;
		
		public event DrupalAsyncCompletedEventHandler<object> TaxonomyTermRetrieveCompleted;
		public event DrupalAsyncCompletedEventHandler<int> TaxonomyTermCreateCompleted;
		public event DrupalAsyncCompletedEventHandler<int> TaxonomyTermUpdateCompleted;
		public event DrupalAsyncCompletedEventHandler<int> TaxonomyTermDeleteCompleted;
		public event DrupalAsyncCompletedEventHandler<XmlRpcStruct[]> TaxonomyTermIndexCompleted;
		public event DrupalAsyncCompletedEventHandler<XmlRpcStruct[]> TaxonomyTermSelectNodesCompleted;

		public object TaxonomyTermRetrieve(int tid)
		{
			this.InitRequest();
			object res = null;
			try {
				res = drupalServiceSystem.TaxonomyTermRetrieve(tid);
			} catch (Exception ex) {
				this.HandleException(ex, "TaxonomyTermRetrieve");
			}
			return res;
		}

		public void TaxonomyTermRetrieveAsync(int tid, object asyncState)
		{
			if (this.TaxonomyTermRetrieveOperationCompleted == null) {
				this.TaxonomyTermRetrieveOperationCompleted = new AsyncCallback(this.OnTaxonomyTermRetrieveCompleted);
			}
			drupalServiceSystem.BeginTaxonomyTermRetrieve(tid, this.TaxonomyTermRetrieveOperationCompleted, asyncState);
		}

		void OnTaxonomyTermRetrieveCompleted(IAsyncResult asyncResult)
		{
			if (this.TaxonomyTermRetrieveCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				object result = null;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndTaxonomyTermRetrieve(asyncResult);
					this.TaxonomyTermRetrieveCompleted(this, new DrupalAsyncCompletedEventArgs<object>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.TaxonomyTermRetrieveCompleted(this, new DrupalAsyncCompletedEventArgs<object>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public int TaxonomyTermCreate(XmlRpcStruct term)
		{
			this.InitRequest();
			int res = -1;
			try {
				res = drupalServiceSystem.TaxonomyTermCreate(term);
			} catch (Exception ex) {
				this.HandleException(ex, "TaxonomyTermCreate");
			}
			return res;
		}

		public void TaxonomyTermCreateAsync(XmlRpcStruct term, object asyncState)
		{
			if (this.TaxonomyTermCreateOperationCompleted == null) {
				this.TaxonomyTermCreateOperationCompleted = new AsyncCallback(this.OnTaxonomyTermCreateCompleted);
			}
			drupalServiceSystem.BeginTaxonomyTermCreate(term, this.TaxonomyTermCreateOperationCompleted, asyncState);
		}

		void OnTaxonomyTermCreateCompleted(IAsyncResult asyncResult)
		{
			if (this.TaxonomyTermCreateCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				int result = -1;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndTaxonomyTermCreate(asyncResult);
					this.TaxonomyTermCreateCompleted(this, new DrupalAsyncCompletedEventArgs<int>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.TaxonomyTermCreateCompleted(this, new DrupalAsyncCompletedEventArgs<int>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public int TaxonomyTermUpdate(int tid, XmlRpcStruct term)
		{
			this.InitRequest();
			int res = -1;
			try {
				res = drupalServiceSystem.TaxonomyTermUpdate(tid, term);
			} catch (Exception ex) {
				this.HandleException(ex, "TaxonomyTermUpdate");
			}
			return res;
		}

		public void TaxonomyTermUpdateAsync(int tid, XmlRpcStruct term, object asyncState)
		{
			if (this.TaxonomyTermUpdateOperationCompleted == null) {
				this.TaxonomyTermUpdateOperationCompleted = new AsyncCallback(this.OnTaxonomyTermUpdateCompleted);
			}
			drupalServiceSystem.BeginTaxonomyTermUpdate(tid, term, this.TaxonomyTermUpdateOperationCompleted, asyncState);
		}

		void OnTaxonomyTermUpdateCompleted(IAsyncResult asyncResult)
		{
			if (this.TaxonomyTermUpdateCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				int result = -1;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndTaxonomyTermUpdate(asyncResult);
					this.TaxonomyTermUpdateCompleted(this, new DrupalAsyncCompletedEventArgs<int>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.TaxonomyTermUpdateCompleted(this, new DrupalAsyncCompletedEventArgs<int>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public int TaxonomyTermDelete(int tid)
		{
			this.InitRequest();
			int res = -1;
			try {
				res = drupalServiceSystem.TaxonomyTermDelete(tid);
			} catch (Exception ex) {
				this.HandleException(ex, "TaxonomyTermDelete");
			}
			return res;
		}

		public void TaxonomyTermDeleteAsync(int tid, object asyncState)
		{
			if (this.TaxonomyTermDeleteOperationCompleted == null) {
				this.TaxonomyTermDeleteOperationCompleted = new AsyncCallback(this.OnTaxonomyTermDeleteCompleted);
			}
			drupalServiceSystem.BeginTaxonomyTermDelete(tid, this.TaxonomyTermDeleteOperationCompleted, asyncState);
		}

		void OnTaxonomyTermDeleteCompleted(IAsyncResult asyncResult)
		{
			if (this.TaxonomyTermDeleteCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				int result = -1;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndTaxonomyTermDelete(asyncResult);
					this.TaxonomyTermDeleteCompleted(this, new DrupalAsyncCompletedEventArgs<int>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.TaxonomyTermDeleteCompleted(this, new DrupalAsyncCompletedEventArgs<int>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public XmlRpcStruct[] TaxonomyTermIndex(int page, string fields, XmlRpcStruct parameters, int page_size)
		{
			this.InitRequest();
			XmlRpcStruct[] res = null;
			try {
				res = drupalServiceSystem.TaxonomyTermIndex(page, fields, parameters, page_size);
			} catch (Exception ex) {
				this.HandleException(ex, "TaxonomyTermIndex");
			}
			return res;
		}

		public void TaxonomyTermIndexAsync(int page, string fields, XmlRpcStruct parameters, int page_size, object asyncState)
		{
			if (this.TaxonomyTermIndexOperationCompleted == null) {
				this.TaxonomyTermIndexOperationCompleted = new AsyncCallback(this.OnTaxonomyTermIndexCompleted);
			}
			drupalServiceSystem.BeginTaxonomyTermIndex(page, fields, parameters, page_size, this.TaxonomyTermIndexOperationCompleted, asyncState);
		}

		void OnTaxonomyTermIndexCompleted(IAsyncResult asyncResult)
		{
			if (this.TaxonomyTermIndexCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				XmlRpcStruct[] result = null;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndTaxonomyTermIndex(asyncResult);
					this.TaxonomyTermIndexCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct[]>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.TaxonomyTermIndexCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct[]>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		/// <summary>
		/// Return nodes attached to a term across all field instances.
		/// </summary>
		/// <param name="tid">The term ID.</param>
		/// <param name="pager">Boolean to indicate whether a pager should be used. </param>
		/// <param name="limit">Integer. The maximum number of nodes to find.</param>
		/// <param name="order">An array of fields and directions.</param>
		/// <returns>An array of node objects.</returns>
		public XmlRpcStruct[] TaxonomyTermSelectNodes(int tid, bool pager, int limit, IDictionary order)
		{
			this.InitRequest();
			XmlRpcStruct[] res = null;
			try {
				res = drupalServiceSystem.TaxonomyTermSelectNodes(tid, pager, limit, ConvertAs(order ?? new Hashtable()));
			} catch (Exception ex) {
				this.HandleException(ex, "TaxonomyTermSelectNodes");
			}
			return res;
		}

		/// <summary>
		/// Return nodes attached to a term across all field instances.
		/// </summary>
		/// <param name="tid">The term ID.</param>
		/// <param name="pager">Boolean to indicate whether a pager should be used. </param>
		/// <param name="limit">Integer. The maximum number of nodes to find.</param>
		/// <returns>An array of node objects ordered by "t.sticky" DESC and "t.created" DESC.</returns>
		public XmlRpcStruct[] TaxonomyTermSelectNodes(int tid, bool pager, int limit)
		{
			var order = new Hashtable();
			order["t.sticky"] = "DESC";
			order["t.created"] = "DESC";
			return this.TaxonomyTermSelectNodes(tid, pager, limit, order);
		}

		public void TaxonomyTermSelectNodesAsync(int tid, bool pager, int limit, IDictionary order, object asyncState)
		{
			if (this.TaxonomyTermSelectNodesOperationCompleted == null) {
				this.TaxonomyTermSelectNodesOperationCompleted = new AsyncCallback(this.OnTaxonomyTermSelectNodesCompleted);
			}
			drupalServiceSystem.BeginTaxonomyTermSelectNodes(tid, pager, limit, ConvertAs(order ?? new Hashtable()), this.TaxonomyTermSelectNodesOperationCompleted, asyncState);
		}

		void OnTaxonomyTermSelectNodesCompleted(IAsyncResult asyncResult)
		{
			if (this.TaxonomyTermSelectNodesCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				XmlRpcStruct[] result = null;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndTaxonomyTermSelectNodes(asyncResult);
					this.TaxonomyTermSelectNodesCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct[]>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.TaxonomyTermSelectNodesCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct[]>(result, ex, asyncResult.AsyncState));
				}
			}
		}
	}
}

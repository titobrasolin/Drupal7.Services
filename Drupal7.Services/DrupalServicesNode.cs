using System;
using CookComputing.XmlRpc;
namespace Drupal7.Services
{
	/// <summary>
	/// https://www.drupal.org/project/services
	/// </summary>
	public sealed partial class DrupalServices
	{
		private AsyncCallback NodeRetrieveOperationCompleted;
		private AsyncCallback NodeCreateOperationCompleted;
		private AsyncCallback NodeUpdateOperationCompleted;
		private AsyncCallback NodeDeleteOperationCompleted;
		private AsyncCallback NodeIndexOperationCompleted;
		private AsyncCallback NodeFilesOperationCompleted;

		public event DrupalAsyncCompletedEventHandler<XmlRpcStruct> NodeRetrieveCompleted;
		public event DrupalAsyncCompletedEventHandler<XmlRpcStruct> NodeCreateCompleted;
		public event DrupalAsyncCompletedEventHandler<XmlRpcStruct> NodeUpdateCompleted;
		public event DrupalAsyncCompletedEventHandler<bool> NodeDeleteCompleted;
		public event DrupalAsyncCompletedEventHandler<XmlRpcStruct[]> NodeIndexCompleted;
		public event DrupalAsyncCompletedEventHandler<DrupalFile[]> NodeFilesCompleted;
		
		public XmlRpcStruct NodeRetrieve(int nid)
		{
			this.InitRequest();
			XmlRpcStruct res = null;
			try {
				res = drupalServiceSystem.NodeRetrieve(nid);
			} catch (Exception ex) {
				this.HandleException(ex, "NodeRetrieve");
			}
			return res;
		}
		
		public void NodeRetrieveAsync(int nid, object asyncState)
		{
			if (this.NodeRetrieveOperationCompleted == null) {
				this.NodeRetrieveOperationCompleted = new AsyncCallback(this.OnNodeRetrieveCompleted);
			}
			drupalServiceSystem.BeginNodeRetrieve(nid, this.NodeRetrieveOperationCompleted, asyncState);
		}

		void OnNodeRetrieveCompleted(IAsyncResult asyncResult)
		{
			if (this.NodeRetrieveCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				XmlRpcStruct result = null;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndNodeRetrieve(asyncResult);
					this.NodeRetrieveCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.NodeRetrieveCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public XmlRpcStruct NodeCreate(object node)
		{
			this.InitRequest();
			XmlRpcStruct res = null;
			try {
				res = drupalServiceSystem.NodeCreate(ConvertAs(node));
			} catch (Exception ex) {
				this.HandleException(ex, "NodeCreate");
			}
			return res;
		}

		public void NodeCreateAsync(object node, object asyncState)
		{
			if (this.NodeCreateOperationCompleted == null) {
				this.NodeCreateOperationCompleted = new AsyncCallback(this.OnNodeCreateCompleted);
			}
			drupalServiceSystem.BeginNodeCreate(ConvertAs(node), this.NodeCreateOperationCompleted, asyncState);
		}

		void OnNodeCreateCompleted(IAsyncResult asyncResult)
		{
			if (this.NodeCreateCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				XmlRpcStruct result = null;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndNodeCreate(asyncResult);
					this.NodeCreateCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.NodeCreateCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public XmlRpcStruct NodeUpdate(int nid, object node)
		{
			this.InitRequest();
			XmlRpcStruct res = null;
			try {
				res = drupalServiceSystem.NodeUpdate(nid, ConvertAs(node));
			} catch (Exception ex) {
				this.HandleException(ex, "NodeUpdate");
			}
			return res;
		}

		public void NodeUpdateAsync(int nid, object node, object asyncState)
		{
			if (this.NodeUpdateOperationCompleted == null) {
				this.NodeUpdateOperationCompleted = new AsyncCallback(this.OnNodeUpdateCompleted);
			}
			drupalServiceSystem.BeginNodeUpdate(nid, ConvertAs(node), this.NodeUpdateOperationCompleted, asyncState);
		}

		void OnNodeUpdateCompleted(IAsyncResult asyncResult)
		{
			if (this.NodeUpdateCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				XmlRpcStruct result = null;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndNodeUpdate(asyncResult);
					this.NodeUpdateCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.NodeUpdateCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public bool NodeDelete(int nid)
		{
			this.InitRequest();
			bool res = false;
			try {
				res = drupalServiceSystem.NodeDelete(nid);
			} catch (Exception ex) {
				this.HandleException(ex, "NodeDelete");
			}
			return res;
		}

		public void NodeDeleteAsync(int nid, object asyncState)
		{
			if (this.NodeDeleteOperationCompleted == null) {
				this.NodeDeleteOperationCompleted = new AsyncCallback(this.OnNodeDeleteCompleted);
			}
			drupalServiceSystem.BeginNodeDelete(nid, this.NodeUpdateOperationCompleted, asyncState);
		}

		void OnNodeDeleteCompleted(IAsyncResult asyncResult)
		{
			if (this.NodeDeleteCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				bool result = false;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndNodeDelete(asyncResult);
					this.NodeDeleteCompleted(this, new DrupalAsyncCompletedEventArgs<bool>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.NodeDeleteCompleted(this, new DrupalAsyncCompletedEventArgs<bool>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public XmlRpcStruct[] NodeIndex(int page, int page_size)
		{
			return this.NodeIndex(page, "*", new XmlRpcStruct(), page_size);
		}

		public XmlRpcStruct[] NodeIndex(int page, string fields, int page_size)
		{
			return this.NodeIndex(page, fields, new XmlRpcStruct(), page_size);
		}

		public XmlRpcStruct[] NodeIndex(int page, string fields, XmlRpcStruct parameters, int page_size)
		{
			this.InitRequest();
			if (string.IsNullOrEmpty(fields)) {
				fields = "*";
			}
			if (parameters == null) {
				parameters = new XmlRpcStruct();
			}
			XmlRpcStruct[] res = null;
			try {
				res = drupalServiceSystem.NodeIndex(page, fields, parameters, page_size);
			} catch (Exception ex) {
				this.HandleException(ex, "NodeIndex");
			}
			return res;
		}

		public void NodeIndexAsync(int page, string fields, XmlRpcStruct parameters, int page_size, object asyncState)
		{
			if (this.NodeIndexOperationCompleted == null) {
				this.NodeIndexOperationCompleted = new AsyncCallback(this.OnNodeIndexCompleted);
			}
			drupalServiceSystem.BeginNodeIndex(page, fields, parameters, page_size, this.NodeIndexOperationCompleted, asyncState);
		}

		void OnNodeIndexCompleted(IAsyncResult asyncResult)
		{
			if (this.NodeIndexCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				XmlRpcStruct[] res = null;
				try {
					res = ((IServiceSystem)clientResult.ClientProtocol).EndNodeIndex(asyncResult);
					this.NodeIndexCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct[]>(res, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.NodeIndexCompleted(this, new DrupalAsyncCompletedEventArgs<XmlRpcStruct[]>(res, ex, asyncResult.AsyncState));
				}
			}
		}

		public DrupalFile[] NodeFiles(int nid, bool include_file_contents, bool get_image_style)
		{
			this.InitRequest();
			DrupalFile[] res = null;
			try {
				res = drupalServiceSystem.NodeFiles(nid, include_file_contents, get_image_style);
			} catch (Exception ex) {
				this.HandleException(ex, "NodeFiles");
			}
			return res;
		}
		
		public void NodeFilesAsync(int nid, bool include_file_contents, bool get_image_style, object asyncState)
		{
			if (this.NodeFilesOperationCompleted == null) {
				this.NodeFilesOperationCompleted = new AsyncCallback(this.OnNodeFilesCompleted);
			}
			drupalServiceSystem.BeginNodeFiles(nid, include_file_contents, get_image_style, this.NodeFilesOperationCompleted, asyncState);
		}

		void OnNodeFilesCompleted(IAsyncResult asyncResult)
		{
			if (this.NodeFilesCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				DrupalFile[] result = null;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndNodeFiles(asyncResult);
					this.NodeFilesCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalFile[]>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.NodeFilesCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalFile[]>(result, ex, asyncResult.AsyncState));
				}
			}
		}
	}
}

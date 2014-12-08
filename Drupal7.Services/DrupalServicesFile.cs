using System;
using CookComputing.XmlRpc;
namespace Drupal7.Services
{
	/// <summary>
	/// https://www.drupal.org/project/services
	/// </summary>
	public sealed partial class DrupalServices
	{
		private AsyncCallback FileCreateOperationCompleted;
		private AsyncCallback FileRetrieveOperationCompleted;
		private AsyncCallback FileDeleteOperationCompleted;
		private AsyncCallback FileIndexOperationCompleted;
		private AsyncCallback FileCreateRawOperationCompleted;
		
		public event DrupalAsyncCompletedEventHandler<DrupalFile> FileCreateCompleted;
		public event DrupalAsyncCompletedEventHandler<DrupalFile> FileRetrieveCompleted;
		public event DrupalAsyncCompletedEventHandler<bool> FileDeleteCompleted;
		public event DrupalAsyncCompletedEventHandler<DrupalFile[]> FileIndexCompleted;
		public event DrupalAsyncCompletedEventHandler<DrupalFile[]> FileCreateRawCompleted;
		
		public DrupalFile FileCreate(DrupalFile file)
		{
			this.InitRequest();
			DrupalFile res = default(DrupalFile);
			try {
				res = drupalServiceSystem.FileCreate(file);
			} catch (Exception ex) {
				this.HandleException(ex, "FileCreate");
			}
			return res;
		}

		public void FileCreateAsync(DrupalFile file, object asyncState)
		{
			if (this.FileCreateOperationCompleted == null) {
				this.FileCreateOperationCompleted = new AsyncCallback(this.OnFileCreateCompleted);
			}
			drupalServiceSystem.BeginFileCreate(file, this.FileCreateOperationCompleted, asyncState);
		}

		void OnFileCreateCompleted(IAsyncResult asyncResult)
		{
			if (this.FileCreateCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				DrupalFile result = default(DrupalFile);
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndFileCreate(asyncResult);
					this.FileCreateCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalFile>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.FileCreateCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalFile>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public DrupalFile FileRetrieve(int fid, bool include_file_contents, bool get_image_style)
		{
			this.InitRequest();
			DrupalFile res = default(DrupalFile);
			try {
				res = drupalServiceSystem.FileRetrieve(fid, include_file_contents, get_image_style);
			} catch (Exception ex) {
				this.HandleException(ex, "FileRetrieve");
			}
			return res;
		}

		public void FileRetrieveAsync(int fid, bool include_file_contents, bool get_image_style, object asyncState)
		{
			if (this.FileRetrieveOperationCompleted == null) {
				this.FileRetrieveOperationCompleted = new AsyncCallback(this.OnFileRetrieveCompleted);
			}
			drupalServiceSystem.BeginFileRetrieve(fid, include_file_contents, get_image_style, this.FileRetrieveOperationCompleted, asyncState);
		}

		private void OnFileRetrieveCompleted(IAsyncResult asyncResult)
		{
			if (this.FileRetrieveCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				DrupalFile result = default(DrupalFile);
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndFileRetrieve(asyncResult);
					this.FileRetrieveCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalFile>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.FileRetrieveCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalFile>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public bool FileDelete(int fid)
		{
			this.InitRequest();
			bool res = false;
			try {
				res = drupalServiceSystem.FileDelete(fid);
			} catch (Exception ex) {
				this.HandleException(ex, "FileDelete");
			}
			return res;
		}

		public void FileDeleteAsync(int fid, object asyncState)
		{
			if (this.FileDeleteOperationCompleted == null) {
				this.FileDeleteOperationCompleted = new AsyncCallback(this.OnFileDeleteCompleted);
			}
			drupalServiceSystem.BeginFileDelete(fid, this.FileDeleteOperationCompleted, asyncState);
		}

		void OnFileDeleteCompleted(IAsyncResult asyncResult)
		{
			if (this.FileDeleteCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				bool result = false;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndFileDelete(asyncResult);
					this.FileDeleteCompleted(this, new DrupalAsyncCompletedEventArgs<bool>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.FileDeleteCompleted(this, new DrupalAsyncCompletedEventArgs<bool>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public DrupalFile[] FileIndex(int page, string fields, XmlRpcStruct parameters, int page_size)
		{
			this.InitRequest();
			DrupalFile[] res = null;
			try {
				res = drupalServiceSystem.FileIndex(page, fields, parameters, page_size);
			} catch (Exception ex) {
				this.HandleException(ex, "FileIndex");
			}
			return res;
		}

		public void FileIndexAsync(int page, string fields, XmlRpcStruct parameters, int page_size, object asyncState)
		{
			if (this.FileIndexOperationCompleted == null) {
				this.FileIndexOperationCompleted = new AsyncCallback(this.OnFileIndexCompleted);
			}
			drupalServiceSystem.BeginFileIndex(page, fields, parameters, page_size, this.FileIndexOperationCompleted, asyncState);
		}

		void OnFileIndexCompleted(IAsyncResult asyncResult)
		{
			if (this.FileIndexCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				DrupalFile[] result = null;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndFileIndex(asyncResult);
					this.FileIndexCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalFile[]>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.FileIndexCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalFile[]>(result, ex, asyncResult.AsyncState));
				}
			}
		}

		public DrupalFile[] FileCreateRaw()
		{
			this.InitRequest();
			DrupalFile[] res = null;
			try {
				res = drupalServiceSystem.FileCreateRaw();
			} catch (Exception ex) {
				this.HandleException(ex, "FileCreateRaw");
			}
			return res;
		}

		public void FileCreateRawAsync(object asyncState)
		{
			if (this.FileCreateRawOperationCompleted == null) {
				this.FileCreateRawOperationCompleted = new AsyncCallback(this.OnFileCreateRawCompleted);
			}
			drupalServiceSystem.BeginFileCreateRaw(this.FileCreateRawOperationCompleted, asyncState);
		}

		void OnFileCreateRawCompleted(IAsyncResult asyncResult)
		{
			if (this.FileCreateRawCompleted != null) {
				var clientResult = (XmlRpcAsyncResult)asyncResult;
				DrupalFile[] result = null;
				try {
					result = ((IServiceSystem)clientResult.ClientProtocol).EndFileCreateRaw(asyncResult);
					this.FileCreateRawCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalFile[]>(result, null, asyncResult.AsyncState));
				} catch (Exception ex) {
					this.FileCreateRawCompleted(this, new DrupalAsyncCompletedEventArgs<DrupalFile[]>(result, ex, asyncResult.AsyncState));
				}
			}
		}
	}
}

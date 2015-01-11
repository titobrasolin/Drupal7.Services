using System;
using System.Collections;
using CookComputing.XmlRpc;
namespace Drupal7.Services
{
	/// <summary>
	/// https://www.drupal.org/project/services_entity
	/// </summary>
	public sealed partial class DrupalServices
	{
		/// <summary>
		/// Retrieves an entity of type File.
		/// </summary>
		/// <param name="file_id">The file id.</param>
		/// <param name="fields">A comma separated list of fields to get.</param>
		/// <returns>An entity of type File.</returns>
		public XmlRpcStruct EntityFileRetrieve(int file_id, string fields = "*")
		{
			this.InitRequest();
			XmlRpcStruct res = null;
			try {
				res = drupalServiceSystem.EntityFileRetrieve("retrieve", "file", file_id, fields);
			} catch (Exception ex) {
				this.HandleException(ex, "EntityFileRetrieve");
			}
			return res;
		}

		/// <summary>
		/// Retrieves an entity of type File.
		/// </summary>
		/// <param name="file_id">The file id.</param>
		/// <param name="revision">The specific revision to retrieve.</param>
		/// <returns>An entity of type File.</returns>
		public XmlRpcStruct EntityFileRetrieve(int file_id, int revision)
		{
			return this.EntityFileRetrieve(file_id, "*", revision);
		}

		/// <summary>
		/// Retrieves an entity of type File.
		/// </summary>
		/// <param name="file_id">The file id.</param>
		/// <param name="fields">A comma separated list of fields to get.</param>
		/// <param name="revision">The specific revision to retrieve.</param>
		/// <returns>An entity of type File.</returns>
		public XmlRpcStruct EntityFileRetrieve(int file_id, string fields, int revision)
		{
			this.InitRequest();
			XmlRpcStruct res = null;
			try {
				res = drupalServiceSystem.EntityFileRetrieve("retrieve", "file", file_id, fields, revision);
			} catch (Exception ex) {
				this.HandleException(ex, "EntityFileRetrieve");
			}
			return res;
		}

//		public object EntityFileUpdate()
//		{
//			this.InitRequest();
//			object res = null;
//			try {
//				res = drupalServiceSystem.EntityFileUpdate();
//			} catch (Exception ex) {
//				this.HandleException(ex, "EntityFileUpdate");
//			}
//			return res;
//		}

//		public object EntityFileDelete()
//		{
//			this.InitRequest();
//			object res = null;
//			try {
//				res = drupalServiceSystem.EntityFileDelete();
//			} catch (Exception ex) {
//				this.HandleException(ex, "EntityFileDelete");
//			}
//			return res;
//		}

		/// <summary>
		/// Retrieves a list of entities of type File.
		/// </summary>
		/// <param name="fields">A comma separated list of fields to get.</param>
		/// <param name="parameters">Filter parameters array such as parameters[title]="test".</param>
		/// <param name="page">The zero-based index of the page to get, defaults to 0.</param>
		/// <param name="pagesize">Number of records to get per page.</param>
		/// <param name="sort">Field to sort by.</param>
		/// <param name="direction">Direction of the sort. ASC or DESC.</param>
		/// <returns>A list of entities of type File.</returns>
		public XmlRpcStruct[] EntityFileIndex(string fields = "*", IDictionary parameters = null, int page = 0, int pagesize = 20, string sort = "", string direction = "ASC")
		{
			this.InitRequest();
			XmlRpcStruct[] res = null;
			try {
				res = drupalServiceSystem.EntityFileIndex("index", "file", fields, ConvertAs(parameters ?? new Hashtable()), page, pagesize, sort, direction);
			} catch (Exception ex) {
				this.HandleException(ex, "EntityFileIndex");
			}
			return res;
		}

//		public object EntityFileCreate()
//		{
//			this.InitRequest();
//			object res = null;
//			try {
//				res = drupalServiceSystem.EntityFileCreate();
//			} catch (Exception ex) {
//				this.HandleException(ex, "EntityFileCreate");
//			}
//			return res;
//		}

//		public object EntityFileCreateRaw()
//		{
//			this.InitRequest();
//			object res = null;
//			try {
//				res = drupalServiceSystem.EntityFileCreateRaw();
//			} catch (Exception ex) {
//				this.HandleException(ex, "EntityFileCreateRaw");
//			}
//			return res;
//		}
	}
}

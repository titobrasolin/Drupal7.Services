using System;
using System.Collections;
using System.Collections.Generic;
using CookComputing.XmlRpc;
namespace Drupal7.Services
{
	/// <summary>
	/// https://www.drupal.org/project/services_entity
	/// </summary>
	public sealed partial class DrupalServices
	{
		/// <summary>
		/// Creates an entity of type Comment.
		/// </summary>
		/// <param name="values"> A representation of the comment.</param>
		/// <returns>An entity of type Comment.</returns>
		public object EntityCommentCreate(object values)
		{
			this.InitRequest();
			object res = null;
			try {
				res = drupalServiceSystem.EntityCommentCreate("create", "comment", ConvertAs(values));
			} catch (Exception ex) {
				this.HandleException(ex, "EntityCommentCreate");
			}
			return res;
		}

		/// <summary>
		/// Updates an entity of type Comment.
		/// </summary>
		/// <param name="comment_id">The comment id.</param>
		/// <param name="values">A representation of the comment.</param>
		/// <returns></returns>
		public object EntityCommentUpdate(int comment_id, object values)
		{
			this.InitRequest();
			object res = null;
			try {
				res = drupalServiceSystem.EntityCommentUpdate("update", "comment", comment_id, ConvertAs(values));
			} catch (Exception ex) {
				this.HandleException(ex, "EntityCommentUpdate");
			}
			return res;
		}

		/// <summary>
		/// Deletes an entity of type Comment.
		/// </summary>
		/// <param name="comment_id"> The comment id.</param>
		public void EntityCommentDelete(int comment_id)
		{
			this.InitRequest();
			try {
				drupalServiceSystem.EntityCommentDelete("delete", "comment", comment_id);
			} catch (Exception ex) {
				this.HandleException(ex, "EntityCommentDelete");
			}
		}

		/// <summary>
		/// Retrieves an entity of type Comment.
		/// </summary>
		/// <param name="comment_id">The comment id.</param>
		/// <param name="fields">A comma separated list of fields to get.</param>
		/// <returns>An entity of type Comment.</returns>
		public XmlRpcStruct EntityCommentRetrieve(int comment_id, string fields = "*")
		{
			this.InitRequest();
			XmlRpcStruct res = null;
			try {
				res = drupalServiceSystem.EntityCommentRetrieve("retrieve", "comment", comment_id, fields);
			} catch (Exception ex) {
				this.HandleException(ex, "EntityCommentRetrieve");
			}
			return res;
		}

		/// <summary>
		/// Retrieves an entity of type Comment.
		/// </summary>
		/// <param name="comment_id">The comment id.</param>
		/// <param name="revision">The specific revision to retrieve.</param>
		/// <returns>An entity of type Comment.</returns>
		public XmlRpcStruct EntityCommentRetrieve(int comment_id, int revision)
		{
			return this.EntityCommentRetrieve(comment_id, "*", revision);
		}

		/// <summary>
		/// Retrieves an entity of type Comment.
		/// </summary>
		/// <param name="comment_id">The comment id.</param>
		/// <param name="fields">A comma separated list of fields to get.</param>
		/// <param name="revision">The specific revision to retrieve.</param>
		/// <returns>An entity of type Comment.</returns>
		public XmlRpcStruct EntityCommentRetrieve(int comment_id, string fields, int revision)
		{
			this.InitRequest();
			XmlRpcStruct res = null;
			try {
				res = drupalServiceSystem.EntityCommentRetrieve("retrieve", "comment", comment_id, fields, revision);
			} catch (Exception ex) {
				this.HandleException(ex, "EntityCommentRetrieve");
			}
			return res;
		}

		/// <summary>
		/// Retrieves a list of entities of type Comment.
		/// </summary>
		/// <param name="fields">A comma separated list of fields to get.</param>
		/// <param name="parameters">Filter parameters array such as parameters[title]="test".</param>
		/// <param name="page">The zero-based index of the page to get, defaults to 0.</param>
		/// <param name="pagesize">Number of records to get per page.</param>
		/// <param name="sort">Field to sort by.</param>
		/// <param name="direction">Direction of the sort. ASC or DESC.</param>
		/// <returns>A list of entities of type Comment.</returns>
		public XmlRpcStruct[] EntityCommentIndex(string fields = "*", IDictionary parameters = null, int page = 0, int pagesize = 20, string sort = "", string direction = "ASC")
		{
			this.InitRequest();
			XmlRpcStruct[] res = null;
			try {
				res = drupalServiceSystem.EntityCommentIndex("index", "comment", fields, ConvertAs(parameters ?? new Hashtable()), page, pagesize, sort, direction);
			} catch (Exception ex) {
				this.HandleException(ex, "EntityCommentIndex");
			}
			return res;
		}

		/// <summary>
		/// Return number of comments on a given node.
		/// </summary>
		/// <param name="nid">The node id to count all comments.</param>
		/// <returns>The number of comments on a given node.</returns>
		public int? EntityCommentCountAll(int nid)
		{
			this.InitRequest();
			bool hasValue = false;
			int res = default(int);
			try {
				hasValue = int.TryParse(drupalServiceSystem.EntityCommentCountAll(nid), out res);
			} catch (Exception ex) {
				this.HandleException(ex, "EntityCommentCountAll");
			}
			return hasValue ? (int?)res : null;
		}

		/// <summary>
		/// Returns number of new comments on a given node since a given timestamp.
		/// </summary>
		/// <param name="nid">The node id to load comments for.</param>
		/// <param name="since">Timestamp to count from (defaults to time of last user acces to node).</param>
		/// <returns>The number of new comments on a given node since a given timestamp.</returns>
		public int? EntityCommentCountNew(int nid, int since = 0)
		{
			this.InitRequest();
			bool hasValue = false;
			int res = default(int);
			try {
				hasValue = int.TryParse(drupalServiceSystem.EntityCommentCountNew(nid, since), out res);
			} catch (Exception ex) {
				this.HandleException(ex, "EntityCommentCountNew");
			}
			return hasValue ? (int?)res : null;
		}
	}
}

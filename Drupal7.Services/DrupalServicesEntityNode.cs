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
		/// Retrieves a list of entities of type Node.
		/// </summary>
		/// <param name="fields">A comma separated list of fields to get.</param>
		/// <param name="parameters">Filter parameters array such as parameters[title]="test".</param>
		/// <param name="page">The zero-based index of the page to get, defaults to 0.</param>
		/// <param name="pagesize">Number of records to get per page.</param>
		/// <param name="sort">Field to sort by.</param>
		/// <param name="direction">Direction of the sort. ASC or DESC.</param>
		/// <returns>A list of entities of type Node.</returns>
		public XmlRpcStruct[] EntityNodeIndex(string fields = "*", IDictionary parameters = null, int page = 0, int pagesize = 20, string sort = "", string direction = "ASC")
		{
			this.InitRequest();
			XmlRpcStruct[] res = null;
			try {
				res = drupalServiceSystem.EntityNodeIndex("index", "node", fields, ConvertAs(parameters ?? new Hashtable()), page, pagesize, sort, direction);
			} catch (Exception ex) {
				this.HandleException(ex, "EntityNodeIndex");
			}
			return res;
		}
	}
}

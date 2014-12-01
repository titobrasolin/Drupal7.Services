using System;
using CookComputing.XmlRpc;
namespace Drupal7.Services
{
	[XmlRpcMissingMapping(MappingAction.Ignore)]
	public struct DrupalFile
	{
		public string type;
		public string target_uri;
		public string uri;
		public string file;
		public string origname;
		public string filesize;
		public string filemime;
		public string uid;
		public string status;
		public object[] rdf_mapping;
		public string timestamp;
		public string uri_full;
		public string filename;
		public string fid;
		public object image_styles;
	}
}

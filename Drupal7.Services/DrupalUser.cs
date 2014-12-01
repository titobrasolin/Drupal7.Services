using System;
using CookComputing.XmlRpc;
namespace Drupal7.Services
{
	[XmlRpcMissingMapping(MappingAction.Ignore)]
	public struct DrupalUser
	{
        public object uid;
		public object login;
		public string access;
		public string init;
		public string signature;
		public string name;
		public string signature_format;
		public string theme;
		public string timezone;
		public object data;
		public string created;
		public object picture;
		public string status;
		public XmlRpcStruct rdf_mapping;
		public XmlRpcStruct roles;
		public string language;
        public string mail;
	}
}

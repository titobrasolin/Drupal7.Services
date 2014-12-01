using System;
using CookComputing.XmlRpc;
namespace Drupal7.Services
{
	[XmlRpcMissingMapping(MappingAction.Ignore)]
	public struct DrupalSessionObject
	{
		public string sessid;
		public string session_name;
		public string token;
		public DrupalUser user;
	}
}

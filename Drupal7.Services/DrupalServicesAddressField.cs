using System;
using CookComputing.XmlRpc;
namespace Drupal7.Services
{
	/// <summary>
	/// https://www.drupal.org/project/services_addressfield
	/// </summary>
	public sealed partial class DrupalServices
	{
		/// <summary>
		/// Get list of all predefined and custom countries.
		/// </summary>
		/// <returns>List of all predefined and custom countries.</returns>
		public XmlRpcStruct AddressFieldCountryGetList()
		{
			this.InitRequest();
			XmlRpcStruct res = null;
			try {
				res = drupalServiceSystem.AddressFieldCountryGetList();
			} catch (Exception ex) {
				this.HandleException(ex, "AddressFieldCountryGetList");
			}
			return res;
		}

		/// <summary>
		/// Returns the predefined administrative areas for the given country code.
		/// </summary>
		/// <param name="country_code">The country code.</param>
		/// <returns>The predefined administrative areas for the given country code.</returns>
		public XmlRpcStruct AddressFieldGetAddressFormatAndAdministrativeAreas(string country_code)
		{
			this.InitRequest();
			XmlRpcStruct res = null;
			try {
				res = drupalServiceSystem.AddressFieldGetAddressFormatAndAdministrativeAreas(country_code);
			} catch (Exception ex) {
				this.HandleException(ex, "AddressFieldGetAddressFormatAndAdministrativeAreas");
			}
			return res;
		}
	}
}

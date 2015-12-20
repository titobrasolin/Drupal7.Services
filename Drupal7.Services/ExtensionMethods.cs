using Drupal7.Services.BaseClasses;
using System.Collections;
using System.Web.Script.Serialization;

namespace Drupal7.Services
{
    public static class ExtensionMethods
    {
        public static T ConvertToType<T>(this IDictionary value)
        {
            var ser = new JavaScriptSerializer();
            return ser.Deserialize<T>(ser.Serialize(value));
        }

        public static BaseNode ToBaseNode(this IDictionary value)
        {
            return ConvertToType<BaseNode>(value);
        }
    }
}

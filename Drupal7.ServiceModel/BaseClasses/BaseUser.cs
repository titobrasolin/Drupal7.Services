using System.Collections.Generic;

namespace Drupal7.ServiceModel.BaseClasses
{
    public class BaseUser
    {
        public int uid { get; set; }
        public int status { get; set; }
        public int created { get; set; }
        public int access { get; set; }
        public int login { get; set; }
        public string name { get; set; }
        public string pass { get; set; }
        public string mail { get; set; }
        public string init { get; set; }
        public string signature { get; set; }
        public string signature_format { get; set; }
        public string picture { get; set; }
        public string language { get; set; }
        public string timezone { get; set; }
        public string theme { get; set; }
        public string services_token { get; set; }
        public object data { get; set; }
        public Dictionary<int, string> roles { get; set; }
    }
}

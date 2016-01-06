using System;
using System.Web.Script.Serialization;
namespace Drupal7.Services
{
    public class BaseUser
    {
        public string signature { get; set; }
        public string data { get; set; }
        public int access { get; set; }
        public string init { get; set; }
        public string pass { get; set; }
        public int created { get; set; }
        public string mail { get; set; }
        public string signature_format { get; set; }
        public int picture { get; set; }
        public string language { get; set; }
        public int login { get; set; }
        public string timezone { get; set; }
        public int status { get; set; }
        public string theme { get; set; }
        public int uid { get; set; }
        public string name { get; set; }
    }
}

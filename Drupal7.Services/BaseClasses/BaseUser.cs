namespace Drupal7.Services
{
    public class BaseUser
    {
        public string signature { get; set; }
        public object data { get; set; }
        public object roles { get; set; }
        public int access { get; set; }
        public string init { get; set; }
        public string pass { get; set; }
        public int created { get; set; }
        public string mail { get; set; }
        public string signature_format { get; set; }
        public string picture { get; set; }
        public string language { get; set; }
        public int login { get; set; }
        public string timezone { get; set; }
        public int status { get; set; }
        public string theme { get; set; }
        public int uid { get; set; }
        public string name { get; set; }
        public string services_token { get; set; }
    }
}

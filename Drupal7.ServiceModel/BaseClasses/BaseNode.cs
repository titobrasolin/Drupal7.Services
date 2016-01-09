namespace Drupal7.ServiceModel.BaseClasses
{
    public class BaseNode : BaseNodeIndexItem
    {
        public string name { get; set; }
        public string path { get; set; }
        public string picture { get; set; }
        public string log { get; set; }
        public int revision_uid { get; set; }
        public int revision_timestamp { get; set; }
        public int comment_count { get; set; }
        public int cid { get; set; }
        public int last_comment_uid { get; set; }
        public string last_comment_name { get; set; }
        public int last_comment_timestamp { get; set; }
        public object data { get; set; }
        public object rdf_mapping { get; set; }
    }
}

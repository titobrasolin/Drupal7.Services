using Drupal7.Services.FieldTypes;

namespace Drupal7.Services.BaseClasses
{
    public class BaseArticle : BaseNode
    {
        public object rdf_mapping { get; set; }
        public string data { get; set; }
        public int picture { get; set; }
        public int last_comment_timestamp { get; set; }
        public TaxonomyTermReferenceField field_tags { get; set; }
        public string last_comment_name { get; set; }
        public string log { get; set; }
        public int cid { get; set; }
        public int revision_uid { get; set; }
        public int comment_count { get; set; }
        public string path { get; set; }
        public ImageField field_image { get; set; }
        public TextWithSummaryField body { get; set; }
        public int revision_timestamp { get; set; }
        public int last_comment_uid { get; set; }
        public string name { get; set; }
    }
}

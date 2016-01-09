using Drupal7.ServiceModel.FieldTypes;

namespace Drupal7.ServiceModel.BaseClasses
{
    public class BaseNodeArticle : BaseNode
    {
        public ImageField field_image { get; set; }
        public TaxonomyTermReferenceField field_tags { get; set; }
        public TextField body { get; set; }
    }
}

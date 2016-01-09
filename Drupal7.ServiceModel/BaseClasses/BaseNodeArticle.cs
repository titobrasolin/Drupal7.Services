using Drupal7.ServiceModel.FieldTypes;
using System.Collections.Generic;

namespace Drupal7.ServiceModel.BaseClasses
{
    public class BaseNodeArticle : BaseNode
    {
		public Dictionary<string, List<ImageFieldItem>> field_image { get; set; }
		public Dictionary<string, List<TaxonomyTermReferenceFieldItem>> field_tags { get; set; }
		public Dictionary<string, List<TextFieldItem>> body { get; set; }
    }
}

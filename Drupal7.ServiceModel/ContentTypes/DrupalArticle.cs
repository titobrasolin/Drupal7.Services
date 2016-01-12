using System.Collections.Generic;
using Drupal7.ServiceModel.BaseClasses;
using Drupal7.ServiceModel.FieldTypes;

namespace Drupal7.ServiceModel.ContentTypes
{
    public class DrupalArticle : BaseNode
    {
        public Dictionary<string, List<ImageFieldItem>> field_image { get; set; }
        public Dictionary<string, List<TaxonomyTermReferenceFieldItem>> field_tags { get; set; }
        public Dictionary<string, List<TextFieldItem>> body { get; set; }
    }
}


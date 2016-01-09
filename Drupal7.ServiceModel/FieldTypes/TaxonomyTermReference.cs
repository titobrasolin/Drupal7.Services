using System.Collections.Generic;

namespace Drupal7.ServiceModel.FieldTypes
{
    public class TaxonomyTermReferenceField : Dictionary<string, IList<TaxonomyTermReferenceFieldItem>>
    {

    }

    public class TaxonomyTermReferenceFieldItem
    {
        public int tid { get; set; }
    }
}

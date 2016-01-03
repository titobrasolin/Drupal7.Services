namespace Drupal7.Services.FieldTypes
{
    public class TaxonomyTid
    {
        public int tid { get; set; }
    }
    public class TaxonomyTermReferenceField
    {
        public TaxonomyTid[] und { get; set; }
    }
}

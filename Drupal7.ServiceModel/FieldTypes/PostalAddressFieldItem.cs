namespace Drupal7.ServiceModel.FieldTypes
{
    public class PostalAddressFieldItem
    {
        public string country { get; set; }
        public string administrative_area { get; set; }
        public string sub_administrative_area { get; set; }
        public string locality { get; set; }
        public string dependent_locality { get; set; }
        public string postal_code { get; set; }
        public string thoroughfare { get; set; }
        public string premise { get; set; }
        public string sub_premise { get; set; }
        public string organisation_name { get; set; }
        public string name_line { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public object data { get; set; }
    }
}

using System.Collections.Generic;

namespace Drupal7.ServiceModel.FieldTypes
{
    public class TextField : Dictionary<string, IList<TextFieldItem>>
    {

    }

    public class TextFieldItem
    {
        public string format { get; set; }
        public string value { get; set; }
        public string safe_value { get; set; }
        public string summary { get; set; }
        public string safe_summary { get; set; }
    }
}

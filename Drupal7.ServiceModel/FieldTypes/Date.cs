using System.Collections.Generic;

namespace Drupal7.ServiceModel.FieldTypes
{
    public class DateField : Dictionary<string, IList<DateFieldItem>>
    {

    }

    public class DateFieldItem
    {
        public string date_type { get; set; }
        public string timezone { get; set; }
        public string timezone_db { get; set; }
        public string value { get; set; }
        public string value2 { get; set; }
        public string rrule { get; set; }
    }
}

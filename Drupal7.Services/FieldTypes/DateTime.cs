using System.Collections.Generic;

namespace Drupal7.Services
{
    public class DateTimeField
    {
        public IList<DateTimeFieldItem> und { get; set; }
    }
    public class DateTimeFieldItem
    {
        public string date_type { get; set; }
        public string timezone { get; set; }
        public string timezone_db { get; set; }
        public string value { get; set; }
        public string value2 { get; set; }
        public string rrule { get; set; }
    }
}

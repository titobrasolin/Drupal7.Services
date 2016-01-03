namespace Drupal7.Services.FieldTypes
{
    public class TextField
    {
        public TextItem[] und { get; set; }
    }
    public class TextItem
    {
        public string value { get; set; }
        public string format { get; set; }
        public string safe_value { get; set; }
    }
}

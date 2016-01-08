namespace Drupal7.Services.FieldTypes
{
    public class TextField
    {
        public TextFieldItem[] und { get; set; }
    }
    public class TextFieldItem
    {
        public string value { get; set; }
        public string format { get; set; }
        public string safe_value { get; set; }
    }
}

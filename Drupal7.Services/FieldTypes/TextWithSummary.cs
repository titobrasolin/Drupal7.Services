namespace Drupal7.Services.FieldTypes
{
    public class TextWithSummaryField
    {
        public TextWithSummaryFieldItem[] und { get; set; }
    }
    public class TextWithSummaryFieldItem : TextFieldItem
    {
        public string summary { get; set; }
        public string safe_summary { get; set; }
    }
}

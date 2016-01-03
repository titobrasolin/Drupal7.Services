namespace Drupal7.Services.FieldTypes
{
    public class TextWithSummaryField
    {
        public TextWithSummaryItem[] und { get; set; }
    }
    public class TextWithSummaryItem : TextItem
    {
        public string summary { get; set; }
        public string safe_summary { get; set; }
    }
}

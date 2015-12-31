namespace Drupal7.Services.FieldTypes
{
    class TextWithSummary : Text
    {
        public string summary { get; set; }
        public string safe_summary { get; set; }
    }
}

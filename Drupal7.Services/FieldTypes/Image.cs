namespace Drupal7.Services.FieldTypes
{
    public class ImageField
    {
        public ImageFieldItem[] und { get; set; }
    }
    public class ImageFieldItem
    {
        public string filename { get; set; }
        public string alt { get; set; }
        public string filemime { get; set; }
        public int fid { get; set; }
        public int filesize { get; set; }
        public object[] rdf_mapping { get; set; }
        public int height { get; set; }
        public string title { get; set; }
        public string uri { get; set; }
        public int timestamp { get; set; }
        public int uid { get; set; }
        public int status { get; set; }
        public int width { get; set; }
    }
}

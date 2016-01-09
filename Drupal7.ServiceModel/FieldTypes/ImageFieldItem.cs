namespace Drupal7.ServiceModel.FieldTypes
{
    public class ImageFieldItem
    {
        public int fid { get; set; }
        public int uid { get; set; }
        public string filename { get; set; }
        public string filemime { get; set; }
        public int filesize { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string uri { get; set; }
        public string title { get; set; }
        public string alt { get; set; }
        public int status { get; set; }
        public int timestamp { get; set; }
        public object rdf_mapping { get; set; }
    }
}

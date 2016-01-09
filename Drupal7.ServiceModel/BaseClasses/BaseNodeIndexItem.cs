using System;

namespace Drupal7.ServiceModel.BaseClasses
{
    public class BaseNodeIndexItem
    {
        public int nid { get; set; }
        public int vid { get; set; }
        public int uid { get; set; }
        public int tnid { get; set; }
        public int translate { get; set; }
        public string language { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public int created { get; set; }
        public int changed { get; set; }
        public int status { get; set; }
        public int promote { get; set; }
        public int sticky { get; set; }
        public int comment { get; set; }
    }
}

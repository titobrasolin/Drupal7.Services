namespace Drupal7.Services.BaseClasses
{
    public class entity
    {
        public string target_id { get; set; }
    }
    public class boolean
    {
        public bool value { get; set; }
    }
    public class integer
    {
        public string value { get; set; }
    }
    public class date
    {
        public string value { get; set; }
        public string timezone_db { get; set; }
        public string date_type { get; set; }
        public string timezone { get; set; }
        public string value2 { get; set; }
    }
    public class text_long
    {
        public string value { get; set; }
        public string format { get; set; }
        public string safe_value { get; set; }
    }
    
    public class BaseNode
    {
        private int _nid;
        private int _promote;
        private int _changed;
        private string _type;
        private int _created;
        private int _comment;
        private string _title;
        private int _sticky;
        private int _tnid;
        private int _uid;
        private int _vid;
        private int _status;
        private int _translate;
        private string _language;

        public int nid
        {
            get
            {
                return _nid;
            }

            set
            {
                _nid = value;
            }
        }

        public int promote
        {
            get
            {
                return _promote;
            }

            set
            {
                _promote = value;
            }
        }

        public int changed
        {
            get
            {
                return _changed;
            }

            set
            {
                _changed = value;
            }
        }

        public string type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public int created
        {
            get
            {
                return _created;
            }

            set
            {
                _created = value;
            }
        }

        public int comment
        {
            get
            {
                return _comment;
            }

            set
            {
                _comment = value;
            }
        }

        public string title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
            }
        }

        public int sticky
        {
            get
            {
                return _sticky;
            }

            set
            {
                _sticky = value;
            }
        }

        public int tnid
        {
            get
            {
                return _tnid;
            }

            set
            {
                _tnid = value;
            }
        }

        public int uid
        {
            get
            {
                return _uid;
            }

            set
            {
                _uid = value;
            }
        }

        public int vid
        {
            get
            {
                return _vid;
            }

            set
            {
                _vid = value;
            }
        }

        public int status
        {
            get
            {
                return _status;
            }

            set
            {
                _status = value;
            }
        }

        public int translate
        {
            get
            {
                return _translate;
            }

            set
            {
                _translate = value;
            }
        }

        public string language
        {
            get
            {
                return _language;
            }

            set
            {
                _language = value;
            }
        }
    }
}

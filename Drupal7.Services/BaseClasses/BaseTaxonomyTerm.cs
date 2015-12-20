namespace Drupal7.Services.BaseClasses
{
    public class BaseTaxonomyTerm
    {
        private int _tid;
        private string _format;
        private string _description;
        private int _parent;
        private string _name;
        private int _weight;
        private int _vid;

        public int tid {
            get {
                return _tid;
            }
            set {
                _tid = value;
            }
        }

        public string format {
            get {
                return _format;
            }
            set {
                _format = value;
            }
        }

        public string description {
            get {
                return _description;
            }
            set {
                _description = value;
            }
        }

        public int parent {
            get {
                return _parent;
            }
            set {
                _parent = value;
            }
        }

        public string name {
            get {
                return _name;
            }
            set {
                _name = value;
            }
        }

        public int weight {
            get {
                return _weight;
            }
            set {
                _weight = value;
            }
        }

        public int vid {
            get {
                return _vid;
            }
            set {
                _vid = value;
            }
        }
    }
}

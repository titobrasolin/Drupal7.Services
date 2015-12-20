namespace Drupal7.Services
{
    public class BaseTaxonomyVocabulary
    {
        private string _machine_name;
        private int _weight;
        private string _description;
        private int _hierarchy;
        private string _module;
        private string _name;
        private int _vid;

        public string machine_name {
            get {
                return _machine_name;
            }
            set {
                _machine_name = value;
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

        public string description {
            get {
                return _description;
            }
            set {
                _description = value;
            }
        }

        public int hierarchy {
            get {
                return _hierarchy;
            }
            set {
                _hierarchy = value;
            }
        }

        public string module {
            get {
                return _module;
            }
            set {
                _module = value;
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


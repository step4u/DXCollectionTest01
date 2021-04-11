using System;
using System.ComponentModel;

namespace DXCollectionTest01
{

    public class Product : INotifyPropertyChanged, ICloneable
    {
        private bool _chk;
        private string _text;

        public Product()
        {
            Chk = false;
            Text = string.Empty;
        }

        public bool Chk {
            get { return _chk; }
            set {
                _chk = value;
                OnPropertyChanged("Chk1");
                System.Diagnostics.Debug.WriteLine("set Chk: " + value);
            }
        }

        public string Text {
            get { return _text; }
            set {
                _text = value;
                OnPropertyChanged("Text");
                System.Diagnostics.Debug.WriteLine("set Text: " + value);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public bool HasSameValues(Product other)
        {
            if (this.Chk != other.Chk) return false;
            if (this.Text != other.Text) return false;

            return true;
        }

        public Product HasSameValue(Product other)
        {
            bool result = true;

            if (this.Chk != other.Chk) result = false;
            if (this.Text != other.Text) result = false;

            if (result)
                return other;
            else
                return this;
        }
    }
}

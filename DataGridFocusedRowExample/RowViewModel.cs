using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridFocusedRowExample
{
    public class RowViewModel : ViewModelBase
    {
        public string _name;
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged("Name"); } }

        public float _money;
        public float Money { get { return _money; } set { _money = value; OnPropertyChanged("Money"); } }

        public int _copyrights;
        public int Copyrights { get { return _copyrights; } set { _copyrights = value; OnPropertyChanged("Copyrights"); } }

        public int _trademarks;
        public int Trademarks { get { return _trademarks; } set { _trademarks = value; OnPropertyChanged("Trademarks"); } }
    }
}

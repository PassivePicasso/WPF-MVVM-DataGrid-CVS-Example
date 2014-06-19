using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;

namespace DataGridFocusedRowExample
{
    class ViewModel : ViewModelBase
    {
        private ObservableCollection<RowViewModel> _models;
        public ObservableCollection<RowViewModel> ModelSource { get { return _models; } }

        public ICollectionView Models { get; set; }

        public ICommand ClearContentCommand { get; set; }

        private string _filterString;
        public String FilterString { get { return _filterString; } set { _filterString = value; OnPropertyChanged("FilterString"); Models.Refresh(); } }

        public ViewModel()
        {
            _models = new ObservableCollection<RowViewModel>();

            Models = CollectionViewSource.GetDefaultView(_models);

            Models.Filter = item =>
            {
                if (string.IsNullOrEmpty(_filterString)) return true;
                else return ((RowViewModel)item).Name.ToLower().Contains(_filterString.ToLower());
            };


            ClearContentCommand = new RelayCommand(commandParameter => ((ObservableCollection<RowViewModel>)commandParameter).Clear(),
                                                   commandParameter =>
                                                   {
                                                       var collection = commandParameter as ObservableCollection<RowViewModel>;
                                                       if (collection == null) return false;
                                                       return collection.Any();
                                                   });

            Timer dt = new Timer(TimeSpan.FromSeconds(2).TotalMilliseconds);
            dt.Elapsed += (s, e) => App.Current.Dispatcher.Invoke(() =>
            {
                _models.Add(ModelDataSource.GetRandomModel());
                CommandManager.InvalidateRequerySuggested();
            });

            dt.Start();
        }
    }
}

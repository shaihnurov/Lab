using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.MVVM.ViewModel.Ilnar
{
    public class IlnarViewModel : ObservableObject
    {
        public object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand GistogrammViewCommand { get; set; }
        public GistogrammViewModel GistrogrammVM { get; set; }
        public IlnarViewModel()
        {
            GistrogrammVM = new GistogrammViewModel();

            GistogrammViewCommand = new RelayCommand(() =>
            {
                CurrentView = GistrogrammVM;
            });
        }
    }
}

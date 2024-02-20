using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lab.MVVM.ViewModel.Ilnar;
using System.Windows;

namespace Lab.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
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

        public RelayCommand IlnarViewCommand { get; set; }
        public IlnarViewModel IlnarVM { get; set; }
        public MainViewModel() 
        { 
            IlnarVM = new IlnarViewModel();

            IlnarViewCommand = new RelayCommand(() =>
            {
                CurrentView = IlnarVM;
            });
        }
    }
}

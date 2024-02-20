using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lab.MVVM.View.Romanov;
using Lab.MVVM.ViewModel.Egor;
using Lab.MVVM.ViewModel.Ilnar;
using Lab.MVVM.ViewModel.Obraztsov;
using Lab.MVVM.ViewModel.Romanov;
using Lab.MVVM.ViewModel.Uvarovskiy;
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

        public RelayCommand GistogrammViewCommand { get; set; }
        public GistogrammViewModel GistrogrammVM { get; set; }
        public RelayCommand IlnarViewCommand { get; set; }
        public RelayCommand RomanovGistogrammViewCommand { get; set; }
        public RelayCommand UvarovskiyGistogrammViewCommand { get; set; }
        public RelayCommand ObraztsovGistogrammViewCommand { get; set; }
        public RelayCommand EgorGistogrammViewCommand { get; set; }
        public RomanovGistogrammViewModel RomanovVM { get; set; }
        public UvarovskiyGistogrammViewModel UvarovskiyVM { get; set; }
        public ObraztsovGistogrammViewModel ObraztsovVM { get; set; }
        public EgorGistogrammViewModel EgorVM { get; set; }
        public MainViewModel() 
        { 
            RomanovVM = new RomanovGistogrammViewModel();
            UvarovskiyVM = new UvarovskiyGistogrammViewModel();
            ObraztsovVM = new ObraztsovGistogrammViewModel();
            EgorVM = new EgorGistogrammViewModel();
            GistrogrammVM = new GistogrammViewModel();

            RomanovGistogrammViewCommand = new RelayCommand(() =>
            {
                CurrentView = RomanovVM;
            });
            UvarovskiyGistogrammViewCommand = new RelayCommand(() =>
            {
                CurrentView = UvarovskiyVM;
            });
            ObraztsovGistogrammViewCommand = new RelayCommand(() =>
            {
                CurrentView = ObraztsovVM;
            });
            EgorGistogrammViewCommand = new RelayCommand(() =>
            {
                CurrentView = EgorVM;
            });
            GistogrammViewCommand = new RelayCommand(() =>
            {
                CurrentView = GistrogrammVM;
            });

        }
    }
}

using GalaSoft.MvvmLight.Command;
using MVVM.Services;
using System.Windows.Input;

namespace MVVM.ViewModels
{
    public class MenuItemViewModel
    {
        private NavigationService navigationService;
        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }
        public MenuItemViewModel()
        {
            navigationService = new NavigationService();
        }

        public ICommand NavigateCommand { get{ return new RelayCommand(Navigate); } }

        private void Navigate()
        {
            App.Master.IsPresented = false;
            navigationService.Navigate(PageName);
        }
    }
}

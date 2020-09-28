using GalaSoft.MvvmLight.Command;
using MVVM.Pages;
using MVVM.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVVM.ViewModels
{
    public class MainViewModel
    {
        #region Attributes
        private NavigationService navigationService;
        public OrderViewModel NewOrder { get; private set; }
        private ApiService apiService;
        #endregion

        #region Properties

        public ObservableCollection<MenuItemViewModel> Menu { get; set; }

        public ObservableCollection<OrderViewModel> Orders { get; set; }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();

            Orders = new ObservableCollection<OrderViewModel>();

            navigationService = new NavigationService();

            apiService = new ApiService();

            LoadMenu();

            //LoadFakeData();
        }
        #endregion

        #region Commands
        public ICommand GoToCommand { get { return new RelayCommand<string>(GoTo); } }

        private void GoTo(string pageName)
        {
            switch (pageName)
            {
                case "NewOrderPage":
                    NewOrder = new OrderViewModel();
                    break;
                default:
                    break;
            }
            navigationService.Navigate(pageName);
        }

        public ICommand StartCommand { get { return new RelayCommand(Start); } }

        private async void Start()
        {
            var orders = await apiService.GetAllorders();
            Orders.Clear();
            foreach (var order in orders)
            {
                Orders.Add(new OrderViewModel
                {
                    Client = order.Client,
                    CreationDate = order.CreationDate,
                    DeliveryDate = order.DeliveryDate,
                    DeliveryInformation = order.DeliveryInformation,
                    Description = order.Description,
                    Title = order.Title,
                    Id = order.Id
                });
            }
            navigationService.SetMainPage();
        }

        #endregion

        #region Methods
        private void LoadFakeData()
        {
            Orders = new ObservableCollection<OrderViewModel>();

            for (int i = 0; i < 10; i++)
            {
                Orders.Add(new OrderViewModel
                {
                    Title = "Lorem Ipsum",
                    DeliveryDate = DateTime.Today,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                });
            }
        }

        private void LoadMenu()
        {
            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_action_orders.png",
                PageName = "MainPage",
                Title = "Pedidos"
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_action_customers.png",
                PageName = "ClientsPage",
                Title = "Clientes"
            });
            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_alarms.png",
                PageName = "AlarmsPage",
                Title = "Alarmas"
            });
            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_settings.png",
                PageName = "SettingsPage",
                Title = "Ajustes"
            });
        }
        #endregion
    }
}

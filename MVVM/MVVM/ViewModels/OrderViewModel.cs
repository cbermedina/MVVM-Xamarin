using GalaSoft.MvvmLight.Command;
using MVVM.Models;
using MVVM.Services;
using System;
using System.Windows.Input;

namespace MVVM.ViewModels
{
    public class OrderViewModel
    {
        #region Attributes
        private ApiService apiService;
        private DialogService dialogService;

        #endregion

        #region Properties
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string DeliveryInformation { get; set; }

        public string Client { get; set; }

        public string Phone { get; set; }
        #endregion

        #region Constructors
        public OrderViewModel()
        {
            apiService = new ApiService();
            dialogService = new DialogService();
        }
        #endregion

        #region Commands

        public ICommand SaveCommand { get { return new RelayCommand(Save); } }

        #endregion
        private async void Save()
        {
            if (string.IsNullOrEmpty(Title))
            {
                await dialogService.ShowMessage("Error", "Debe ingresar un titulo");
            }
            var order = new Order
            {
                Client = Client,
                CreationDate = DateTime.Now,
                DeliveryDate = DateTime.Now,
                DeliveryInformation = DeliveryInformation,
                Description = Description,
                IsDelivered = false,
                Phone = Phone,
                Title = Title
            };
            await apiService.CreateOrder(order);
            await dialogService.ShowMessage("Información", "El servicio ha sido creado.");
        }
    }
}

using MVVM.Classes;
using MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Services
{
    public class ApiService
    {
        #region Properties
        DataAccess da = new DataAccess();
        #endregion
        #region Methods
        public async Task<List<Order>> GetAllorders()
        {
            try
            {
               
                //var order = new Order { Client="Cesar", CreationDate =DateTime.Now, DeliveryDate= DateTime.Now, DeliveryInformation="Prueba", Description="Prueba description", IsDelivered=true, Phone="2113020", Title="My phone number"};
                //da.Insert<Order>(order);
                var orders = da.GetList<Order>(false);
                return orders;
                //var client = new HttpClient();
                ////Base direction
                //client.BaseAddress = new Uri("http://www.google.com");
                //var url = "/service/api/orders";
                //var response = await client.GetAsync(url);
                //if (!response.IsSuccessStatusCode)
                //{
                //    return new List<Order>();
                //}
                //var result = await response.Content.ReadAsStringAsync();
                //var orders = JsonConvert.DeserializeObject<List<Order>>(result);
                //return orders;
                return new List<Order>();
            }
            catch
            {
                return new List<Order>();
            }
        }

        public async Task<Order> CreateOrder(Order order)
        {
            try
            {
                 da.Insert<Order>(order);
               // var orders = da.GetList<Order>(false);
                return order;
                //var content = JsonConvert.SerializeObject(order);
                //var body = new StringContent(content, Encoding.UTF8, "application/json");
                //var client = new HttpClient();
                //client.BaseAddress = new Uri("http://www.google.com");
                //var url = "/service/api/orders";
                //var response = await client.PostAsync(url, body);
                //if (!response.IsSuccessStatusCode)
                //{
                //    return null;
                //}

                //var result = await response.Content.ReadAsStringAsync();
                // var newOrder = JsonConvert.DeserializeObject<Order>(result);
                //return newOrder;
            }
            catch
            {
                return null;
            }
        }
        #endregion


    }
}

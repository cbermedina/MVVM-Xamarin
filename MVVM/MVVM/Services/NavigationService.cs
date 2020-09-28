using MVVM.Pages;

namespace MVVM.Services
{
    public class NavigationService
    {
        public async void Navigate(string PageName)
        {
            App.Master.IsPresented = false;

            switch (PageName)
            {
                case "AlarmsPage":
                  await  App.Navigator.PushAsync(new AlarmsPage());
                    break;
                case "ClientsPage":
                    await App.Navigator.PushAsync(new ClientsPage());
                    break;
                case "SettingsPage":
                    await App.Navigator.PushAsync(new SettingsPage());
                    break;
                case "NewOrderPage":
                    await App.Navigator.PushAsync(new NewOrderPage());
                    break;
                case "MainPage":
                    await App.Navigator.PopToRootAsync();
                    break;
                default:
                    break;
            }
        }

        internal void SetMainPage()
        {
            App.Current.MainPage = new MasterPage();
        }
    }
}

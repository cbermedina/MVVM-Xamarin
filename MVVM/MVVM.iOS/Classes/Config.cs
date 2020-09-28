using MVVM.Interfaces;
using SQLite.Net.Interop;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(MVVM.iOS.Classes.Config))]
namespace MVVM.iOS.Classes
{
    public class Config : IConfig
    {
        private string directoryDB;
        private ISQLitePlatform platform;

        public string DirectoryDB
        {
            get
            {
                if (string.IsNullOrEmpty(directoryDB))
                {
                    var directorio = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    directoryDB = System.IO.Path.Combine(directorio, "..", "Library");
                }

                return directoryDB;
            }
        }

        public ISQLitePlatform Platform
        {
            get
            {
                if (platform == null)
                {
                    platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
                }

                return platform;
            }
        }
    }
}

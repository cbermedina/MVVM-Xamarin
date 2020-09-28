﻿using MVVM.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Interop;
using Xamarin.Forms;
using Windows.Storage;

[assembly: Dependency(typeof(MVVM.WinPhone.Classes.Config))]
namespace MVVM.WinPhone.Classes
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
                    directoryDB = ApplicationData.Current.LocalFolder.Path;
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
                    platform = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
                }

                return platform;
            }
        }
    }
}

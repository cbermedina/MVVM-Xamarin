using SQLite.Net.Interop;

namespace MVVM.Interfaces
{
   public interface IConfig
    {
        string DirectoryDB { get; }

        ISQLitePlatform Platform { get; }
    }
}

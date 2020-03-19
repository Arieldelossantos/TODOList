using System;
using System.IO;
using SQLite;
using TODOList.iOS.Services;
using TODOList.Services;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_iOS))]
namespace TODOList.iOS.Services
{
    public class SQLite_iOS : ISQLite
    {
        public SQLiteAsyncConnection GetConnection()
        {
            string dbLocation = "TODO.db3";

            var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(docsPath, "../Library/");
            dbLocation = Path.Combine(libraryPath, dbLocation);
            //var sqlConn = new SQLiteConnectionWithLock( new SQLiteConnectionString(dbLocation, false));
            return new SQLiteAsyncConnection(dbLocation);
        }
    }
}

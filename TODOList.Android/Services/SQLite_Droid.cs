using System;
using System.IO;
using SQLite;
using TODOList.Droid.Services;
using TODOList.Services;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_Droid))]
namespace TODOList.Droid.Services
{
    public class SQLite_Droid : ISQLite
    {
        public SQLiteAsyncConnection GetConnection()
        {
            string dbLocation = "TODO.db3";

            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            dbLocation = Path.Combine(documentsPath, dbLocation);
           
            return new SQLiteAsyncConnection(dbLocation);
        }
    }
}

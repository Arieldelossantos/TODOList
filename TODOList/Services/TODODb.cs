using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using TODOList.Models;
using Xamarin.Forms;

namespace TODOList.Services
{
    public class TODODb : ITODODb
    {
        private SQLiteAsyncConnection db;

        public TODODb()
        {
            db = DependencyService.Get<ISQLite>().GetConnection();
            CreateTables();
        }

        private void CreateTables()
        {
            db.CreateTableAsync<TaskTODO>();
        }

        public SQLiteAsyncConnection GetConnection()
        {
            return db;
        }

        public async Task SaveTask(TaskTODO taskTODO)
        {
            await db.InsertAsync(taskTODO);
        }

        public IEnumerable<TaskTODO> LoadData()
        {           
            var data = db.GetConnection().Table<TaskTODO>();

           return  data.ToList();
        }

        public async Task CompleteTask(TaskTODO taskTODO)
        {
            taskTODO.Completed = true;

            await db.InsertOrReplaceAsync(taskTODO);
        }
    }
}

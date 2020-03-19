using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using TODOList.Models;

namespace TODOList.Services
{
    public interface ITODODb
    {
        SQLiteAsyncConnection GetConnection();

        Task SaveTask(TaskTODO taskTODO);
        Task CompleteTask(TaskTODO taskTODO);
        IEnumerable<TaskTODO> LoadData();
    }
}

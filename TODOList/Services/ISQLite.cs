using System;
using SQLite;

namespace TODOList.Services
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetConnection();       
    }
}

using MvvmCross.Plugins.Sqlite;
using SQLite.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Core.Contracts.Services;
using Users.Core.Model;

namespace Users.Core.Services.Data
{
    public class DataService
        : IDataService
    {
        private readonly SQLiteConnection _connection;

        public DataService(IMvxSqliteConnectionFactory factory)
        {
            _connection = factory.GetConnection("data.dat");
            _connection.CreateTable<User>();
        }

        public Task<int> Save(User user)
        {
            return Task.FromResult(_connection.Insert(user));
        }

        public Task Load()
        {
            return Task.FromResult(_connection.Table<User>().Last<User>());
        }

        public Task<List<User>> GetAllItems()
        {
            return Task.FromResult(_connection.Table<User>().ToList<User>());
        }
    }
}


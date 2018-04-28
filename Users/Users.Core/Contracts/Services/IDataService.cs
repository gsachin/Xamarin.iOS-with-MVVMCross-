using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Core.Model;

namespace Users.Core.Contracts.Services
{
    public interface IDataService
    {
        Task<int> Save(User user);
        Task Load();
        Task<List<User>> GetAllItems();
    }

}


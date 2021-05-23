using MyOnlineStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyOnlineStore.Interfaces
{
    public interface IApiMethods
    {
        Task<List<StoreItems>> GetStoreItems();
    }
}
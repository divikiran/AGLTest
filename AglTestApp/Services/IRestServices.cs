using System;
using System.Threading.Tasks;

namespace AglTestApp.Services
{
    public interface IRestServices<T> where T : class, new()
    {
        Task<T> GetAllAsync();
    }
}
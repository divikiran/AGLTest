using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AglTestApp.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
    }
}

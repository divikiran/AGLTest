using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AglTestApp.Models;

namespace AglTestApp.Interfaces
{
    public interface IOwnersRepository: IRepository<OwnerPets>
    {
        Task<List<OwnerPets>> GetData();
    }
}

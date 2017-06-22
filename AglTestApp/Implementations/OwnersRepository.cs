using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AglTestApp.Interfaces;
using AglTestApp.Models;
using AglTestApp.Services;

namespace AglTestApp.Implementations
{
    public class OwnersRepository : Repository<OwnerPets>, IOwnersRepository
    {
		public async Task<List<OwnerPets>> GetData()
		{
			try
			{
				var httpClient = new RestServices<List<OwnerPets>>();
                List<OwnerPets> list = await httpClient.GetAllAsync();

                if (list == null || list.Count == 0)
                    return null;
                
				return list;
			}
			catch (Exception e)
			{
				throw e;
			}
		}
    }
}

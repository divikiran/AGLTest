using System;
using System.Collections.Generic;

namespace AglTestApp.Models
{
    public class OwnerPets
    {
		public string Name { get; set; }
		public string Gender { get; set; }
		public int Age { get; set; }
		public List<Pet> Pets { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace AglTestApp.Models
{
    public class PetsCollection
    {
        public string GroupText
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public PetsCollection(string gender, Pet pet)
        {
            GroupText = gender;
            Text = pet.Name;
        }
    }
}

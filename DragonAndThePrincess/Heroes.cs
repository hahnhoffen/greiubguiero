using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonAndThePrincess
{
    internal class Heroes
    {
        public string Name { get; set; }    
        public string Description { get; set; }

        public Heroes(string name, string description) 
        {
            Name = name;
            Description = description;
        }

    }
}

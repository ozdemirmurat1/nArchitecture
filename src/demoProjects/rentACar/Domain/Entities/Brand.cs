using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Brand:Entity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<Model> Models { get; set; }

        // entityFramework parametresiz ctor a ihtiyaç duyabilir.Belki ilerleyen versiyonlarda ihtiyaç yoktur.
        public Brand()
        {
            
        }

        public Brand(int id,string name):base(id) 
        {
            Name = name;
        }
    }
}

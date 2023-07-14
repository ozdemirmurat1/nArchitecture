using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Model:Entity<int>
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public decimal DailyPrice { get; set; }
        public string ImageUrl { get; set; }

        // Birçok Orm'de kullanmak için virtual ekledik.Örneğin NHibarnate. virtual eklemek zorunda da değiliz.Alışkanlık
        public virtual Brand Brand { get; set; }

        public Model()
        {
            
        }

        public Model(int id,int brandId,string name,decimal dailyPrice,string imageUrl):base(id)
        {
            Name = name;
            DailyPrice = dailyPrice;
            ImageUrl = imageUrl;
            BrandId = brandId;
        }



    }
}

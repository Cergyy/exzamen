using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekzBast.Model
{
    class LocalDataProvider : IDataProvider
    {
        public IEnumerable<Product> GetProduts()
        {
            return new Product[]
            {
                new Product {Name="Картошка",Cena=20,Kolichestvo=105.1,Vremiy=TimeSpan.FromDays(20),Vvid="Овощи" },
                new Product {Name="Малина",Cena=50,Kolichestvo=155.1,Vremiy=TimeSpan.FromDays(30),Vvid="Ягоды" },
            };
        }
        public IEnumerable<Vvid> GetProductVvid()
        {
            return new Vvid[]
            {
            new Vvid{Title="Овощи"},
            new Vvid{Title="Ягоды"},
            new Vvid{Title="Рис"}
            };
        }
    }
}

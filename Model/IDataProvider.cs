using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekzBast.Model
{
    interface IDataProvider
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Vvid> GetProductVvid();
    }
}
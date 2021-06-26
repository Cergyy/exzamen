using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekzBast
{
    public class Product
    {
        public string Name { get; set; }
        public int Cena { get; set; }
        public double Kolichestvo { get; set; }
        public TimeSpan Vremiy { get; set; }
        public string Vvid { get; set; }
        public string Title { get; internal set; }
    }
}
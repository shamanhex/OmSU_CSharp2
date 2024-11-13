using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLLab.DB
{
    public class Product
    {
        public string Name { get; set; }
        public double Count { get; set; }
        public DateTime LastRelease { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mikethebiller.BLL
{
    class productsbll
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public String Description { get; set; }
        public decimal Rate { get; set; }
        public decimal Qty { get; set; }
        public DateTime added_date { get; set; }
        public int added_by { get; set; }
       // public int MyProperty { get; set; }
    }
}

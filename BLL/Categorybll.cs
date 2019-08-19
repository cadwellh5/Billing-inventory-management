using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mikethebiller.BLL
{
    class Categorybll
    {
        public int id{ get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public DateTime added_date {get; set; }
        public int added_by { get; set; }
        
    }
}

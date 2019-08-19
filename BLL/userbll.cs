using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mikethebiller.BLL
{
    class userbll
    {
        public  int id { get; set; }
    public string First_name { get; set; }
        public string Last_name  { get; set; }
        public string email { get; set; }
        public string  username { get; set; }
        public string password  { get; set; }
        public string contact { get; set; }
        public string   Address { get; set; }
        public string user_type { get; set; }
        public DateTime added_date { get; set; }
        public int added_by { get; set; }

    }
}

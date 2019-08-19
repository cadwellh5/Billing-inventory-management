using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mikethebiller.BLL
{
    class Transactionbll
    {
        public int id { get; set; }
        public String Type { get; set; }
        public int dea_cust_id { get; set; }
        public Decimal Grand_total { get; set; }
        public DateTime transaction_date { get; set; }
        public  Decimal tax { get; set; }
        public Decimal discount { get; set; }
        public int added_by { get; set; }
        public DataTable transactiondetails { get; set; }

    }
}

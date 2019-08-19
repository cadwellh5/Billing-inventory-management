using mikethebiller.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mikethebiller.DAL
{
    class Transactiondetaildal
    {

        static string myconnstring = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;



        #region Insert Data in Transaction method
        public bool Insert(trnsctiondetailbll u)
        {
            bool issuccess = false;
           // transactionid = -1;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                String sql = "INSERT INTO trnsction_detail_tbl(pid,rate,qty,Total,dea_cust_id,added_date,added_by) VALUES (@pid,@rate,@qty,@Total,@dea_cust_id,@added_date,@added_by)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@pid", u.pid);
                cmd.Parameters.AddWithValue("@rate", u.rate);
                cmd.Parameters.AddWithValue("@qty", u.qty);
                cmd.Parameters.AddWithValue("@Total", u.Total);
                cmd.Parameters.AddWithValue("@dea_cust_id", u.dea_cust_id);
                cmd.Parameters.AddWithValue("@added_date", u.added_date);
                cmd.Parameters.AddWithValue("@added_by", u.added_by);
                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    issuccess = true;
                }
                else
                {
                    issuccess = false;

                }
            }
            catch (Exception e)

            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }





            return issuccess;

        }

        #endregion
    }
}

using mikethebiller.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mikethebiller.DAL
{
    class Transactiondal
    {
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;



        #region Insert Data in Transaction method
        public bool Insert(Transactionbll u, out int transactionid)
        {
            bool issuccess = false;
            transactionid = -1;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                String sql = "INSERT INTO transactions_tbl(Type,dea_cust_id,Grand_total,transaction_date,tax,discount,added_by) VALUES (@Type,@dea_cust_id,@Grand_total,@transaction_date,@tax,@discount,@added_by) ; SELECT @@IDENTITY;";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Type", u.Type);
                cmd.Parameters.AddWithValue("@dea_cust_id", u.dea_cust_id);
                cmd.Parameters.AddWithValue("@Grand_total", u.Grand_total);
                cmd.Parameters.AddWithValue("@transaction_date", u.transaction_date);
                cmd.Parameters.AddWithValue("@tax", u.tax);
                cmd.Parameters.AddWithValue("@discount", u.discount);
                cmd.Parameters.AddWithValue("@added_by", u.added_by);
                conn.Open();
                object o = cmd.ExecuteScalar();
                if (o != null)
                {
                    transactionid = int.Parse(o.ToString());
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
        

    
    #region display transactions
    public DataTable displayalltransactions()
    {

        SqlConnection con = new SqlConnection(myconnstring);
        DataTable dt = new DataTable();
        try
        {
            String sql = "SELECT *  FROM transactions_tbl";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            con.Open();
            adapter.Fill(dt);



        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
        finally
        {
            con.Close();

        }
        return dt;


    }


        #endregion
        #region display transactions based on type
        public DataTable displaytypeoftransaction(string type)
        {

            SqlConnection con = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT *  FROM transactions_tbl where Type='"+type+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);



            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                con.Close();

            }
            return dt;


        }

        #endregion
        #region display transactions based on dcid
        public DataTable displaytypeoftransactiondcid(int dcid1)
        {

            SqlConnection con = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT *  FROM transactions_tbl where dea_cust_id='" + dcid1 + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);



            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                con.Close();

            }
            return dt;


        }

        #endregion



    }
}

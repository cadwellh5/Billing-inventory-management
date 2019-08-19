
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
    class logindal
    {
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
     public bool logincheck(loginbll l)
        {
            bool issuccess = false;
            SqlConnection con = new SqlConnection(myconnstring);
            try
            {
                string sql = "SELECT * FROM users_tbl WHERE username=@username AND password=@password AND user_type=@user_type ";
                SqlCommand cmd = new SqlCommand(sql, con);

             cmd.Parameters.AddWithValue("@username", l.username);
            cmd.Parameters.AddWithValue("@password", l.password);
          
            cmd.Parameters.AddWithValue("@user_type", l.user_type);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
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
                con.Close();
            }



            return issuccess;






            
        }
    }
}

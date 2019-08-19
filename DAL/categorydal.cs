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
    class categorydal
    {
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Select Data from Database
        public DataTable Select()
        {

            SqlConnection con = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT *  FROM categories_tbl";
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

        #region Insert Data In Database
        public bool Insert(Categorybll u)
        {
            bool issuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                String sql = "INSERT INTO categories_tbl(Title,Description,added_date,added_by) VALUES (@Title,@Description,@added_date,@added_by)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                
                cmd.Parameters.AddWithValue("@Title", u.Title);
                cmd.Parameters.AddWithValue("@Description", u.Description);
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


        #region Update data in database
        public bool Update(Categorybll u)
        {
            bool issuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                String sql = "UPDATE  categories_tbl SET Title=@Title,Description=@Description,added_date=@added_date,added_by=@added_by WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Title", u.Title);
                cmd.Parameters.AddWithValue("@Description", u.Description);
                cmd.Parameters.AddWithValue("@added_date", u.added_date);
                cmd.Parameters.AddWithValue("@added_by", u.added_by);
                cmd.Parameters.AddWithValue("@id", u.id);
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
        #region Delete data in Database
        public bool Delete(Categorybll u)
        {
            bool issuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                String sql = "DELETE FROM categories_tbl where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", u.id);

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
        #region Search categories in database using keywords

        public DataTable Search(string keywords)
        {

            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM categories_tbl WHERE id  LIKE '%" + keywords + "%' OR Title LIKE '%" + keywords + "%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);




            }
            catch (Exception e)

            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        #endregion
    }
}
using mikethebiller.BLL;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace mikethebiller.DAL
{
    class DCdal
    {
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Select Data from Database
        public DataTable Select()
        {

            SqlConnection con = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT *  FROM dealer_custmr_tbl";
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
        #region Insert data in database
        public bool Insert(DCbll u)
        {
            bool issuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                String sql = "INSERT INTO dealer_custmr_tbl(Type,Name,Email,Contact,Address,added_date,added_by) VALUES (@Type,@Name,@Email,@Contact,@Address,@added_date,@added_by)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Type", u.Type);
                cmd.Parameters.AddWithValue("@Name", u.Name);
                cmd.Parameters.AddWithValue("@Email", u.Email);
                cmd.Parameters.AddWithValue("@Contact", u.Contact);
                cmd.Parameters.AddWithValue("@Address", u.Address);
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
        #region Delete data in Database
        public bool Delete(DCbll u)
        {
            bool issuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                String sql = "DELETE FROM  dealer_custmr_tbl where id=@id";
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
        #region Update data in database
        public bool Update(DCbll u)
        {
            bool issuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                String sql = "UPDATE   dealer_custmr_tbl SET    Type=@Type,Name=@Name,Email=@Email,Contact=@Contact,Address=@Address,added_date=@added_date,added_by=@added_by WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Type", u.Type);
                cmd.Parameters.AddWithValue("@Name", u.Name);
                cmd.Parameters.AddWithValue("@Email", u.Email);
                cmd.Parameters.AddWithValue("@Contact", u.Contact);
                cmd.Parameters.AddWithValue("@Address", u.Address);
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
        #region Search categories in database using keywords

        public DataTable Search(string keywords)
        {

            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM dealer_custmr_tbl WHERE Type  LIKE '%" + keywords + "%' OR Name LIKE '%" + keywords + "%'  OR Email LIKE '%" + keywords + "%' OR Contact LIKE '%" + keywords + "%' OR Address LIKE '%" + keywords + "%' ";
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
        #region method to search dealer_customer for transaction module
        public DCbll Search_dea_cust_transaction(String keywords)
        { 
            DCbll dc = new DCbll();
        SqlConnection conn = new SqlConnection(myconnstring);
        DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT Name,Email,Contact,Address FROM dealer_custmr_tbl WHERE Type  LIKE '%" + keywords + "%' OR id   LIKE '%" + keywords + "%' OR Name LIKE '%" + keywords + "%'  OR Email LIKE '%" + keywords + "%' OR Contact LIKE '%" + keywords + "%' OR Address LIKE '%" + keywords + "%' ";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        conn.Open();
                adapter.Fill(dt);
                if(dt.Rows.Count>0)
                {
                    dc.Name = dt.Rows[0]["Name"].ToString();
                    dc.Email = dt.Rows[0]["Email"].ToString();
                    dc.Contact = dt.Rows[0]["Contact"].ToString();
                    dc.Address = dt.Rows[0]["Address"].ToString();
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

            return dc;




        }

        #endregion
        #region method to get id of customer or dealer based on name
        public DCbll getid(string name)
        {
            DCbll dc = new DCbll();
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT id FROM dealer_custmr_tbl WHERE Name='"+name+"'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dc.id = int.Parse(dt.Rows[0]["id"].ToString());
                   
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

            return dc;
        }
#endregion
    }
}

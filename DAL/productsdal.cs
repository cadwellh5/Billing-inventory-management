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
    class productsdal
    {
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Select Data from Database
        public DataTable Select()
        {

            SqlConnection con = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT *  FROM products_tbl";
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
        public bool Insert(productsbll u)
        {
            bool issuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                String sql = "INSERT INTO products_tbl(Name,Category,Description,Rate,Qty,added_date,added_by) VALUES (@Name,@Category,@Description,@Rate,@Qty,@added_date,@added_by)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Name", u.Name);
                cmd.Parameters.AddWithValue("@Category", u.Category);
                cmd.Parameters.AddWithValue("@Description", u.Description);
                cmd.Parameters.AddWithValue("@Rate", u.Rate);
                cmd.Parameters.AddWithValue("@Qty", u.Qty);
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
        public bool Delete(productsbll u)
        {
            bool issuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                String sql = "DELETE FROM products_tbl where id=@id";
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
        public bool Update(productsbll u)
        {
            bool issuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                String sql = "UPDATE  products_tbl SET Name=@Name,Category=@Category,Description=@Description,Rate=@Rate,Qty=@Qty,added_date=@added_date,added_by=@added_by WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Name", u.Name);
                cmd.Parameters.AddWithValue("@Category", u.Category);
                cmd.Parameters.AddWithValue("@Description", u.Description);
                cmd.Parameters.AddWithValue("@Rate", u.Rate);
                cmd.Parameters.AddWithValue("@Qty" +
                    "", u.Qty);
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
                String sql = "SELECT * FROM products_tbl WHERE id  LIKE '%" + keywords + "%' OR Name LIKE '%" + keywords + "%'  OR Category LIKE '%" + keywords + "%' OR Description LIKE '%" + keywords + "%' OR Rate LIKE '%" + keywords + "%' OR Qty LIKE '%" + keywords + "%'";
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
        #region method to search products for transaction module
        public productsbll Search_products_transaction(String keywords)
        {
            productsbll dc = new productsbll();
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT Name,Rate,Qty FROM products_tbl WHERE Name  LIKE '%" + keywords + "%' OR Name   LIKE '%" + keywords + "%' OR Category LIKE '%" + keywords + "%'  OR Rate LIKE '%" + keywords + "%' ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dc.Name = dt.Rows[0]["Name"].ToString();
                  // dc.Category = dt.Rows[0]["Category"].ToString();
                    dc.Rate = Decimal.Parse(dt.Rows[0]["Rate"].ToString());
                    dc.Qty = Decimal.Parse(dt.Rows[0]["Qty"].ToString());
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
        #region method to get current quantity from db 
        public decimal Getqty(int productid)
        {
            SqlConnection conn = new SqlConnection(myconnstring);
            decimal qty = 0;

            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT Qty FROM products_tbl WHERE id=" + productid;

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    qty = decimal.Parse(dt.Rows[0]["qty"].ToString());
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

            return qty;

        }
        #endregion
        #region method to update qty in db
        public bool Updatequantity(int productid, decimal qty)
        {
            bool Success = false;

            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string sql = "UPDATE products_tbl SET Qty=@Qty where id=@id";


                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Qty", qty);
                cmd.Parameters.AddWithValue("@id", productid);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    Success = true;
                }
                else
                {
                    Success = false;

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





            return Success;
        }

        #endregion
        #region increase qty

        public bool increaseqty(int pdid ,decimal incqty)
            {
                bool success = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                decimal curqty = Getqty(pdid);
                decimal newqty = curqty + incqty;
                success = Updatequantity(pdid, newqty);


           

            }
            catch (Exception e)

            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }



            return success;
            }
        #endregion
        #region method to decrease qty
        public bool decreaseqty(int pdid, decimal qty)
        {
            bool success = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                decimal curqty = Getqty(pdid);
                decimal newqty = curqty-qty;
                success = Updatequantity(pdid, newqty);




            }
            catch (Exception e)

            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }



            return success;
        }
        #endregion
        #region method to get id  based on product_name
        public productsbll getpid(string name)
        {
            productsbll p = new productsbll();
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT id FROM products_tbl WHERE Name='"+name+"'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    p.id = int.Parse(dt.Rows[0]["id"].ToString());

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

            return p;
        }
        #endregion
        #region display products based on category
        public DataTable displayproductsofcategory(string category)
        {

            SqlConnection con = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT *  FROM products_tbl where Category='" + category + "'";
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

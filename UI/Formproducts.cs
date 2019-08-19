using mikethebiller.BLL;
using mikethebiller.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mikethebiller.UI
{
    public partial class Formproducts : Form
    {
        public Formproducts()
        {
            InitializeComponent();
        }
        productsbll u2 = new productsbll();
        productsdal dal2 = new productsdal();



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        categorydal d = new categorydal();
        private void Formproducts_Load(object sender, EventArgs e)
        {
            DataTable dt = dal2.Select();
            dataGridView1.DataSource = dt;

          DataTable categoryDT = d.Select();
            categorycmb.DataSource = categoryDT;
            categorycmb.DisplayMember = "Title";
            categorycmb.ValueMember = "Title";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        private void clear()
        {
            pid.Text = "";
            name.Text = "";
            categorycmb.Text = "";
            rate.Text = "";
            qty.Text = "";
            description.Text = ""; ;



        }
        userdal udal = new userdal();
        private void button1_Click(object sender, EventArgs e)
        {
            u2.Name = name.Text;
            u2.Category = categorycmb.Text;

            u2.Description = description.Text;
            u2.Rate = Decimal.Parse(rate.Text);
            u2.Qty = Decimal.Parse(qty.Text);
            u2.added_date = DateTime.Now;
            string loggduser = Formlogin.loggdin;
            userbll u = udal.getid(loggduser);
            u2.added_by = u.id;
            bool success = dal2.Insert(u2);
            if (success == true)
            {

                MessageBox.Show("Products added successfullY");
                clear();
            }
            else
            {
                MessageBox.Show("FAILED TO ADD NEW PRODUCT");

            }
            DataTable dt = dal2.Select();
            dataGridView1.DataSource = dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            u2.id = int.Parse(pid.Text);
            u2.Name = name.Text;
            u2.Category = categorycmb.Text;

            u2.Description = description.Text;
            u2.Rate = Decimal.Parse(rate.Text);
            u2.Qty = Decimal.Parse(qty.Text);
            u2.added_date = DateTime.Now;
            u2.added_by = 1;

            bool success = dal2.Update(u2);
            if (success == true)
            {

                MessageBox.Show("PRODUCTS UPDATED SUCCESFULLY");
                clear();
            }
            else
            {
                MessageBox.Show("FAILED TO UPDATE USER");

            }
            DataTable dt = dal2.Select();
            dataGridView1.DataSource = dt;
       
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            u2.id = int.Parse(pid.Text);
            bool success = dal2.Delete(u2);
            if (success == true)
            {

                MessageBox.Show("CATEGORY DELETED SUCCESFULLY");
                clear();
            }
            else
            {
                MessageBox.Show("FAILED TO DELETE CATEGORY");

            }
            DataTable dt = dal2.Select();
            dataGridView1.DataSource = dt;
           
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            pid.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();


            name.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
           categorycmb .Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            description.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
           rate .Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
           qty .Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            String keywords = search.Text;
            if (keywords != null)
            {

                DataTable dt = dal2.Search(keywords);
                dataGridView1.DataSource = dt;
            }
            else
            {
                DataTable dt = dal2.Select();
                dataGridView1.DataSource = dt;
            }
        }

        private void category_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

using mikethebiller.BLL;
using mikethebiller.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace mikethebiller.UI
{
    public partial class FormDC : Form
    {
        public FormDC()
        {
            InitializeComponent();
        }
        DCbll v = new DCbll();
        DCdal s = new DCdal();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void clear()
        {
                ID.Text = "";
            
            nme.Text = "";
            email1.Text = "";
           
            contact1.Text = "";
            address1.Text = "";
          


        }
        userdal udal = new userdal();
        private void button1_Click(object sender, EventArgs e)
        {
            v.Type = comboType.Text;
            v.Name = nme.Text;
            v.Email = email1.Text;
      
            
            v.Contact = contact1.Text;
            v.Address = address1.Text;
         
            v.added_date = DateTime.Now;
            string loggduser = Formlogin.loggdin;
            userbll u = udal.getid(loggduser);
            v.added_by = u.id;
           
            bool success =s.Insert(v);
            if (success == true)
            {

                MessageBox.Show("USER CREATED SUCCESFULLY");
                clear();
            }
            else
            {
                MessageBox.Show("FAILED TO ADD NEW USER");

            }
            DataTable dt = s.Select();
            dataGridView8.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            v.id = int.Parse(ID.Text);
            v.Type = comboType.Text;
            v.Name = nme.Text;
            v.Email = email1.Text;


            v.Contact = contact1.Text;
            v.Address = address1.Text;

            v.added_date = DateTime.Now;
            v.added_by = 1; bool success = s.Update(v);
            if (success == true)
            {

                MessageBox.Show("USER UPDATED SUCCESFULLY");
                clear();
                DataTable dt = s.Select();
                dataGridView8.DataSource = dt;
            }
            else
            {
                MessageBox.Show("FAILED TO UPDATE USER");

            }
           /* DataTable dt = s.Select();
            dataGridView8.DataSource = dt;*/
        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int rowIndex = e.RowIndex;
            ID.Text = dataGridView8.Rows[rowIndex].Cells[0].Value.ToString();


            comboType.Text = dataGridView8.Rows[rowIndex].Cells[1].Value.ToString();
            nme.Text = dataGridView8.Rows[rowIndex].Cells[2].Value.ToString();
            email1.Text = dataGridView8.Rows[rowIndex].Cells[3].Value.ToString();

            contact1.Text = dataGridView8.Rows[rowIndex].Cells[4].Value.ToString();
            address1.Text = dataGridView8.Rows[rowIndex].Cells[5].Value.ToString();
       

        }

        private void FormDC_Load(object sender, EventArgs e)
        {
            DataTable dt = s.Select();
            dataGridView8.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            v.id = int.Parse(ID.Text);
            bool success = s.Delete(v);
            if (success == true)
            {

                MessageBox.Show("CATEGORY DELETED SUCCESFULLY");
                clear();
            }
            else
            {
                MessageBox.Show("FAILED TO DELETE CATEGORY");

            }
            DataTable dt = s.Select();
            dataGridView8.DataSource = dt;


        }

        private void search3_TextChanged(object sender, EventArgs e)
        {
            String keywords = search3.Text;
            if (keywords != null)
            {

                DataTable dt = s.Search(keywords);
                dataGridView8.DataSource = dt;
            }
            else
            {
                DataTable dt = s.Select();
                dataGridView8.DataSource = dt;
            }

        }
    }
}

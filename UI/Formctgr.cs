using mikethebiller.BLL;
using mikethebiller.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace mikethebiller.UI
{
    public partial class Formctgr : Form
    {
        public Formctgr()
        {
            InitializeComponent();
        }
        Categorybll u1 = new Categorybll();
        categorydal dal1 = new categorydal();
        userdal udal=new userdal();
        private void button1_Click(object sender, EventArgs e)
        {
            u1.Title = title.Text;
            u1.Description = description.Text;
            u1.added_date = DateTime.Now;
            string loggduser = Formlogin.loggdin;
            userbll u = udal.getid(loggduser);
            
            u1.added_by = u.id;
            bool success = dal1.Insert(u1);
            if (success == true)
            {

                MessageBox.Show("CATEGORY CREATED SUCCESFULLY");
                clear();
            }           
            else
            {
                MessageBox.Show("FAILED ");

            }
        }

        private void Formctgr_Load(object sender, EventArgs e)
        {

            DataTable dt = dal1.Select();
            dataGridView1.DataSource = dt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            cid.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            
            title.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
           description .Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();


        }

        private void cid_TextChanged(object sender, EventArgs e)
        {

        }
        private void clear()
        {
            cid.Text = "";
            title.Text = "";
            description.Text = "";
        }
            private void button2_Click(object sender, EventArgs e)
        {
            u1.id = Convert.ToInt32(cid.Text);
            u1.Title = title.Text;
            u1.Description = description.Text;
            u1.added_date = DateTime.Now;
            u1.added_by = 1;
            bool success = dal1.Update(u1);
            if (success == true)
            {

                MessageBox.Show("TABLE UPDATED SUCCESFULLY");
                clear();
            }
            else
            {
                MessageBox.Show("FAILED TO UPDATE");

            }
            DataTable dt = dal1.Select();
            dataGridView1.DataSource = dt;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            u1.id =     int.Parse(cid.Text);
            bool success = dal1.Delete(u1);
            if (success == true)
            {
                
                MessageBox.Show("USER DELETED SUCCESFULLY");
                clear();
            }
            else
            {
                MessageBox.Show("FAILED TO DELETE USER");

            }
            DataTable dt = dal1.Select();
            dataGridView1.DataSource = dt;

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            String keywords = search2.Text;
            if (keywords != null)
            {

                DataTable dt = dal1.Search(keywords);
                dataGridView1.DataSource = dt;
            }
            else
            {
                DataTable dt = dal1.Select();
                dataGridView1.DataSource = dt;
            }
        }
    }
}

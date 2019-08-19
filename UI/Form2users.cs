using mikethebiller.BLL;
using mikethebiller.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace mikethebiller.UI
{
    public partial class Form2users : Form
    {
        public Form2users()
        {
            InitializeComponent();
        }

     userbll u = new userbll();
        userdal dal = new userdal();      

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2users_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dataGridView1.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            String loggduser = Formlogin.loggdin;
            u.First_name = firstname.Text;
            u.Last_name = lastname.Text;
            u.email = Email.Text;
            u.username = Username.Text;
            u.password = Password.Text;
            u.contact = Contact.Text;
            u.Address = address.Text;
            u.user_type = UserType.Text;
            u.added_date = DateTime.Now;
           
            userbll v = dal.getid(loggduser);

            u.added_by = v.id;
            bool success = dal.Insert(u);
            if(success==true)
            {

                MessageBox.Show("USER CREATED SUCCESFULLY");
                clear();
            }
            else
            {
                MessageBox.Show("FAILED TO ADD NEW USER");

            }
            DataTable dt = dal.Select();
            dataGridView1.DataSource = dt;


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
            Password.PasswordChar = '*';
            Password.MaxLength = 17;
        }
        private void clear()
        {
            uid.Text = "";
            firstname.Text="";
            lastname.Text = ""; 
            Email.Text = "" ;
            Username.Text = "" ;
             Password.Text="";
            Contact.Text="";
            address.Text="";
            UserType.Text="";
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            u.id = Convert.ToInt32(uid.Text);
            u.First_name = firstname.Text;
            u.Last_name = lastname.Text;
            u.email = Email.Text;
            u.username = Username.Text;
            u.password = Password.Text;
            u.contact = Contact.Text;
            u.Address = address.Text;
            u.user_type = UserType.Text;
            u.added_date = DateTime.Now;
            u.added_by = 1;
            bool success = dal.Update(u);
            if (success == true)
            {

                MessageBox.Show("USER UPDATED SUCCESFULLY");
                clear();
            }
            else
            {
                MessageBox.Show("FAILED TO UPDATE USER");

            }
            DataTable dt = dal.Select();
            dataGridView1.DataSource = dt;


        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            uid.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();


            firstname.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            lastname.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            Email.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
           Username.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            Password.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            Contact.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
            address.Text = dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
            UserType.Text = dataGridView1.Rows[rowIndex].Cells[8].Value.ToString();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            u.id = Convert.ToInt32(uid.Text);
            bool success = dal.Delete(u);
            if (success == true)
            {

                MessageBox.Show("USER DELETED SUCCESFULLY");
                clear();
            }
            else
            {
                MessageBox.Show("FAILED TO DELETE USER");

            }
            DataTable dt = dal.Select();
            dataGridView1.DataSource = dt;


        }

        private void search1_TextChanged(object sender, EventArgs e)
        {
            String keywords = search1.Text;
            if (keywords != null)
            {

                DataTable dt = dal.Search(keywords);
                dataGridView1.DataSource = dt;
            }
            else
            {
                DataTable dt = dal.Select();
                dataGridView1.DataSource = dt;
            }

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}

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
    public partial class Formlogin : Form
    {
        public Formlogin()
        {
            InitializeComponent();
        }
        loginbll l = new loginbll();
        logindal dal = new logindal();
        public static String loggdin;
        private void Formlogin_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            l.username = uname.Text.Trim();
            l.password = pwd.Text.Trim();
            l.user_type = utype.Text.Trim();
            bool success = dal.logincheck(l);
            if (success == true)
            {

                MessageBox.Show("USER LOGGED IN SUCCESSFULLY");
                loggdin = l.username;
                switch (l.user_type)
                {
                    case "Admin":
                        {
                            Form1 admin = new Form1();
                            admin.Show();
                            this.Hide();

                        } break;

                    case "User":
                        {
                            FormUserdashboard user = new FormUserdashboard();
                            user.Show();
                            this.Hide();
                        }

                        break;


                
                }

               
            }
            else
            {
                MessageBox.Show("FAILED TO LOGIN");

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

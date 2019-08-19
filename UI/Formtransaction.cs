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
    public partial class Formtransaction : Form
    {
        public Formtransaction()
        {
            InitializeComponent();
        }
        Transactiondal tdal = new Transactiondal();

        private void Formtransaction_Load(object sender, EventArgs e)
        {

            DataTable dt = tdal.displayalltransactions();
            dataGridView1.DataSource = dt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = combotype.Text;
            DataTable dt = tdal.displaytypeoftransaction(type);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataTable dt = tdal.displayalltransactions();
            dataGridView1.DataSource = dt;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int keywords =int.Parse( searchid.Text);
            if (keywords != null)
            {

                DataTable dt = tdal.displaytypeoftransactiondcid(keywords);
                dataGridView1.DataSource = dt;
            }
            else
            {
                DataTable dt = tdal.displayalltransactions();
                dataGridView1.DataSource = dt;
            }
        }
    }
}

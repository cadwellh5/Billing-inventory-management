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
    public partial class Forminventory : Form
    {
        public Forminventory()
        {
            InitializeComponent();
        }
        categorydal cdal = new categorydal();
        productsdal pdal = new productsdal();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Forminventory_Load(object sender, EventArgs e)
        {
            DataTable cdt = cdal.Select();
            combocat.DataSource =cdt;
            combocat.DisplayMember = "Title";
            combocat.ValueMember = "Title";
            DataTable pdt = pdal.Select();
            dataGridView1.DataSource = pdt;
        }

        private void combocat_SelectedIndexChanged(object sender, EventArgs e)
        {

            string category = combocat.Text;
            DataTable dt = pdal.displayproductsofcategory(category);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable cdt = cdal.Select();
            combocat.DataSource = cdt;
            combocat.DisplayMember = "Title";
            combocat.ValueMember = "Title";
            DataTable pdt = pdal.Select();
            dataGridView1.DataSource = pdt;
        }
    }
}

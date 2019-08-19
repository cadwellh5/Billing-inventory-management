using mikethebiller.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mikethebiller
{
    public partial class FormUserdashboard : Form
    {
        public FormUserdashboard()
        {
            InitializeComponent();
        }
        public static string transactiontype;
        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void salesFormsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            transactiontype = "SALES";
            Formpurchasesales w = new Formpurchasesales();
            w.Show();
        }


        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            transactiontype = "PURCHASE";
            Formpurchasesales p = new Formpurchasesales();
            p.Show();
        }

        private void FormUserdashboard_Load(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formlogin l = new Formlogin();
            l.Show();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void inventoryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Forminventory i = new Forminventory();
            i.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            label3.Text = Formlogin.loggdin;
        }
    }
}

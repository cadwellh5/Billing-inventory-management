using mikethebiller.BLL;
using mikethebiller.DAL;
using System;
using System.Transactions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;

namespace mikethebiller.UI
{
    public partial class Formpurchasesales : Form
    {
        public Formpurchasesales()
        {
            InitializeComponent();
        }
        DCdal dcdal = new DCdal();
        productsdal pdal = new productsdal();
        DataTable transactiondt = new DataTable();
        Transactiondal tdal = new Transactiondal();
        Transactiondetaildal tddal = new Transactiondetaildal();

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Formpurchasesales_Load(object sender, EventArgs e)
        {
            String type = FormUserdashboard.transactiontype;
            label1.Text = type;
            transactiondt.Columns.Add("Name");
            transactiondt.Columns.Add("Rate");
            transactiondt.Columns.Add("Qty");
            transactiondt.Columns.Add("Total");
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click_1(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Formpurchasesales_TextChanged(object sender, EventArgs e)
        {

        }

        private void dcsearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = dcsearch.Text;
            if (keyword == "")
            {
                dcname.Text = "";
                dcemail.Text = "";
                dccontact.Text = "";
                dcaddress.Text = "";
            }
            DCbll d = dcdal.Search_dea_cust_transaction(keyword);
            dcname.Text = d.Name;
            dcemail.Text = d.Email;
            dccontact.Text = d.Contact;
            dcaddress.Text = d.Address;

        }
        private void clear()
        {


            psearch.Text = "";

            pname.Text = "";
            pcat.Text = "";
            prate.Text = "";

            pqty.Text = "";






        }
        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String prname = pname.Text;
            Decimal pdrate = Decimal.Parse(prate.Text);
            Decimal pdqty = Decimal.Parse(pqty.Text);
            Decimal Total = pdrate * pdqty;
            Decimal subtotal = Decimal.Parse(sbtotal.Text);
            subtotal = subtotal + Total;
            if (prname == "")
            {
                MessageBox.Show("Select the product and Try again");

            }
            else
            {
                transactiondt.Rows.Add(prname, pdrate, pdqty, Total);
                dgvproducts.DataSource = transactiondt;
                sbtotal.Text = subtotal.ToString();
                clear();
            }

        }

        private void psearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = psearch.Text;
            if (keyword == "")
            {

                pname.Text = "";
                pcat.Text = "0";
                prate.Text = "0";
                pqty.Text = "0";
            }
            productsbll d = pdal.Search_products_transaction(keyword);
            pname.Text = d.Name;
              pcat.Text = d.Qty.ToString();
            prate.Text = d.Rate.ToString();

        }

        private void discount_TextChanged(object sender, EventArgs e)
        {
            String val = discount.Text;
            if (val == "")
            {
                MessageBox.Show("Enter discount if available else press 0");

            }
            else
            {
                decimal subtotal = Decimal.Parse(sbtotal.Text);
                decimal Discount = Decimal.Parse(discount.Text);
                decimal gtotal = ((100 - Discount) / 100) * subtotal;
                grandtotal.Text = gtotal.ToString();
            }
        }



        private void vat_TextChanged(object sender, EventArgs e)
        {
            String value = grandtotal.Text;
            if (value == "")
            {
                MessageBox.Show("Calculate discountand set the grand total first");

            }
            else
            {
                Decimal prevgtotal = Decimal.Parse(grandtotal.Text);
                Decimal Vat = Decimal.Parse(vat.Text);
                Decimal gtotalvat = ((100 + Vat) / 100) * prevgtotal;
                grandtotal.Text = gtotalvat.ToString();

            }
        }

        private void PA_TextChanged(object sender, EventArgs e)
        {
            Decimal gtotal = Decimal.Parse(grandtotal.Text);
            Decimal paidamt = Decimal.Parse(PA.Text);
            Decimal ramt = paidamt - gtotal;
            RA.Text = ramt.ToString();
        }


        private void grandtotal_TextChanged(object sender, EventArgs e)
        {

        }
        userdal udal = new userdal();
        private void button2_Click(object sender, EventArgs e)
        {
            Transactionbll transaction = new Transactionbll();
            transaction.Type = label1.Text;
            string dea_csname = dcname.Text;
            DCbll dc = dcdal.getid(dea_csname);
            transaction.dea_cust_id = dc.id;
            transaction.Grand_total = Math.Round(decimal.Parse(grandtotal.Text), 2);
            transaction.transaction_date = DateTime.Now;
            transaction.tax = decimal.Parse(vat.Text);
            transaction.discount = decimal.Parse(discount.Text);
            string usrname = Formlogin.loggdin;
            userbll u = udal.getid(usrname);
            transaction.added_by = u.id;
            transaction.transactiondetails = transactiondt;

            bool success = false;
            //inserting transaction and transaction details
            using (TransactionScope scope = new TransactionScope())

            {
                int transactionid = -1;
                bool w = tdal.Insert(transaction, out transactionid);

                for (int i = 0; i < transactiondt.Rows.Count; i++)
                {
                    trnsctiondetailbll tddetail = new trnsctiondetailbll();
                    String prdname = transactiondt.Rows[i][0].ToString();
                    productsbll p = pdal.getpid(prdname);
                    tddetail.pid = p.id;

                    tddetail.rate = decimal.Parse(transactiondt.Rows[i][1].ToString());
                    tddetail.qty = decimal.Parse(transactiondt.Rows[i][2].ToString());
                    tddetail.Total = Math.Round(decimal.Parse(transactiondt.Rows[i][3].ToString()), 2);
                    tddetail.dea_cust_id = dc.id;
                    tddetail.added_date = DateTime.Now;
                    tddetail.added_by = u.id;
                    //INC OR DEC QTY
                      string ttype = label1.Text;
                       bool x = false;
                       if (ttype == "PURCHASE")
                       {
                            x = pdal.increaseqty(tddetail.pid, tddetail.qty);
                       }
                       else if(ttype=="SALES")
                       {

                           x = pdal.decreaseqty(tddetail.pid, tddetail.qty);

                       }



                    bool y = tddal.Insert(tddetail);

                    success = w && y && x;
                }
                if (success == true)
                {
                    scope.Complete();
                    DGVPrinter print = new DGVPrinter();
                    print.Title = "\r\n\r\n MIKE'S STORES  PVT LTD \r\n";
                    print.SubTitle = "KOCHI ,KERALA ,phone - +919537583616\r\n\r\n";
                    print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    print.PageNumbers = true;
                    print.PageNumberInHeader = false;
                    print.PorportionalColumns = true;
                    print.HeaderCellAlignment = StringAlignment.Near;
                    print.Footer = "Discount :" + discount.Text + "% \r\n" + "vat :" + vat.Text + "%\r\n" + "GRAND_TOTAL:" + grandtotal.Text + "\r\n" +"Date & time of purchase:"+dateTimePicker1.Value+"\r\n\r" + " THANK YOU";
                    print.FooterSpacing = 40 ;
                    print.PrintDataGridView(dgvproducts);

                    MessageBox.Show("TRANSACTION C0MPLETED SUCCESSFULLY");
                    dgvproducts.DataSource = null;
                    dgvproducts.Rows.Clear();
                    dgvproducts.DataSource = null;
                    dgvproducts.Rows.Clear();
                    dcsearch.Text = "";
                    dcname.Text = "";
                    dcemail.Text = "";
                    dccontact.Text = "";
                    dcaddress.Text = "";
                    clear();
                    sbtotal.Text = "";
                      discount.Text = "0";
                      grandtotal.Text = "0";
                      vat.Text = "0";
                    PA.Text = "0";
                    RA.Text = "0";
                }










                else
                {
                    MessageBox.Show("TRANSACTION FAILED");
                }





            }

        }

        private void pcat_TextChanged(object sender, EventArgs e)
        {

        }
    } }
  


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tema1_csdotnet
{
    public partial class InsertCustomer : Form
    {
        public InsertCustomer()
        {
            InitializeComponent();
        }

        private void button_insert_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new TestContext())
                {
                    var customer = new CUSTOMER { NAME = this.textBox_nume.Text, ADRESA = this.textBox_adresa.Text };
                    db.CUSTOMERs.AddObject(customer);
                    this.textBox_nume.Text = customer.CUSTOMERID.ToString();
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Obiectul nu a putut fi adaugat! "+ex.InnerException);
            }
            Operations op = new Operations();
            op.InsertCustomer(this.textBox_nume.Text, this.textBox_adresa.Text);
           this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new TestContext())
                {
                    CUSTOMER c = db.CUSTOMERs.First(i => i.NAME == this.textBox_nume.Text);
                    c.ADRESA = this.textBox_adresa.Text;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Obiectul nu a putut fi adaugat! " + ex.InnerException);
            }
            this.Close();
        }
    }
}

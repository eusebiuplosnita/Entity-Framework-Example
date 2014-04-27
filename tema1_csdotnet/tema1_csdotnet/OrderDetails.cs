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
    public partial class OrderDetails : Form
    {
        public OrderDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (TestContext db = new TestContext())
                {

                    ORDERDETAIL r = new ORDERDETAIL
                    {
                        ORDERID = Convert.ToInt16(this.textBox1.Text),
                        PRODUS = this.textBox2.Text,
                        VALOARE = Convert.ToDecimal(this.textBox3.Text),
                        SERIAL = Convert.ToInt16(this.textBox4.Text)
                    };

                    db.ORDERDETAILS.AddObject(r);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Obiectul nu a putut fi adaugat! " + ex.InnerException);
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new TestContext())
                {
                    ORDERDETAIL c = db.ORDERDETAILS.First(i => i.ORDERID == Convert.ToInt16(this.textBox2.Text));
                    c.PRODUS = this.textBox1.Text;
                    c.VALOARE = Convert.ToDecimal(this.textBox3.Text);
                    c.SERIAL = Convert.ToInt16(this.textBox4.Text);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Obiectul nu a putut fi updatat! " + ex.InnerException);
            }
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                TestContext db = new TestContext();
                if (this.textBox1.Text != null)
                {
                    ORDERDETAIL c = db.ORDERDETAILS.First(i => i.ORDERID == Convert.ToInt16(this.textBox1.Text));
                    db.ORDERDETAILS.DeleteObject(c);
                }
                if (this.textBox2.Text != null)
                {
                    ORDERDETAIL c = db.ORDERDETAILS.First(i => i.PRODUS == this.textBox2.Text);
                    db.ORDERDETAILS.DeleteObject(c);
                }
                if (this.textBox3.Text != null)
                {
                    ORDERDETAIL c = db.ORDERDETAILS.First(i => i.VALOARE == Convert.ToDecimal(this.textBox3.Text));
                    db.ORDERDETAILS.DeleteObject(c);
                }
                if (this.textBox4.Text != null)
                {
                    ORDERDETAIL c = db.ORDERDETAILS.First(i => i.SERIAL == Convert.ToInt16(this.textBox4.Text));
                    db.ORDERDETAILS.DeleteObject(c);
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Obiectul nu a putut fi sters! " + ex.InnerException);
            }
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}

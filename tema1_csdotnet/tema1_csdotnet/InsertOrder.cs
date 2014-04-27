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
    public partial class InsertOrder : Form
    {
        public InsertOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (TestContext db = new TestContext())
                {

                    ORDER r = new ORDER
                    {
                        DATA = Convert.ToDateTime(this.textBox1.Text),
                        CUSTOMERID = Convert.ToInt16(this.textBox2.Text),
                        VALOARE = Convert.ToDecimal(this.textBox3.Text)
                    };

                    db.ORDERs.AddObject(r);
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
            this.Close();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new TestContext())
                {
                    ORDER c = db.ORDERs.First(i => i.CUSTOMERID == Convert.ToInt16(this.textBox2.Text));
                    c.DATA = Convert.ToDateTime(this.textBox1.Text);
                    c.VALOARE = Convert.ToDecimal(this.textBox3.Text);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Obiectul nu a putut fi updatat! " + ex.InnerException);
            }
            this.Close();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                TestContext db = new TestContext();
                if (this.textBox1.Text != null )
                {
                    ORDER c = db.ORDERs.First(i => i.DATA == Convert.ToDateTime(this.textBox1.Text));
                    db.ORDERs.DeleteObject(c);
                }
                if (this.textBox2.Text != null)
                {
                    ORDER c = db.ORDERs.First(i => i.CUSTOMERID == Convert.ToInt16(this.textBox2.Text));
                    db.ORDERs.DeleteObject(c);
                }
                if (this.textBox3.Text != null)
                {
                    ORDER c = db.ORDERs.First(i => i.VALOARE == Convert.ToDecimal(this.textBox3.Text));
                    db.ORDERs.DeleteObject(c);
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Obiectul nu a putut fi sters! " + ex.InnerException);
            }
            this.Close();
        }
    }
}

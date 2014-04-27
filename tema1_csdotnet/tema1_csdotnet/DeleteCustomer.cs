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
    public partial class DeleteCustomer : Form
    {
        public DeleteCustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TestContext db = new TestContext();
                if (this.textBox1.Text != null)
                {
                    CUSTOMER c = db.CUSTOMERs.First(i => i.NAME == this.textBox1.Text);
                    db.CUSTOMERs.DeleteObject(c);
                    db.SaveChanges();
                }

                if (this.textBox2.Text != null)
                {
                    CUSTOMER c = db.CUSTOMERs.First(i => i.ADRESA == this.textBox2.Text);
                    db.CUSTOMERs.DeleteObject(c);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Obiectul nu a putut fi sters! " + ex.InnerException);
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;

namespace tema1_csdotnet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button_insert_customer_Click(object sender, EventArgs e)
        {
            InsertCustomer ic = new InsertCustomer();
            ic.Show();
        }

        private void button_update_customer_Click(object sender, EventArgs e)
        {
            InsertCustomer uc = new InsertCustomer();
            uc.Show();
        }

        private void button_delete_customer_Click(object sender, EventArgs e)
        {
            DeleteCustomer dc = new DeleteCustomer();
            dc.Show();
        }

        private void button_insert_order_Click(object sender, EventArgs e)
        {
            InsertOrder io = new InsertOrder();
            io.Show();
        }

        private void button_update_order_Click(object sender, EventArgs e)
        {
            InsertOrder io = new InsertOrder();
            io.Show();
        }

        private void button_delete_order_Click(object sender, EventArgs e)
        {
            InsertOrder io = new InsertOrder();
            io.Show();
        }

        private void button_insert_orderdet_Click(object sender, EventArgs e)
        {
            OrderDetails od = new OrderDetails();
            od.Show();
        }

        private void button_update_orderdet_Click(object sender, EventArgs e)
        {
            OrderDetails od = new OrderDetails();
            od.Show();
        }

        private void button_delete_orderdet_Click(object sender, EventArgs e)
        {
            OrderDetails od = new OrderDetails();
            od.Show();
        }

        private void button_execute_Click(object sender, EventArgs e)
        {
            using (var db = new TestContext())
            {
                if (radioButton1.Checked)
                {
                    string result = string.Empty;
                    foreach (string s in db.ExecuteStoreQuery<string>("Select Name from CUSTOMER, (select CUSTOMERID,Count(CUSTOMERID) as val1 from ORDER) V1 where V1.CUSTOMERID = CUSTOMERID AND V1.val1 = @pN", new SqlParameter { ParameterName = "pN", Value = Convert.ToInt32(this.textBox_n.Text) }))
                    {
                        result += s+"\n";
                    }
                    this.richTextBox2.Text = result;
                }
                else
                {
                    string result = string.Empty;
                    var query = from b in db.ORDERDETAILS
                                where b.PRODUS == this.textBox2.Text
                                select b;
                    foreach(var s in query)
                    {
                        result += s.ORDERID + "  " + s.PRODUS + "  " + s.SERIAL + "\n";
                    }
                    this.richTextBox2.Text = result;
                }
            }
        }


    }
}

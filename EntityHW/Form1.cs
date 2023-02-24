using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityHW.Models;

namespace EntityHW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new AddForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new ModifyForm();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var form = new ViewForm();
            form.ShowDialog();
        }
        public static SqlConnection OpenConnection()
        {
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataAdapter da;
            SqlDataReader dr;

            var DataSource = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()) + "\\Product.mdf;Integrated Security=True";
            cn = new SqlConnection(@DataSource);
            return cn;
        }
    }
}

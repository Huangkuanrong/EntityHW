using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityHW.Models;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;

namespace EntityHW
{
    public partial class ViewForm : Form
    {
        public ViewForm()
        {
            InitializeComponent();
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataAdapter da;
            SqlDataReader dr;

            var DataSource = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()) + "\\Product.mdf;Integrated Security=True";
            cn = new SqlConnection(@DataSource);
            cn.Open();

            cmd = new SqlCommand("Select * from ProductTable", cn);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            cn.Close();
        }


    }
}

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
using EntityHW.Controllers;
using EntityHW.Models;

namespace EntityHW
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
            BindData.toDataGridView(this.dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductTable data = new ProductTable()
            {
                Model = textBox1.Text.Trim(),
                Name = textBox2.Text.Trim(),
                Quantity = textBox3.Text.Trim(),
                Price = textBox4.Text.Trim(),
                Category = textBox5.Text.Trim(),
            };
            try
            {
                SaveData(data);
                MessageBox.Show("Add file compelete");
                ClearTextBoxes();
                BindData.toDataGridView(this.dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ClearTextBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        public static void SaveData(ProductTable data)
        {
            var cn = Form1.OpenConnection();
            cn.Open();
            var query = "INSERT INTO ProductTable " +
                        "(Model, Name, Quantity, Price, Category) " +
                        "VALUES (@Model, @Name, @Quantity, @Price, @Category)";

            var cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@Model", data.Model);
            cmd.Parameters.AddWithValue("@Name", data.Name);
            cmd.Parameters.AddWithValue("@Quantity", data.Quantity);
            cmd.Parameters.AddWithValue("@Price", data.Price);
            cmd.Parameters.AddWithValue("@Category", data.Category);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}

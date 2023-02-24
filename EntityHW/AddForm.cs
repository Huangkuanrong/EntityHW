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

        private void button2_Click(object sender, EventArgs e)
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
                SearchData(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        public void SearchData(ProductTable data)
        {
            var cn = Form1.OpenConnection();
            cn.Open();
            var cmd = new SqlCommand();

            if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "" || textBox4.Text != "" || textBox5.Text != "")
            {
                if (textBox1.Text != "")
                {
                    cmd = new SqlCommand("Select * from ProductTable where Model = @Model", cn);
                    cmd.Parameters.AddWithValue("@Model", data.Model);
                }

                if (textBox2.Text != "")
                {
                    cmd = new SqlCommand("Select * from ProductTable where Name = @Name", cn);
                    cmd.Parameters.AddWithValue("@Name", data.Name);
                }

                if (textBox3.Text != "")
                {
                    cmd = new SqlCommand("Select * from ProductTable where Quantity = @Quantity", cn);
                    cmd.Parameters.AddWithValue("@Quantity", data.Quantity);
                }

                if (textBox4.Text != "")
                {
                    cmd = new SqlCommand("Select * from ProductTable where Price = @Price", cn);
                    cmd.Parameters.AddWithValue("@Price", data.Price);
                }

                if (textBox5.Text != "")
                {
                    cmd = new SqlCommand("Select * from ProductTable where Category = @Category", cn);
                    cmd.Parameters.AddWithValue("@Category", data.Category);
                }
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                cn.Close();
                MessageBox.Show("Found data complete");
            }
            else
            {
                BindData.toDataGridView(this.dataGridView1);
            }
        }
    }
}

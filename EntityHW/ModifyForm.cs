using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using EntityHW.Controllers;
using EntityHW.Models;

namespace EntityHW
{
    public partial class ModifyForm : Form
    {
        public ModifyForm()
        {
            InitializeComponent();
            BindData.toDataGridView(this.dataGridView1);
            ClearTextBoxes();
            RefreshComboBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ProductTable data = new ProductTable()
                {
                    Model = comboBox1.Text.Trim(),
                    Name = textBox2.Text.Trim(),
                    Quantity = textBox3.Text.Trim(),
                    Price = textBox4.Text.Trim(),
                    Category = textBox5.Text.Trim(),
                };
                UpdateData(data);
                MessageBox.Show("Update file compelete");
                ClearTextBoxes();
                BindData.toDataGridView(this.dataGridView1);
                comboBox1_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void RefreshComboBox()
        {
            var cn = Form1.OpenConnection();
            cn.Open();

            var cmd = new SqlCommand("Select * from ProductTable", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<string> list = new List<string>();
            while (reader.Read())
            {
                list.Add((string)reader[0]);
            }
            reader.Close();
            cn.Close();
            
            comboBox1.DataSource = list;
            comboBox1.Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = QueryDataByModel();
            ClearTextBoxes();
            textBox2.Text = list[1];
            textBox3.Text = list[2];
            textBox4.Text = list[3];
            textBox5.Text = list[4];
        }

        private void ClearTextBoxes()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void ModifyForm_Load(object sender, EventArgs e)
        {
        }

        public List<string> QueryDataByModel()
        {
            var cn = Form1.OpenConnection();
            cn.Open();

            var model = comboBox1.SelectedItem.ToString();
            var cmd = new SqlCommand("Select * from ProductTable where Model = @Model", cn);
            cmd.Parameters.AddWithValue("@Model", model);

            var reader = cmd.ExecuteReader();
            List<string> list = new List<string>();

            while (reader.Read())
            {
                list.Add((string)reader[0]);
                list.Add((string)reader[1]);
                list.Add((string)reader[2]);
                list.Add((string)reader[3]);
                list.Add((string)reader[4]);
            }

            reader.Close();
            cn.Close();
            return list;
        }

        public static void UpdateData(ProductTable data)
        {
            var cn = Form1.OpenConnection();
            cn.Open();
            var query = "UPDATE ProductTable " +
                        "Set Model = @Model, Name = @Name, Quantity = @Quantity, Price = @Price, Category = @Category " +
                        "Where Model = @Model";

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
            try
            {
                DeleteData();
                MessageBox.Show("Delete file compelete");
                ClearTextBoxes();
                RefreshComboBox();
                BindData.toDataGridView(this.dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void DeleteData()
        {
            var cn = Form1.OpenConnection();
            cn.Open();
            var query = "Delete from ProductTable where Model = @Model";
            var cmd = new SqlCommand(query, cn);
            var model = comboBox1.SelectedItem.ToString();
            cmd.Parameters.AddWithValue("@Model", model);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}

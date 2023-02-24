using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityHW.Models;

namespace EntityHW
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
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
                ProductModel products = new ProductModel();
                products.ProductTable.Add(data);
                products.SaveChanges();
                MessageBox.Show("Add file compelete");
                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
    }
}

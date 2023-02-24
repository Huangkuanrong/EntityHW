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
    public partial class ModifyForm : Form
    {
        public ModifyForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void RefreshComboBox()
        {
            var products = new ProductModel();
            var list = products.ProductTable.ToList();
            var myProductModels = new List<string>();
            foreach (var product in list)
            {
                myProductModels.Add(product.Model);
            }

            comboBox1.DataSource = null;
            comboBox1.DataSource = myProductModels;
            comboBox1.Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ModifyForm_Load(object sender, EventArgs e)
        {
        }
    }
}

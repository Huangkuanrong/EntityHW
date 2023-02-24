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
using System.IO;
using EntityHW.Controllers;
using static EntityHW.Controllers.BindData;

namespace EntityHW
{
    public partial class ViewForm : Form
    {
        public ViewForm()
        {
            InitializeComponent();
            BindData.toDataGridView(this.dataGridView1);
        }
    }
}

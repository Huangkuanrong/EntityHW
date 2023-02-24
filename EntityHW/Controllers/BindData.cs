using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace EntityHW.Controllers
{
    internal class BindData
    {
        public static void toDataGridView(DataGridView dtGridView)
        {
            var cn = Form1.OpenConnection();
            cn.Open();
            var cmd = new SqlCommand("Select * from ProductTable", cn);
            var da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtGridView.DataSource = dt;
            cn.Close();
        }
    }
}

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

namespace UAS_OOP_1204029
{
    public partial class ViewDaftarUlang : Form
    {
        public ViewDaftarUlang()
        {
            InitializeComponent();
        }
        private SqlConnection conn;
        private SqlCommand cmd1;
        private SqlDataAdapter DataAdapter;
        private DataSet DataSet;

        private void ViewDaftarUlang_Load(object sender, EventArgs e)
        {
            string constr = @"Data Source=DESKTOP-84EMVRI\FADILSQL;Initial Catalog=UAS;Integrated Security=True";
            conn = new SqlConnection(constr);
            conn.Open();
            cmd1 = new SqlCommand();
            cmd1.Connection = conn;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from tr_daftar_ulang";
            DataSet = new DataSet();
            DataAdapter = new SqlDataAdapter(cmd1);
            DataAdapter.Fill(DataSet, "tr_daftar_ulang");
            dgDU.DataSource = DataSet;
            dgDU.DataMember = "tr_daftar_ulang";
            dgDU.Refresh();
            conn.Close();
        }
    }
}

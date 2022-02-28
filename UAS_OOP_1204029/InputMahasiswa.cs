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
    public partial class InputMahasiswa : Form
    {
        string prodi;
        public InputMahasiswa()
        {
            InitializeComponent();

            SqlConnection myConnection = new SqlConnection(@"Data Source=DESKTOP-84EMVRI\FADILSQL;Initial Catalog=UAS;Integrated Security=True");

            myConnection.Open();

            SqlCommand myCommand = new SqlCommand("SELECT * FROM ms_prodi", myConnection);
            SqlDataReader reader;

            reader = myCommand.ExecuteReader();
            DataTable myDataTable = new DataTable();
            myDataTable.Columns.Add("kode_prodi", typeof(string));
            myDataTable.Columns.Add("singkatan", typeof(string));
            myDataTable.Load(reader);

            cbProdi.ValueMember = "kode_prodi";
            cbProdi.DisplayMember = "singkatan";
            cbProdi.DataSource = myDataTable;

            myConnection.Close();
        }
        private void clear()
        {

            txtNpm.Text = "";
            txtNamaMhs.Text = "";
            cbProdi.SelectedIndex = 0;

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (txtNpm.Text != "")
            {
                if (txtNamaMhs.Text != "")
                {
                    if (cbProdi.Text != "")
                    {
                        string npm = txtNpm.Text;
                        string nama = txtNamaMhs.Text;
                        string prodi = this.prodi;

                        SqlConnection myConnection = new SqlConnection(@"Data Source=DESKTOP-84EMVRI\FADILSQL;Initial Catalog=UAS;Integrated Security=True");
                        string sql = "INSERT INTO ms_mhs ([npm],[nama_mhs]," + "[kode_prodi]) VALUES (@npm,@namaMhs,@kodeProdi)";

                        using (SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-84EMVRI\FADILSQL;Initial Catalog=UAS;Integrated Security=True"))
                        {
                            try
                            {
                                Connection.Open();

                                using (SqlCommand command = new SqlCommand(sql, Connection))
                                {
                                    command.Parameters.Add("@npm", SqlDbType.VarChar).Value = npm;
                                    command.Parameters.Add("@namaMhs", SqlDbType.VarChar).Value = nama;
                                    command.Parameters.Add("@kodeProdi", SqlDbType.VarChar).Value = prodi;

                                    int rowsAdded = command.ExecuteNonQuery();
                                    if (rowsAdded > 0)
                                        MessageBox.Show("Data berhasil di simpan");
                                    else
                                        MessageBox.Show("Data tidak tersimpan");

                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("ERROR:" + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nama harus diisi !", "Infromasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Nama harus diisi !", "Infromasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            else
            {
                MessageBox.Show("NPM harus diisi !", "Infromasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void txtNpm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void txtNamaMhs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbProdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.prodi = cbProdi.SelectedValue.ToString();
        }

        private void InputMahasiswa_Load(object sender, EventArgs e)
        {

        }
    }
}

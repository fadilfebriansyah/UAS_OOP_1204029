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
    public partial class UpdateMahasiswa : Form
    {
        public UpdateMahasiswa()
        {
            InitializeComponent();
        }
        private DataSet dsMhs;
        public DataSet CreateMhsDataSet()
        {
            DataSet myDataSet = new DataSet();

            try
            {
                //connection string digunakan untuk koneksi ke basisdata P_1204049
                SqlConnection myConnection = new SqlConnection(@"Data Source=DESKTOP-84EMVRI\FADILSQL;Initial Catalog=UAS;Integrated Security=True");

                //membuat objek dengan nama myCommand, inisialisasi dari class sqlCommand
                SqlCommand myCommand = new SqlCommand();

                //menetapkan koneksi basisdata yang digunakan yaitu object myConnection
                myCommand.Connection = myConnection;

                //mengatur perintah SQL yang digunkan untuk object Command
                myCommand.CommandText = "SELECT * FROM ms_mhs";
                myCommand.CommandType = CommandType.Text;

                //buatlah data adapter dan tentukan object command
                //tambahkan table mapping untuk prodi
                SqlDataAdapter myDataAdapter = new SqlDataAdapter();
                myDataAdapter.SelectCommand = myCommand;
                myDataAdapter.TableMappings.Add("Table", "ms_mhs");

                //gunakan method fill dari data adapter untuk mengisi dataset
                myDataAdapter.Fill(myDataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return myDataSet;
        }
        private void RefreshDataSet()
        {
            //mengatur nilai DataSet dsProdi
            //nilai didapat daripengambilan method CreateProdiDataSet
            dsMhs = CreateMhsDataSet();

            //bind dataset ke dalam data grid dgProdi
            dgm.DataSource = dsMhs.Tables["ms_mhs"];
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            //connection string digunakan untuk koneksi ke basisdata P_1204049
            SqlConnection myConnection = new SqlConnection(@"Data Source=DESKTOP-84EMVRI\FADILSQL;Initial Catalog=UAS;Integrated Security=True");
            //buka connection
            myConnection.Open();

            //membuat dataadapter dan commandbuilder
            SqlDataAdapter myAdapter = new SqlDataAdapter("select * from ms_mhs", myConnection);
            SqlCommandBuilder myCmdBuilder = new SqlCommandBuilder(myAdapter);

            //menggunakan commandbuilder untuk build insertcommand, updatecommand, dan
            //deletecommand required by dataadapter
            myAdapter.InsertCommand = myCmdBuilder.GetInsertCommand();
            myAdapter.UpdateCommand = myCmdBuilder.GetUpdateCommand();
            myAdapter.DeleteCommand = myCmdBuilder.GetDeleteCommand();

            //perhatikan juga mengenai transaksi.. ini sangat penting!
            //Pelajari..!
            SqlTransaction myTransaction;
            myTransaction = myConnection.BeginTransaction();
            myAdapter.DeleteCommand.Transaction = myTransaction;
            myAdapter.UpdateCommand.Transaction = myTransaction;
            myAdapter.InsertCommand.Transaction = myTransaction;

            //coba untuk update, jika sukses commit
            //jika tidak roll back
            try
            {
                //panggil method update dari DataAdapter
                //dan menyimpan jumlah perubahan baris datanya ke variable rowsUpdate
                int rowsUpdated = myAdapter.Update(dsMhs, "ms_mhs");

                //method commit, bagian penting dari transaksi
                //jika ada kegagalan dalam satu proses transaksi, maka seluruh transaksi dibatalkan
                myTransaction.Commit();

                //tampilkan pesan jumlah baris data yang diupdate ke layar
                MessageBox.Show(rowsUpdated.ToString() + "baris diperbarui", "Informasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                //panggil method RefreshDataSet untuk menyegarkan datagris
                RefreshDataSet();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to update: " + ex.Message);
                //jika terjadi kegagalan dalam transaksi, batalkan semua (rollback)
                myTransaction.Rollback();
            }

            //coba hilangkan coment dari baris berikut, untuk mengetahui command yang dibuat 
            //oleh sqlCommandBuilder
            MessageBox.Show(myAdapter.InsertCommand.CommandText);
            MessageBox.Show(myAdapter.UpdateCommand.CommandText);
        }
    }
    }


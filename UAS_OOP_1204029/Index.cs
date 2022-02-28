using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UAS_OOP_1204029
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        private void prodiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputProgramStudi Tampil = new InputProgramStudi();            
            Tampil.Show();
        }

        private void mahasiswaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputMahasiswa Tampil = new InputMahasiswa();          
            Tampil.Show();
        }

        private void ViewmahasiswaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ViewMahasiswa Tampil = new ViewMahasiswa();
            Tampil.Show();
        }

        private void ViewprodiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ViewProgramStudi Tampil = new ViewProgramStudi();
            Tampil.Show();
        }

        private void ViewdaftarUlangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewDaftarUlang Tampil = new ViewDaftarUlang();
            Tampil.Show();
        }

        private void UpdatemahasiswaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            UpdateMahasiswa Tampil = new UpdateMahasiswa();
            Tampil.Show();
        }

        private void UpdateprodiToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            UpdateProgramStudi Tampil = new UpdateProgramStudi();
            Tampil.Show();
        }

        private void UpdatedaftarUlangToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            UpdateDaftarUlang Tampil = new UpdateDaftarUlang();
            Tampil.Show();
        }

        private void TransaksidaftarUlangToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InputDaftarUlang Tampil = new InputDaftarUlang();
            Tampil.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkademikApp
{
    public partial class FrmEntryMahasiswa : Form
    {
        // deklarasi tipe data untuk event OnCreate dan OnUpdate
        public delegate void CreateUpdateEventHandler(Mahasiswa mhs);
        // deklarasi event ketika terjadi proses input data baru
        public event CreateUpdateEventHandler OnCreate;
        // deklarasi event ketika terjadi proses update data
        public event CreateUpdateEventHandler OnUpdate;
        // deklarasi variabel untuk menyimpan status entry data (input baru atau update)
        private bool isNewData = true;
        // deklarasi variabel/objek mhs untuk meyimpan data mahasiswa
        private Mahasiswa mhs;
        // Constructor default
        public FrmEntryMahasiswa()
        {
            InitializeComponent();
        }

        public FrmEntryMahasiswa(string title)
            : this()
        {
            this.Text = title;
        }

        public FrmEntryMahasiswa(string title, Mahasiswa obj)
            : this()
        {
            this.Text = title;

            isNewData = false;
            mhs = obj;

            txtNpm.Text = mhs.Npm;
            txtNama.Text = mhs.Nama;
            txtAngkatan.Text = mhs.Angkatan;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // jika data baru, inisialisasi objek mahasiswa
            if (isNewData) mhs = new Mahasiswa();
            // set nilai property objek mahasiswa yg diambil dari TextBox
            mhs.Npm = txtNpm.Text;
            mhs.Nama = txtNama.Text;
            mhs.Angkatan = txtAngkatan.Text;
            if (isNewData) // data baru
            {
                OnCreate(mhs); // panggil event OnCreate

                // reset form input, utk persiapan input data berikutnya
                txtNpm.Clear();
                txtNama.Clear();
                txtAngkatan.Clear();

                txtNpm.Focus();
            }
            else // update
            {
                OnUpdate(mhs); // panggil event OnUpdate
                this.Close();
            }
        }

        private void btnSelesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

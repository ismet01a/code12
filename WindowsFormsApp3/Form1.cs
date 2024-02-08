using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace WindowsFormsApp3
{
        public partial class Form1 : Form
        {
            OleDbConnection connection = new OleDbConnection();
            public Form1()
            {
                InitializeComponent();
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\borc_veritabani.accdb;Persist Security Info=False;";
            }

            private void Form1_Load(object sender, EventArgs e)
            {
                VerileriGetir();
            }

            private void VerileriGetir()
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from borclar";
                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgw.DataSource = dt;
                connection.Close();
            }

            private void btn_ekle_Click(object sender, EventArgs e)
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "insert into borclar (Ad, Borc) values('" + txt_ad.Text + "', '" + txt_borc.Text + "')";
                command.ExecuteNonQuery();
                connection.Close();
                VerileriGetir();
            }

            private void btn_sil_Click(object sender, EventArgs e)
            {
                if (dgw.SelectedRows.Count > 0)
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "delete from borclar where ID=" + dgw.SelectedRows[0].Cells["ID"].Value.ToString() + "";
                    command.ExecuteNonQuery();
                    connection.Close();
                    VerileriGetir();
                }
                else
                {
                    MessageBox.Show("Lütfen bir satır seçin.");
                }
            }

            private void btn_guncelle_Click(object sender, EventArgs e)
            {
                if (dgw.SelectedRows.Count > 0)
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "update borclar set Ad='" + txt_ad.Text + "', Borc='" + txt_borc.Text + "' where ID=" + dgw.SelectedRows[0].Cells["ID"].Value.ToString() + "";
                    command.ExecuteNonQuery();
                    connection.Close();
                    VerileriGetir();
                }
                else
                {
                    MessageBox.Show("Lütfen bir satır seçin.");
                }
            }

            private void btn_kaydet_Click(object sender, EventArgs e)
            {
                // Değişiklikleri veritabanına kaydetmek için buraya gerekli kodu ekleyebilirsiniz.
            }
        }
    }


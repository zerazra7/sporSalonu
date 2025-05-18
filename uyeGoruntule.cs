using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace yazilim_proje2
{
    public partial class uyeGoruntule : BaseForm
    {
        private readonly SqlConnection baglanti = new SqlConnection(
    ConfigurationManager.ConnectionStrings["SporSalonu"].ConnectionString);


        public uyeGoruntule()
        {
            InitializeComponent();
        }

        private void uyeGoruntule_Load(object sender, EventArgs e)
        {
            UyeListesiniYukle();
        }

        private void UyeListesiniYukle(string filtre = "")
        {
            List<Uye> uyeler = new List<Uye>();

            try
            {
                baglanti.Open();
                string query = "SELECT * FROM uyeTbl";

                if (!string.IsNullOrWhiteSpace(filtre))
                {
                    query += " WHERE UYEisim LIKE @filtre";
                }

                SqlCommand cmd = new SqlCommand(query, baglanti);
                if (!string.IsNullOrWhiteSpace(filtre))
                {
                    cmd.Parameters.AddWithValue("@filtre", "%" + filtre + "%");
                }

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Uye uye = new Uye
                    {
                        Isim = reader["UYEisim"].ToString(),
                        Telefon = reader["UYEtel"].ToString(),
                        Cinsiyet = reader["UYEcinsiyet"].ToString(),
                        Tip = reader["UYEtip"].ToString(),
                        Yas = Convert.ToInt32(reader["UYEyas"]),
                        Odeme = Convert.ToInt32(reader["UYEodeme"])
                    };

                    uyeler.Add(uye);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri alınırken hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }

            dataGridView1.DataSource = uyeler;
        }

        private void buttonAra_Click(object sender, EventArgs e)
        {
            string aranan = txtAra.Text.Trim();
            UyeListesiniYukle(aranan);
        }

        private void buttonYenile_Click(object sender, EventArgs e)
        {
            UyeListesiniYukle(); // boş filtre ile tüm üyeleri yükler
        }

        private void buttonGeri_Click(object sender, EventArgs e)
        {
            new anaSayfa().Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

    }
}

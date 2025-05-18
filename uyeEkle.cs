using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace yazilim_proje2
{
    public partial class uyeEkle : BaseForm
    {
        public uyeEkle()
        {
            InitializeComponent();
        }

        private readonly SqlConnection baglanti = new SqlConnection(
            @"Data Source=(LocalDB)\MSSQLLocalDB;
              AttachDbFilename=C:\Users\Asus\Documents\sporDB.mdf;
              Integrated Security=True;Connect Timeout=30");

        private void uyeEkle_Load(object sender, EventArgs e)
        {
            // Cinsiyet seçenekleri
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new[] { "Erkek", "Kadın" });
            comboBox1.SelectedIndex = 0;

            // Üye tipi seçenekleri
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(new[] { "Standart", "Premium" });
            comboBox2.SelectedIndex = 0;

            numericUpDown1.ValueChanged += (s, e) => UpdateAylikTutar();
            comboBox2.SelectedIndexChanged += (s, e) => UpdateAylikTutar();
            // İlk gösterim için
            UpdateAylikTutar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Modeli oluştur, bütün validasyon burada
                var uye = new Uye
                {
                    Isim = adsydtxt.Text,
                    Cinsiyet = comboBox1.SelectedItem.ToString(),
                    Telefon = teltxt.Text,                   // burada validasyon patlarsa catch'e düşer
                    Yas = int.Parse(yastxt.Text),
                    Odeme = int.Parse(textBoxAylikTutar.Text),
                    Tip = comboBox2.SelectedItem.ToString()
                };

                // 2) DB kaydı
                baglanti.Open();
                var sql = @"
            INSERT INTO uyeTbl
              (UYEisim, UYEtel, UYEcinsiyet, UYEyas, UYEodeme, UYEtip)
            VALUES
              (@isim,@tel,@cins,@yas,@odem,@tip)";
                using (var cmd = new SqlCommand(sql, baglanti))
                {
                    cmd.Parameters.AddWithValue("@isim", uye.Isim);
                    cmd.Parameters.AddWithValue("@tel", uye.Telefon);
                    cmd.Parameters.AddWithValue("@cins", uye.Cinsiyet);
                    cmd.Parameters.AddWithValue("@yas", uye.Yas);
                    cmd.Parameters.AddWithValue("@odem", uye.Odeme);
                    cmd.Parameters.AddWithValue("@tip", uye.Tip);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Üye başarıyla eklendi:\n\n" + uye.BilgiVer(),
                                "Onay", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                // Hangi validasyon hatası varsa oradaki mesaj gösterilir
                MessageBox.Show(ex.Message, "Geçersiz Girdi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmedik hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
                ClearInputs();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            adsydtxt.Clear();
            teltxt.Clear();
            yastxt.Clear();
            textBoxAylikTutar.Clear();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new anaSayfa().Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new login().Show();
            this.Hide();
        }

        private void UpdateAylikTutar()
        {
            // üüye tipi bazlı aylık ücret
            decimal aylik = comboBox2.SelectedItem.ToString() == "Premium"
                            ? 4000m
                            : 1200m;
          
            int aySayisi = (int)numericUpDown1.Value;

            
            textBoxAylikTutar.Text = (aylik * aySayisi).ToString("0.##");
        }

        private void yastxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void teltxt_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;
using System.Configuration;

namespace yazilim_proje2
{
    public partial class guncelle : BaseForm
    {
        private readonly SqlConnection baglanti = new SqlConnection(
    ConfigurationManager.ConnectionStrings["SporSalonu"].ConnectionString);


        public guncelle()
        {
            InitializeComponent();
        }

        private void guncelle_Load(object sender, EventArgs e)
        {
            LoadUyeler();

            // Cinsiyet combobox’ı 
            comboBoxCinsiyet.Items.Clear();
            comboBoxCinsiyet.Items.AddRange(new[] { "Erkek", "Kadın" });
            comboBoxCinsiyet.SelectedIndex = 0;

            // Üye tipi combobox’ı
            comboBoxTip.Items.Clear();
            comboBoxTip.Items.Add("Standart");
            comboBoxTip.Items.Add("Premium");
            comboBoxTip.SelectedIndex = 0;
        }

        private void LoadUyeler()
        {
            var dt = new DataTable();
            using (var da = new SqlDataAdapter("SELECT * FROM uyeTbl", baglanti))
            {
                da.Fill(dt);
            }
            dataGridView1.DataSource = dt;
        }

        private int key = 0;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridView1.Rows.Count) return;

            var row = dataGridView1.Rows[e.RowIndex];
            key = Convert.ToInt32(row.Cells["UYEid"].Value);

            txtIsim.Text = row.Cells["UYEisim"].Value.ToString();
            txtTel.Text = row.Cells["UYEtel"].Value.ToString();
            comboBoxCinsiyet.SelectedItem = row.Cells["UYEcinsiyet"].Value.ToString();
            txtYas.Text = row.Cells["UYEyas"].Value.ToString();
            txtOdeme.Text = row.Cells["UYEodeme"].Value.ToString();
            comboBoxTip.SelectedItem = row.Cells["UYEtip"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> hatalar = new List<string>();
            
            int yas = 0;
            int odeme = 0;

            if (key == 0)
            {
                MessageBox.Show("Lütfen güncellenecek üyeyi seçiniz.");
                return;
            }
            int uyeId = key;

            // İsim kontrolü
            if (string.IsNullOrWhiteSpace(txtIsim.Text) ||
                !Regex.IsMatch(txtIsim.Text, @"^[a-zA-ZğüşöçıİĞÜŞÖÇ\s]+$"))
                hatalar.Add("Geçerli bir isim giriniz (sadece harf).");

            // Telefon kontrolü
            // Telefon kontrolü
            var rawTel = txtTel.Text;
            // 1) Sadece rakamları al
            var digits = new string(rawTel.Where(char.IsDigit).ToArray());

            // 2) Eğer 0 ile başlamışsa ve 11 haneliyse baştaki sıfırı at
            if (digits.Length == 11 && digits.StartsWith("0"))
                digits = digits.Substring(1);

            // 3) Şimdi mutlaka 10 hane olmalı
            if (digits.Length != 10)
                hatalar.Add("Telefon numarası tam olarak 10 haneli olmalıdır.");

            // Yaş kontrolü
            if (string.IsNullOrWhiteSpace(txtYas.Text) || !int.TryParse(txtYas.Text, out yas) || yas < 18 || yas > 110)
                hatalar.Add("Geçerli bir yaş giriniz (18–110 arası).");

            // Ödeme kontrolü
            if (string.IsNullOrWhiteSpace(txtOdeme.Text) || !int.TryParse(txtOdeme.Text, out odeme) || odeme < 0)
                hatalar.Add("Geçerli bir ödeme tutarı giriniz.");

            // Cinsiyet kontrolü
            if (comboBoxCinsiyet.SelectedIndex == -1)
                hatalar.Add("Cinsiyet seçiniz.");

            // Üye tipi kontrolü
            if (comboBoxTip.SelectedIndex == -1)
                hatalar.Add("Üye tipi seçiniz.");

            // Hata varsa göster
            if (hatalar.Count > 0)
            {
                MessageBox.Show(string.Join("\n", hatalar), "Hatalar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hata yoksa güncelleme işlemi
            try
            {
                Uye uye = new Uye
                {
                    Isim = txtIsim.Text,
                    Telefon = digits,
                    Yas = yas,
                    Odeme = odeme,
                    Cinsiyet = comboBoxCinsiyet.SelectedItem.ToString(),
                    Tip = comboBoxTip.SelectedItem.ToString()
                };

                baglanti.Open();
                string query = @"UPDATE uyeTbl 
                         SET UYEisim=@isim, UYEtel=@tel, UYEcinsiyet=@cinsiyet, 
                             UYEyas=@yas, UYEodeme=@odeme, UYEtip=@tip 
                         WHERE UYEid=@id";
                SqlCommand cmd = new SqlCommand(query, baglanti);
                cmd.Parameters.AddWithValue("@id", uyeId);
                cmd.Parameters.AddWithValue("@isim", uye.Isim);
                cmd.Parameters.AddWithValue("@tel", digits);
                cmd.Parameters.AddWithValue("@cinsiyet", uye.Cinsiyet);
                cmd.Parameters.AddWithValue("@yas", uye.Yas);
                cmd.Parameters.AddWithValue("@odeme", uye.Odeme);
                cmd.Parameters.AddWithValue("@tip", uye.Tip);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Üye bilgileri başarıyla güncellendi.\n" + uye.BilgiVer());

                LoadUyeler();    // DataGridView’i güncel verilerle yeniden doldurur
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }



        private void button3_Click(object sender, EventArgs e)  // Sil
        {
            if (key == 0)
            {
                MessageBox.Show("Silinecek üyeyi seçiniz.");
                return;
            }

            try
            {
                baglanti.Open();
                using (var cmd = new SqlCommand("DELETE FROM uyeTbl WHERE UYEid = @id", baglanti))
                {
                    cmd.Parameters.AddWithValue("@id", key);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Üye başarıyla silindi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
                LoadUyeler();
                ClearInputs();
            }
        }

        private void button2_Click(object sender, EventArgs e)  // Reset
        {
            ClearInputs();
        }

        private void button4_Click(object sender, EventArgs e)  // Ana Sayfa
        {
            new anaSayfa().Show();
            this.Hide();
        }

        private void ClearInputs()
        {
            key = 0;
            txtIsim.Clear();
            txtTel.Clear();
            txtYas.Clear();
            txtOdeme.Clear();
            comboBoxCinsiyet.SelectedIndex = -1; // temizlenince seçiliymiş gibi görünmesin diye 0 değil -1
            comboBoxTip.SelectedIndex = -1;
        }
    }
}

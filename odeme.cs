using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace yazilim_proje2
{
    public partial class odeme : BaseForm
    {
        public odeme()
        {
            InitializeComponent();
        }
        private readonly SqlConnection baglanti = new SqlConnection(
    ConfigurationManager.ConnectionStrings["SporSalonu"].ConnectionString);



        private void fillName()
        {
            baglanti.Open();
            SqlCommand cmd =new SqlCommand("select UYEisim from uyeTbl", baglanti);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("UYEisim",typeof(string));
            dt.Load(rdr);
            comboBox1.ValueMember = "UYEisim";
            comboBox1.DataSource = dt;
            baglanti.Close();


        }
        
        private void uyeler()
        {
            baglanti.Open();
            string query = "select *from odemeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox2.Text = "";        }

        private void button3_Click(object sender, EventArgs e)
        {
            anaSayfa syf = new anaSayfa();
            syf.Show();
            this.Hide();
        }

        private void odeme_Load(object sender, EventArgs e)
        {
            fillName();
            uyeler();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Eksik bilgi");
                }
                else
                {
                    string odemeperiyot = dateTimePicker1.Value.Month.ToString() + dateTimePicker1.Value.Year.ToString();
                    SqlDataAdapter sda = new SqlDataAdapter("select count (*) from odemeTbl where odmUYE='" + comboBox1.SelectedValue.ToString() + "' and odmAY='" + odemeperiyot + "'", baglanti);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        MessageBox.Show("Zaten ödeme yapıldı.");
                    }
                    else
                    {
                        baglanti.Open();
                        string query = "insert into odemeTbl values('" + odemeperiyot + "','" + comboBox1.SelectedValue.ToString() + "'," + textBox2.Text + ")";
                        SqlCommand komut = new SqlCommand(query, baglanti);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Tutar başarıyla ödendi.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baglanti.Close();
                uyeler();
            }
        }
    }
}

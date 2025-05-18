using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yazilim_proje2
{
    public partial class login : BaseForm
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = ""
;        }

        private void button2_Click(object sender, EventArgs e)
        {
            if( textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Eksik bilgi.");
            }else if(textBox1.Text=="admin"&&textBox2.Text=="1234")
            {
                anaSayfa syf = new anaSayfa();
                syf.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı ama hangisi söylemem.");
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}

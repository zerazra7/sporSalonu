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
    public partial class anaSayfa : BaseForm
    {
        public anaSayfa()
        {
            InitializeComponent();
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            uyebtn.BackColor = Color.Teal;
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            uyebtn.BackColor = Color.Azure;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            guncellebtn.BackColor = Color.Teal;
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            guncellebtn.BackColor = Color.Teal;
        }


        private void button1_MouseHover(object sender, EventArgs e)
        {
            odemebtn.BackColor = Color.Teal;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            odemebtn.BackColor = Color.Teal;
        }


        private void guncellebtn_Click(object sender, EventArgs e)
        {
            guncelle guncelle = new guncelle();
            guncelle.Show();
            this.Hide();
        }

        private void uyebtn_Click(object sender, EventArgs e)
        {
            uyeEkle uyeekle = new uyeEkle();
            uyeekle.Show();
            this.Hide();

        }

        private void odemebtn_Click(object sender, EventArgs e)
        {
            odeme odeme = new odeme();
            odeme.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uyeGoruntule grnt = new uyeGoruntule(); 
            grnt.Show();
            this.Hide();
        }

        private void anaSayfa_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

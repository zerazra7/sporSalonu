using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace yazilim_proje2
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent(); 
            ApplyTheme();           // Sonra temayı uygular
        }

        
        /// tüm child formların ortak tema kodları
        
        protected virtual void ApplyTheme()
        {
            this.BackColor = Color.FromArgb(230, 240, 255);

            // Buton stili
            foreach (var btn in this.Controls.OfType<Button>())
                btn.BackColor = Color.Azure;

            // DataGridView stili
            foreach (var dgv in this.Controls.OfType<DataGridView>())
            {
                dgv.BackgroundColor = Color.White;
                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            }

            
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {

        }
    }
}

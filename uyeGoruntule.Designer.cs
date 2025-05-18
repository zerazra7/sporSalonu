namespace yazilim_proje2
{
    partial class uyeGoruntule
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtAra = new System.Windows.Forms.TextBox();
            this.buttonAra = new System.Windows.Forms.Button();
            this.buttonYenile = new System.Windows.Forms.Button();
            this.buttonGeri = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(42, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "Üye Listesi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(280, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(471, 48);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pilates Space Akademi";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(38, 136);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(879, 426);
            this.dataGridView1.TabIndex = 40;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtAra
            // 
            this.txtAra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAra.Location = new System.Drawing.Point(48, 589);
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(301, 39);
            this.txtAra.TabIndex = 41;
            // 
            // buttonAra
            // 
            this.buttonAra.BackColor = System.Drawing.Color.Black;
            this.buttonAra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonAra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonAra.Location = new System.Drawing.Point(394, 583);
            this.buttonAra.Name = "buttonAra";
            this.buttonAra.Size = new System.Drawing.Size(127, 51);
            this.buttonAra.TabIndex = 42;
            this.buttonAra.Text = "Ara";
            this.buttonAra.UseVisualStyleBackColor = false;
            this.buttonAra.Click += new System.EventHandler(this.buttonAra_Click);
            // 
            // buttonYenile
            // 
            this.buttonYenile.BackColor = System.Drawing.Color.Black;
            this.buttonYenile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonYenile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonYenile.Location = new System.Drawing.Point(542, 583);
            this.buttonYenile.Name = "buttonYenile";
            this.buttonYenile.Size = new System.Drawing.Size(129, 51);
            this.buttonYenile.TabIndex = 43;
            this.buttonYenile.Text = "Yenile";
            this.buttonYenile.UseVisualStyleBackColor = false;
            this.buttonYenile.Click += new System.EventHandler(this.buttonYenile_Click);
            // 
            // buttonGeri
            // 
            this.buttonGeri.BackColor = System.Drawing.Color.Black;
            this.buttonGeri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonGeri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonGeri.Location = new System.Drawing.Point(849, 583);
            this.buttonGeri.Name = "buttonGeri";
            this.buttonGeri.Size = new System.Drawing.Size(123, 57);
            this.buttonGeri.TabIndex = 44;
            this.buttonGeri.Text = "Geri";
            this.buttonGeri.UseVisualStyleBackColor = false;
            this.buttonGeri.Click += new System.EventHandler(this.buttonGeri_Click);
            // 
            // uyeGoruntule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(984, 652);
            this.Controls.Add(this.buttonGeri);
            this.Controls.Add(this.buttonYenile);
            this.Controls.Add(this.buttonAra);
            this.Controls.Add(this.txtAra);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "uyeGoruntule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "uyeGoruntule";
            this.Load += new System.EventHandler(this.uyeGoruntule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtAra;
        private System.Windows.Forms.Button buttonAra;
        private System.Windows.Forms.Button buttonYenile;
        private System.Windows.Forms.Button buttonGeri;
    }
}
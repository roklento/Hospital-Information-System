namespace Proje_Hastane
{
    partial class FrmGirisler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGirisler));
            this.Btn_Hasta = new System.Windows.Forms.Button();
            this.Btn_Doktor = new System.Windows.Forms.Button();
            this.Btn_Sekreter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Hasta
            // 
            this.Btn_Hasta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Hasta.BackgroundImage")));
            this.Btn_Hasta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Hasta.Location = new System.Drawing.Point(62, 236);
            this.Btn_Hasta.Name = "Btn_Hasta";
            this.Btn_Hasta.Size = new System.Drawing.Size(207, 120);
            this.Btn_Hasta.TabIndex = 1;
            this.Btn_Hasta.UseVisualStyleBackColor = true;
            this.Btn_Hasta.Click += new System.EventHandler(this.Btn_Hasta_Click);
            // 
            // Btn_Doktor
            // 
            this.Btn_Doktor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Doktor.BackgroundImage")));
            this.Btn_Doktor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Doktor.Location = new System.Drawing.Point(308, 236);
            this.Btn_Doktor.Name = "Btn_Doktor";
            this.Btn_Doktor.Size = new System.Drawing.Size(207, 120);
            this.Btn_Doktor.TabIndex = 2;
            this.Btn_Doktor.UseVisualStyleBackColor = true;
            this.Btn_Doktor.Click += new System.EventHandler(this.Btn_Doktor_Click);
            // 
            // Btn_Sekreter
            // 
            this.Btn_Sekreter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Sekreter.BackgroundImage")));
            this.Btn_Sekreter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Sekreter.Location = new System.Drawing.Point(559, 236);
            this.Btn_Sekreter.Name = "Btn_Sekreter";
            this.Btn_Sekreter.Size = new System.Drawing.Size(207, 120);
            this.Btn_Sekreter.TabIndex = 3;
            this.Btn_Sekreter.UseVisualStyleBackColor = true;
            this.Btn_Sekreter.Click += new System.EventHandler(this.Btn_Sekreter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(124, 359);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hasta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(360, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 33);
            this.label2.TabIndex = 4;
            this.label2.Text = "Doktor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Corbel", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(604, 359);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 33);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sekreter";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(575, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Script", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(52, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(490, 57);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sağlıklı Yaşam Hastanesi";
            // 
            // FrmGirisler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(833, 442);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_Sekreter);
            this.Controls.Add(this.Btn_Doktor);
            this.Controls.Add(this.Btn_Hasta);
            this.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmGirisler";
            this.Text = "Sağlıklı Yaşam Hastane Giriş";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Hasta;
        private System.Windows.Forms.Button Btn_Doktor;
        private System.Windows.Forms.Button Btn_Sekreter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
    }
}


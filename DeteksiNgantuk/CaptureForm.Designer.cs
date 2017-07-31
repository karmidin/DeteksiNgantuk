namespace DeteksiNgantuk
{
    partial class CaptureForm
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
            this.components = new System.ComponentModel.Container();
            this.CaptureImgBox = new Emgu.CV.UI.ImageBox();
            this.LeftEyeImgBox = new Emgu.CV.UI.ImageBox();
            this.LeftEyeSobelImgBox = new System.Windows.Forms.PictureBox();
            this.RightEyeSobelImgBox = new System.Windows.Forms.PictureBox();
            this.RightEyeImgBox = new Emgu.CV.UI.ImageBox();
            this.ptbHasilAkhirKiri = new System.Windows.Forms.PictureBox();
            this.ptbHasilAkhirKanan = new System.Windows.Forms.PictureBox();
            this.LblEnergyKiri = new System.Windows.Forms.Label();
            this.LblEnergyKanan = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblFormat = new System.Windows.Forms.Label();
            this.lblDimensions = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.ofdGambar = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.CaptureImgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftEyeImgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftEyeSobelImgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightEyeSobelImgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightEyeImgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbHasilAkhirKiri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbHasilAkhirKanan)).BeginInit();
            this.SuspendLayout();
            // 
            // CaptureImgBox
            // 
            this.CaptureImgBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CaptureImgBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CaptureImgBox.Location = new System.Drawing.Point(5, 7);
            this.CaptureImgBox.Name = "CaptureImgBox";
            this.CaptureImgBox.Size = new System.Drawing.Size(349, 298);
            this.CaptureImgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CaptureImgBox.TabIndex = 36;
            this.CaptureImgBox.TabStop = false;
            // 
            // LeftEyeImgBox
            // 
            this.LeftEyeImgBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LeftEyeImgBox.Location = new System.Drawing.Point(380, 7);
            this.LeftEyeImgBox.Name = "LeftEyeImgBox";
            this.LeftEyeImgBox.Size = new System.Drawing.Size(221, 141);
            this.LeftEyeImgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LeftEyeImgBox.TabIndex = 44;
            this.LeftEyeImgBox.TabStop = false;
            // 
            // LeftEyeSobelImgBox
            // 
            this.LeftEyeSobelImgBox.Location = new System.Drawing.Point(380, 167);
            this.LeftEyeSobelImgBox.Name = "LeftEyeSobelImgBox";
            this.LeftEyeSobelImgBox.Size = new System.Drawing.Size(221, 138);
            this.LeftEyeSobelImgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LeftEyeSobelImgBox.TabIndex = 45;
            this.LeftEyeSobelImgBox.TabStop = false;
            // 
            // RightEyeSobelImgBox
            // 
            this.RightEyeSobelImgBox.Location = new System.Drawing.Point(617, 167);
            this.RightEyeSobelImgBox.Name = "RightEyeSobelImgBox";
            this.RightEyeSobelImgBox.Size = new System.Drawing.Size(222, 138);
            this.RightEyeSobelImgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RightEyeSobelImgBox.TabIndex = 47;
            this.RightEyeSobelImgBox.TabStop = false;
            // 
            // RightEyeImgBox
            // 
            this.RightEyeImgBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RightEyeImgBox.Location = new System.Drawing.Point(617, 7);
            this.RightEyeImgBox.Name = "RightEyeImgBox";
            this.RightEyeImgBox.Size = new System.Drawing.Size(222, 141);
            this.RightEyeImgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RightEyeImgBox.TabIndex = 46;
            this.RightEyeImgBox.TabStop = false;
            // 
            // ptbHasilAkhirKiri
            // 
            this.ptbHasilAkhirKiri.Location = new System.Drawing.Point(390, 315);
            this.ptbHasilAkhirKiri.Name = "ptbHasilAkhirKiri";
            this.ptbHasilAkhirKiri.Size = new System.Drawing.Size(195, 104);
            this.ptbHasilAkhirKiri.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbHasilAkhirKiri.TabIndex = 48;
            this.ptbHasilAkhirKiri.TabStop = false;
            // 
            // ptbHasilAkhirKanan
            // 
            this.ptbHasilAkhirKanan.Location = new System.Drawing.Point(632, 315);
            this.ptbHasilAkhirKanan.Name = "ptbHasilAkhirKanan";
            this.ptbHasilAkhirKanan.Size = new System.Drawing.Size(198, 104);
            this.ptbHasilAkhirKanan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbHasilAkhirKanan.TabIndex = 49;
            this.ptbHasilAkhirKanan.TabStop = false;
            // 
            // LblEnergyKiri
            // 
            this.LblEnergyKiri.AutoSize = true;
            this.LblEnergyKiri.Location = new System.Drawing.Point(387, 438);
            this.LblEnergyKiri.Name = "LblEnergyKiri";
            this.LblEnergyKiri.Size = new System.Drawing.Size(57, 13);
            this.LblEnergyKiri.TabIndex = 50;
            this.LblEnergyKiri.Text = "Energy Kiri";
            // 
            // LblEnergyKanan
            // 
            this.LblEnergyKanan.AutoSize = true;
            this.LblEnergyKanan.Location = new System.Drawing.Point(629, 438);
            this.LblEnergyKanan.Name = "LblEnergyKanan";
            this.LblEnergyKanan.Size = new System.Drawing.Size(74, 13);
            this.LblEnergyKanan.TabIndex = 51;
            this.LblEnergyKanan.Text = "Energy Kanan";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(6, 323);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 22);
            this.btnBrowse.TabIndex = 52;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(98, 323);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(257, 20);
            this.txtFilePath.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "Size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 402);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "Dimensions";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 424);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Format";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 424);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 61;
            this.label5.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(66, 402);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(66, 380);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 59;
            this.label7.Text = ":";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(66, 357);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 13);
            this.label8.TabIndex = 58;
            this.label8.Text = ":";
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Location = new System.Drawing.Point(81, 425);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(10, 13);
            this.lblFormat.TabIndex = 65;
            this.lblFormat.Text = "-";
            // 
            // lblDimensions
            // 
            this.lblDimensions.AutoSize = true;
            this.lblDimensions.Location = new System.Drawing.Point(81, 403);
            this.lblDimensions.Name = "lblDimensions";
            this.lblDimensions.Size = new System.Drawing.Size(10, 13);
            this.lblDimensions.TabIndex = 64;
            this.lblDimensions.Text = "-";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(81, 381);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(10, 13);
            this.lblSize.TabIndex = 63;
            this.lblSize.Text = "-";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(81, 358);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(10, 13);
            this.lblName.TabIndex = 62;
            this.lblName.Text = "-";
            // 
            // CaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 461);
            this.Controls.Add(this.lblFormat);
            this.Controls.Add(this.lblDimensions);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.LblEnergyKanan);
            this.Controls.Add(this.LblEnergyKiri);
            this.Controls.Add(this.ptbHasilAkhirKanan);
            this.Controls.Add(this.ptbHasilAkhirKiri);
            this.Controls.Add(this.RightEyeSobelImgBox);
            this.Controls.Add(this.RightEyeImgBox);
            this.Controls.Add(this.LeftEyeSobelImgBox);
            this.Controls.Add(this.LeftEyeImgBox);
            this.Controls.Add(this.CaptureImgBox);
            this.Name = "CaptureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Deteksi";
            this.Load += new System.EventHandler(this.CaptureForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CaptureImgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftEyeImgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftEyeSobelImgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightEyeSobelImgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightEyeImgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbHasilAkhirKiri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbHasilAkhirKanan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox CaptureImgBox;
        private Emgu.CV.UI.ImageBox LeftEyeImgBox;
        private System.Windows.Forms.PictureBox LeftEyeSobelImgBox;
        private System.Windows.Forms.PictureBox RightEyeSobelImgBox;
        private Emgu.CV.UI.ImageBox RightEyeImgBox;
        private System.Windows.Forms.PictureBox ptbHasilAkhirKiri;
        private System.Windows.Forms.PictureBox ptbHasilAkhirKanan;
        private System.Windows.Forms.Label LblEnergyKiri;
        private System.Windows.Forms.Label LblEnergyKanan;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblFormat;
        private System.Windows.Forms.Label lblDimensions;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.OpenFileDialog ofdGambar;
    }
}


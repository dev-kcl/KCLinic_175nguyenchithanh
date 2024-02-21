namespace KClinic2._1.View.ChanDoanHinhAnh
{
    partial class ZoomHinhAnh
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
            this.pnpictureBox1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnpictureBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnpictureBox1
            // 
            this.pnpictureBox1.Controls.Add(this.pictureBox1);
            this.pnpictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnpictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pnpictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnpictureBox1.Name = "pnpictureBox1";
            this.pnpictureBox1.Size = new System.Drawing.Size(800, 450);
            this.pnpictureBox1.TabIndex = 16;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.FillColor = System.Drawing.Color.Transparent;
            this.pictureBox1.ImageRotate = 0F;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseTransparentBackground = true;
            // 
            // ZoomHinhAnh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnpictureBox1);
            this.Name = "ZoomHinhAnh";
            this.Text = "ZoomHinhAnh";
            this.Load += new System.EventHandler(this.ZoomHinhAnh_Load);
            this.pnpictureBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnpictureBox1;
        private Guna.UI2.WinForms.Guna2PictureBox pictureBox1;
    }
}
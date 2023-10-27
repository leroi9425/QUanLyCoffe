namespace QuanLyQuanCafe
{
    partial class FormTTDH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTTDH));
            this.label1 = new System.Windows.Forms.Label();
            this.dsHoaDon = new System.Windows.Forms.FlowLayoutPanel();
            this.firstLabel = new System.Windows.Forms.Label();
            this.lbInfo = new System.Windows.Forms.Label();
            this.lbMaHoaDon = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Label();
            this.dsHoaDon.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // dsHoaDon
            // 
            this.dsHoaDon.AutoScroll = true;
            this.dsHoaDon.Controls.Add(this.firstLabel);
            this.dsHoaDon.Location = new System.Drawing.Point(38, 54);
            this.dsHoaDon.Name = "dsHoaDon";
            this.dsHoaDon.Size = new System.Drawing.Size(708, 232);
            this.dsHoaDon.TabIndex = 1;
            // 
            // firstLabel
            // 
            this.firstLabel.BackColor = System.Drawing.Color.White;
            this.firstLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstLabel.Location = new System.Drawing.Point(3, 0);
            this.firstLabel.Name = "firstLabel";
            this.firstLabel.Size = new System.Drawing.Size(344, 83);
            this.firstLabel.TabIndex = 1;
            this.firstLabel.Text = "ĐÃ THANH TOÁN";
            this.firstLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label2_MouseClick);
            // 
            // lbInfo
            // 
            this.lbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfo.Location = new System.Drawing.Point(42, 323);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(521, 63);
            this.lbInfo.TabIndex = 2;
            // 
            // lbMaHoaDon
            // 
            this.lbMaHoaDon.AutoSize = true;
            this.lbMaHoaDon.BackColor = System.Drawing.Color.Transparent;
            this.lbMaHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaHoaDon.ForeColor = System.Drawing.Color.Red;
            this.lbMaHoaDon.Location = new System.Drawing.Point(42, 300);
            this.lbMaHoaDon.Name = "lbMaHoaDon";
            this.lbMaHoaDon.Size = new System.Drawing.Size(248, 25);
            this.lbMaHoaDon.TabIndex = 3;
            this.lbMaHoaDon.Text = "MÃ ĐƠN : PM9165512";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.Transparent;
            this.btnThanhToan.Location = new System.Drawing.Point(593, 345);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(134, 50);
            this.btnThanhToan.TabIndex = 4;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // FormTTDH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.lbMaHoaDon);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.dsHoaDon);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormTTDH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTTDH";
            this.Load += new System.EventHandler(this.FormTTDH_Load);
            this.dsHoaDon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel dsHoaDon;
        private System.Windows.Forms.Label firstLabel;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Label lbMaHoaDon;
        private System.Windows.Forms.Label btnThanhToan;
    }
}
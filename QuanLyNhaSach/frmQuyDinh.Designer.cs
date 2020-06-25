namespace QuanLyNhaSach
{
    partial class frmQuyDinh
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
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnMacDinh = new System.Windows.Forms.Button();
            this.btnThayDoi = new System.Windows.Forms.Button();
            this.numSoLuongTon = new System.Windows.Forms.NumericUpDown();
            this.numSoLuongTonSauKhiBan = new System.Windows.Forms.NumericUpDown();
            this.numSoLuongNhapSach = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbQuyDinh = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongTon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongTonSauKhiBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongNhapSach)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnThoat.Location = new System.Drawing.Point(297, 181);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(85, 28);
            this.btnThoat.TabIndex = 23;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnMacDinh
            // 
            this.btnMacDinh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMacDinh.Location = new System.Drawing.Point(191, 181);
            this.btnMacDinh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMacDinh.Name = "btnMacDinh";
            this.btnMacDinh.Size = new System.Drawing.Size(85, 28);
            this.btnMacDinh.TabIndex = 22;
            this.btnMacDinh.Text = "Mặc định";
            this.btnMacDinh.UseVisualStyleBackColor = true;
            this.btnMacDinh.Click += new System.EventHandler(this.btnMacDinh_Click);
            // 
            // btnThayDoi
            // 
            this.btnThayDoi.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnThayDoi.Location = new System.Drawing.Point(85, 181);
            this.btnThayDoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThayDoi.Name = "btnThayDoi";
            this.btnThayDoi.Size = new System.Drawing.Size(85, 28);
            this.btnThayDoi.TabIndex = 21;
            this.btnThayDoi.Text = "Thay đổi";
            this.btnThayDoi.UseVisualStyleBackColor = true;
            this.btnThayDoi.Click += new System.EventHandler(this.btnThayDoi_Click);
            // 
            // numSoLuongTon
            // 
            this.numSoLuongTon.Location = new System.Drawing.Point(342, 100);
            this.numSoLuongTon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numSoLuongTon.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSoLuongTon.Name = "numSoLuongTon";
            this.numSoLuongTon.Size = new System.Drawing.Size(83, 27);
            this.numSoLuongTon.TabIndex = 20;
            this.numSoLuongTon.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // numSoLuongTonSauKhiBan
            // 
            this.numSoLuongTonSauKhiBan.Location = new System.Drawing.Point(342, 135);
            this.numSoLuongTonSauKhiBan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numSoLuongTonSauKhiBan.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSoLuongTonSauKhiBan.Name = "numSoLuongTonSauKhiBan";
            this.numSoLuongTonSauKhiBan.Size = new System.Drawing.Size(83, 27);
            this.numSoLuongTonSauKhiBan.TabIndex = 19;
            this.numSoLuongTonSauKhiBan.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numSoLuongNhapSach
            // 
            this.numSoLuongNhapSach.Location = new System.Drawing.Point(342, 61);
            this.numSoLuongNhapSach.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numSoLuongNhapSach.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSoLuongNhapSach.Name = "numSoLuongNhapSach";
            this.numSoLuongNhapSach.Size = new System.Drawing.Size(83, 27);
            this.numSoLuongNhapSach.TabIndex = 18;
            this.numSoLuongNhapSach.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 138);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(305, 19);
            this.label3.TabIndex = 17;
            this.label3.Text = "Đầu sách có lượng tồn sau khi bán ít nhất là:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(295, 19);
            this.label2.TabIndex = 16;
            this.label2.Text = "Chỉ nhập các đầu sách có lượng tồn ít hơn:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "Số lượng nhập sách ít nhất:";
            // 
            // lbQuyDinh
            // 
            this.lbQuyDinh.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuyDinh.Location = new System.Drawing.Point(1, -2);
            this.lbQuyDinh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbQuyDinh.Name = "lbQuyDinh";
            this.lbQuyDinh.Size = new System.Drawing.Size(469, 47);
            this.lbQuyDinh.TabIndex = 2;
            this.lbQuyDinh.Text = "QUY ĐỊNH";
            this.lbQuyDinh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmQuyDinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 234);
            this.Controls.Add(this.lbQuyDinh);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnMacDinh);
            this.Controls.Add(this.btnThayDoi);
            this.Controls.Add(this.numSoLuongTon);
            this.Controls.Add(this.numSoLuongTonSauKhiBan);
            this.Controls.Add(this.numSoLuongNhapSach);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmQuyDinh";
            this.Text = "Quy Định";
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongTon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongTonSauKhiBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongNhapSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnMacDinh;
        private System.Windows.Forms.Button btnThayDoi;
        private System.Windows.Forms.NumericUpDown numSoLuongTon;
        private System.Windows.Forms.NumericUpDown numSoLuongTonSauKhiBan;
        private System.Windows.Forms.NumericUpDown numSoLuongNhapSach;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbQuyDinh;
    }
}
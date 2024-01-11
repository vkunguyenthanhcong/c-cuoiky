namespace GUI
{
    partial class DoiMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoiMatKhau));
            xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            btnDoiMatKhau = new DevExpress.XtraEditors.SimpleButton();
            txtMatKhau2_Repeat = new TextBox();
            txtMatKhau2 = new TextBox();
            txtMatKhau1 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            xtraScrollableControl1.SuspendLayout();
            SuspendLayout();
            // 
            // xtraScrollableControl1
            // 
            xtraScrollableControl1.Controls.Add(btnDoiMatKhau);
            xtraScrollableControl1.Controls.Add(txtMatKhau2_Repeat);
            xtraScrollableControl1.Controls.Add(txtMatKhau2);
            xtraScrollableControl1.Controls.Add(txtMatKhau1);
            xtraScrollableControl1.Controls.Add(label4);
            xtraScrollableControl1.Controls.Add(label3);
            xtraScrollableControl1.Controls.Add(label2);
            xtraScrollableControl1.Controls.Add(label1);
            xtraScrollableControl1.Dock = DockStyle.Fill;
            xtraScrollableControl1.Location = new Point(0, 0);
            xtraScrollableControl1.Name = "xtraScrollableControl1";
            xtraScrollableControl1.Size = new Size(537, 325);
            xtraScrollableControl1.TabIndex = 0;
            // 
            // btnDoiMatKhau
            // 
            btnDoiMatKhau.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnDoiMatKhau.ImageOptions.SvgImage");
            btnDoiMatKhau.Location = new Point(193, 248);
            btnDoiMatKhau.Name = "btnDoiMatKhau";
            btnDoiMatKhau.Size = new Size(148, 43);
            btnDoiMatKhau.TabIndex = 7;
            btnDoiMatKhau.Text = "Đổi Mật Khẩu";
            btnDoiMatKhau.Click += btnDoiMatKhau_Click;
            // 
            // txtMatKhau2_Repeat
            // 
            txtMatKhau2_Repeat.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtMatKhau2_Repeat.Location = new Point(228, 188);
            txtMatKhau2_Repeat.Name = "txtMatKhau2_Repeat";
            txtMatKhau2_Repeat.Size = new Size(218, 23);
            txtMatKhau2_Repeat.TabIndex = 6;
            txtMatKhau2_Repeat.UseSystemPasswordChar = true;
            // 
            // txtMatKhau2
            // 
            txtMatKhau2.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtMatKhau2.Location = new Point(228, 138);
            txtMatKhau2.Name = "txtMatKhau2";
            txtMatKhau2.Size = new Size(218, 23);
            txtMatKhau2.TabIndex = 5;
            txtMatKhau2.UseSystemPasswordChar = true;
            // 
            // txtMatKhau1
            // 
            txtMatKhau1.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtMatKhau1.Location = new Point(228, 88);
            txtMatKhau1.Name = "txtMatKhau1";
            txtMatKhau1.Size = new Size(218, 23);
            txtMatKhau1.TabIndex = 4;
            txtMatKhau1.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(63, 192);
            label4.Name = "label4";
            label4.Size = new Size(146, 16);
            label4.TabIndex = 3;
            label4.Text = "Nhập Lại Mật Khẩu Mới :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(63, 137);
            label3.Name = "label3";
            label3.Size = new Size(97, 16);
            label3.TabIndex = 2;
            label3.Text = "Mật Khẩu Mới : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(63, 91);
            label2.Name = "label2";
            label2.Size = new Size(124, 16);
            label2.TabIndex = 1;
            label2.Text = "Mật Khẩu Hiện Tại : ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(193, 33);
            label1.Name = "label1";
            label1.Size = new Size(154, 25);
            label1.TabIndex = 0;
            label1.Text = "Đổi Mật Khẩu";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // DoiMatKhau
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(537, 325);
            Controls.Add(xtraScrollableControl1);
            Name = "DoiMatKhau";
            Text = "DoiMatKhau";
            xtraScrollableControl1.ResumeLayout(false);
            xtraScrollableControl1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private Label label1;
        private Label label2;
        private DevExpress.XtraEditors.SimpleButton btnDoiMatKhau;
        private TextBox txtMatKhau2_Repeat;
        private TextBox txtMatKhau2;
        private TextBox txtMatKhau1;
        private Label label4;
        private Label label3;
    }
}
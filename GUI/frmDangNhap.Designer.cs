namespace GUI
{
    partial class frmDangNhap
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
            groupBox1 = new GroupBox();
            label4 = new Label();
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(btnLogin);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 440);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Đăng Nhập";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(613, 300);
            label4.Name = "label4";
            label4.Size = new Size(104, 15);
            label4.TabIndex = 7;
            label4.Text = "Đăng Kí Tài Khoản";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(533, 248);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(184, 34);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Đăng Nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtPassword.Location = new Point(533, 189);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(184, 29);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            txtUsername.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtUsername.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtUsername.Location = new Point(533, 136);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(184, 29);
            txtUsername.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(442, 196);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 3;
            label3.Text = "Mật Khẩu :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(442, 143);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 2;
            label2.Text = "Tài Khoản :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(518, 79);
            label1.Name = "label1";
            label1.Size = new Size(167, 21);
            label1.TabIndex = 1;
            label1.Text = "Đăng Nhập Hệ Thống";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(22, 78);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(383, 237);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // frmDangNhap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 242, 255);
            ClientSize = new Size(800, 464);
            Controls.Add(groupBox1);
            Name = "frmDangNhap";
            Text = "Đăng Nhập";
            FormClosing += frmDangNhap_FormClosing;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private PictureBox pictureBox1;
        private Label label1;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label label3;
        private Label label2;
        private Label label4;
        private Button btnLogin;
    }
}
namespace GUI
{
    partial class frmTrangChuSinhVien
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
            tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
            tabNavigationPage1 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            tabNavigationPage2 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            ((System.ComponentModel.ISupportInitialize)tabPane1).BeginInit();
            tabPane1.SuspendLayout();
            tabNavigationPage1.SuspendLayout();
            SuspendLayout();
            // 
            // tabPane1
            // 
            tabPane1.Controls.Add(tabNavigationPage1);
            tabPane1.Controls.Add(tabNavigationPage2);
            tabPane1.Dock = DockStyle.Fill;
            tabPane1.Location = new Point(0, 0);
            tabPane1.Name = "tabPane1";
            tabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] { tabNavigationPage1, tabNavigationPage2 });
            tabPane1.RegularSize = new Size(1418, 758);
            tabPane1.SelectedPage = tabNavigationPage1;
            tabPane1.Size = new Size(1418, 758);
            tabPane1.TabIndex = 0;
            tabPane1.Text = "tabPane1";
            // 
            // tabNavigationPage1
            // 
            tabNavigationPage1.Caption = "Thông Tin Sinh Viên";
            tabNavigationPage1.Controls.Add(xtraScrollableControl1);
            tabNavigationPage1.Name = "tabNavigationPage1";
            tabNavigationPage1.Size = new Size(1418, 725);
            // 
            // xtraScrollableControl1
            // 
            xtraScrollableControl1.Dock = DockStyle.Fill;
            xtraScrollableControl1.Location = new Point(0, 0);
            xtraScrollableControl1.Name = "xtraScrollableControl1";
            xtraScrollableControl1.Size = new Size(1418, 725);
            xtraScrollableControl1.TabIndex = 0;
            // 
            // tabNavigationPage2
            // 
            tabNavigationPage2.Caption = "tabNavigationPage2";
            tabNavigationPage2.Name = "tabNavigationPage2";
            tabNavigationPage2.Size = new Size(1418, 758);
            // 
            // frmTrangChuSinhVien
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1418, 758);
            Controls.Add(tabPane1);
            Name = "frmTrangChuSinhVien";
            Text = "frmTrangChuSinhVien";
            ((System.ComponentModel.ISupportInitialize)tabPane1).EndInit();
            tabPane1.ResumeLayout(false);
            tabNavigationPage1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraBars.Navigation.TabPane tabPane1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage1;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage2;
    }
}
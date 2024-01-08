namespace GUI
{
    partial class frmListSinhVien
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
            gridControlListSV = new DevExpress.XtraGrid.GridControl();
            gridViewListSV = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)gridControlListSV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewListSV).BeginInit();
            SuspendLayout();
            // 
            // gridControlListSV
            // 
            gridControlListSV.Dock = DockStyle.Fill;
            gridControlListSV.Location = new Point(0, 0);
            gridControlListSV.MainView = gridViewListSV;
            gridControlListSV.Name = "gridControlListSV";
            gridControlListSV.Size = new Size(1279, 649);
            gridControlListSV.TabIndex = 0;
            gridControlListSV.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewListSV });
            // 
            // gridViewListSV
            // 
            gridViewListSV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gridColumn1, gridColumn2, gridColumn3 });
            gridViewListSV.GridControl = gridControlListSV;
            gridViewListSV.Name = "gridViewListSV";
            gridViewListSV.Click += gridViewListSV_Click;
            // 
            // gridColumn1
            // 
            gridColumn1.Caption = "Mã Sinh Viên";
            gridColumn1.FieldName = "Masv";
            gridColumn1.Name = "gridColumn1";
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            gridColumn2.Caption = "Họ Và Tên";
            gridColumn2.FieldName = "Hoten";
            gridColumn2.Name = "gridColumn2";
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            gridColumn3.Caption = "Địa Chỉ Tạm Trú";
            gridColumn3.FieldName = "Tamtru";
            gridColumn3.Name = "gridColumn3";
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = 2;
            // 
            // frmListSinhVien
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1279, 649);
            Controls.Add(gridControlListSV);
            Name = "frmListSinhVien";
            Text = "Danh Sách Sinh Viên";
            ((System.ComponentModel.ISupportInitialize)gridControlListSV).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewListSV).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlListSV;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewListSV;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}
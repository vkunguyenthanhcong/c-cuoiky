using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmListSinhVien : DevExpress.XtraEditors.XtraForm
    {
        private frmTrangChu frm;
        public frmListSinhVien(frmTrangChu frm)
        {
            InitializeComponent();
            loadDataTable();
            this.frm = frm;
        }

        private void loadDataTable()
        {
            HoSoSinhVienBLl hoSoSinhVienBLl = new HoSoSinhVienBLl();
            List<ThongTinSinhVien> sinhVienList = hoSoSinhVienBLl.getSinhVienListTamTru();
            gridControlListSV.DataSource = sinhVienList;
            gridViewListSV.OptionsBehavior.Editable = false;
            foreach (GridColumn column in gridViewListSV.Columns)
            {
                column.BestFit();
            }
        }
        private void gridViewListSV_Click(object sender, EventArgs e)
        {
            if (gridViewListSV.SelectedRowsCount > 0)
            {
                int focusedRowHandle = gridViewListSV.GetSelectedRows()[0];
                int columnIndex = gridViewListSV.Columns["Masv"].VisibleIndex;
                object obMaSV = gridViewListSV.GetRowCellValue(focusedRowHandle, "Masv");
                object obHoTen = gridViewListSV.GetRowCellValue(focusedRowHandle, "Hoten");
                object obTamTru = gridViewListSV.GetRowCellValue(focusedRowHandle, "Tamtru");

                frm.SetDataFromListSV((string)obMaSV, (string)obHoTen, (string)obTamTru);
            }
        }
    }
}
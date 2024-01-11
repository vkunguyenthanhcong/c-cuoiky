using BLL;
using DevExpress.XtraEditors;
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
    public partial class DoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        private frmTrangChu frm;
        public string strPassword = "";
        public DoiMatKhau(frmTrangChu frm, string password)
        {
            InitializeComponent();
            this.frm = frm;
            strPassword = password;
        }
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (txtMatKhau1.Text == "" || txtMatKhau2.Text == "" || txtMatKhau2_Repeat.Text == "")
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                if (txtMatKhau1.Text != strPassword)
                {
                    XtraMessageBox.Show("Mật khẩu mới và mật khẩu cũ giống nhau");
                }
                else
                {
                    if (txtMatKhau2.Text != txtMatKhau2_Repeat.Text)
                    {
                        XtraMessageBox.Show("Mật khẩu không khớp nhau");
                    }
                    else
                    {
                        frm.updatePassword(txtMatKhau2.Text);
                    }
                }
            }
        }
    }
}
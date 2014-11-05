using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CSKH_Control_WUCTaiKhoan : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            LoadTaiKhoan();
            LoadDonVi(this.DDLDonVi);
        }
    }

    private void LoadTaiKhoan()
    {
        DataTable dt = DBClass.GetTable("select NV.Tai_Khoan, NV.Ho_Ten, NV.Dien_Thoai, NV.Loai_Tai_Khoan," +
        " DVTT.Ten_Don_Vi from Nhan_Vien NV, DM_Don_Vi DVTT where NV.Ma_Don_Vi = DVTT.Ma_Don_Vi" + 
        " order by DVTT.Ten_Don_Vi asc, NV.Loai_Tai_Khoan asc");
        this.MyGRV01.DataSource = dt;
        this.MyGRV01.DataBind();
    }

    public string ChuyenLoaiTaiKhoan(string ltk)
    {
        switch (ltk.Trim())
        {
            case "0":
                return "Nhân viên chiết tính";
            case "1":
                return "Nhân viên quản lý";
            case "2":
                return "Lãnh đạo ký";
            case "3":
                return "Quản trị viên";
            case "4":
                return "Nhân viên vật tư";
        }
        return "Nhân viên chiết tính";
    }

    private void LoadThongTin(string tk)
    {
        DataTable dt = DBClass.GetTable("select * from Nhan_Vien where Tai_Khoan = '" + tk.Trim() + "'");
        if (dt.Rows.Count > 0)
        {
            DataRow dtr = dt.Rows[0];
            this.WTaiKhoan.Text = tk.Trim();
            this.WHoTen.Text = dtr["Ho_Ten"].ToString().Trim();
            this.WDiaChi.Text = dtr["Dia_Chi"].ToString().Trim();
            this.WChucVu.Text = dtr["Chuc_Vu"].ToString().Trim();
            this.WDienThoai.Text = dtr["Dien_Thoai"].ToString().Trim();
            this.WGhiChu.Text = dtr["Ghi_Chu"].ToString().Trim();
            LoadDonVi(this.DDLDonVi);
            this.DDLDonVi.SelectedValue = dtr["Ma_Don_Vi"].ToString().Trim();
            this.DDLQuyen.SelectedValue = dtr["Loai_Tai_Khoan"].ToString().Trim();
        }
    }

    private void LoadDonVi(DropDownList mycb)
    {
        DataTableReader dttr = DBClass.GetTable("select * from DM_Don_Vi order by Ten_Don_Vi asc").CreateDataReader();
        mycb.Items.Clear();
        while (dttr.Read())
        {
            ListItem li = new ListItem();
            li.Value = dttr["Ma_Don_Vi"].ToString().Trim();
            li.Text = dttr["Ten_Don_Vi"].ToString().Trim();
            mycb.Items.Add(li);
        }
    }

    protected void CVV1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if ((this.WDienThoai.Text.Trim().IndexOf("0702") == 0) || (this.WDienThoai.Text.Trim().IndexOf("096") == 0))
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }

    protected void MyGRV01_CellSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedCellEventArgs e)
    {
        if (e.CurrentSelectedCells.Count > 0)
        {
            this.LoadThongTin(this.MyGRV01.Behaviors.Selection.SelectedCells[0].Row.Items[0].Text);
        }        
    }

    protected void MyGRV01_RowSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
    {
        if (e.CurrentSelectedRows.Count > 0)
        {
            this.LoadThongTin(this.MyGRV01.Behaviors.Selection.SelectedRows[0].Items[0].Text);
        }        
    }

    protected void MyGRV01_PageIndexChanged(object sender, Infragistics.Web.UI.GridControls.PagingEventArgs e)
    {
        this.LoadTaiKhoan();
    }

    protected void MyGRV01_DataFiltered(object sender, Infragistics.Web.UI.GridControls.FilteredEventArgs e)
    {
        this.LoadTaiKhoan();
    }

    protected void BThoat_Click(object sender, EventArgs e)
    {
        this.Response.Redirect(ResolveUrl("~/Chiet_Tinh/Default.aspx"));
    }

    protected void WIBThemMoi_Click(object sender, EventArgs e)
    {
        if (this.Page.IsValid)
        {
            DataTable dt = DBClass.GetTable("select * from Nhan_Vien where Tai_Khoan = '" + this.WTaiKhoan.Text.Trim() + "'");
            if (dt.Rows.Count < 1)
            {
                DataRow dtr = dt.NewRow();
                dtr["Tai_Khoan"] = this.WTaiKhoan.Text.Trim();
                dtr["Ho_Ten"] = this.WHoTen.Text.Trim();
                dtr["Dia_Chi"] = this.WDiaChi.Text.Trim();
                dtr["Chuc_Vu"] = this.WChucVu.Text.Trim();
                dtr["Dien_Thoai"] = this.WDienThoai.Text.Trim();
                dtr["Ma_Don_Vi"] = this.DDLDonVi.SelectedValue.Trim();
                dtr["Loai_Tai_Khoan"] = this.DDLQuyen.SelectedValue.Trim();
                dtr["Ghi_Chu"] = this.WGhiChu.Text.Trim();
                if (this.WMatKhau.Text.Trim().Length > 0)
                {
                    MaHoaII.MaHoaWeb mh = new MaHoaII.MaHoaWeb();
                    dtr["Mat_Khau"] = mh.MaHoa_Link.Clock(this.WMatKhau.Text.Trim());
                }
                else
                {
                    this.LMsg.Text = "Vui lòng nhập mật khẩu";
                    goto thoat;
                }
                dt.Rows.Add(dtr);
                if (DBClass.UpdateTable("select * from Nhan_Vien where Tai_Khoan = '" + this.WTaiKhoan.Text.Trim() + "'", dt) == true)
                {
                    this.LMsg.Text = "Tạo mới thông tin thành công";
                    this.MyGRV01.ClearDataSource();
                    LoadTaiKhoan();
                }
                else
                {
                    this.LMsg.Text = "Tạo mới thông tin thất bại, vui lòng kiểm tra lại dữ liệu";
                }
            }
        }
    thoat: ;
    }

    protected void WIBCapNhat_Click(object sender, EventArgs e)
    {
        if (this.Page.IsValid)
        {
            DataTable dt = DBClass.GetTable("select * from Nhan_Vien where Tai_Khoan = '" + this.WTaiKhoan.Text.Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                DataRow dtr = dt.Rows[0];
                dtr["Ho_Ten"] = this.WHoTen.Text.Trim();
                dtr["Dia_Chi"] = this.WDiaChi.Text.Trim();
                dtr["Chuc_Vu"] = this.WChucVu.Text.Trim();
                dtr["Dien_Thoai"] = this.WDienThoai.Text.Trim();
                dtr["Ma_Don_Vi"] = this.DDLDonVi.SelectedValue.Trim();
                dtr["Loai_Tai_Khoan"] = this.DDLQuyen.SelectedValue.Trim();
                dtr["Ghi_Chu"] = this.WGhiChu.Text.Trim();
                if (this.WMatKhau.Text.Trim().Length > 0)
                {
                    MaHoaII.MaHoaWeb mh = new MaHoaII.MaHoaWeb();
                    dtr["Mat_Khau"] = mh.MaHoa_Link.Clock(this.WMatKhau.Text.Trim());
                }
                if (DBClass.UpdateTable("select * from Nhan_Vien where Tai_Khoan = '" + this.WTaiKhoan.Text.Trim() + "'", dt) == true)
                {
                    this.LMsg.Text = "Cập nhật thông tin thành công";
                    this.MyGRV01.ClearDataSource();
                    this.LoadTaiKhoan();
                }
                else
                {
                    this.LMsg.Text = "Cập nhật thông tin thất bại, vui lòng kiểm tra lại dữ liệu";
                }
            }
        }
    }

    protected void WIBXoa_Click(object sender, EventArgs e)
    {
        if (this.Page.IsValid)
        {
            DataTable dt = DBClass.GetTable("select * from Nhan_Vien where Tai_Khoan = '" + this.WTaiKhoan.Text.Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                dt.Rows[0].Delete();
                if (DBClass.UpdateTable("select * from Nhan_Vien where Tai_Khoan = '" + this.WTaiKhoan.Text.Trim() + "'", dt) == true)
                {
                    this.LMsg.Text = "Xóa thông tin thành công";
                    this.MyGRV01.ClearDataSource();
                    LoadTaiKhoan();
                }
                else
                {
                    this.LMsg.Text = "Xóa thông tin thất bại, vui lòng kiểm tra lại dữ liệu";
                }
            }
        }
    }
}

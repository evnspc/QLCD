using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Configuration;

public partial class Chiet_Tinh_Control_WUCKhachHang : System.Web.UI.UserControl
{

    private string TaoMaKH()
    {
        DataTable dtnv = DBClass.GetTable("select Ma_Don_Vi from Nhan_Vien where Tai_Khoan = '" + Session["Nhan_Vien"].ToString().Trim() + "'");
        if (dtnv.Rows.Count > 0)
        {
            DateTime cd = DateTime.Now.ToUniversalTime().AddHours(7);
            string mkht = cd.Year.ToString().Trim() + cd.Month.ToString().Trim() + cd.Day.ToString().Trim() + dtnv.Rows[0]["Ma_Don_Vi"].ToString().Trim();
            DataTable dt = DBClass.GetTable("select Count(Ma_KH) as Tong from Khach_Hang where Ma_KH like '%" + mkht.Trim() + "%'");
            int i;
            if (dt.Rows.Count > 0)
            {
                i = int.Parse(dt.Rows[0]["Tong"].ToString().Trim()) + 1;
            }
            else { i = 1; }
            string mkh;
            DataTable dtch;
        ll:
            mkh = mkht + i.ToString().Trim();
            dtch = DBClass.GetTable("select * from Khach_Hang where Ma_KH = '" + mkh.Trim() + "'");
            if (dtch.Rows.Count > 0)
            {
                dtch = null;
                i = i+1;
                goto ll;
            }
            return mkh; 
        }
        return "";
    }
      
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            LoadKhachHang();
        }
    }

    private void LoadKhachHang()
    {
        string strsql = "select * from Khach_Hang where Ghi_Chu = '" + this.LayMaDonViTuTaiKhoan().Trim() + "'" +
        " and Ngay_Thang >= '" + ((DateTime)this.WTuNgay.Value).ToShortDateString() + "' and Ngay_Thang <= '" + ((DateTime)this.WDenNgay.Value).ToShortDateString() + "' order by Ma_KH desc";
        if (this.Div_Sql.InnerText.Trim().Length > 2)
        {
            strsql = this.Div_Sql.InnerText.Trim();
        }
        DataTable dt = DBClass.GetTable(strsql);
        this.MyGrid01.DataSource = dt;
        this.MyGrid01.DataBind();
    }

    private void LoadThongTinKhachHang(string mkh)
    {
        DataTable dt = DBClass.GetTable("select * from Khach_Hang where Ma_KH = '" + mkh.Trim() + "'");
        if (dt.Rows.Count > 0)
        {
            this.WMaKH.Text = dt.Rows[0]["Ma_KH"].ToString().Trim();
            this.WHoTen.Text = dt.Rows[0]["Ho_Ten"].ToString().Trim();
            this.WDiaChi.Text = dt.Rows[0]["Dia_Chi"].ToString().Trim();            
        }
    }

    protected void BTra_Click(object sender, EventArgs e)
    {
        string strsql = "select * from Khach_Hang where Ghi_Chu = '" + this.LayMaDonViTuTaiKhoan().Trim() + "'" +
        " and Ngay_Thang >= '" + ((DateTime)this.WTuNgay.Value).ToShortDateString() + "' and Ngay_Thang <= '" + ((DateTime)this.WDenNgay.Value).ToShortDateString() + "'";
        if (this.WTraMaKH.Text.Trim().Length > 0)
        {
            strsql = strsql + " and Ma_KH = '" + this.WTraMaKH.Text.Trim() + "'";
        }
        if (this.WTraTenKH.Text.Trim().Length > 0)
        {
            strsql = strsql + " and Ho_Ten like '%" + this.WTraTenKH.Text.Trim() + "%'";
        }
        strsql = strsql + " order by Ma_KH desc";
        DataTable dt = DBClass.GetTable(strsql);
        this.Div_Sql.InnerText = strsql;
        this.MyGrid01.ClearDataSource();
        this.MyGrid01.DataSource = dt;
        this.MyGrid01.DataBind();
    }

    protected void MyGrid01_CellSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedCellEventArgs e)
    {
        if (e.CurrentSelectedCells.Count > 0)
        {
            this.LoadThongTinKhachHang(e.CurrentSelectedCells[0].Row.Items[0].Text.ToString().Trim());
        }
    }

    protected void MyGrid01_RowSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
    {
        if (e.CurrentSelectedRows.Count > 0)
        {
            this.LoadThongTinKhachHang(e.CurrentSelectedRows[0].Items[0].Text.ToString().Trim());
        }
    }

    protected void MyGrid01_DataFiltered(object sender, Infragistics.Web.UI.GridControls.FilteredEventArgs e)
    {
        this.LoadKhachHang();
    }

    private string LayMaDonViTuTaiKhoan()
    {
        try
        {
            DataTable dt = DBClass.GetTable("select * from Nhan_Vien where Tai_Khoan = '" + Session["Nhan_Vien"].ToString().Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Ma_Don_Vi"].ToString().Trim();
            }
        }
        catch { }
        return "";
    }

    private string LayMaVungTuTaiKhoan()
    {
        try
        {
            DataTable dt = DBClass.GetTable("select * from Nhan_Vien where Tai_Khoan = '" + Session["Nhan_Vien"].ToString().Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Ma_Vung"].ToString().Trim();
            }
        }
        catch { }
        return "";
    }

    protected void WIBThemMoi_Click(object sender, EventArgs e)
    {
        string mkh = TaoMaKH();
        DataTable dt = DBClass.GetTable("select * from Khach_Hang where Ma_KH = '" + mkh.Trim() + "'");
        if (dt.Rows.Count < 1 && mkh.Trim().Length > 0)
        {
            DataRow dtr = dt.NewRow();
            dtr["Ma_KH"] = mkh.Trim();
            dtr["Ho_Ten"] = this.WHoTen.Text.Trim();
            dtr["Dia_Chi"] = this.WDiaChi.Text.Trim();
            dtr["Ngay_Thang"] = DateTime.Now.ToUniversalTime().AddHours(7);
            dtr["Ghi_Chu"] = this.LayMaDonViTuTaiKhoan();
            dt.Rows.Add(dtr);
            if (DBClass.UpdateTable("select * from Khach_Hang where Ma_KH = '" + mkh.Trim() + "'", dt) == true)
            {
                this.LMsg.Text = "Tạo mới thông tin thành công";
                this.TaoMoiBCT(mkh.Trim());
            }
            else
            {
                this.LMsg.Text = "Tạo mới thông tin thất bại, vui lòng kiểm tra lại dữ liệu";
            }
        }
        else { this.LMsg.Text = "Tạo mới thông tin thất bại, vui lòng kiểm tra lại dữ liệu"; }
    }

    protected void WIBCapNhat_Click(object sender, EventArgs e)
    {
        DataTable dt = DBClass.GetTable("select * from Khach_Hang where Ma_KH = '" + this.WMaKH.Text.Trim() + "'");
        if (dt.Rows.Count > 0)
        {
            DataRow dtr = dt.Rows[0];
            dtr["Ho_Ten"] = this.WHoTen.Text.Trim();
            dtr["Dia_Chi"] = this.WDiaChi.Text.Trim();
            dtr["Ghi_Chu"] = this.LayMaDonViTuTaiKhoan();
            if (DBClass.UpdateTable("select * from Khach_Hang where Ma_KH = '" + this.WMaKH.Text.Trim() + "'", dt) == true)
            {
                this.LMsg.Text = "Cập nhật thông tin thành công";
                this.MyGrid01.ClearDataSource();
                LoadKhachHang();
            }
            else
            {
                this.LMsg.Text = "Cập nhật thông tin thất bại, vui lòng kiểm tra lại dữ liệu";
            }
        }
    }

    protected void WIBXoa_Click(object sender, EventArgs e)
    {
        DataTable dt = DBClass.GetTable("select * from Khach_Hang where Ma_KH = '" + this.WMaKH.Text.Trim() + "'");
        if (dt.Rows.Count > 0)
        {
            dt.Rows[0].Delete();
            if (DBClass.UpdateTable("select * from Khach_Hang where Ma_KH = '" + this.WMaKH.Text.Trim() + "'", dt) == true)
            {
                this.LMsg.Text = "Xóa thông tin thành công";
                this.MyGrid01.ClearDataSource();
                LoadKhachHang();
            }
            else
            {
                this.LMsg.Text = "Xóa thông tin thất bại, vui lòng kiểm tra lại dữ liệu";
            }
        }
    }

    protected void WIBLapMoi_Click(object sender, EventArgs e)
    {
        this.TaoMoiBCT(this.WMaKH.Text.Trim());
    }

    private void TaoMoiBCT( string mkh)
    {
        if (mkh.Trim().Length > 0)
        {
            int nam = DateTime.Now.ToUniversalTime().AddHours(7).Year;
            DataTable dttaoma = DBClass.GetTable("select count(bct.So_Van_Ban) as Tong from Bang_Chiet_Tinh bct, Nhan_Vien nv where bct.Nguoi_Lap = nv.Tai_Khoan and nv.Ma_Don_Vi = '" + this.LayMaDonViTuTaiKhoan().Trim() + "' and bct.Ngay_Lap >= '1/1/" + nam.ToString().Trim() + "' and bct.Ngay_Lap <= '12/31/" + nam.ToString().Trim() + "'");
            int ssvb = int.Parse(dttaoma.Rows[0]["Tong"].ToString().Trim()) + 1;
            string svb;
            DataTable dt;
        ll:
            svb = ssvb.ToString().Trim() + "-" + this.LayMaDonViTuTaiKhoan().Trim() + "-" + nam.ToString().Trim();
            dt = DBClass.GetTable("select * from Bang_Chiet_Tinh where So_Van_Ban = '" + svb.Trim() + "'");
            if (dt.Rows.Count < 1)
            {
                DataRow dtrhs = DBClass.LayHeSo(Server.MapPath("~/Chiet_Tinh/Temp.xml"));

                string qdnc = "";
                string qdvt = "";
                try
                {
                    qdnc = dtrhs["Nhan_Cong"].ToString().Trim();
                }
                catch { }
                try
                {
                    qdvt = dtrhs["Vat_Tu"].ToString().Trim();
                }
                catch { }
                DataRow dtr = dt.NewRow();
                dtr["So_Van_Ban"] = svb.Trim();
                dtr["Ma_KH"] = mkh.Trim();
                dtr["Loai_Cong_Tac"] = "GDKC1P";
                dtr["Ngay_Lap"] = DateTime.Today.ToUniversalTime().AddHours(7);                                
                dtr["Nguoi_Lap"] = Session["Nhan_Vien"].ToString().Trim();
                dtr["Loai_Chiet_Tinh"] = 0;
                dtr["Quyet_Dinh_VT"] = qdvt.Trim();
                dtr["Quyet_Dinh_NC"] = qdnc.Trim();
                dtr["Ma_Vung"] = this.LayMaVungTuTaiKhoan().Trim();

                dt.Rows.Add(dtr);
                if (DBClass.UpdateTable("select * from Bang_Chiet_Tinh where So_Van_Ban = '" + svb.Trim() + "'", dt) == true)
                {
                    this.Response.Redirect(ResolveUrl("~/Chiet_Tinh/BangChietTinh.aspx?ID=" + svb.Trim()));
                }
            }
            else
            {
                ssvb = ssvb + 1;
                dt = null;
                goto ll;
            }
        }
    }

    protected void BThoat_Click(object sender, EventArgs e)
    {
        this.Response.Redirect(ResolveUrl("~/Chiet_Tinh/Default.aspx"));
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Chiet_Tinh_Control_WUCKHExpress : System.Web.UI.UserControl
{
    public delegate void MyEventHandler(string mkh);
    public event MyEventHandler MyEvent;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            LoadKhachHang();
        }
    }

    private void LoadKhachHang()
    {
        string strsql = "select * from Khach_Hang where Ghi_Chu = '" + this.LayMaDonViTuTaiKhoan().Trim() + "' order by Ho_Ten asc";
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
        string strsql = "select * from Khach_Hang where Ghi_Chu = '" + this.LayMaDonViTuTaiKhoan().Trim() + "'";
        if (this.WTraMaKH.Text.Trim().Length > 0)
        {
            strsql = strsql + " and Ma_KH = '" + this.WTraMaKH.Text.Trim() + "'";
        }
        if (this.WTraTenKH.Text.Trim().Length > 0)
        {
            strsql = strsql + " and Ho_Ten like '%" + this.WTraTenKH.Text.Trim() + "%'";
        }
        strsql = strsql + " order by Ho_Ten asc";
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

    protected void BChon_Click(object sender, EventArgs e)
    {
        if (this.WMaKH.Text.Trim().Length > 0)
        {
            MyEvent(this.WMaKH.Text.Trim()); 
        }
    }

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
                i = i + 1;
                goto ll;
            }
            return mkh;
        }
        return "";
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
            dtr["Ghi_Chu"] = this.LayMaDonViTuTaiKhoan();
            dt.Rows.Add(dtr);
            if (DBClass.UpdateTable("select * from Khach_Hang where Ma_KH = '" + mkh.Trim() + "'", dt) == true)
            {
                this.LMsg.Text = "Tạo mới thông tin thành công";
                this.MyGrid01.ClearDataSource();
                LoadKhachHang();
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
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Chiet_Tinh_Control_WUCDMChiPhi : System.Web.UI.UserControl
{
    protected void BTra_Click(object sender, EventArgs e)
    {
        string strsql = "select DMCP.*, LCP.Ten_Loai from DM_Chi_Phi DMCP, Loai_Chi_Phi LCP where LCP.Ma_Loai = DMCP.Ma_Loai";
        if (this.WTraMaCP.Text.Trim().Length > 0)
        {
            strsql = strsql + " and DMCP.Ma_Chi_Phi = '" + this.WTraMaCP.Text.Trim() + "'";
        }
        if (this.WTraTenCP.Text.Trim().Length > 0)
        {
            strsql = strsql + " and DMCP.Ten_Chi_Phi like '%" + this.WTraTenCP.Text.Trim() + "%'";
        }

        strsql = strsql + " and DMCP.Ma_Loai = '" + this.WTraLoaiCP.SelectedValue.ToString().Trim() + "' order by LCP.Ten_Loai asc, DMCP.Ten_Chi_Phi asc";
        DataTable dt = DBClass.GetTable(strsql);
        this.StrSql.InnerText = strsql;
        this.MyGrid01.ClearDataSource();
        this.MyGrid01.DataSource = dt;
        this.MyGrid01.DataBind();
    }

    private void LoadDMChiPhi()
    {
        string strsql = "select DMCP.*, LCP.Ten_Loai from DM_Chi_Phi DMCP, Loai_Chi_Phi LCP where LCP.Ma_Loai = DMCP.Ma_Loai order by LCP.Ten_Loai asc, DMCP.Ten_Chi_Phi asc";
        if (this.StrSql.InnerText.Trim().Length > 2)
        {
            strsql = this.StrSql.InnerText.Trim();
        }
        DataTable dt = DBClass.GetTable(strsql);
        this.MyGrid01.DataSource = dt;
        this.MyGrid01.DataBind();
    }
    
    protected void WIBThemMoi_Click(object sender, EventArgs e)
    {
        DataTable dt = DBClass.GetTable("select * from DM_Chi_Phi where Ma_Chi_Phi = '" + this.WMaCP.Text.Trim() + "'");
        if (dt.Rows.Count < 1)
        {
            DataRow dtr = dt.NewRow();
            dtr["Ma_Chi_Phi"] = this.WMaCP.Text.Trim();
            dtr["Ten_Chi_Phi"] = this.WTenCP.Text.Trim();
            dtr["Don_Gia"] = this.WDonGia.Text.Trim();
            dtr["DVT"] = this.WDVT.Text.Trim();
            dtr["Ma_Loai"] = this.DDLLoai.SelectedValue.Trim();
            dtr["Khong_Su_Dung"] = this.WThuongDung.Text.Trim();
            dt.Rows.Add(dtr);
            if (DBClass.UpdateTable("select * from DM_Chi_Phi where Ma_Chi_Phi = '" + this.WMaCP.Text.Trim() + "'", dt) == true)
            {
                this.LMsg.Text = "Tạo mới thông tin thành công";
                this.MyGrid01.ClearDataSource();
                this.LoadDMChiPhi();
            }
            else
            {
                this.LMsg.Text = "Tạo mới thông tin thất bại, vui lòng kiểm tra lại dữ liệu";
            }
        }
    }

    protected void WIBCapNhat_Click(object sender, EventArgs e)
    {
        DataTable dt = DBClass.GetTable("select * from DM_Chi_Phi where Ma_Chi_Phi = '" + this.WMaCP.Text.Trim() + "'");
        if (dt.Rows.Count > 0)
        {
            DataRow dtr = dt.Rows[0];
            dtr["Ten_Chi_Phi"] = this.WTenCP.Text.Trim();
            dtr["Don_Gia"] = this.WDonGia.Text.Trim();
            dtr["DVT"] = this.WDVT.Text.Trim();
            dtr["Ma_Loai"] = this.DDLLoai.SelectedValue.Trim();
            dtr["Khong_Su_Dung"] = this.WThuongDung.Text.Trim();
            dtr["Ma_Danh_Phap"] = this.WMaDinhMuc.Text.Trim();
            dtr["Loai_NC"] = this.WLoaiNC.Text.Trim();
            if (DBClass.UpdateTable("select * from DM_Chi_Phi where Ma_Chi_Phi = '" + this.WMaCP.Text.Trim() + "'", dt) == true)
            {
                this.LMsg.Text = "Cập nhật thông tin thành công";
                this.MyGrid01.ClearDataSource();
                this.LoadDMChiPhi();
            }
            else
            {
                this.LMsg.Text = "Cập nhật thông tin thất bại, vui lòng kiểm tra lại dữ liệu";
            }
        }
    }

    protected void WIBXoa_Click(object sender, EventArgs e)
    {
        DataTable dt = DBClass.GetTable("select * from DM_Chi_Phi where Ma_Chi_Phi = '" + this.WMaCP.Text.Trim() + "'");
        if (dt.Rows.Count > 0)
        {
            dt.Rows[0].Delete();
            if (DBClass.UpdateTable("select * from DM_Chi_Phi where Ma_Chi_Phi = '" + this.WMaCP.Text.Trim() + "'", dt) == true)
            {
                this.LMsg.Text = "Xóa thông tin thành công";
                this.MyGrid01.ClearDataSource();
                this.LoadDMChiPhi();
            }
            else
            {
                this.LMsg.Text = "Xóa thông tin thất bại, vui lòng kiểm tra lại dữ liệu";
            }
        }
    }

    private void LoadThongTinChiPhi(string mcp)
    {
        DataTable dt = DBClass.GetTable("select * from DM_Chi_Phi where Ma_Chi_Phi = '" + mcp.Trim() + "'");
        if (dt.Rows.Count > 0)
        {
            this.WMaCP.Text = dt.Rows[0]["Ma_Chi_Phi"].ToString().Trim();
            this.WTenCP.Text = dt.Rows[0]["Ten_Chi_Phi"].ToString().Trim();
            this.WDonGia.Text = dt.Rows[0]["Don_Gia"].ToString().Trim();
            this.WDVT.Text = dt.Rows[0]["DVT"].ToString().Trim();
            this.WThuongDung.Text = dt.Rows[0]["Khong_Su_Dung"].ToString().Trim();
            this.WMaDinhMuc.Text = dt.Rows[0]["Ma_Danh_Phap"].ToString().Trim();
            this.WLoaiNC.Text = dt.Rows[0]["Loai_NC"].ToString().Trim();
            this.DDLLoai.SelectedValue = dt.Rows[0]["Ma_Loai"].ToString().Trim();
        }
    }

    private void LoadLoaiCP()
    {
        DataTable dt = DBClass.GetTable("select * from Loai_Chi_Phi order by Ma_Loai asc");
        this.DDLLoai.DataSource = dt;
        this.DDLLoai.DataBind();
    }

    private void LoadTraLoaiCP()
    {
        DataTable dt = DBClass.GetTable("select * from Loai_Chi_Phi order by Ma_Loai asc");
        this.WTraLoaiCP.DataSource = dt;
        this.WTraLoaiCP.DataBind();
    }

    protected void MyGrid01_CellSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedCellEventArgs e)
    {
        if (e.CurrentSelectedCells.Count > 0)
        {
            this.LoadThongTinChiPhi(e.CurrentSelectedCells[0].Row.Items[0].Text.Trim());
        }
    }

    protected void MyGrid01_RowSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
    {
        if (e.CurrentSelectedRows.Count > 0)
        {
            this.LoadThongTinChiPhi(e.CurrentSelectedRows[0].Items[0].Text.Trim());
        }
    }

    protected void MyGrid01_DataFiltered(object sender, Infragistics.Web.UI.GridControls.FilteredEventArgs e)
    {
        this.LoadDMChiPhi();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            this.LoadLoaiCP();
            this.LoadTraLoaiCP();
        }
    }

    protected void BThoat_Click(object sender, EventArgs e)
    {
        this.Response.Redirect(ResolveUrl("~/Chiet_Tinh/Default.aspx"));
    }
}

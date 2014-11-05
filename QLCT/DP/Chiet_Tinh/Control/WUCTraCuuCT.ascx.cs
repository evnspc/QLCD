using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Chiet_Tinh_Control_WUCChietTinh : System.Web.UI.UserControl
{
    public string HienThiNgay(object dt)
    {
        DateTime cd = (DateTime)dt;
        return cd.Day.ToString().Trim() + "/" + cd.Month.ToString().Trim() + "/" + cd.Year.ToString().Trim() + " " + cd.ToShortTimeString();
    }

    public string HienThiLCT(string ct)
    {
        if (ct.Trim() == "0")
        {
            return "Ngành điện chịu chi phí";
        }
        else
        {
            return "Khách hàng chịu chi phí";
        }
    }

    public string LayTenCP(string mavt)
    {
        try
        {
            DataTable dt = DBClass.GetTable("select * from DM_Chi_Phi where ID_Chi_Phi = '" + mavt.Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Ten_Chi_Phi"].ToString().Trim();
            }
        }
        catch { }
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

    protected void BTra_Click(object sender, EventArgs e)
    {
        string strsql = "select BCT.*, KH.Ho_Ten, DMDV.Ten_Don_Vi, LCT.Ten_Loai as Ten_Cong_Tac from DM_Don_Vi DMDV, Nhan_Vien NV, Bang_Chiet_Tinh BCT," +
        " Khach_Hang KH, Loai_Cong_Tac LCT where BCT.Ma_KH = KH.Ma_KH and BCT.Nguoi_Lap = NV.Tai_Khoan and DMDV.Ma_Don_Vi = " +
        "NV.Ma_Don_Vi and DMDV.Ma_Don_Vi = '" + this.LayMaDonViTuTaiKhoan().Trim() + "' and LCT.Ma_Loai = BCT.Loai_Cong_Tac" +
        " and BCT.Ngay_Lap >= '" + ((DateTime)this.WTuNgay.Value).ToShortDateString() + "' and BCT.Ngay_Lap <= '" + ((DateTime)this.WDenNgay.Value).ToShortDateString() + "'";
        if (this.WTraSoVB.Text.Trim().Length > 0)
        {
            strsql = strsql + " and BCT.So_Van_Ban = '" + this.WTraSoVB.Text.Trim() + "-" + LayMaDonViTuTaiKhoan().Trim() + "'";
        }
        if (this.WTraKH.Text.Trim().Length > 0)
        {
            strsql = strsql + " and KH.Ho_Ten like N'%" + this.WTraKH.Text.Trim() + "%'";
        }
        strsql = strsql + " order by BCT.Ngay_Lap desc";
        this.Div_SqlBCT.InnerText = strsql;
        DataTable dt = DBClass.GetTable(strsql);
        this.MyGrid01.DataSource = dt;
        this.MyGrid01.DataBind();
    }

    private void LoadBangChietTinh()
    {
        string strsql = "select BCT.*, KH.Ho_Ten, DMDV.Ten_Don_Vi, LCT.Ten_Loai as Ten_Cong_Tac from DM_Don_Vi DMDV, Nhan_Vien NV, Bang_Chiet_Tinh BCT," +
        " Khach_Hang KH, Loai_Cong_Tac LCT where BCT.Ma_KH = KH.Ma_KH and BCT.Nguoi_Lap = NV.Tai_Khoan and DMDV.Ma_Don_Vi = " +
        "NV.Ma_Don_Vi and DMDV.Ma_Don_Vi = '" + this.LayMaDonViTuTaiKhoan().Trim() + "' and LCT.Ma_Loai = BCT.Loai_Cong_Tac";
        strsql = strsql + " order by BCT.Ngay_Lap desc";
        if (this.Div_SqlBCT.InnerText.Trim().Length > 2)
        {
            strsql = this.Div_SqlBCT.InnerText.Trim();
        }
        DataTable dt = DBClass.GetTable(strsql);
        this.MyGrid01.ClearDataSource();
        this.MyGrid01.DataSource = dt;
        this.MyGrid01.DataBind();
    }

    protected void MyGrid01_DataFiltered(object sender, Infragistics.Web.UI.GridControls.FilteredEventArgs e)
    {
        this.LoadBangChietTinh();
    }

    protected void BCapNhat_Click(object sender, EventArgs e)
    {
        string svb = "";
        if (this.MyGrid01.Behaviors.Selection.SelectedRows.Count > 0)
        {
            svb = this.MyGrid01.Behaviors.Selection.SelectedRows[0].Items[0].Text.Trim();
        }
        else
        {
            if (this.MyGrid01.Behaviors.Selection.SelectedCells.Count > 0)
            {
                svb = this.MyGrid01.Behaviors.Selection.SelectedCells[0].Row.Items[0].Text.Trim();
            }
        }
        if (svb.Trim().Length > 0)
        {
            this.Response.Redirect(ResolveUrl("~/Chiet_Tinh/BangChietTinh.aspx?ID=" + svb.Trim()));
        }
    }

    protected void BXoa_Click(object sender, EventArgs e)
    {
        string svb = "";
        if (this.MyGrid01.Behaviors.Selection.SelectedRows.Count > 0)
        {
            svb = this.MyGrid01.Behaviors.Selection.SelectedRows[0].Items[0].Text.Trim();
        }
        else
        {
            if (this.MyGrid01.Behaviors.Selection.SelectedCells.Count > 0)
            {
                svb = this.MyGrid01.Behaviors.Selection.SelectedCells[0].Row.Items[0].Text.Trim();
            }
        }
        if (svb.Trim().Length > 0)
        {
            DataTable dt = DBClass.GetTable("select * from Bang_Chiet_Tinh where So_Van_Ban = '" + svb.Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                dt.Rows[0].Delete();
                if (DBClass.UpdateTable("select * from Bang_Chiet_Tinh where So_Van_Ban = '" + svb.Trim() + "'", dt) == true)
                {
                    this.LoadBangChietTinh();
                }
            }
        }
    }

    protected void BThoat_Click(object sender, EventArgs e)
    {
        this.Response.Redirect(ResolveUrl("~/Chiet_Tinh/Default.aspx"));
    }

    protected void BCapNhatGia_Click(object sender, EventArgs e)
    {
        try
        {
            string svb = "";
            if (this.MyGrid01.Behaviors.Selection.SelectedRows.Count > 0)
            {
                svb = this.MyGrid01.Behaviors.Selection.SelectedRows[0].Items[0].Text.Trim();
            }
            else
            {
                if (this.MyGrid01.Behaviors.Selection.SelectedCells.Count > 0)
                {
                    svb = this.MyGrid01.Behaviors.Selection.SelectedCells[0].Row.Items[0].Text.Trim();
                }
            }
            if ((DBClass.GetTable("select * from Bang_Chiet_Tinh where So_Van_Ban = '" + svb.Trim() + "' and Ngay_Thu_Tien is null")).Rows.Count > 0)
            {
                if (svb.Trim().Length > 0)
                {
                    DataTable dt = DBClass.GetTable("select * from Chi_Phi where So_Van_Ban = '" + svb.Trim() + "'");
                    DataTable dttemp = DBClass.GetTable("select * from DM_Chi_Phi");

                    DataRow dtrhs = DBClass.LayHeSo(Server.MapPath("~/Chiet_Tinh/Temp.xml"));
                    string qd_vt = "";
                    string qd_nc = "";
                    try
                    {
                        qd_vt = dtrhs["Vat_Tu"].ToString().Trim();
                        qd_nc = dtrhs["Nhan_Cong"].ToString().Trim();
                    }
                    catch { }
                    int i = 0;
                    while (i < dt.Rows.Count)
                    {
                        DataTable dtte = DBClass.GetTable("select * from DM_Chi_Phi where ID_Chi_Phi = " + dt.Rows[i]["ID_Vat_Tu"].ToString().Trim());
                        if (dtte.Rows.Count > 0)
                        {
                            DataRow[] dtrr = dttemp.Select("Ma_Chi_Phi = '" + dtte.Rows[0]["Ma_Chi_Phi"].ToString().Trim() + "' and Ma_Quyet_Dinh = '" + qd_vt.Trim() + "'");
                            if (dtrr.Length > 0)
                            {
                                dt.Rows[i]["ID_Vat_Tu"] = dtrr[0]["ID_Chi_Phi"].ToString().Trim();
                            }
                        }
                        i++;
                    }
                    DBClass.UpdateTable("select * from Chi_Phi where So_Van_Ban = '" + svb.Trim() + "'", dt);
                    this.LThongBao.Text = "Cập nhật giá mới cho bảng chiết tính thành công";
                }
            }
            else
            {
                this.LThongBao.Text = "Bảng chiết tính này đã xuất kho rồi nên không thể cập nhật lại giá";
            }
        }
        catch {
            this.LThongBao.Text = "Cập nhật giá mới cho bảng chiết tính thất bại";
        }
        this.WDWThongBao.WindowState = Infragistics.Web.UI.LayoutControls.DialogWindowState.Normal;
    }

    protected void BQuyetToan_Click(object sender, EventArgs e)
    {
        string svb = "";
        if (this.MyGrid01.Behaviors.Selection.SelectedRows.Count > 0)
        {
            svb = this.MyGrid01.Behaviors.Selection.SelectedRows[0].Items[0].Text.Trim();
        }
        else
        {
            if (this.MyGrid01.Behaviors.Selection.SelectedCells.Count > 0)
            {
                svb = this.MyGrid01.Behaviors.Selection.SelectedCells[0].Row.Items[0].Text.Trim();
            }
        }
        if (svb.Trim().Length > 0)
        {
            this.Response.Redirect(ResolveUrl("~/Chiet_Tinh/QuyetToanVT.aspx?ID=" + svb.Trim()));
        }
    }

    protected void BInChietTinh_Click(object sender, EventArgs e)
    {
        string svb = "";
        if (this.MyGrid01.Behaviors.Selection.SelectedRows.Count > 0)
        {
            svb = this.MyGrid01.Behaviors.Selection.SelectedRows[0].Items[0].Text.Trim();
        }
        else
        {
            if (this.MyGrid01.Behaviors.Selection.SelectedCells.Count > 0)
            {
                svb = this.MyGrid01.Behaviors.Selection.SelectedCells[0].Row.Items[0].Text.Trim();
            }
        }
        if (svb.Trim().Length > 0)
        {
            this.Response.Redirect(ResolveUrl("~/Chiet_Tinh/Report.aspx") + "?ID=" + svb.Trim());
        }
    }

    protected void BBBQuyetToan_Click(object sender, EventArgs e)
    {
        string svb = "";
        if (this.MyGrid01.Behaviors.Selection.SelectedRows.Count > 0)
        {
            svb = this.MyGrid01.Behaviors.Selection.SelectedRows[0].Items[0].Text.Trim();
        }
        else
        {
            if (this.MyGrid01.Behaviors.Selection.SelectedCells.Count > 0)
            {
                svb = this.MyGrid01.Behaviors.Selection.SelectedCells[0].Row.Items[0].Text.Trim();
            }
        }
        if (svb.Trim().Length > 0)
        {
            this.Response.Redirect(ResolveUrl("~/Chiet_Tinh/BBQuyetToan.aspx") + "?ID=" + svb.Trim());
        }
    }
}
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
        try
        {
            DateTime cd = (DateTime)dt;
            return cd.Day.ToString().Trim() + "/" + cd.Month.ToString().Trim() + "/" + cd.Year.ToString().Trim();
        }
        catch {
            return "";
        }
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

    public string HienThiTinhTrang(string ct)
    {
        if (ct.Trim() == "0")
        {
            return "Chưa thanh toán";
        }
        else
        {
            return "Đã thanh toán";
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
        "NV.Ma_Don_Vi and DMDV.Ma_Don_Vi = '" + this.LayMaDonViTuTaiKhoan().Trim() + "' and LCT.Ma_Loai = BCT.Loai_Cong_Tac";
        if (this.WTraSoVB.Text.Trim().Length > 0)
        {
            strsql = strsql + " and BCT.So_Van_Ban like N'%" + this.WTraSoVB.Text.Trim() + "%'";
        }
        if (this.WTraKH.Text.Trim().Length > 0)
        {
            strsql = strsql + " and KH.Ho_Ten like N'%" + this.WTraKH.Text.Trim() + "%'";
        }
        DateTime tungay = (DateTime)this.WDTuNgay.Value;
        DateTime denngay = (DateTime)this.WDDenNgay.Value;
        tungay = tungay.AddDays(-1);
        denngay = denngay.AddDays(1);
        strsql = strsql + " and BCT.Ngay_Lap > '" + tungay.ToShortDateString() + "' and BCT.Ngay_Lap < '" + denngay.ToShortDateString() + "'";
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
        if (this.MyGrid01.Behaviors.Selection.SelectedRows.Count > 0)
        {
            string strsql = "select * from Bang_Chiet_Tinh where So_Van_Ban = '" + this.MyGrid01.Behaviors.Selection.SelectedRows[0].Items[0].Text.Trim() + "'";
            int i = 1;
            while (i < this.MyGrid01.Behaviors.Selection.SelectedRows.Count)
            {
                strsql = strsql + " or So_Van_Ban = '" + this.MyGrid01.Behaviors.Selection.SelectedRows[i].Items[0].Text.Trim() + "'";
                i = i + 1;
            }
            DataTable dt = DBClass.GetTable(strsql);
            if (dt.Rows.Count > 0)
            {
                i = 0;
                while (i < dt.Rows.Count)
                {
                    dt.Rows[i]["Ngay_Thu_Tien"] = this.WNgayThuTien.Value;
                    i = i + 1;
                }
                DBClass.UpdateTable(strsql, dt);
                this.LoadBangChietTinh();
            }
        }
        else
        {
            if (this.MyGrid01.Behaviors.Selection.SelectedCells.Count > 0)
            {
                string strsql = "select * from Bang_Chiet_Tinh where So_Van_Ban = '" + this.MyGrid01.Behaviors.Selection.SelectedCells[0].Row.Items[0].Text.Trim() + "'";
                int i = 1;
                while (i < this.MyGrid01.Behaviors.Selection.SelectedCells.Count)
                {
                    strsql = strsql + " or So_Van_Ban = '" + this.MyGrid01.Behaviors.Selection.SelectedCells[0].Row.Items[0].Text.Trim() + "'";
                    i = i + 1;
                }
                DataTable dt = DBClass.GetTable(strsql);
                if (dt.Rows.Count > 0)
                {
                    i = 0;
                    while (i < dt.Rows.Count)
                    {
                        dt.Rows[i]["Ngay_Thu_Tien"] = this.WNgayThuTien.Value;
                        i = i + 1;
                    }
                    DBClass.UpdateTable(strsql, dt);
                    this.LoadBangChietTinh();
                }
            }
        }        
    }

    protected void BThoat_Click(object sender, EventArgs e)
    {
        this.Response.Redirect(ResolveUrl("~/Chiet_Tinh/Default.aspx"));
    }

    protected void BChuaTT_Click(object sender, EventArgs e)
    {
        if (this.MyGrid01.Behaviors.Selection.SelectedRows.Count > 0)
        {
            string strsql = "select * from Bang_Chiet_Tinh where So_Van_Ban = '" + this.MyGrid01.Behaviors.Selection.SelectedRows[0].Items[0].Text.Trim() + "'";
            int i = 1;
            while (i < this.MyGrid01.Behaviors.Selection.SelectedRows.Count)
            {
                strsql = strsql + " or So_Van_Ban = '" + this.MyGrid01.Behaviors.Selection.SelectedRows[i].Items[0].Text.Trim() + "'";
                i = i + 1;
            }
            DataTable dt = DBClass.GetTable(strsql);
            if (dt.Rows.Count > 0)
            {
                i = 0;
                while (i < dt.Rows.Count)
                {
                    dt.Rows[i]["Ngay_Thu_Tien"] = DBNull.Value;
                    i = i + 1;
                }
                DBClass.UpdateTable(strsql, dt);
                this.LoadBangChietTinh();
            }
        }
        else
        {
            if (this.MyGrid01.Behaviors.Selection.SelectedCells.Count > 0)
            {
                string strsql = "select * from Bang_Chiet_Tinh where So_Van_Ban = '" + this.MyGrid01.Behaviors.Selection.SelectedCells[0].Row.Items[0].Text.Trim() + "'";
                int i = 1;
                while (i < this.MyGrid01.Behaviors.Selection.SelectedCells.Count)
                {
                    strsql = strsql + " or So_Van_Ban = '" + this.MyGrid01.Behaviors.Selection.SelectedCells[0].Row.Items[0].Text.Trim() + "'";
                    i = i + 1;
                }
                DataTable dt = DBClass.GetTable(strsql);
                if (dt.Rows.Count > 0)
                {
                    i = 0;
                    while (i < dt.Rows.Count)
                    {
                        dt.Rows[i]["Ngay_Thu_Tien"] = DBNull.Value;
                        i = i + 1;
                    }
                    DBClass.UpdateTable(strsql, dt);
                    this.LoadBangChietTinh();
                }
            }
        }        
    }
}
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
            return "Ngành điện đầu tư";
        }
        else
        {
            return "Khách hàng đầu tư";
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

    private Boolean KiemTraSoVB(string svb)
    {
        DataTable dt = DBClass.GetTable("select * from Bang_Chiet_Tinh bct, Nhan_Vien nv where bct.So_Van_Ban = '" + svb.Trim() + "' and nv.Tai_Khoan = bct.Nguoi_Lap and nv.Ma_Don_Vi = '" + this.LayMaDonViTuTaiKhoan() + "'");
        if (dt.Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private Boolean KiemTraThucXuat(string svb)
    {
        DataTable dt = DBClass.GetTable("select * from Bang_Chiet_Tinh bct, Nhan_Vien nv where bct.So_Van_Ban = '" + svb.Trim() + "' and nv.Tai_Khoan = bct.Nguoi_Lap and nv.Ma_Don_Vi = '" + this.LayMaDonViTuTaiKhoan() + "'");
        try
        {
            if (dt.Rows[0]["Ngay_Thu_Tien"].ToString().Trim().Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }catch
        {
            return false;
        }
    }

    protected void BTra_Click(object sender, EventArgs e)
    {
        string cud = "-" + DateTime.Now.Year.ToString();
        if (this.WTraSoVB.Text.IndexOf(",") < 0)
        {
            if (KiemTraSoVB(this.WTraSoVB.Text.Trim() + "-" + this.LayMaDonViTuTaiKhoan().Trim() + cud))
            {
                if (this.KiemTraThucXuat(this.WTraSoVB.Text.Trim() + "-" + this.LayMaDonViTuTaiKhoan().Trim() + cud) == false)
                {
                    try
                    {
                        ListBox lb = (ListBox)Session["Temp_BCT"];
                        if (KiemTraTonTai(this.WTraSoVB.Text.Trim() + "-" + this.LayMaDonViTuTaiKhoan().Trim() + cud, lb) == false)
                        {
                            lb.Items.Add(new ListItem("A", this.WTraSoVB.Text.Trim() + "-" + this.LayMaDonViTuTaiKhoan().Trim() + cud));
                            this.LoadBangChietTinh();
                        }
                    }
                    catch
                    {
                        ListBox lb = new ListBox();
                        lb.Items.Add(new ListItem("A", this.WTraSoVB.Text.Trim() + "-" + this.LayMaDonViTuTaiKhoan().Trim() + cud));
                        Session["Temp_BCT"] = lb;
                        this.LoadBangChietTinh();
                    }
                }
                else
                {
                    this.WMSG.InnerText = "Bảng chiết tính này đã có ngày thực xuất rồi không thể chọn nữa, vui lòng kiểm tra lại.";
                    this.WebDialogWindow2.WindowState = Infragistics.Web.UI.LayoutControls.DialogWindowState.Normal;
                }
            }
        }
        else
        {
            string[] msvb = this.WTraSoVB.Text.Trim().Split(',');
            this.WMSG.InnerText = "Các Bảng chiết tính số:";
            Boolean co = false;
            int i = 0;
            while (i < msvb.Length)
            {
                if (KiemTraSoVB(msvb[i].Trim() + "-" + this.LayMaDonViTuTaiKhoan().Trim() + cud))
                {
                    if (this.KiemTraThucXuat(msvb[i].Trim() + "-" + this.LayMaDonViTuTaiKhoan().Trim() + cud) == false)
                    {
                        try
                        {
                            ListBox lb = (ListBox)Session["Temp_BCT"];
                            if (KiemTraTonTai(msvb[i].Trim() + "-" + this.LayMaDonViTuTaiKhoan().Trim() + cud, lb) == false)
                            {
                                lb.Items.Add(new ListItem("A", msvb[i].Trim() + "-" + this.LayMaDonViTuTaiKhoan().Trim() + cud));                                
                            }
                        }
                        catch
                        {
                            ListBox lb = new ListBox();
                            lb.Items.Add(new ListItem("A", msvb[i].Trim() + "-" + this.LayMaDonViTuTaiKhoan().Trim() + cud));
                            Session["Temp_BCT"] = lb;                            
                        }
                    }
                    else
                    {
                        if (co)
                        {
                            this.WMSG.InnerText = this.WMSG.InnerText + ", " + msvb[i].Trim(); 
                        }
                        else
                        {
                            co = true;
                            this.WMSG.InnerText = this.WMSG.InnerText + " " + msvb[i].Trim(); 
                        }
                    }
                }
                i = i + 1;
            }
            this.WMSG.InnerText = this.WMSG.InnerText + " này đã có ngày thực xuất rồi không thể chọn nữa, vui lòng kiểm tra lại.";
            if (co)
            {
                this.WebDialogWindow2.WindowState = Infragistics.Web.UI.LayoutControls.DialogWindowState.Normal;
            }
            this.LoadBangChietTinh();
        }
    }

    private Boolean KiemTraTonTai(string svb, ListBox lb)
    {
        int i = 0;
        while (i < lb.Items.Count)
        {
            if (lb.Items[i].Value.Trim() == svb.Trim())
            {
                return true;
            }
            i = i + 1;
        }
        return false;
    }

    private void LoadBangChietTinh()
    {
        string strsql = "select BCT.*, KH.Ho_Ten, DMDV.Ten_Don_Vi, LCT.Ten_Loai as Ten_Cong_Tac from DM_Don_Vi DMDV, Nhan_Vien NV, Bang_Chiet_Tinh BCT," +
        " Khach_Hang KH, Loai_Cong_Tac LCT where ( BCT.Ma_KH = KH.Ma_KH and BCT.Nguoi_Lap = NV.Tai_Khoan and DMDV.Ma_Don_Vi = " +
        "NV.Ma_Don_Vi and DMDV.Ma_Don_Vi = '" + this.LayMaDonViTuTaiKhoan().Trim() + "' and LCT.Ma_Loai = BCT.Loai_Cong_Tac )";
        try
        {
            ListBox lb = (ListBox)Session["Temp_BCT"];
            if (lb.Items.Count > 0)
            {
                strsql = strsql + " and ( BCT.So_Van_Ban = '" + lb.Items[0].Value.Trim() + "'";
                int i = 1;
                while (i < lb.Items.Count)
                {
                    strsql = strsql + " or BCT.So_Van_Ban = '" + lb.Items[i].Value.Trim() + "'";
                    i = i + 1;
                }
            }
            strsql = strsql + ") order by BCT.Ngay_Lap desc";
            DataTable dt = DBClass.GetTable(strsql);
            this.MyGrid01.ClearDataSource();
            this.MyGrid01.DataSource = dt;
            this.MyGrid01.DataBind();
        }
        catch { }
    }
        
    protected void BCapNhat_Click(object sender, EventArgs e)
    {
        string strsql = "select * from Bang_Chiet_Tinh where";
        try
        {
            ListBox lb = (ListBox)Session["Temp_BCT"];
            if (lb.Items.Count > 0)
            {
                strsql = strsql + " So_Van_Ban = '" + lb.Items[0].Value.Trim() + "'";
                int i = 1;
                while (i < lb.Items.Count)
                {
                    strsql = strsql + " or So_Van_Ban = '" + lb.Items[i].Value.Trim() + "'";
                    i = i + 1;
                }
            }
            strsql = strsql + " order by Ngay_Lap desc";
            DataTable dt = DBClass.GetTable(strsql);
            int j = 0;
            while (j < dt.Rows.Count)
            {
                dt.Rows[j]["Ngay_Thu_Tien"] = this.WNgayThuTien.Value;
                j = j + 1;
            }
            DBClass.UpdateTable(strsql,dt);
            
            this.Response.Redirect(ResolveUrl("~/Chiet_Tinh/CRBaoCaoCP01.aspx"));
        }
        catch { }    
    }

    protected void BThoat_Click(object sender, EventArgs e)
    {
        this.Response.Redirect(ResolveUrl("~/Chiet_Tinh/Default.aspx"));
    }

    protected void BXoaChon_Click(object sender, EventArgs e)
    {
        if (this.MyGrid01.Behaviors.Selection.SelectedRows.Count > 0)
        {
            int i = 0;
            while (i < this.MyGrid01.Behaviors.Selection.SelectedRows.Count)
            {
                this.XoaTonTai(this.MyGrid01.Behaviors.Selection.SelectedRows[i].Items[0].Text.Trim());
                i = i + 1;
            }
        }
        else
        {
            if (this.MyGrid01.Behaviors.Selection.SelectedCells.Count > 0)
            {
                int i = 0;
                while (i < this.MyGrid01.Behaviors.Selection.SelectedCells.Count)
                {
                    this.XoaTonTai(this.MyGrid01.Behaviors.Selection.SelectedCells[i].Row.Items[0].Text.Trim());
                    i = i + 1;
                }
            }
        }
        this.LoadBangChietTinh();
    }

    private void XoaTonTai(string svb)
    {
        try
        {
            ListBox lb = (ListBox)Session["Temp_BCT"];
            int i = 0;
            while (i < lb.Items.Count)
            {
                if (lb.Items[i].Value.Trim() == svb.Trim())
                {
                    lb.Items.RemoveAt(i);
                }
                i = i + 1;
            }
            Session["Temp_BCT"]=lb;
        }
        catch { }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            Session["Temp_BCT"] = null;
        }
    }

    public void Redirect(string url, string target, string windowFeatures)
    { 
        HttpContext context = HttpContext.Current; 
        if ((String.IsNullOrEmpty(target) || target.Equals("_self", StringComparison.OrdinalIgnoreCase)) && String.IsNullOrEmpty(windowFeatures)) 
        { 
            context.Response.Redirect(url);
        }else{ 
            Page page = (Page)context.Handler; 
            if (page == null) { 
                throw new InvalidOperationException("Cannot redirect to new window outside Page context.");
            } 
            url = page.ResolveClientUrl(url); 
            string script; 
            if (!String.IsNullOrEmpty(windowFeatures)) { 
                script = @"window.open(""{0}"", ""{1}"", ""{2}"");"; 
            } else { 
                script = @"window.open(""{0}"", ""{1}"");"; 
            } 
            script = String.Format(script, url, target, windowFeatures); 
            ScriptManager.RegisterStartupScript(page, typeof(Page), "Redirect", script, true); 
        } 
    }
}
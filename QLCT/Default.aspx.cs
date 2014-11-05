using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            Infragistics.Web.UI.Framework.AppStyling.AppStylingManager.Settings.StyleSetName = "Windows7";
            KhoiTaoDuLieu();
        }
    }

    private Boolean KiemTraTK()
    {
        MaHoaII.MaHoaWeb mh = new MaHoaII.MaHoaWeb();
        string ps = mh.MaHoa_Link.Clock(this.WMatKhau.Text);
        DataTable dt = DBClass.GetTable("select * from Nhan_Vien where Tai_Khoan = '" + this.WTaiKhoan.Text.Trim() + "'");
        int i = 0;
        while (i<dt.Rows.Count)
        {
            if (dt.Rows[i]["Mat_Khau"].ToString().Trim() == ps)
            {
                Session["Nhan_Vien"] = this.WTaiKhoan.Text.Trim();
                this.Response.Redirect(ResolveUrl("~/Chiet_Tinh/Default.aspx"));
                return true;
            }
            i = i + 1;
        }
        return false;
    }

    protected void WIBDangNhap_Click(object sender, EventArgs e)
    {
        Boolean kq = this.KiemTraTK();
        if (kq == false)
        {
            this.LMsg.Text = "Tài khoản hay mật khẩu không phù hợp";
        }
    }

    private void KhoiTaoDuLieu()
    {
        string vt = "";
        string nc = "";
        string hs = "";
        try
        {
            try
            {
                DataRow dtr = DBClass.LayHeSo(Server.MapPath("~/Chiet_Tinh/Temp.xml"));
                vt = dtr["Vat_Tu"].ToString().Trim();
                nc = dtr["Nhan_Cong"].ToString().Trim();
                hs = dtr["He_So"].ToString().Trim();
            }
            catch { }
            DataTable dt = DBClass.GetTable("select * from QDAD");
            if (dt.Rows.Count > 0)
            {
                if ((vt != dt.Rows[0]["Vat_Tu"].ToString().Trim()) || (nc != dt.Rows[0]["Nhan_Cong"].ToString().Trim()) || (hs != dt.Rows[0]["He_So"].ToString().Trim()))
                {
                    try
                    {
                        DBClass.LuuHeSo(dt.Rows[0]["Vat_Tu"].ToString().Trim(), dt.Rows[0]["Nhan_Cong"].ToString().Trim(), dt.Rows[0]["He_So"].ToString().Trim(), Server.MapPath("~/Chiet_Tinh/Temp.xml"));
                    }
                    catch
                    { }
                }
            }
        }
        catch { }
    }
}

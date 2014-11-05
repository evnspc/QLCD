using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NhanVien_NVMasterPage : DLMasterPage
{
    public override void DKPostBack(Control ct)
    {
        this.WebScriptManager1.RegisterPostBackControl(ct);
        base.DKPostBack(ct);
    }

    private void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.Link_HD.HRef = ResolveUrl("~/hdqlct.pdf");
            if (Session["Nhan_Vien"].ToString().Trim().Length < 1)
            {
                this.Response.Redirect(ResolveUrl("~/Default.aspx"));
            }
        }
        catch
        {
            this.Response.Redirect(ResolveUrl("~/Default.aspx"));
        }

        if (this.Menu_Main.Controls.Count < 1)
        {
            Infragistics.Web.UI.Framework.AppStyling.AppStylingManager.Settings.StyleSetName = "Windows7";
            DataTable dt = DBClass.GetTable("select * from Nhan_Vien where Tai_Khoan = '" + Session["Nhan_Vien"].ToString().Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                Control ct;
                switch (dt.Rows[0]["Loai_Tai_Khoan"].ToString().Trim())
                {
                    case "0":
                        ct = LoadControl(ResolveUrl("Control/WUCMenuNV.ascx"));
                        this.Menu_Main.Controls.Add(ct);
                        break;
                    case "1":
                        ct = LoadControl(ResolveUrl("Control/WUCMenuNVQL.ascx"));
                        this.Menu_Main.Controls.Add(ct);
                        break;
                    case "2":
                        ct = LoadControl(ResolveUrl("Control/WUCMenuLD.ascx"));
                        this.Menu_Main.Controls.Add(ct);
                        break;
                    case "3":
                        ct = LoadControl(ResolveUrl("Control/WUCMenuQTV.ascx"));
                        this.Menu_Main.Controls.Add(ct);
                        break;
                    case "4":
                        ct = LoadControl(ResolveUrl("Control/WUCMenuNVVT.ascx"));
                        this.Menu_Main.Controls.Add(ct);
                        break;
                }
            }
        }
    }
}
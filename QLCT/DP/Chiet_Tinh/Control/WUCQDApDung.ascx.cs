using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;

public partial class Chiet_Tinh_Control_WUCDMDonVi : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            KhoiTaoDuLieu();
        }
    }

    private void KhoiTaoDuLieu()
    {
        DataTable dt = DBClass.GetTable("select * from Quyet_Dinh order by Ngay_Thang desc, Ten_Quyet_Dinh asc");
        this.DDLQDVT.DataSource = dt;
        this.DDLQDVT.DataBind();

        this.DDLQDNC.DataSource = dt;
        this.DDLQDNC.DataBind();

        this.DDLQDHS.DataSource = dt;
        this.DDLQDHS.DataBind();

        string vt = "";
        string nc = "";
        string hs = "";        

        try
        {
            DataRow dtr = DBClass.LayHeSo(Server.MapPath("~/Chiet_Tinh/Temp.xml"));
            vt = dtr["Vat_Tu"].ToString().Trim();
            nc = dtr["Nhan_Cong"].ToString().Trim();
            hs = dtr["He_So"].ToString().Trim();
        }
        catch { }
        this.DDLQDVT.SelectedValue = vt;
        this.DDLQDNC.SelectedValue = nc;
        this.DDLQDHS.SelectedValue = hs;
    }

    protected void WIBCapNhat_Click(object sender, EventArgs e)
    {
        try
        {
            DBClass.LuuHeSo(this.DDLQDVT.SelectedValue.Trim(),this.DDLQDNC.SelectedValue.Trim(),this.DDLQDHS.SelectedValue.Trim(),Server.MapPath("~/Chiet_Tinh/Temp.xml"));
            DataTable dt = DBClass.GetTable("select * from QDAD");
            if (dt.Rows.Count > 0)
            {
                dt.Rows[0]["Vat_Tu"] = this.DDLQDVT.SelectedValue.Trim();
                dt.Rows[0]["Nhan_Cong"] = this.DDLQDNC.SelectedValue.Trim();
                dt.Rows[0]["He_So"] = this.DDLQDHS.SelectedValue.Trim();
                DBClass.UpdateTable("select * from QDAD", dt);
            }
            this.LMsg.Text = "Cập nhật hoàn thành";
        }
        catch {
            this.LMsg.Text = "Cập nhật thất bại";
        }
    }
}

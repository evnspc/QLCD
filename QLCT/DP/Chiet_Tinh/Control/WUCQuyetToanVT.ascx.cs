using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Chiet_Tinh_Control_WUCChietTinh : System.Web.UI.UserControl
{
    
    public string LayTenCP(string mavt)
    {
        try
        {
            DataTable dt = DBClass.GetTable("select * from DM_Chi_Phi where Ma_Chi_Phi = '" + mavt.Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Ten_Chi_Phi"].ToString().Trim();
            }
        }
        catch { }
        return "";
    }

    private void LoadChietTinh()
    {
        if (this.Div_SqlCT.InnerText.Trim().Length > 2)
        {
            DataTable dt = DBClass.GetTable(this.Div_SqlCT.InnerText.Trim());
            this.MyGrid02.DataSource = dt;
            this.MyGrid02.DataBind();
        }
        else
        {
            string strsql = "select * from Chi_Phi where Ma_Loai = '1' and So_Van_Ban = '" + this.WSoVanBan.Text.Trim() + "'"; 
            this.Div_SqlCT.InnerText = strsql;
            DataTable dttemp = DBClass.GetTable(strsql);
            this.MyGrid02.DataSource = dttemp;
            this.MyGrid02.DataBind();
        }
        
    }

    private void LoadThongTinBangChietTinh()
    {
        try
        {
            if (this.Request.QueryString["ID"].ToString().Trim().Length > 0)
            {
                DataTable dt = DBClass.GetTable("select bct.*, kh.Ho_Ten from Bang_Chiet_Tinh bct, Khach_Hang kh where bct.Ma_KH = kh.Ma_KH and So_Van_Ban = '" + this.Request.QueryString["ID"].ToString().Trim() + "'");
                if (dt.Rows.Count > 0)
                {
                    this.WSoVanBan.Text = dt.Rows[0]["So_Van_Ban"].ToString().Trim();
                    this.WTenKhachHang.Text = dt.Rows[0]["Ho_Ten"].ToString().Trim();
                    LoadChietTinh();
                }
            }
        }
        catch { }
    }
      
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (this.IsPostBack == false)
        {
            this.LoadThongTinBangChietTinh();            
        }
    }
    
    protected void BLuuBCT_Click(object sender, EventArgs e)
    {
        this.UpdateCP();
    }

    protected void BThoat_Click(object sender, EventArgs e)
    {
        this.Response.Redirect(ResolveUrl("~/Chiet_Tinh/Default.aspx"));
    }

    private void UpdateCP()
    {
        int i = 0;
        string sqlstr = "select * from Chi_Phi where ( So_Van_Ban = '" + this.WSoVanBan.Text.Trim() + "' )";
        Boolean cpkq = false;
        while (i < this.MyGrid02.Rows.Count)
        {
            if (cpkq)
            {
                sqlstr = sqlstr + " or Ma_Chi_Phi = '" + ((Label)this.MyGrid02.Rows[i].FindControl("LIDVT")).Text + "'";
            }
            else
            {
                sqlstr = sqlstr + " and ( Ma_Chi_Phi = '" + ((Label)this.MyGrid02.Rows[i].FindControl("LIDVT")).Text + "'";
                cpkq = true;
            }
            i++;
        }
        if (cpkq)
        {
            sqlstr = sqlstr + " )";
            DataTable dt = DBClass.GetTable(sqlstr);
            DataTable dtdgvt = DBClass.GetTable("select Ma_Chi_Phi, Don_Gia from DM_Chi_Phi where Ma_Loai = '1'");
            int j = 0;
            while (j < this.MyGrid02.Rows.Count)
            {
                string idvt = ((Label)this.MyGrid02.Rows[j].FindControl("LIDVT")).Text;
                string qtvt = ((TextBox)this.MyGrid02.Rows[j].FindControl("QTVT")).Text;
                i = 0;
                while (i < dt.Rows.Count)
                {
                    if (idvt.Trim()==dt.Rows[i]["Ma_Chi_Phi"].ToString().Trim())
                    {
                        try
                        {
                            dt.Rows[i]["Quyet_Toan"] = qtvt;
                        }
                        catch {
                            dt.Rows[i]["Quyet_Toan"] = 0;
                        }
                        break;
                    }
                    i++;
                }
                j++;
            }
            DBClass.UpdateTable(sqlstr, dt);
            this.LoadChietTinh();
        }
    }

    protected void BInChietTinh_Click(object sender, EventArgs e)
    {
        this.Response.Redirect(ResolveUrl("~/Chiet_Tinh/ReportQTVT.aspx") + "?ID=" + this.WSoVanBan.Text.Trim());
    }
}

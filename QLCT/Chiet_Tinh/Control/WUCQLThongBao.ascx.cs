using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Chiet_Tinh_Control_WUCDMDonVi : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            this.CKThongTin.Text = File.ReadAllText(Server.MapPath("~/Chiet_Tinh/TB.txt"));
        }
    }
        
    protected void BCapNhat_Click(object sender, EventArgs e)
    {
        File.WriteAllText(Server.MapPath("~/Chiet_Tinh/TB.txt"), this.CKThongTin.Text);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChamSocVien_Control_WUCMenuPage : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime cd = DateTime.Now.ToUniversalTime().AddHours(7);
        this.Div_Ngay.InnerText = "Hôm nay: " + cd.Day.ToString().Trim() + "/" + cd.Month.ToString().Trim() + "/" + cd.Year.ToString().Trim() + " - " + cd.ToShortTimeString().Trim();
    }

}

using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

public partial class Chiet_Tinh_Control_WUCReport : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (this.Request.QueryString["ID"].ToString().Trim().Length > 0)
            {
                LapBangQTVT(this.Request.QueryString["ID"].ToString().Trim());
            }
        }
        catch { }
    }

    private void LapBangQTVT(string svb)
    {
        DataSet1 ds = new DataSet1();
        DataTable dtbct = DBClass.GetTable("select BCT.So_Van_Ban, KH.Ho_Ten, KH.Dia_Chi from Bang_Chiet_Tinh BCT, Khach_Hang KH where KH.Ma_KH = BCT.Ma_KH and BCT.So_Van_Ban = '" + svb.Trim() + "'");
        if (dtbct.Rows.Count > 0)
        {
            DataRow dtr = ds.QT_BCT.NewRow();
            dtr["So_Van_Ban"] = dtbct.Rows[0]["So_Van_Ban"].ToString().Trim().Replace("-","/CT-").Replace("D","Đ");;
            dtr["Ho_Ten"] = dtbct.Rows[0]["Ho_Ten"].ToString().Trim();
            dtr["Dia_Chi"] = dtbct.Rows[0]["Dia_Chi"].ToString().Trim();
            ds.QT_BCT.Rows.Add(dtr);
            ds.QT_BCT.AcceptChanges();
        }

        DBClass.GetTable("select DMCP.Ten_Chi_Phi, DMCP.DVT, CP.So_Luong, CP.So_Luong_KH, CP.Quyet_Toan from Chi_Phi CP, DM_Chi_Phi DMCP where CP.Ma_Chi_Phi = DMCP.Ma_Chi_Phi and CP.Ma_Loai = '1' and CP.So_Van_Ban = '" + svb.Trim() + "'", ds.QT_VT);

        this.CRQTVT.ReportDocument.SetDataSource((DataSet)ds);
        this.CRQTVT.ReportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, svb.Trim());
    }
}

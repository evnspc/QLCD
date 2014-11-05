using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

public partial class Chiet_Tinh_Control_WUCReport : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LapBangDanhMuc();
    }
    
    private void LapBangDanhMuc()
    {

        DataSet1 ds = new DataSet1();
        DBClass.GetTable("select Ma_Chi_Phi, Ten_Chi_Phi, Don_Gia from DM_Chi_Phi order by Ma_Loai asc, Ten_Chi_Phi asc", ds.DM_CP);
        
        //this.CRV1.ReportSource = this.CRSND;
        this.CRSND.ReportDocument.SetDataSource((DataSet)ds);
        //this.CRV1.RefreshReport();
        this.CRSND.ReportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "BaoCao");
    }

    protected void BLuuBC_Click(object sender, EventArgs e)
    {
        ExportFormatType tf;
        switch (this.DDLLoaiFile.SelectedValue.Trim())
        {
            case "PDF":
                tf = ExportFormatType.PortableDocFormat;
                break;
            case "DOC":
                tf = ExportFormatType.WordForWindows;
                break;
            case "XLS":
                tf = ExportFormatType.Excel;
                break;
            default:
                tf = ExportFormatType.PortableDocFormat;
                break;
        }
        this.CRSND.ReportDocument.ExportToHttpResponse(tf, Response, false, "BaoCao");
    }
}

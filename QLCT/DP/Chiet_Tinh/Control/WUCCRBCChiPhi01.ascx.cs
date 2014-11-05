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
    private void LapBaoCao()
    {
        try
        {
            if (Session["Nhan_Vien"].ToString().Trim().Length > 0)
            {
                DataTable dt = DBClass.GetTable("select nv.Ma_Don_Vi, nv.Ho_Ten, dmdv.Ten_Don_Vi from Nhan_Vien nv, DM_Don_Vi dmdv where nv.Ma_Don_Vi = dmdv.Ma_Don_Vi and nv.Tai_Khoan = '" + Session["Nhan_Vien"].ToString().Trim() + "'");
                DataSet1 ds = new DataSet1();
                DateTime cd = DateTime.Now.ToUniversalTime().AddHours(7);                
                DataRow dtr = ds.Tieu_De_BC_CP.NewRow();
                dtr["Tieu_De"] = "BÁO CÁO THỐNG KÊ VẬT TƯ";
                dtr["Thoi_Gian"] = "";
                dtr["Ngay_Lap"] = "Ngày " + cd.Day.ToString().Trim() + " Tháng " + cd.Month.ToString().Trim() + " Năm " + cd.Year.ToString().Trim();
                dtr["Nguoi_Lap"] = dt.Rows[0]["Ho_Ten"].ToString().Trim();
                dtr["Ten_Don_Vi"] = dt.Rows[0]["Ten_Don_Vi"].ToString().Trim();
                ds.Tieu_De_BC_CP.Rows.Add(dtr);
                ds.Tieu_De_BC_CP.AcceptChanges();

                string strsqlcp, strsqlbct = "";
                strsqlcp = "select dmcp.Ma_Danh_Phap as Ma_Chi_Phi, dmcp.Ten_Chi_Phi, dmcp.DVT, Sum(cp.So_Luong) as So_Luong from Nhan_Vien nv, Bang_Chiet_Tinh bct, DM_Chi_Phi dmcp, Chi_Phi cp where nv.Tai_Khoan = bct.Nguoi_Lap and bct.So_Van_Ban = cp.So_Van_Ban and cp.ID_Vat_Tu = dmcp.ID_Chi_Phi and nv.Ma_Don_Vi = '" + dt.Rows[0]["Ma_Don_Vi"].ToString().Trim() + "' and dmcp.Ma_Danh_Phap <> 'NULL'";
                
                strsqlbct = "select nv.Ma_Don_Vi, bct.Ngay_Lap, nv.Ho_Ten as Nguoi_Lap, bct.So_Van_Ban, kh.Ho_Ten as Khach_Hang from Bang_Chiet_Tinh bct, Khach_Hang kh, Nhan_Vien nv where bct.Nguoi_Lap = nv.Tai_Khoan and bct.Ma_KH = kh.Ma_KH and nv.Ma_Don_Vi = '" + dt.Rows[0]["Ma_Don_Vi"].ToString().Trim() + "'";

                ListBox lb = (ListBox)Session["Temp_BCT"];
                if (lb.Items.Count > 0)
                {
                    strsqlcp = strsqlcp + " and ( bct.So_Van_Ban = '" + lb.Items[0].Value.Trim() + "'";
                    strsqlbct = strsqlbct + " and ( bct.So_Van_Ban = '" + lb.Items[0].Value.Trim() + "'";
                    int i = 1;
                    while (i < lb.Items.Count)
                    {
                        strsqlcp = strsqlcp + " or bct.So_Van_Ban = '" + lb.Items[i].Value.Trim() + "'";
                        strsqlbct = strsqlbct + " or bct.So_Van_Ban = '" + lb.Items[i].Value.Trim() + "'";
                        i = i + 1;
                    }
                    strsqlcp = strsqlcp + " )";
                    strsqlbct = strsqlbct + " )";
                }

                strsqlcp = strsqlcp + " group by dmcp.Ma_Danh_Phap, dmcp.Ten_Chi_Phi, dmcp.DVT";
                strsqlbct = strsqlbct + "  order by bct.Ngay_Lap desc";
                
                DataTable dttemp = DBClass.GetTable(strsqlcp);
                
                DataTableReader dtrr = dttemp.CreateDataReader();
                while (dtrr.Read())
                {
                    DataRow dtcp = ds.BC_Chi_Phi.NewRow();
                    dtcp["Ma_Chi_Phi"] = dtrr["Ma_Chi_Phi"].ToString().Trim();
                    dtcp["Ten_Chi_Phi"] = dtrr["Ten_Chi_Phi"].ToString().Trim();
                    dtcp["So_Luong"] = double.Parse(dtrr["So_Luong"].ToString().Trim());
                    dtcp["DVT"] = dtrr["DVT"].ToString().Trim();
                    ds.BC_Chi_Phi.Rows.Add(dtcp);
                }
                ds.BC_Chi_Phi.AcceptChanges();

                DataTable dtbct = DBClass.GetTable(strsqlbct);
                DataTableReader dtrrbct = dtbct.CreateDataReader();
                while (dtrrbct.Read())
                {
                    DateTime nl = (DateTime)dtrrbct["Ngay_Lap"];
                    string strnl = nl.Day.ToString().Trim() + "/" + nl.Month.ToString().Trim() + "/" + nl.Year.ToString().Trim();
                    DataRow drtbct = ds.BC_BCT.NewRow();
                    drtbct["So_Van_Ban"] = dtrrbct["So_Van_Ban"].ToString().Trim().Replace("-", "/CT-").Replace("D", "Đ");
                    drtbct["Khach_Hang"] = dtrrbct["Khach_Hang"].ToString().Trim();
                    drtbct["Ngay_Lap"] = strnl;
                    drtbct["Nguoi_Lap"] = dtrrbct["Nguoi_Lap"].ToString().Trim();
                    ds.BC_BCT.Rows.Add(drtbct);
                }
                ds.BC_BCT.AcceptChanges();

                this.CRV1.ReportSource = this.CRSND;
                this.CRSND.ReportDocument.SetDataSource((DataSet)ds);
                this.CRV1.RefreshReport();
            }
        }
        catch
        {
            this.Response.Redirect(ResolveUrl("~/Chiet_Tinh/Default.aspx"));
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.LapBaoCao();        
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

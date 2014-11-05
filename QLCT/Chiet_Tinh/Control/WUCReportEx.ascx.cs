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
        //try
        //{
            if (this.Request.QueryString["ID"].ToString().Trim().Length > 0)
            {
                LapBangChietTinh(this.Request.QueryString["ID"].ToString().Trim());
            }
        //}
        //catch { }
    }

    private string LayTenCongTacCon(string mactc)
    {
        DataTable dt = DBClass.GetTable("select * from Cong_Tac_Con where Ma_Loai = '" + mactc.Trim() + "'");
        if (dt.Rows.Count>0)
        {
            return dt.Rows[0]["Ten_Loai"].ToString().Trim();
        }
        return "";
    }

    private void LapBangChietTinh(string svb)
    {
        string lct, mct = "";
        double dtnc = 0;
        double dtvt = 0;
        DataSet1 ds = new DataSet1();
        DataTable dtbct = DBClass.GetTable("select bct.Ma_Vung, bct.Cong_Tac_Con, bct.Quyet_Dinh_VT, bct.Quyet_Dinh_NC, bct.Loai_Chiet_Tinh, bct.So_Van_Ban, bct.Ngay_Lap, dmdv.Ma_Don_Vi," +
        " kh.Ho_Ten, kh.Dia_Chi, lct.Ma_Loai as Ma_Cong_Tac, lct.Ten_Loai as Loai_Cong_Tac, bct.HS_Nhan_Cong, bct.HS_Phi_Khac as Phi_Truc_Tiep_Khac, bct.HS_CP_Chung as Chi_Phi_Chung," +
        " bct.HS_CP_Chung_1 as Chi_Phi_Chung_1, bct.HS_CP_Chung_2 as Chi_Phi_Chung_2, bct.HS_TN_Chiu_Thue as Thu_Nhap_Chiu_Thue, bct.HS_KS_CT as Khao_Sat_Chiet_Tinh, nv.Ho_Ten as Nguoi_Lap," +
        " dmdv.Ten_Don_Vi from Bang_Chiet_Tinh bct, Khach_Hang kh, Nhan_Vien nv, DM_Don_Vi dmdv, Loai_Cong_Tac lct" +
        " where bct.Nguoi_Lap = nv.Tai_Khoan and nv.Ma_Don_Vi = dmdv.Ma_Don_Vi and bct.Ma_KH = kh.Ma_KH and lct.Ma_Loai = bct.Loai_Cong_Tac and bct.So_Van_Ban = '" + svb.Trim() + "'");
        string qdnc;
        string qdvt;
        if (dtbct.Rows.Count > 0)
        {
            DataRow dtrbct = ds.Bang_Chiet_Tinh.NewRow();
            dtrbct["So_Van_Ban"] = (dtbct.Rows[0]["So_Van_Ban"].ToString().Trim().Substring(0,dtbct.Rows[0]["So_Van_Ban"].ToString().Trim().LastIndexOf("-"))).Replace("-","/CT-").Replace("D","Đ");

            dtrbct["Ho_Ten"] = dtbct.Rows[0]["Ho_Ten"].ToString().Trim() + " - Mã vùng: " + dtbct.Rows[0]["Ma_Vung"].ToString().Trim();
            dtrbct["Loai_Cong_Tac"] = dtbct.Rows[0]["Loai_Cong_Tac"].ToString().Trim() + " - " + this.LayTenCongTacCon(dtbct.Rows[0]["Cong_Tac_Con"].ToString().Trim());
            dtrbct["Dia_Chi"] = dtbct.Rows[0]["Dia_Chi"].ToString().Trim();
            mct = dtbct.Rows[0]["Ma_Cong_Tac"].ToString().Trim();

            dtrbct["HS_Nhan_Cong"] = double.Parse(dtbct.Rows[0]["HS_Nhan_Cong"].ToString().Trim());
            dtrbct["Phi_Truc_Tiep_Khac"] = double.Parse(dtbct.Rows[0]["Phi_Truc_Tiep_Khac"].ToString().Trim());
            dtrbct["Chi_Phi_Chung"] = double.Parse(dtbct.Rows[0]["Chi_Phi_Chung"].ToString().Trim());
            dtrbct["Chi_Phi_Chung_1"] = double.Parse(dtbct.Rows[0]["Chi_Phi_Chung_1"].ToString().Trim());
            dtrbct["Chi_Phi_Chung_2"] = double.Parse(dtbct.Rows[0]["Chi_Phi_Chung_2"].ToString().Trim());
            dtrbct["Thu_Nhap_Chiu_Thue"] = double.Parse(dtbct.Rows[0]["Thu_Nhap_Chiu_Thue"].ToString().Trim());
            dtrbct["Khao_Sat_Chiet_Tinh"] = double.Parse(dtbct.Rows[0]["Khao_Sat_Chiet_Tinh"].ToString().Trim());
            
            DateTime nl = (DateTime)dtbct.Rows[0]["Ngay_Lap"];

            dtrbct["Ngay_Lap"] = "Ngày " + nl.Day.ToString().Trim() + " Tháng " + nl.Month.ToString().Trim() + " Năm " + nl.Year.ToString().Trim();
            
            dtrbct["Nguoi_Lap"] = dtbct.Rows[0]["Nguoi_Lap"].ToString().Trim();
            dtrbct["Ten_Don_Vi"] = dtbct.Rows[0]["Ten_Don_Vi"].ToString().ToUpper().Trim();            
            
            qdnc = dtbct.Rows[0]["Quyet_Dinh_NC"].ToString().ToUpper().Trim();
            qdvt = dtbct.Rows[0]["Quyet_Dinh_VT"].ToString().ToUpper().Trim();
            
            DataTable dtcancunc = DBClass.GetTable("select Noi_Dung from Quyet_Dinh where Ma_Quyet_Dinh = '" + qdnc.Trim() + "'");
            DataTable dtcancuvt = DBClass.GetTable("select Noi_Dung from Quyet_Dinh where Ma_Quyet_Dinh = '" + qdvt.Trim() + "'");

            if (dtcancuvt.Rows.Count > 0)
            {
                dtrbct["Can_Cu"] = dtcancuvt.Rows[0]["Noi_Dung"].ToString().Trim();
            }

            if (dtcancunc.Rows.Count > 0)
            {
                dtrbct["Can_Cu"] = dtrbct["Can_Cu"].ToString().Trim() + "\n" + dtcancunc.Rows[0]["Noi_Dung"].ToString().Trim();
            }

            DataTable dtcp = DBClass.GetTable("select CP.*, DMCP.DVT, DMCP.Ten_Chi_Phi, DMCP.Ma_Danh_Phap, LCP.Ten_Loai from Chi_Phi CP, DM_Chi_Phi DMCP, Loai_Chi_Phi LCP where LCP.Ma_Loai = CP.Ma_Loai and CP.Ma_Chi_Phi = DMCP.Ma_Chi_Phi and CP.So_Van_Ban = '" + svb.Trim() + "'");
            DataTableReader dtcprd = dtcp.CreateDataReader();
            
            while (dtcprd.Read())
            {
                DataRow dtrcp = ds.Chi_Phi.NewRow();
                dtrcp["So_Luong"] = dtcprd["So_Luong"];
                dtrcp["So_Luong_KH"] = dtcprd["So_Luong_KH"];
                dtrcp["Ten_Chi_Phi"] = dtcprd["Ten_Chi_Phi"].ToString().Trim();
                
                if (dtcprd["Ma_Loai"].ToString().Trim()=="2")
                {
                    dtrcp["Don_Gia_Nhan_Cong"] = dtcprd["Don_Gia"];
                    double ttnc = Math.Round(double.Parse(dtrcp["Don_Gia_Nhan_Cong"].ToString().Trim()) * (double.Parse(dtrcp["So_Luong"].ToString().Trim()) + double.Parse(dtrcp["So_Luong_KH"].ToString().Trim())));
                    dtrcp["TT_Nhan_Cong"] = ttnc;
                    dtrcp["Don_Gia_Vat_Tu"] = 0;
                    dtrcp["TT_Vat_Tu"] = 0;
                    dtnc = dtnc + ttnc;
                }else{
                    dtrcp["Don_Gia_Vat_Tu"] = dtcprd["Don_Gia"];
                    double ttvt = Math.Round(double.Parse(dtrcp["Don_Gia_Vat_Tu"].ToString().Trim()) * double.Parse(dtrcp["So_Luong"].ToString().Trim()));
                    dtrcp["TT_Vat_Tu"] = ttvt;
                    dtrcp["Don_Gia_Nhan_Cong"] = 0;
                    dtrcp["TT_Nhan_Cong"] = 0;
                    dtvt = dtvt + ttvt;
                }

                dtrcp["So_Luong"] = dtrcp["So_Luong"].ToString().Replace(".",",");
                dtrcp["So_Luong_KH"] = dtrcp["So_Luong_KH"].ToString().Replace(".", ",");

                dtrcp["DVT"] = dtcprd["DVT"].ToString().Trim();
                dtrcp["Ma_Dinh_Muc"] = dtcprd["Ma_Danh_Phap"].ToString().Trim();
                dtrcp["Loai_Chi_Phi"] = "Chi Phí " + dtcprd["Ten_Loai"].ToString().Trim();
                ds.Chi_Phi.Rows.Add(dtrcp);
            }
            ds.Chi_Phi.AcceptChanges();

            ////////////////////////////////////////////////////////////////////

            double nc = Math.Round(dtnc * double.Parse(dtrbct["HS_Nhan_Cong"].ToString().Trim()));

            dtrbct["Tong_Nhan_Cong"] = dtnc;
            dtrbct["Tong_Vat_Tu"] = dtvt;

            if (dtbct.Rows[0]["Loai_Chiet_Tinh"].ToString().Trim() == "0")
            {
                double TT_T = Math.Round(double.Parse(dtrbct["Tong_Vat_Tu"].ToString().Trim()) + nc);
                double TT_CPC = Math.Round(double.Parse(dtrbct["Chi_Phi_Chung_1"].ToString().Trim()) / 100 * double.Parse(dtrbct["Chi_Phi_Chung_2"].ToString().Trim()) / 100 * nc);
                double TT_G = Math.Round(TT_T + TT_CPC);
                ConvertClass cc = new ConvertClass();
                dtrbct["Bang_Chu"] = "(Bằng chữ: " + cc.Convert(TT_G.ToString().Trim(),'.', " Chấm") + " đồng)";
                dtrbct["T"] = TT_T;
                dtrbct["VL"] = Math.Round(double.Parse(dtrbct["Tong_Vat_Tu"].ToString().Trim()));
                dtrbct["NC"] = nc;
                dtrbct["C"] = TT_CPC;
                dtrbct["G"] = TT_G;
            }
            else
            {
                double TT = Math.Round((double.Parse(dtrbct["Tong_Vat_Tu"].ToString().Trim()) + nc) * double.Parse(dtrbct["Phi_Truc_Tiep_Khac"].ToString().Trim()) / 100);
                double TT_T = Math.Round(double.Parse(dtrbct["Tong_Vat_Tu"].ToString().Trim()) + nc + TT);
                double TT_C = Math.Round(double.Parse(dtrbct["Chi_Phi_Chung"].ToString().Trim()) / 100 * nc);
                
                double TL = Math.Round((TT_T + TT_C) * double.Parse(dtrbct["Thu_Nhap_Chiu_Thue"].ToString().Trim()) / 100);
                double TT_K = Math.Round((TT_T + TT_C + TL) * double.Parse(dtrbct["Khao_Sat_Chiet_Tinh"].ToString().Trim()) / 100);
                double TT_G = Math.Round(TT_T + TT_C + TL + TT_K);
                double VAT = Math.Round(TT_G * 10 / 100);
                double TT_Z = Math.Round(TT_G + VAT);
                ConvertClass cc = new ConvertClass();                
                dtrbct["Bang_Chu"] = "(Bằng chữ: " + cc.Convert(TT_Z.ToString().Trim(), '.', " Chấm") + " đồng)";
                dtrbct["T"] = TT_T;
                dtrbct["VL"] = Math.Round(double.Parse(dtrbct["Tong_Vat_Tu"].ToString().Trim()));
                dtrbct["NC"] = nc;                
                dtrbct["TT"] = TT;
                dtrbct["C"] = TT_C;
                dtrbct["TL"] = TL;
                dtrbct["K"] = TT_K;
                dtrbct["G"] = TT_G;
                dtrbct["VAT"] = VAT;
                dtrbct["Z"] = TT_Z;
            }
            ds.Bang_Chiet_Tinh.Rows.Add(dtrbct);
            ds.Bang_Chiet_Tinh.AcceptChanges();
            lct = dtbct.Rows[0]["Loai_Chiet_Tinh"].ToString().Trim();            
        }
        
        if (dtbct.Rows[0]["Loai_Chiet_Tinh"].ToString().Trim() == "0")
        {
            //this.CRV1.ReportSource = this.CRSND;
            this.Div_File.InnerText = "1";
            this.CRSND.ReportDocument.SetDataSource((DataSet)ds);
            this.CRSND.ReportDocument.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, this.Request.QueryString["ID"].ToString().Trim());
        }
        else
        {
            if (dtbct.Rows[0]["Loai_Chiet_Tinh"].ToString().Trim() == "1")
            {
                //this.CRV1.ReportSource = this.CRSKH;
                this.Div_File.InnerText = "0";
                this.CRSKH.ReportDocument.SetDataSource((DataSet)ds);
                this.CRSKH.ReportDocument.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, this.Request.QueryString["ID"].ToString().Trim());
            }
        }
        //this.CRV1.RefreshReport();
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
        if (Div_File.InnerText.Trim() == "0")
        {
            this.CRSKH.ReportDocument.ExportToHttpResponse(tf, Response, false, "BaoCao");
        }
        else
        {
            this.CRSND.ReportDocument.ExportToHttpResponse(tf, Response, false, "BaoCao");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Chiet_Tinh_Control_WUCBBQuyetToan : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.KhoiTao();
    }

    private void KhoiTao()
    {
        try
        {
            if (this.Request.QueryString["id"].ToString().Trim().Length > 0)
            {
                string svb = this.Request.QueryString["id"].ToString().Trim();
                DataTableReader dtcp = DBClass.GetTable("select cp.So_Luong, dmcp.Ten_Chi_Phi, dmcp.DVT from Chi_Phi cp, DM_Chi_Phi dmcp where dmcp.Ma_Chi_Phi = cp.Ma_Chi_Phi and dmcp.Ma_Loai = '1' and cp.So_Van_Ban = '" + svb.Trim() + "'").CreateDataReader();
                DataTable dtbct = DBClass.GetTable("select * from Bang_Chiet_Tinh where So_Van_Ban = '" + svb.Trim() + "'");
                DataTable dtdv = DBClass.GetTable("select dv.* from DM_Don_Vi dv, Bang_Chiet_Tinh bct, Nhan_Vien nv where dv.Ma_Don_Vi = nv.Ma_Don_Vi and nv.Tai_Khoan = bct.Nguoi_Lap and bct.So_Van_Ban = '" + svb.Trim() + "'");
                
                Infragistics.Excel.Workbook workbook = Infragistics.Excel.Workbook.Load(Server.MapPath("~/Chiet_Tinh/Mau_BB.xls"));
                Infragistics.Excel.Worksheet Wsheet = workbook.Worksheets[0];
                Wsheet.GetCell("A2").Value = dtdv.Rows[0]["Ten_Don_Vi"].ToString().ToUpper().Trim();
                
                Wsheet.GetCell("B10").Value = "I- Đại diện " + dtdv.Rows[0]["Ten_Don_Vi"].ToString().Trim();

                if (int.Parse(dtbct.Rows[0]["Loai_Chiet_Tinh"].ToString().Trim()) == 0)
                {
                    Wsheet.GetCell("A5").Value = "V/v nghiệm thu vật tư lắp đặt công tơ theo chiết tính: " + (svb.Trim().Substring(0, svb.Trim().LastIndexOf("-"))).Replace("-", "/CT-").Replace("D", "Đ") + "                                                        Ngành điện chịu chi phí";
                }
                else
                {
                    Wsheet.GetCell("A5").Value = "V/v nghiệm thu vật tư lắp đặt công tơ theo chiết tính: " + (svb.Trim().Substring(0, svb.Trim().LastIndexOf("-"))).Replace("-", "/CT-").Replace("D", "Đ") + "                                                        Khách hàng chịu chi phí";
                }
                                    
                int bd = 23;
                int bdem = 1;
                while (dtcp.Read())
                {
                    Wsheet.GetCell("A" + bd.ToString().Trim()).CellFormat.SetFormatting(Wsheet.GetCell("A23").CellFormat);
                    Wsheet.GetCell("B" + bd.ToString().Trim()).CellFormat.SetFormatting(Wsheet.GetCell("B23").CellFormat);
                    Wsheet.GetCell("C" + bd.ToString().Trim()).CellFormat.SetFormatting(Wsheet.GetCell("C23").CellFormat);
                    Wsheet.GetCell("D" + bd.ToString().Trim()).CellFormat.SetFormatting(Wsheet.GetCell("D23").CellFormat);
                    Wsheet.GetCell("E" + bd.ToString().Trim()).CellFormat.SetFormatting(Wsheet.GetCell("E23").CellFormat);
                    Wsheet.GetCell("F" + bd.ToString().Trim()).CellFormat.SetFormatting(Wsheet.GetCell("F23").CellFormat);
                    Wsheet.GetCell("G" + bd.ToString().Trim()).CellFormat.SetFormatting(Wsheet.GetCell("G23").CellFormat);
                    Wsheet.GetCell("H" + bd.ToString().Trim()).CellFormat.SetFormatting(Wsheet.GetCell("H23").CellFormat);
                    Wsheet.GetCell("I" + bd.ToString().Trim()).CellFormat.SetFormatting(Wsheet.GetCell("I23").CellFormat);
                    Wsheet.GetCell("J" + bd.ToString().Trim()).CellFormat.SetFormatting(Wsheet.GetCell("J23").CellFormat);

                    Wsheet.GetCell("A" + bd.ToString().Trim()).Value = bdem.ToString().Trim();
                    Wsheet.GetCell("B" + bd.ToString().Trim()).Value = dtcp["Ten_Chi_Phi"].ToString().Trim();
                    Wsheet.GetCell("C" + bd.ToString().Trim()).Value = dtcp["DVT"].ToString().Trim();
                    Wsheet.GetCell("D" + bd.ToString().Trim()).Value = dtcp["So_Luong"].ToString().Trim();

                    bdem++;
                    bd++;
                }

                Infragistics.Excel.Worksheet Wsheetbt = workbook.Worksheets[1];

                int ibt = 1;
                
                Wsheet.MergedCellsRegions.Add(bd, 1, bd, 9);
                Wsheet.Rows[bd].Height = 500;
                
                Wsheet.MergedCellsRegions.Add(bd + 1, 1, bd + 1, 9);
                Wsheet.Rows[bd+1].Height = 600;

                Wsheet.MergedCellsRegions.Add(bd + 2, 1, bd + 2, 9);
                Wsheet.Rows[bd+2].Height = 500;

                Wsheet.MergedCellsRegions.Add(bd + 3, 1, bd + 3, 9);
                Wsheet.Rows[bd+3].Height = 600;

                Wsheet.MergedCellsRegions.Add(bd + 4, 1, bd + 4, 9);
                Wsheet.Rows[bd+4].Height = 1000;

                Wsheet.MergedCellsRegions.Add(bd + 5, 0, bd + 5, 2);
                Wsheet.MergedCellsRegions.Add(bd + 5, 3, bd + 5, 5);
                Wsheet.MergedCellsRegions.Add(bd + 5, 6, bd + 5, 9);
                Wsheet.Rows[bd + 5].Height = 500;

                Wsheet.MergedCellsRegions.Add(bd + 6, 0, bd + 6, 2);
                Wsheet.MergedCellsRegions.Add(bd + 6, 3, bd + 6, 5);
                Wsheet.Rows[bd + 6].Height = 500;

                Wsheet.MergedCellsRegions.Add(bd + 7, 0, bd + 7, 2);
                Wsheet.MergedCellsRegions.Add(bd + 7, 3, bd + 7, 5);
                Wsheet.Rows[bd + 7].Height = 500;

                Wsheet.MergedCellsRegions.Add(bd + 8, 0, bd + 8, 2);
                Wsheet.Rows[bd + 8].Height = 500;

                Wsheet.MergedCellsRegions.Add(bd + 9, 0, bd + 9, 2);
                Wsheet.MergedCellsRegions.Add(bd + 9, 3, bd + 9, 5);
                Wsheet.Rows[bd + 9].Height = 500;

                bd++;

                while (ibt<=10)
                {
                    Wsheet.GetCell("A" + bd.ToString().Trim()).CellFormat.SetFormatting(Wsheetbt.GetCell("A" + ibt.ToString().Trim()).CellFormat);
                    Wsheet.GetCell("B" + bd.ToString().Trim()).CellFormat.SetFormatting(Wsheetbt.GetCell("B" + ibt.ToString().Trim()).CellFormat);
                    Wsheet.GetCell("C" + bd.ToString().Trim()).CellFormat.SetFormatting(Wsheetbt.GetCell("C" + ibt.ToString().Trim()).CellFormat);
                    Wsheet.GetCell("D" + bd.ToString().Trim()).CellFormat.SetFormatting(Wsheetbt.GetCell("D" + ibt.ToString().Trim()).CellFormat);
                    Wsheet.GetCell("E" + bd.ToString().Trim()).CellFormat.SetFormatting(Wsheetbt.GetCell("E" + ibt.ToString().Trim()).CellFormat);
                    Wsheet.GetCell("F" + bd.ToString().Trim()).CellFormat.SetFormatting(Wsheetbt.GetCell("F" + ibt.ToString().Trim()).CellFormat);
                    Wsheet.GetCell("G" + bd.ToString().Trim()).CellFormat.SetFormatting(Wsheetbt.GetCell("G" + ibt.ToString().Trim()).CellFormat);
                    Wsheet.GetCell("H" + bd.ToString().Trim()).CellFormat.SetFormatting(Wsheetbt.GetCell("H" + ibt.ToString().Trim()).CellFormat);
                    Wsheet.GetCell("I" + bd.ToString().Trim()).CellFormat.SetFormatting(Wsheetbt.GetCell("I" + ibt.ToString().Trim()).CellFormat);
                    Wsheet.GetCell("J" + bd.ToString().Trim()).CellFormat.SetFormatting(Wsheetbt.GetCell("J" + ibt.ToString().Trim()).CellFormat);

                   
                    Wsheet.GetCell("A" + bd.ToString().Trim()).Value = Wsheetbt.GetCell("A" + ibt.ToString().Trim()).Value;
                    Wsheet.GetCell("B" + bd.ToString().Trim()).Value = Wsheetbt.GetCell("B" + ibt.ToString().Trim()).Value;
                    Wsheet.GetCell("C" + bd.ToString().Trim()).Value = Wsheetbt.GetCell("C" + ibt.ToString().Trim()).Value;
                    Wsheet.GetCell("D" + bd.ToString().Trim()).Value = Wsheetbt.GetCell("D" + ibt.ToString().Trim()).Value;
                    Wsheet.GetCell("E" + bd.ToString().Trim()).Value = Wsheetbt.GetCell("E" + ibt.ToString().Trim()).Value;
                    Wsheet.GetCell("F" + bd.ToString().Trim()).Value = Wsheetbt.GetCell("F" + ibt.ToString().Trim()).Value;
                    Wsheet.GetCell("G" + bd.ToString().Trim()).Value = Wsheetbt.GetCell("G" + ibt.ToString().Trim()).Value;
                    Wsheet.GetCell("H" + bd.ToString().Trim()).Value = Wsheetbt.GetCell("H" + ibt.ToString().Trim()).Value;
                    Wsheet.GetCell("I" + bd.ToString().Trim()).Value = Wsheetbt.GetCell("I" + ibt.ToString().Trim()).Value;
                    Wsheet.GetCell("J" + bd.ToString().Trim()).Value = Wsheetbt.GetCell("J" + ibt.ToString().Trim()).Value;
                    
                    ibt++;
                    bd++;
                }
                               

                workbook.Worksheets.RemoveAt(1);
                
                System.IO.MemoryStream theStream = new System.IO.MemoryStream();

                workbook.Save(theStream);
                DateTime cd = DateTime.Now.ToUniversalTime().AddHours(7);
                byte[] byteArr = (byte[])Array.CreateInstance(typeof(byte), theStream.Length);
                theStream.Position = 0;
                theStream.Read(byteArr, 0, Convert.ToInt32(theStream.Length));
                theStream.Close();
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment; filename=" + cd.Day.ToString() + cd.Month.ToString() + cd.Year.ToString() + ".xls");
                Response.ContentType = "application/vnd.ms-excel";
                Response.BinaryWrite(byteArr);
                Response.End();
                workbook = null;
            }
        }
        catch { }
    }
}

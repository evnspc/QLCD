using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.IO;

public partial class Chiet_Tinh_Control_WUCDMChiPhi : System.Web.UI.UserControl
{
    private void LoadFromFileExcel()
    {
        if (this.Div_FN.InnerText.Length > 0)
        {
            try
            {
                string fn = this.Div_FN.InnerText.Trim();
                String connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fn + ";" + "Extended Properties='Excel 8.0;IMEX=1'";
                OleDbConnection conn = new OleDbConnection(connString);
                conn.Open();
                string lenh = "SELECT * FROM [Sheet1$]";
                OleDbDataAdapter oleDA = new OleDbDataAdapter(lenh, conn);

                DataSet1 ds1 = new DataSet1();
                oleDA.Fill(ds1.DM_LienKet);
                conn.Close();
                this.MyGrid01.DataSource = ds1.DM_LienKet;
                this.MyGrid01.DataBind();
            }
            catch
            {
                this.LThongBao.Text = "Không thể Load File vì tồn tại các mã trùng lập nhau hoặc không đúng cấu trúc";
                this.WDWThongBao.WindowState = Infragistics.Web.UI.LayoutControls.DialogWindowState.Normal;
            }
        }
    }

    protected void MyGrid01_DataFiltered(object sender, Infragistics.Web.UI.GridControls.FilteredEventArgs e)
    {
        this.LoadFromFileExcel();
    }

    protected void BLoadFile_Click(object sender, EventArgs e)
    {
        if (this.FUL1.PostedFile.FileName.Length > 3)
        {
            string fkt = this.FUL1.PostedFile.FileName;
            if (fkt.Substring(fkt.Length-3,3).ToLower() == "xls" || fkt.Substring(fkt.Length-4,4).ToLower() == "xlsx")
            {
                string fn = DBClass.LayMaSoMoi() + ".xls";
                string[] mfn = Directory.GetFiles(Server.MapPath("~/Chiet_Tinh/FL/"));
                int i = 0;
                while (mfn.Length > i)
                {
                    try
                    {
                        File.Delete(mfn[i]);
                    }
                    catch { }                    
                    i = i + 1;
                }
                fn = Server.MapPath("~/Chiet_Tinh/FL/" + fn);
                this.FUL1.SaveAs(fn);
                this.Div_FN.InnerText = fn;
                try
                {
                    String connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fn + ";" + "Extended Properties='Excel 8.0;IMEX=1'";
                    OleDbConnection conn = new OleDbConnection(connString);
                    conn.Open();
                    string lenh = "SELECT * FROM [Sheet1$]";
                    OleDbDataAdapter oleDA = new OleDbDataAdapter(lenh, conn);

                    DataSet1 ds1 = new DataSet1();
                    oleDA.Fill(ds1.DM_LienKet);
                    conn.Close();
                    this.MyGrid01.DataSource = ds1.DM_LienKet;
                    this.MyGrid01.DataBind();
                }
                catch
                {
                    this.LThongBao.Text = "Không thể Load File vì tồn tại các mã trùng lập nhau hoặc không đúng cấu trúc";
                    this.WDWThongBao.WindowState = Infragistics.Web.UI.LayoutControls.DialogWindowState.Normal;
                }
            }
        }
    }

    private void LoadLoaiCT()
    {
        DataTable dt = DBClass.GetTable("select * from Loai_Cong_Tac order by Ma_Loai asc");
        this.DDLLoaiCT.DataSource = dt;
        this.DDLLoaiCT.DataBind();
        this.DDLLoaiCT01.DataSource = dt;
        this.DDLLoaiCT01.DataBind();
    }

    protected void BTraDMCP_Click(object sender, EventArgs e)
    {
        this.MyGrid02.ClearDataSource();
        LoadDMCTTuLoai();
    }

    private void LoadDMCTTuLoai()
    {
        string strsql = "select * from Lien_Ket where Ma_Cong_Tac = '" + this.DDLLoaiCT.SelectedValue.Trim() + "' order by Ma_Vat_Tu asc";
        DataTable dt = DBClass.GetTable(strsql);
        DataTable dtcp = DBClass.GetTable("select Ma_Chi_Phi, Ten_Chi_Phi from DM_Chi_Phi");
        int i = 0;
        while (i < dt.Rows.Count)
        {
            DataRow[] mrvt = dtcp.Select("Ma_Chi_Phi = '" + dt.Rows[i]["Ma_Vat_Tu"].ToString().Trim() + "'");
            if (mrvt.Length>0)
            {
                dt.Rows[i]["Ma_Vat_Tu"] = mrvt[0]["Ten_Chi_Phi"].ToString().Trim();
            }

            DataRow[] mrnc = dtcp.Select("Ma_Chi_Phi = '" + dt.Rows[i]["Ma_Nhan_Cong"].ToString().Trim() + "'");
            if (mrnc.Length > 0)
            {
                dt.Rows[i]["Ma_Nhan_Cong"] = mrnc[0]["Ten_Chi_Phi"].ToString().Trim();
            }
            i++;
        }
        dt.AcceptChanges();
        this.MyGrid02.DataSource = dt;
        this.MyGrid02.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            this.LoadLoaiCT();
        }
    }

    protected void BDBDuLieu_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtdmcp = DBClass.GetTable("select * from DM_Chi_Phi");
            string fn = this.Div_FN.InnerText.Trim();
            String connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fn + ";" + "Extended Properties='Excel 8.0;IMEX=1'";
            OleDbConnection conn = new OleDbConnection(connString);
            conn.Open();
            string lenh = "SELECT * FROM [Sheet1$]";
            OleDbDataAdapter oleDA = new OleDbDataAdapter(lenh, conn);

            DataSet1 ds1 = new DataSet1();
            oleDA.Fill(ds1.DM_LienKet);
            conn.Close();
            DataTableReader dtr = ds1.DM_LienKet.CreateDataReader();
            DataTable dtkt = DBClass.GetTable("select * from Lien_Ket where Ma_Cong_Tac = '" + this.DDLLoaiCT01.SelectedValue.ToString().Trim() + "'");
            int i = 0;
            while (i<dtkt.Rows.Count)
            {
                dtkt.Rows[i].Delete();
                i++;
            }
            DBClass.UpdateTable("select * from Lien_Ket where Ma_Cong_Tac = '" + this.DDLLoaiCT01.SelectedValue.ToString().Trim() + "'", dtkt);

            DataTable dtkt01 = DBClass.GetTable("select * from Lien_Ket where Ma_Cong_Tac = '" + this.DDLLoaiCT01.SelectedValue.ToString().Trim() + "'");
            while (dtr.Read())
            {
                DataRow dtrnew = dtkt01.NewRow();
                dtrnew["Ma_Vat_Tu"] = dtr["Ma_Vat_Tu"].ToString().Trim();
                dtrnew["Ma_Nhan_Cong"] = dtr["Ma_Nhan_Cong"].ToString().Trim();
                dtrnew["Ma_Cong_Tac"] = this.DDLLoaiCT01.SelectedValue.ToString().Trim();
                dtrnew["Ti_Le"] = dtr["Ti_Le"];
                dtkt01.Rows.Add(dtrnew);                
            }
            DBClass.UpdateTable("select * from Lien_Ket where Ma_Cong_Tac = '" + this.DDLLoaiCT01.SelectedValue.ToString().Trim() + "'", dtkt01);
            
            this.LThongBao.Text = "Quá trình xử lý thông tin thành công.";
            this.LoadDMCTTuLoai();
            this.WDWThongBao.WindowState = Infragistics.Web.UI.LayoutControls.DialogWindowState.Normal;
        }
        catch
        {
            this.LThongBao.Text = "Quá trình xử lý thông tin thất bại.";
            this.WDWThongBao.WindowState = Infragistics.Web.UI.LayoutControls.DialogWindowState.Normal;
        }
    }
        
    protected void MyGrid02_DataFiltered(object sender, Infragistics.Web.UI.GridControls.FilteredEventArgs e)
    {
        LoadDMCTTuLoai();
    }
}

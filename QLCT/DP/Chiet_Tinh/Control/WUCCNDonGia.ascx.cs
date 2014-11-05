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
                oleDA.Fill(ds1.DM_Chi_Phi);
                conn.Close();
                this.MyGrid01.DataSource = ds1.DM_Chi_Phi;
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
                    oleDA.Fill(ds1.DM_Chi_Phi);
                    conn.Close();
                    this.MyGrid01.DataSource = ds1.DM_Chi_Phi;
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

    private void LoadLoaiCP()
    {
        DataTable dt = DBClass.GetTable("select * from Loai_Chi_Phi order by Ma_Loai asc");
        this.DDLLoaiCP.DataSource = dt;
        this.DDLLoaiCP.DataBind();
        this.DDLLoaiCP01.DataSource = dt;
        this.DDLLoaiCP01.DataBind();
    }

    protected void BDBDonGia_Click(object sender, EventArgs e)
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
            oleDA.Fill(ds1.DM_Chi_Phi);
            conn.Close();
            DataTableReader dtr = ds1.DM_Chi_Phi.CreateDataReader();
            while (dtr.Read())
            {
                DataTable dtkt = DBClass.GetTable("select * from DM_Chi_Phi where Ma_Chi_Phi = '" + dtr["Ma_Chi_Phi"].ToString().Trim() +
                "' and Ma_Loai = '" + this.DDLLoaiCP01.SelectedValue.ToString().Trim() + "'");
                if (dtkt.Rows.Count > 0)
                {
                    DataRow dtrnew = dtkt.Rows[0];
                    dtrnew["Don_Gia"] = dtr["Don_Gia"];
                }
                DBClass.UpdateTable("select * from DM_Chi_Phi where Ma_Chi_Phi = '" + dtr["Ma_Chi_Phi"].ToString().Trim() +
                "' and Ma_Loai = '" + this.DDLLoaiCP01.SelectedValue.ToString().Trim() + "'", dtkt);
            }
            this.LThongBao.Text = "Quá trình xử lý thông tin thành công.";
            this.LoadDMCPTuLoai();
            this.WDWThongBao.WindowState = Infragistics.Web.UI.LayoutControls.DialogWindowState.Normal;
        }
        catch
        {
            this.LThongBao.Text = "Quá trình xử lý thông tin thất bại.";
            this.WDWThongBao.WindowState = Infragistics.Web.UI.LayoutControls.DialogWindowState.Normal;
        }
    }

    protected void BTraDMCP_Click(object sender, EventArgs e)
    {
        this.MyGrid02.ClearDataSource();
        LoadDMCPTuLoai();
    }

    private void LoadDMCPTuLoai()
    {
        string strsql = "select DMCP.* from DM_Chi_Phi DMCP" +
        " where DMCP.Ma_Loai = '" + this.DDLLoaiCP.SelectedValue.Trim() + "' order by DMCP.Ten_Chi_Phi asc";
        DataTable dt = DBClass.GetTable(strsql);        
        this.MyGrid02.DataSource = dt;
        this.MyGrid02.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            this.LoadLoaiCP();
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
            oleDA.Fill(ds1.DM_Chi_Phi);
            conn.Close();
            DataTableReader dtr = ds1.DM_Chi_Phi.CreateDataReader();
            while (dtr.Read())
            {
                DataTable dtkt = DBClass.GetTable("select * from DM_Chi_Phi where Ma_Chi_Phi = '" + dtr["Ma_Chi_Phi"].ToString().Trim() +
                "' and Ma_Loai = '" + this.DDLLoaiCP01.SelectedValue.ToString().Trim() + "'");
                if (dtkt.Rows.Count > 0)
                {
                    DataRow dtrnew = dtkt.Rows[0];
                    dtrnew["Ten_Chi_Phi"] = dtr["Ten_Chi_Phi"].ToString().Trim();
                    dtrnew["Ma_Danh_Phap"] = dtr["Ma_Danh_Phap"].ToString().Trim();
                    dtrnew["Don_Gia"] = dtr["Don_Gia"];
                    dtrnew["DVT"] = dtr["DVT"].ToString().Trim();
                    dtrnew["Loai_NC"] = dtr["Loai_NC"].ToString().Trim();                    
                }
                else
                {
                    DataRow dtrnew = dtkt.NewRow();
                    dtrnew["Ma_Chi_Phi"] = dtr["Ma_Chi_Phi"].ToString().Trim();
                    dtrnew["Ma_Danh_Phap"] = dtr["Ma_Danh_Phap"].ToString().Trim();
                    dtrnew["Ten_Chi_Phi"] = dtr["Ten_Chi_Phi"].ToString().Trim();
                    dtrnew["Don_Gia"] = dtr["Don_Gia"];
                    dtrnew["Loai_NC"] = dtr["Loai_NC"].ToString().Trim();
                    dtrnew["DVT"] = dtr["DVT"].ToString().Trim();
                    dtrnew["Ma_Loai"] = this.DDLLoaiCP01.SelectedValue.Trim();
                    dtkt.Rows.Add(dtrnew);
                }
                DBClass.UpdateTable("select * from DM_Chi_Phi where Ma_Chi_Phi = '" + dtr["Ma_Chi_Phi"].ToString().Trim() +
                "' and Ma_Loai = '" + this.DDLLoaiCP01.SelectedValue.ToString().Trim() + "'", dtkt);
            }
            this.LThongBao.Text = "Quá trình xử lý thông tin thành công.";
            this.LoadDMCPTuLoai();
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
        LoadDMCPTuLoai();
    }
}

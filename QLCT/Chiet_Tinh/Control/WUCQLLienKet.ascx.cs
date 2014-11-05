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
            this.LoadDSLoaiCT();
            this.LoadDSVatTu();
            this.LoadDSNhanCong();
        }
    }

    private void LoadDSNhanCong()
    {
        DataTable dt = DBClass.GetTable("select Ma_Chi_Phi, Ten_Chi_Phi from DM_Chi_Phi where Ma_Loai = '2'");
        this.LBDSNCVT.DataSource = dt;
        this.LBDSNCVT.DataBind();
    }

    private void LoadDSLoaiCT()
    {
        DataTable dt = DBClass.GetTable("select Ma_Loai, Ten_Loai from Loai_Cong_Tac");
        this.DDLLoaiCT.DataSource = dt;
        this.DDLLoaiCT.DataBind();
    }

    private void LoadDSVatTu()
    {
        DataTable dt = DBClass.GetTable("select Ma_Chi_Phi, Ten_Chi_Phi from DM_Chi_Phi where Ma_Loai = '1'");
        this.LBDSVatTu.DataSource = dt;
        this.LBDSVatTu.DataBind();
    }

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

    protected void LBDSVatTu_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.LBDSVatTu.SelectedIndex > -1)
        {
            this.LoadDSNhanCong(this.LBDSVatTu.SelectedValue.Trim());
        }
    }

    private void LoadDSNhanCong(string mvt)
    {
        DataTable dt = DBClass.GetTable("select * from Lien_Ket where Ma_Cong_Tac = '" + this.DDLLoaiCT.SelectedValue.Trim() + "' and Ma_Vat_Tu = '" + mvt.Trim() + "'");
        this.MyGrid02.DataSource = dt;
        this.MyGrid02.DataBind();
    }

    protected void BThem_Click(object sender, EventArgs e)
    {
        this.WebDialogWindow2.WindowState = Infragistics.Web.UI.LayoutControls.DialogWindowState.Normal;
    }

    protected void BThemNC_Click(object sender, EventArgs e)
    {
        if (this.LBDSVatTu.SelectedIndex > -1)
        {
            DataTable dt = DBClass.GetTable("select * from Lien_Ket where Ma_Cong_Tac = '" + this.DDLLoaiCT.SelectedValue.Trim() + "' and Ma_Vat_Tu = '" + this.LBDSVatTu.SelectedValue.Trim() + "'");
            int i = 0;
            while (i<this.LBDSNCVT.Items.Count)
            {
                if (this.LBDSNCVT.Items[i].Selected == true)
                {
                    DataRow[] mdtr = dt.Select("Ma_Nhan_Cong = '" + this.LBDSNCVT.Items[i].Value.Trim() + "'");
                    if (mdtr.Length < 1)
                    {
                        DataRow dtr = dt.NewRow();
                        dtr["Ma_Vat_Tu"] = this.LBDSVatTu.SelectedValue.Trim();
                        dtr["Ma_Cong_Tac"] = this.DDLLoaiCT.SelectedValue.Trim();
                        dtr["Ma_Nhan_Cong"] = this.LBDSNCVT.Items[i].Value.Trim();
                        dtr["Ti_Le"] = 1;
                        dt.Rows.Add(dtr);
                    }
                }
                i++;
            }
            DBClass.UpdateTable("select * from Lien_Ket where Ma_Cong_Tac = '" + this.DDLLoaiCT.SelectedValue.Trim() + "' and Ma_Vat_Tu = '" + this.LBDSVatTu.SelectedValue.Trim() + "'" , dt);
            this.LoadDSNhanCong(this.LBDSVatTu.SelectedValue.Trim());
            this.WebDialogWindow2.WindowState = Infragistics.Web.UI.LayoutControls.DialogWindowState.Hidden;
        } 
    }

    protected void BThoatNC_Click(object sender, EventArgs e)
    {
        this.WebDialogWindow2.WindowState = Infragistics.Web.UI.LayoutControls.DialogWindowState.Hidden;
    }

    protected void BCapNhat_Click(object sender, EventArgs e)
    {
        DataTable dt = DBClass.GetTable("select * from Lien_Ket where Ma_Cong_Tac = '" + this.DDLLoaiCT.SelectedValue.Trim() + "' and Ma_Vat_Tu = '" + this.LBDSVatTu.SelectedValue.Trim() + "'");
        int i = 0;
        while (i < this.MyGrid02.Rows.Count)
        {
            string id = ((Label)this.MyGrid02.Rows[i].FindControl("LIDVT")).Text;
            DataRow[] mdtr = dt.Select("Ma_Nhan_Cong = '" + id.Trim() + "'");
            if (mdtr.Length > 0)
            {
                try
                {
                    double tl = double.Parse(((TextBox)this.MyGrid02.Rows[i].FindControl("TBTiLe")).Text.Trim());
                    mdtr[0]["Ti_Le"] = tl;
                    DBClass.UpdateTable("select * from Lien_Ket where Ma_Cong_Tac = '" + this.DDLLoaiCT.SelectedValue.Trim() + "' and Ma_Vat_Tu = '" + this.LBDSVatTu.SelectedValue.Trim() + "'", dt);
                }
                catch
                {}
            }
            i++;
        }
    }

    protected void BXoa_Click(object sender, EventArgs e)
    {
        int i = 0;
        string sqlstr = "select * from Lien_Ket where ( Ma_Cong_Tac = '" + this.DDLLoaiCT.SelectedValue.Trim() + "' and Ma_Vat_Tu = '" + this.LBDSVatTu.SelectedValue.Trim() + "' )";
        Boolean cpkq = false;
        while (i < this.MyGrid02.Rows.Count)
        {
            if (((CheckBox)this.MyGrid02.Rows[i].FindControl("CBXoa")).Checked == true)
            {
                if (cpkq)
                {
                    sqlstr = sqlstr + " or Ma_Nhan_Cong = '" + ((Label)this.MyGrid02.Rows[i].FindControl("LIDVT")).Text + "'";
                }
                else
                {
                    sqlstr = sqlstr + " and ( Ma_Nhan_Cong = '" + ((Label)this.MyGrid02.Rows[i].FindControl("LIDVT")).Text + "'";
                    cpkq = true;
                }
            }
            i++;
        }
        if (cpkq)
        {
            sqlstr = sqlstr + " )";
            DataTable dt = DBClass.GetTable(sqlstr);
            i = 0;
            while (i < dt.Rows.Count)
            {
                dt.Rows[i].Delete();
                i++;
            }
            DBClass.UpdateTable(sqlstr, dt);
            this.LoadDSNhanCong(this.LBDSVatTu.SelectedValue.Trim());
        }
    }
}

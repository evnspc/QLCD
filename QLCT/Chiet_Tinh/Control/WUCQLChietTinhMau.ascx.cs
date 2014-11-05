using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Chiet_Tinh_Control_WUCQLLoaiChiPhi : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            this.LoadLoaiCTMau();
            this.LoadVatTu();
            this.LoadVatTuCTMau();
        }
    }

    private void LoadLoaiCTMau()
    {
        DataTable dt = DBClass.GetTable("select * from Loai_CT_Mau order by Ma_Loai asc");
        this.DDLLoaiChiPhi.DataSource = dt;
        this.DDLLoaiChiPhi.DataBind();
    }

    protected void DDLLoaiChiPhi_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadVatTuCTMau();
    }

    private void LoadVatTu()
    {
        DataTable dtvt = DBClass.GetTable("select Ma_Chi_Phi, Ten_Chi_Phi from DM_Chi_Phi where Ma_Loai = '1' order by Ten_Chi_Phi asc");
        this.LBVatTu.DataSource = dtvt;
        this.LBVatTu.DataBind();
    }

    private void LoadVatTuCTMau()
    {
        DataTable dtvt = DBClass.GetTable("select CP.Ma_Chi_Phi, CP.Ten_Chi_Phi from DM_Chi_Phi CP, Chiet_Tinh_Mau CTM where CTM.Ma_Chi_Phi = CP.Ma_Chi_Phi and CP.Ma_Loai = '1' and CTM.Ma_Loai = '" + this.DDLLoaiChiPhi.SelectedValue.Trim() + "' order by CP.Ten_Chi_Phi asc");
        this.LBVTCP.DataSource = dtvt;
        this.LBVTCP.DataBind();
    }

    protected void BThem_Click(object sender, EventArgs e)
    {
        if (this.LBVatTu.SelectedIndex > -1)
        {
            int i = 0;
            DataTable dtvt = DBClass.GetTable("select * from Chiet_Tinh_Mau CTM where CTM.Ma_Loai = '" + this.DDLLoaiChiPhi.SelectedValue.Trim() + "'");
            while (i < this.LBVatTu.Items.Count)
            {
                if (this.LBVatTu.Items[i].Selected)
                {
                    int j = 0;
                    while (j < this.LBVTCP.Items.Count)
                    {
                        if (this.LBVTCP.Items[j].Value.ToString().Trim() == this.LBVatTu.Items[i].Value.ToString().Trim())
                        {
                            goto th;    
                        }
                        j++;
                    }
                    DataRow dtr = dtvt.NewRow();
                    dtr["Ma_Loai"] = this.DDLLoaiChiPhi.SelectedValue.Trim();
                    dtr["Ma_Chi_Phi"] = this.LBVatTu.Items[i].Value.ToString().Trim();
                    dtvt.Rows.Add(dtr);
                }
                th:;
                i++;
            }
            DBClass.UpdateTable("select * from Chiet_Tinh_Mau CTM where CTM.Ma_Loai = '" + this.DDLLoaiChiPhi.SelectedValue.Trim() + "'", dtvt);
            this.LoadVatTuCTMau();
        }
    }

    protected void BXoa_Click(object sender, EventArgs e)
    {
        if (this.LBVTCP.SelectedIndex > -1)
        {
            int i = 0;
            while (i < this.LBVTCP.Items.Count)
            {
                if (this.LBVTCP.Items[i].Selected)
                {
                    DataTable dtvt = DBClass.GetTable("select * from Chiet_Tinh_Mau CL where CL.Ma_Loai = '" + this.DDLLoaiChiPhi.SelectedValue.Trim() + "' and CL.Ma_Chi_Phi = '" + this.LBVTCP.Items[i].Value.ToString().Trim() + "'");
                    if (dtvt.Rows.Count > 0)
                    {
                        dtvt.Rows[0].Delete();
                        DBClass.UpdateTable("select * from Chiet_Tinh_Mau CL where CL.Ma_Loai = '" + this.DDLLoaiChiPhi.SelectedValue.Trim() + "' and CL.Ma_Chi_Phi = '" + this.LBVTCP.Items[i].Value.ToString().Trim() + "'", dtvt);
                    }                                        
                }
                i++;
            }
            this.LoadVatTuCTMau();
        }
    }
}

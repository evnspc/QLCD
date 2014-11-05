using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Chiet_Tinh_Control_WUCDMDonVi : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            this.LoadMaVung();
            this.LoadThongTinHeSo(this.DDLMaVung.SelectedValue.ToString().Trim());
        }
    }

    private void LoadMaVung()
    {
        DataTable dt = DBClass.GetTable("select * from He_So order by Ma_Vung asc");
        this.DDLMaVung.DataSource = dt;
        this.DDLMaVung.DataBind();
    }

    private void LoadThongTinHeSo(string mv)
    {
        DataTable dt = DBClass.GetTable("select * from He_So where Ma_Vung = '" + mv.Trim() + "'");
        if (dt.Rows.Count > 0)
        {
            this.WHSNhanCong.Text = dt.Rows[0]["HS_Nhan_Cong"].ToString().Trim();

            this.WCPChung1.Text = dt.Rows[0]["HS_CP_Chung_1"].ToString().Trim();
            this.WCPChung2.Text = dt.Rows[0]["HS_CP_Chung_2"].ToString().Trim();
                        
            this.WPhiTrucTiepKhac.Text = dt.Rows[0]["HS_Phi_Khac"].ToString().Trim();
            this.WCPChung.Text = dt.Rows[0]["HS_CP_Chung"].ToString().Trim();
            this.WTNChiuThue.Text = dt.Rows[0]["HS_TN_Chiu_Thue"].ToString().Trim();
            this.WKSChietTinh.Text = dt.Rows[0]["HS_KS_CT"].ToString().Trim();
        }
    }

    protected void WIBCapNhat_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            DataTable dt = DBClass.GetTable("select * from He_So where Ma_Vung = '" + this.DDLMaVung.SelectedValue.Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                DataRow dtr = dt.Rows[0];

                dtr["HS_Nhan_Cong"] = this.WHSNhanCong.Text.Trim();

                dtr["HS_CP_Chung_1"] = this.WCPChung1.Text.Trim();
                dtr["HS_CP_Chung_2"] = this.WCPChung2.Text.Trim();

                dtr["HS_Phi_Khac"] = this.WPhiTrucTiepKhac.Text.Trim();
                dtr["HS_CP_Chung"] = this.WCPChung.Text.Trim();
                dtr["HS_TN_Chiu_Thue"] = this.WTNChiuThue.Text.Trim();
                dtr["HS_KS_CT"] = this.WKSChietTinh.Text.Trim();

                if (DBClass.UpdateTable("select * from He_So where Ma_Vung = '" + this.DDLMaVung.SelectedValue.Trim() + "'", dt) == true)
                {
                    this.LMsg.Text = "Cập nhật thông tin thành công";
                }
                else
                {
                    this.LMsg.Text = "Cập nhật thông tin thất bại, vui lòng kiểm tra lại dữ liệu";
                }
            }
        }
    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        int i = 0;
        while (i < this.WHSNhanCong.Text.Trim().Length)
        {
            if (((this.WHSNhanCong.Text.Trim()[i] >= '0') && (this.WHSNhanCong.Text.Trim()[i] <= '9')) || (this.WHSNhanCong.Text.Trim()[i] == '.')){}
            else{
                args.IsValid = false;
                goto thoat;
            }
            i = i + 1;
        }
        args.IsValid = true;
    thoat: ;
    }

    protected void BThoat_Click(object sender, EventArgs e)
    {
        this.Response.Redirect(ResolveUrl("~/Chiet_Tinh/Default.aspx"));
    }

    protected void DDLMaVung_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadThongTinHeSo(this.DDLMaVung.SelectedValue.ToString().Trim());
    }
}

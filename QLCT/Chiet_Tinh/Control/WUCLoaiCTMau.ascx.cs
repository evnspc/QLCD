using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Chiet_Tinh_Control_WUCLoaiChiPhi : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            this.LoadLoaiCTMau();
        }
    }

    private void LoadLoaiCTMau()
    {
        DataTable dt = DBClass.GetTable("select * from Loai_CT_Mau order by Ten_Loai asc");
        this.MyGrid01.DataSource = dt;
        this.MyGrid01.DataBind();
    }

    private void LoadThongTinLoaiCTMau(string ml)
    {
        DataTable dt = DBClass.GetTable("select * from Loai_CT_Mau where Ma_Loai = '" + ml.Trim() + "'");
        if (dt.Rows.Count > 0)
        {
            this.WMaLoai.Text=dt.Rows[0]["Ma_Loai"].ToString().Trim();
            this.WTenLoai.Text = dt.Rows[0]["Ten_Loai"].ToString().Trim();
        }
    }
       
    protected void MyGrid01_DataFiltered(object sender, Infragistics.Web.UI.GridControls.FilteredEventArgs e)
    {
        this.LoadLoaiCTMau();
    }

    protected void MyGrid01_CellSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedCellEventArgs e)
    {
        if (e.CurrentSelectedCells.Count > 0)
        {
            this.LoadThongTinLoaiCTMau(e.CurrentSelectedCells[0].Row.Items[0].Text.Trim());
        }
    }

    protected void MyGrid01_RowSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
    {
        if (e.CurrentSelectedRows.Count > 0)
        {
            this.LoadThongTinLoaiCTMau(e.CurrentSelectedRows[0].Items[0].Text.Trim());
        }
    }

    protected void WIBThemMoi_Click(object sender, EventArgs e)
    {
        DataTable dt = DBClass.GetTable("select * from Loai_CT_Mau where Ma_Loai = '" + this.WMaLoai.Text.Trim() + "'");
        if (dt.Rows.Count < 1)
        {
            DataRow dtr = dt.NewRow();
            dtr["Ma_Loai"] = this.WMaLoai.Text.Trim();
            dtr["Ten_Loai"] = this.WTenLoai.Text.Trim();            
            dt.Rows.Add(dtr);
            if (DBClass.UpdateTable("select * from Loai_CT_Mau where Ma_Loai = '" + this.WMaLoai.Text.Trim() + "'", dt) == true)
            {
                this.LMsg.Text = "Tạo mới thông tin thành công";
                this.MyGrid01.ClearDataSource();
                this.LoadLoaiCTMau();
            }
            else
            {
                this.LMsg.Text = "Tạo mới thông tin thất bại, vui lòng kiểm tra lại dữ liệu";
            }
        }
    }

    protected void WIBCapNhat_Click(object sender, EventArgs e)
    {
        DataTable dt = DBClass.GetTable("select * from Loai_CT_Mau where Ma_Loai = '" + this.WMaLoai.Text.Trim() + "'");
        if (dt.Rows.Count > 0)
        {
            DataRow dtr = dt.Rows[0];
            dtr["Ten_Loai"] = this.WTenLoai.Text.Trim();
            if (DBClass.UpdateTable("select * from Loai_CT_Mau where Ma_Loai = '" + this.WMaLoai.Text.Trim() + "'", dt) == true)
            {
                this.LMsg.Text = "Cập nhật thông tin thành công";
                this.MyGrid01.ClearDataSource();
                this.LoadLoaiCTMau();
            }
            else
            {
                this.LMsg.Text = "Cập nhật thông tin thất bại, vui lòng kiểm tra lại dữ liệu";
            }
        }
    }

    protected void WIBXoa_Click(object sender, EventArgs e)
    {
        DataTable dt = DBClass.GetTable("select * from Loai_CT_Mau where Ma_Loai = '" + this.WMaLoai.Text.Trim() + "'");
        if (dt.Rows.Count > 0)
        {
            dt.Rows[0].Delete();
            if (DBClass.UpdateTable("select * from Loai_CT_Mau where Ma_Loai = '" + this.WMaLoai.Text.Trim() + "'", dt) == true)
            {
                this.LMsg.Text = "Xóa thông tin thành công";
                this.MyGrid01.ClearDataSource();
                this.LoadLoaiCTMau();
            }
            else
            {
                this.LMsg.Text = "Xóa thông tin thất bại, vui lòng kiểm tra lại dữ liệu";
            }
        }    
    }

    protected void BThoat_Click(object sender, EventArgs e)
    {
        this.Response.Redirect(ResolveUrl("~/Chiet_Tinh/Default.aspx"));
    }
}

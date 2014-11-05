using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Chiet_Tinh_Control_WUCLoaiChiPhi : System.Web.UI.UserControl
{
    public string HienThiNgay(object dt)
    {
        DateTime cd = (DateTime)dt;
        return cd.Day.ToString().Trim() + "/" + cd.Month.ToString().Trim() + "/" + cd.Year.ToString().Trim() + " " + cd.ToShortTimeString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            this.LoadQuyetDinh();
        }
    }

    private void LoadQuyetDinh()
    {
        DataTable dt = DBClass.GetTable("select * from Quyet_Dinh order by Ngay_Thang desc");
        this.MyGrid01.DataSource = dt;
        this.MyGrid01.DataBind();
    }

    private void LoadThongTinQuyetDinh(string ml)
    {
        DataTable dt = DBClass.GetTable("select * from Quyet_Dinh where Ma_Quyet_Dinh = '" + ml.Trim() + "'");
        if (dt.Rows.Count > 0)
        {
            this.WMaQD.Text=dt.Rows[0]["Ma_Quyet_Dinh"].ToString().Trim();
            this.WTenQD.Text = dt.Rows[0]["Ten_Quyet_Dinh"].ToString().Trim();
            this.WNgayThang.Value = (DateTime)dt.Rows[0]["Ngay_Thang"];
            this.WNoiDung.Text = dt.Rows[0]["Noi_Dung"].ToString().Trim();
        }
    }
       
    protected void MyGrid01_DataFiltered(object sender, Infragistics.Web.UI.GridControls.FilteredEventArgs e)
    {
        this.LoadQuyetDinh();
    }

    protected void MyGrid01_CellSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedCellEventArgs e)
    {
        if (e.CurrentSelectedCells.Count > 0)
        {
            this.LoadThongTinQuyetDinh(e.CurrentSelectedCells[0].Row.Items[0].Text.Trim());
        }
    }

    protected void MyGrid01_RowSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
    {
        if (e.CurrentSelectedRows.Count > 0)
        {
            this.LoadThongTinQuyetDinh(e.CurrentSelectedRows[0].Items[0].Text.Trim());
        }
    }

    protected void WIBThemMoi_Click(object sender, EventArgs e)
    {
        DataTable dt = DBClass.GetTable("select * from Quyet_Dinh where Ma_Quyet_Dinh = '" + this.WMaQD.Text.Trim() + "'");
        if (dt.Rows.Count < 1)
        {
            DataRow dtr = dt.NewRow();
            dtr["Ma_Quyet_Dinh"] = this.WMaQD.Text.Trim();
            dtr["Ten_Quyet_Dinh"] = this.WTenQD.Text.Trim();
            dtr["Ngay_Thang"] = this.WNgayThang.Value;
            dtr["Noi_Dung"] = this.WNoiDung.Text.Trim();
            dt.Rows.Add(dtr);
            if (DBClass.UpdateTable("select * from Quyet_Dinh where Ma_Quyet_Dinh = '" + this.WMaQD.Text.Trim() + "'", dt) == true)
            {
                this.LMsg.Text = "Tạo mới thông tin thành công";
                this.MyGrid01.ClearDataSource();
                this.LoadQuyetDinh();
            }
            else
            {
                this.LMsg.Text = "Tạo mới thông tin thất bại, vui lòng kiểm tra lại dữ liệu";
            }
        }
    }

    protected void WIBCapNhat_Click(object sender, EventArgs e)
    {
        DataTable dt = DBClass.GetTable("select * from Quyet_Dinh where Ma_Quyet_Dinh = '" + this.WMaQD.Text.Trim() + "'");
        if (dt.Rows.Count > 0)
        {
            DataRow dtr = dt.Rows[0];
            dtr["Ten_Quyet_Dinh"] = this.WTenQD.Text.Trim();
            dtr["Ngay_Thang"] = this.WNgayThang.Value;
            dtr["Noi_Dung"] = this.WNoiDung.Text.Trim();
            if (DBClass.UpdateTable("select * from Quyet_Dinh where Ma_Quyet_Dinh = '" + this.WMaQD.Text.Trim() + "'", dt) == true)
            {
                this.LMsg.Text = "Cập nhật thông tin thành công";
                this.MyGrid01.ClearDataSource();
                this.LoadQuyetDinh();
            }
            else
            {
                this.LMsg.Text = "Cập nhật thông tin thất bại, vui lòng kiểm tra lại dữ liệu";
            }
        }
    }

    protected void WIBXoa_Click(object sender, EventArgs e)
    {
        DataTable dt = DBClass.GetTable("select * from Quyet_Dinh where Ma_Quyet_Dinh = '" + this.WMaQD.Text.Trim() + "'");
        if (dt.Rows.Count > 0)
        {
            dt.Rows[0].Delete();
            if (DBClass.UpdateTable("select * from Quyet_Dinh where Ma_Quyet_Dinh = '" + this.WMaQD.Text.Trim() + "'", dt) == true)
            {
                this.LMsg.Text = "Xóa thông tin thành công";
                this.MyGrid01.ClearDataSource();
                this.LoadQuyetDinh();
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

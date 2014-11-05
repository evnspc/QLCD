using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChamSocVien_Control_WUCThongTin : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            LoadThongTin();
        }
    }

    private void LoadThongTin()
    {
        DataTable dt = DBClass.GetTable("select * from Nhan_Vien where Tai_Khoan = '" + Session["Nhan_Vien"].ToString().Trim() + "'");
        if (dt.Rows.Count > 0)
        {
            DataRow dtr = dt.Rows[0];
            this.WMaNhanVien.Text = Session["Nhan_Vien"].ToString().Trim();
            this.WHoTen.Text = dtr["Ho_Ten"].ToString().Trim();
            this.WDiaChi.Text = dtr["Dia_Chi"].ToString().Trim();
            this.WChucVu.Text = dtr["Chuc_Vu"].ToString().Trim();
            this.WDienThoai.Text = dtr["Dien_Thoai"].ToString().Trim();
            this.WGhiChu.Text = dtr["Ghi_Chu"].ToString().Trim();
            LoadDonVi(this.DDLDonVi);
            this.DDLDonVi.SelectedValue = dtr["Ma_Don_Vi"].ToString().Trim();
        }
    }

    private void LoadDonVi(DropDownList mycb)
    {
        DataTableReader dttr = DBClass.GetTable("select * from DM_Don_Vi order by Ten_Don_Vi asc").CreateDataReader();
        mycb.Items.Clear();
        while (dttr.Read())
        {
            ListItem li = new ListItem();
            li.Value = dttr["Ma_Don_Vi"].ToString().Trim();
            li.Text = dttr["Ten_Don_Vi"].ToString().Trim();
            mycb.Items.Add(li);
        }
    }

    protected void CVV1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if ((this.WDienThoai.Text.Trim().IndexOf("0702") == 0) || (this.WDienThoai.Text.Trim().IndexOf("096") == 0))
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }

    protected void BThoat_Click(object sender, EventArgs e)
    {
        this.Response.Redirect(ResolveUrl("~/Chiet_Tinh/Default.aspx"));
    }

    protected void WIBCapNhat_Click(object sender, EventArgs e)
    {
        if (this.Page.IsValid)
        {
            DataTable dt = DBClass.GetTable("select * from Nhan_Vien where Tai_Khoan = '" + Session["Nhan_Vien"].ToString().Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                DataRow dtr = dt.Rows[0];
                dtr["Ho_Ten"] = this.WHoTen.Text.Trim();
                dtr["Dia_Chi"] = this.WDiaChi.Text.Trim();
                dtr["Chuc_Vu"] = this.WChucVu.Text.Trim();
                dtr["Dien_Thoai"] = this.WDienThoai.Text.Trim();
                dtr["Ma_Don_Vi"] = this.DDLDonVi.SelectedValue.Trim();
                dtr["Ghi_Chu"] = this.WGhiChu.Text.Trim();
                if (this.WMatKhau.Text.Trim().Length > 0)
                {
                    MaHoaII.MaHoaWeb mh = new MaHoaII.MaHoaWeb();
                    dtr["Mat_Khau"] = mh.MaHoa_Link.Clock(this.WMatKhau.Text.Trim());
                }
                if (DBClass.UpdateTable("select * from Nhan_Vien where Tai_Khoan = '" + Session["Nhan_Vien"].ToString().Trim() + "'", dt) == true)
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
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Chiet_Tinh_Control_WUCChietTinh : System.Web.UI.UserControl
{
    public string LayTenCP(string mavt)
    {
        try
        {
            DataTable dt = DBClass.GetTable("select * from DM_Chi_Phi where ID_Chi_Phi = '" + mavt.Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Ten_Chi_Phi"].ToString().Trim();
            }
        }
        catch { }
        return "";
    }

    private void LoadChietTinh()
    {
        if (this.Div_SqlCT.InnerText.Trim().Length > 2)
        {
            DataTable dt = DBClass.GetTable(this.Div_SqlCT.InnerText.Trim());
            this.MyGrid02.ClearDataSource();
            this.MyGrid02.DataSource = dt;
            this.MyGrid02.DataBind();
        }
        else
        {
            string strsql = "select * from Chi_Phi where So_Van_Ban = '" + this.WSoVanBan.Text.Trim() + "'";
            this.Div_SqlCT.InnerText = strsql;
            DataTable dttemp = DBClass.GetTable(strsql);
            this.MyGrid02.ClearDataSource();
            this.MyGrid02.DataSource = dttemp;
            this.MyGrid02.DataBind();
        }
        
    }

    private void LoadThongTinBangChietTinh()
    {
        try
        {
            if (this.Request.QueryString["ID"].ToString().Trim().Length > 0)
            {
                DataTable dt = DBClass.GetTable("select bct.*, kh.Ho_Ten from Bang_Chiet_Tinh bct, Khach_Hang kh where bct.Ma_KH = kh.Ma_KH and So_Van_Ban = '" + this.Request.QueryString["ID"].ToString().Trim() + "'");
                if (dt.Rows.Count > 0)
                {
                    this.WSoVanBan.Text = dt.Rows[0]["So_Van_Ban"].ToString().Trim();
                    this.WMaKhachHang.Text = dt.Rows[0]["Ma_KH"].ToString().Trim();
                    this.WTenKhachHang.Text = dt.Rows[0]["Ho_Ten"].ToString().Trim();
                    this.DDLCongTac.SelectedValue = dt.Rows[0]["Loai_Cong_Tac"].ToString().Trim();
                    this.DDLChietTinh.SelectedValue = dt.Rows[0]["Loai_Chiet_Tinh"].ToString().Trim();
                    this.WNgayLap.Value = (DateTime)dt.Rows[0]["Ngay_Lap"];
                    LoadChietTinh();
                }
            }
        }
        catch { }
    }

    protected void MyGrid02_DataFiltered(object sender, Infragistics.Web.UI.GridControls.FilteredEventArgs e)
    {
        this.LoadChietTinh();
    }

    private double GetDonGia(string mcp)
    {
        DataTable dt = DBClass.GetTable("select * from DM_Chi_Phi where Ma_Chi_Phi = '" + mcp.Trim() + "'");
        if (dt.Rows.Count > 0)
        {
            return double.Parse(dt.Rows[0]["Don_Gia"].ToString().Trim());
        }
        else
        {
            return 0;
        }
    }

    private void resetVTNC()
    {
        this.DDVatTu.SelectedValue = "VT_No";
        this.DDNhanCong.SelectedValue = "NC_No";        
    }

    protected void WIBThemCP_Click(object sender, EventArgs e)
    {
        if (this.DDVatTu.SelectedValue.ToString().Substring(0, 2).ToLower().Trim() == "vt" & this.DDNhanCong.SelectedValue.ToString().Substring(0, 2).ToLower().Trim() == "nc")
        {
            string id_vt, id_nc;
            DataRow dtrhs = DBClass.LayHeSo(Server.MapPath("~/Chiet_Tinh/Temp.xml"));

            string qd_vt = "";
            string qd_nc = "";

            try
            {
                qd_vt = dtrhs["Vat_Tu"].ToString().Trim();
                qd_nc = dtrhs["Nhan_Cong"].ToString().Trim();
            }
            catch { }
            DataTable dt_id_vt = DBClass.GetTable("select ID_Chi_Phi from DM_Chi_Phi where Ma_Chi_Phi = '" + this.DDVatTu.SelectedValue.ToString().Trim() + "' and Ma_Quyet_Dinh = '" + qd_vt.Trim() + "'");
            if (dt_id_vt.Rows.Count > 0)
            {
                id_vt = dt_id_vt.Rows[0]["ID_Chi_Phi"].ToString().Trim();
            }
            else
            {
                id_vt = "";
            }
            DataTable dt_id_nc = DBClass.GetTable("select ID_Chi_Phi from DM_Chi_Phi where Ma_Chi_Phi = '" + this.DDNhanCong.SelectedValue.ToString().Trim() + "' and Ma_Quyet_Dinh = '" + qd_nc.Trim() + "'");
            if (dt_id_nc.Rows.Count > 0)
            {
                id_nc = dt_id_nc.Rows[0]["ID_Chi_Phi"].ToString().Trim();
            }
            else
            {
                id_nc = "";
            }

            string sqlstr = "select * from Chi_Phi where So_Van_Ban = '" + this.WSoVanBan.Text.Trim() + "'";
            if (id_vt.Trim().Length > 0)
            {
                sqlstr = sqlstr + " and ID_Vat_Tu = " + id_vt.Trim();
            }
            if (id_nc.Trim().Length > 0)
            {
                sqlstr = sqlstr + " and ID_Nhan_Cong = " + id_nc.Trim();
            }
            DataTable dt = DBClass.GetTable(sqlstr);
            if (dt.Rows.Count > 0)
            {
                dt.Rows[0]["So_Luong"] = (double.Parse(dt.Rows[0]["So_Luong"].ToString().Trim()) + double.Parse(this.WSoLuong.Text.Trim())).ToString().Trim();
            }
            else
            {

                DataRow dtr = dt.NewRow();
                dtr["So_Van_Ban"] = this.WSoVanBan.Text.Trim();
                if (id_vt.Trim().Length > 0)
                {
                    dtr["ID_Vat_Tu"] = id_vt.Trim();
                }
                if (id_nc.Trim().Length > 0)
                {
                    dtr["ID_Nhan_Cong"] = id_nc.Trim();
                }
                dtr["So_Luong"] = this.WSoLuong.Text.Trim();
                dt.Rows.Add(dtr);
            }
            DBClass.UpdateTable(sqlstr, dt);
            string strsql = "select * from Chi_Phi where So_Van_Ban = '" + this.WSoVanBan.Text.Trim() + "'";
            this.Div_SqlCT.InnerText = strsql;
            DataTable dttemp = DBClass.GetTable(strsql);
            this.MyGrid02.ClearDataSource();
            this.MyGrid02.DataSource = dttemp;
            this.MyGrid02.DataBind();
            resetVTNC();
            this.DDVatTu.Focus();
        }
    }

    protected void WIBXoaCP_Click(object sender, EventArgs e)
    {
        if (this.MyGrid02.Behaviors.Selection.SelectedRows.Count > 0)
        {
            string strsql = "select * from Chi_Phi where ID = " + this.MyGrid02.Behaviors.Selection.SelectedRows[0].Items[0].Text.Trim();
            int i = 1;
            while (i < this.MyGrid02.Behaviors.Selection.SelectedRows.Count)
            {
                strsql = strsql + " or ID = " + this.MyGrid02.Behaviors.Selection.SelectedRows[i].Items[0].Text.Trim();
                i = i + 1;
            }
            DataTable dt = DBClass.GetTable(strsql);
            if (dt.Rows.Count > 0)
            {
                i = 0;
                while (i<dt.Rows.Count)
                {
                    dt.Rows[i].Delete();
                    i = i + 1;
                }                
                DBClass.UpdateTable(strsql, dt);
                string strsql1 = "select * from Chi_Phi where So_Van_Ban = '" + this.WSoVanBan.Text.Trim() + "'";
                this.Div_SqlCT.InnerText = strsql1;
                DataTable dttemp = DBClass.GetTable(strsql1);
                this.MyGrid02.ClearDataSource();
                this.MyGrid02.DataSource = dttemp;
                this.MyGrid02.DataBind();
                resetVTNC();
            }
        }
        else
        {
            if (this.MyGrid02.Behaviors.Selection.SelectedCells.Count > 0)
            {
                string strsql = "select * from Chi_Phi where ID = " + this.MyGrid02.Behaviors.Selection.SelectedCells[0].Row.Items[0].Text.Trim();
                int i = 1;
                while (i < this.MyGrid02.Behaviors.Selection.SelectedCells.Count)
                {
                    strsql = strsql + " or ID = " + this.MyGrid02.Behaviors.Selection.SelectedCells[i].Row.Items[0].Text.Trim();
                    i = i + 1;
                }
                DataTable dt = DBClass.GetTable(strsql);
                if (dt.Rows.Count > 0)
                {
                    i = 0;
                    while (i < dt.Rows.Count)
                    {
                        dt.Rows[i].Delete();
                        i = i + 1;
                    }
                    DBClass.UpdateTable(strsql, dt);
                    string strsql1 = "select * from Chi_Phi where So_Van_Ban = '" + this.WSoVanBan.Text.Trim() + "'";
                    this.Div_SqlCT.InnerText = strsql1;
                    DataTable dttemp = DBClass.GetTable(strsql1);
                    this.MyGrid02.ClearDataSource();
                    this.MyGrid02.DataSource = dttemp;
                    this.MyGrid02.DataBind();
                    resetVTNC();
                }
            }
        }
    }

    private void LoadLoaiCongTac()
    {
        DataTable dt = DBClass.GetTable("select * from Loai_Cong_Tac order by Ten_Loai asc");
        this.DDLCongTac.DataSource = dt;
        this.DDLCongTac.DataBind();
    }

    private void LoadVatTu()
    {
        DataRow dtrhs = DBClass.LayHeSo(Server.MapPath("~/Chiet_Tinh/Temp.xml"));
        string qd_vt = "";
        try
        {
            qd_vt = dtrhs["Vat_Tu"].ToString().Trim();
        }
        catch { }
        DataTable dt = DBClass.GetTable("select Ma_Chi_Phi, Ten_Chi_Phi from DM_Chi_Phi where Ma_Loai = '1' and Ma_Quyet_Dinh = '" + qd_vt.Trim() + "' order by Ten_Chi_Phi asc" );
        DataRow dtr = dt.NewRow();
        dtr["Ma_Chi_Phi"] = "VT_No";
        dtr["Ten_Chi_Phi"] = "Không có vật tư";
        dt.Rows.InsertAt(dtr, 0);
        dt.AcceptChanges();
        this.DDVatTu.DataSource = dt;
        this.DDVatTu.DataBind();
    }

    private void LoadNhanCong()
    {
        DataRow dtrhs = DBClass.LayHeSo(Server.MapPath("~/Chiet_Tinh/Temp.xml"));
        string qd_nc = "";
        try
        {
            qd_nc = dtrhs["Nhan_Cong"].ToString().Trim();
        }
        catch { }
        DataTable dt = DBClass.GetTable("select Ma_Chi_Phi, Ten_Chi_Phi from DM_Chi_Phi where Ma_Loai = '2' and Ma_Quyet_Dinh = '" + qd_nc.Trim() + "' order by Ten_Chi_Phi asc");
        DataRow dtr = dt.NewRow();
        dtr["Ma_Chi_Phi"] = "NC_No";
        dtr["Ten_Chi_Phi"] = "Không có nhân công";
        dt.Rows.InsertAt(dtr, 0);
        dt.AcceptChanges();
        this.DDNhanCong.DataSource = dt;
        this.DDNhanCong.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {       
        if (this.IsPostBack == false)
        {
            this.LoadLoaiCongTac();
            this.LoadVatTu();
            this.LoadNhanCong();
            this.LoadThongTinBangChietTinh();            
            this.Link_InCT.HRef = ResolveUrl("~/Chiet_Tinh/Report.aspx") + "?ID=" + this.WSoVanBan.Text.Trim();
            this.DDVatTu.Attributes.Add("onkeypress", "return FocusHere(event,'" + this.DDNhanCong.ClientID + "_TextBox')");
            this.DDNhanCong.Attributes.Add("onkeypress", "return FocusHere(event,'" + this.WSoLuong.ClientID + "')");
            this.WSoLuong.Attributes.Add("onfocusin", " select();");
            //this.DDVatTu.Attributes.Add("onclick", "return FocusHere(event,'" + this.DDNhanCong.ClientID + "_TextBox')");
        }
        this.DDVatTu.Focus();
    }

    protected void WIBSuaCP_Click(object sender, EventArgs e)
    {
        if (this.DDVatTu.SelectedValue.ToString().Substring(0, 2).ToLower().Trim() == "vt" & this.DDNhanCong.SelectedValue.ToString().Substring(0, 2).ToLower().Trim() == "nc")
        {
            string id_vt, id_nc;
            DataRow dtrhs = DBClass.LayHeSo(Server.MapPath("~/Chiet_Tinh/Temp.xml"));

            string qd_vt = "";
            string qd_nc = "";
            try
            {
                qd_vt = dtrhs["Vat_Tu"].ToString().Trim();
                qd_nc = dtrhs["Nhan_Cong"].ToString().Trim();
            }
            catch { }
            DataTable dt_id_vt = DBClass.GetTable("select * from DM_Chi_Phi where Ma_Chi_Phi = '" + this.DDVatTu.SelectedValue.ToString().Trim() + "' and Ma_Quyet_Dinh = '" + qd_vt.Trim() + "'");
            if (dt_id_vt.Rows.Count > 0)
            {
                id_vt = dt_id_vt.Rows[0]["ID_Chi_Phi"].ToString().Trim();
            }
            else
            {
                id_vt = "";
            }
            DataTable dt_id_nc = DBClass.GetTable("select * from DM_Chi_Phi where Ma_Chi_Phi = '" + this.DDNhanCong.SelectedValue.ToString().Trim() + "' and Ma_Quyet_Dinh = '" + qd_nc.Trim() + "'");
            if (dt_id_nc.Rows.Count > 0)
            {
                id_nc = dt_id_nc.Rows[0]["ID_Chi_Phi"].ToString().Trim();
            }
            else
            {
                id_nc = "";
            }
            DataTable dt = DBClass.GetTable("select * from Chi_Phi where ID = " + this.Div_ID.InnerText.Trim());
            if (dt.Rows.Count > 0)
            {
                try
                {
                    dt.Rows[0]["ID_Vat_Tu"] = id_vt;
                }
                catch { }
                try
                {
                    dt.Rows[0]["ID_Nhan_Cong"] = id_nc;
                }
                catch { }
                dt.Rows[0]["So_Luong"] = this.WSoLuong.Text;
                DBClass.UpdateTable("select * from Chi_Phi where ID = " + this.Div_ID.InnerText.Trim(),dt);
                LoadChietTinh();
                resetVTNC();
            }
        }
    }

    protected void MyGrid02_CellSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedCellEventArgs e)
    {
        if (e.CurrentSelectedCells.Count > 0)
        {
            this.LoadCTCP(e.CurrentSelectedCells[0].Row.Items[0].Text.Trim());
        }
    }

    protected void MyGrid02_RowSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
    {
        if (e.CurrentSelectedRows.Count > 0)
        {
            this.LoadCTCP(e.CurrentSelectedRows[0].Items[0].Text.Trim());
        }
    }

    private void LoadCTCP(string id)
    {
        DataTable dt = DBClass.GetTable("select * from Chi_Phi where ID = " + id.Trim());
        if (dt.Rows.Count > 0)
        {
            string id_vt, id_nc;
            try
            {
                DataTable dt_id_vt = DBClass.GetTable("select * from DM_Chi_Phi where ID_Chi_Phi = " + dt.Rows[0]["ID_Vat_Tu"].ToString().Trim());
                if (dt_id_vt.Rows.Count > 0)
                {
                    id_vt = dt_id_vt.Rows[0]["Ma_Chi_Phi"].ToString().Trim();
                }
                else
                {
                    id_vt = "VT_No";
                }
            }
            catch { id_vt = "VT_No"; }
            try
            {
                DataTable dt_id_nc = DBClass.GetTable("select * from DM_Chi_Phi where ID_Chi_Phi = " + dt.Rows[0]["ID_Nhan_Cong"].ToString().Trim());
                if (dt_id_nc.Rows.Count > 0)
                {
                    id_nc = dt_id_nc.Rows[0]["Ma_Chi_Phi"].ToString().Trim();
                }
                else
                {
                    id_nc = "NC_No";
                }
            }
            catch { id_nc = "NC_No"; }
            this.Div_ID.InnerText = dt.Rows[0]["ID"].ToString().Trim();
            this.DDVatTu.SelectedValue = id_vt;
            this.DDNhanCong.SelectedValue = id_nc;
            this.WSoLuong.Text = dt.Rows[0]["So_Luong"].ToString().Trim();
        }
    }

    protected void BLuuBCT_Click(object sender, EventArgs e)
    {
        DataTable dt = DBClass.GetTable("select * from Bang_Chiet_Tinh where So_Van_Ban = '" + this.WSoVanBan.Text.Trim() + "'");
        if (dt.Rows.Count > 0)
        {
            DataRow dtr = dt.Rows[0];
            dtr["Loai_Cong_Tac"] = this.DDLCongTac.SelectedValue.Trim();
            dtr["Ngay_Lap"] = this.WNgayLap.Value;
            dtr["Ngay_Thu_Tien"] = DBNull.Value;
            dtr["Nguoi_Lap"] = Session["Nhan_Vien"].ToString().Trim();
            dtr["Loai_Chiet_Tinh"] = this.DDLChietTinh.SelectedValue.Trim();

            if (DBClass.UpdateTable("select * from Bang_Chiet_Tinh where So_Van_Ban = '" + this.WSoVanBan.Text.Trim() + "'", dt) == true)
            {
                this.LMsg.Text = "Lưu thông tin bảng chiết tính thành công";
            }
            else
            {
                this.LMsg.Text = "Lưu thông tin bảng chiết tính thất bại vui lòng kiểm tra lại dữ liệu";
            }
        }
        else
        {
            this.LMsg.Text = "Vui lòng chọn bảng chiết tính cần cập nhật";
        }
    }

    protected void BThoat_Click(object sender, EventArgs e)
    {
        this.Response.Redirect(ResolveUrl("~/Chiet_Tinh/Default.aspx"));
    }
}

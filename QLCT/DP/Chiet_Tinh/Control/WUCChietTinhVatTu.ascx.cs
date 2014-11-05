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
            DataTable dt = DBClass.GetTable("select * from DM_Chi_Phi where Ma_Chi_Phi = '" + mavt.Trim() + "'");
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
            this.MyGrid02.DataSource = dt;
            this.MyGrid02.DataBind();
        }
        else
        {
            string strsql = "select * from Chi_Phi where Ma_Loai = '1' and So_Van_Ban = '" + this.WSoVanBan.Text.Trim() + "'"; 
            this.Div_SqlCT.InnerText = strsql;
            DataTable dttemp = DBClass.GetTable(strsql);
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
                    this.DDLMaVung.SelectedValue = dt.Rows[0]["Ma_Vung"].ToString().Trim();
                    this.WNgayLap.Value = (DateTime)dt.Rows[0]["Ngay_Lap"];
                    LoadChietTinh();
                }
            }
        }
        catch { }
    }
       
    private void LoadLoaiCongTac()
    {
        DataTable dt = DBClass.GetTable("select * from Loai_Cong_Tac order by Ten_Loai asc");
        this.DDLCongTac.DataSource = dt;
        this.DDLCongTac.DataBind();
    }

    private void LoadVatTu()
    {
        DataTable dtvt = DBClass.GetTable("select Ma_Chi_Phi, Ten_Chi_Phi from DM_Chi_Phi where Ma_Loai = '1' order by Ten_Chi_Phi asc" );
        this.LBVatTu.DataSource = dtvt;
        this.LBVatTu.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {       
        if (this.IsPostBack == false)
        {
            this.LoadLoaiCongTac();
            this.LoadVatTu();
            this.LoadThongTinBangChietTinh();            
            //this.Link_InCT.HRef = ResolveUrl("~/Chiet_Tinh/Report.aspx") + "?ID=" + this.WSoVanBan.Text.Trim();
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
            dtr["Nguoi_Lap"] = Session["Nhan_Vien"].ToString().Trim();
            dtr["Loai_Chiet_Tinh"] = this.DDLChietTinh.SelectedValue.Trim();
            dtr["Ma_Vung"] = this.DDLMaVung.SelectedValue.Trim();

            if (DBClass.UpdateTable("select * from Bang_Chiet_Tinh where So_Van_Ban = '" + this.WSoVanBan.Text.Trim() + "'", dt) == true)
            {
                this.UpdateCP();
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

    protected void BThem_Click(object sender, EventArgs e)
    {
        if (this.LBVatTu.SelectedIndex > -1)
        {
            string id_vt;
            int i = 0;
            Boolean cokq = false;
            DataTable checkvt = DBClass.GetTable("select * from DM_Chi_Phi where Ma_Loai = '1'");
            while (i < this.LBVatTu.Items.Count)
            {
                if (this.LBVatTu.Items[i].Selected)
                {
                    id_vt = this.LBVatTu.Items[i].Value.ToString().Trim();
                    DataTable dtvt = DBClass.GetTable("select * from Chi_Phi where So_Van_Ban = '" + this.WSoVanBan.Text.Trim() + "' and Ma_Chi_Phi = '" + id_vt.Trim() + "'");
                    if (dtvt.Rows.Count < 1)
                        {
                            DataRow[] mdtr = checkvt.Select("Ma_Chi_Phi = '" + id_vt.Trim() + "'");
                            
                            DataRow dtrvt = dtvt.NewRow();
                            dtrvt["So_Van_Ban"] = this.WSoVanBan.Text.Trim();
                            dtrvt["Ma_Chi_Phi"] = id_vt.Trim();
                            dtrvt["So_Luong"] = 0;
                            dtrvt["So_Luong_KH"] = 0;
                            dtrvt["Ma_Loai"] = "1";
                            if (mdtr.Length > 0)
                            {
                                dtrvt["Don_Gia"] = mdtr[0]["Don_Gia"];
                            }
                            dtvt.Rows.Add(dtrvt);
                            DBClass.UpdateTable("select * from Chi_Phi where So_Van_Ban = '" + this.WSoVanBan.Text.Trim() + "' and Ma_Chi_Phi = '" + id_vt.Trim() + "'", dtvt);
                            cokq = true;
                        }
                }
                i++;
            }
            if (cokq)
            {
                this.LoadChietTinh();
            }
        }
    }

    protected void BXoa_Click(object sender, EventArgs e)
    {
        int i = 0;
        string sqlstr = "select * from Chi_Phi where ( So_Van_Ban = '" + this.WSoVanBan.Text.Trim() + "' )";
        Boolean cpkq = false;
        while (i < this.MyGrid02.Rows.Count)
        {
            if (((CheckBox)this.MyGrid02.Rows[i].FindControl("CBXoa")).Checked==true)
            {
                if (cpkq)
                {
                    sqlstr = sqlstr + " or Ma_Chi_Phi = '" + ((Label)this.MyGrid02.Rows[i].FindControl("LIDVT")).Text + "'";
                }
                else
                {
                    sqlstr = sqlstr + " and ( Ma_Chi_Phi = '" + ((Label)this.MyGrid02.Rows[i].FindControl("LIDVT")).Text + "'";
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
            DBClass.UpdateTable(sqlstr,dt);
            this.LoadChietTinh();
        }
    }

    private void UpdateCP()
    {
        int i = 0;
        string sqlstr = "select * from Chi_Phi where ( So_Van_Ban = '" + this.WSoVanBan.Text.Trim() + "' )";
        Boolean cpkq = false;
        while (i < this.MyGrid02.Rows.Count)
        {
            if (cpkq)
            {
                sqlstr = sqlstr + " or Ma_Chi_Phi = '" + ((Label)this.MyGrid02.Rows[i].FindControl("LIDVT")).Text + "'";
            }
            else
            {
                sqlstr = sqlstr + " and ( Ma_Chi_Phi = '" + ((Label)this.MyGrid02.Rows[i].FindControl("LIDVT")).Text + "'";
                cpkq = true;
            }
            i++;
        }
        if (cpkq)
        {
            sqlstr = sqlstr + " )";
            DataTable dt = DBClass.GetTable(sqlstr);
            DataTable dtdgvt = DBClass.GetTable("select Ma_Chi_Phi, Don_Gia from DM_Chi_Phi where Ma_Loai = '1'");
            int j = 0;
            while (j < this.MyGrid02.Rows.Count)
            {
                string idvt = ((Label)this.MyGrid02.Rows[j].FindControl("LIDVT")).Text;
                string sl = ((TextBox)this.MyGrid02.Rows[j].FindControl("TBVTND")).Text;
                string slkh = ((TextBox)this.MyGrid02.Rows[j].FindControl("TBVTKH")).Text;
                double dgvt;
                try
                {
                     dgvt= double.Parse(((TextBox)this.MyGrid02.Rows[j].FindControl("TBVTGIA")).Text.Trim());
                }
                catch
                {
                    dgvt = 0;
                }

                i = 0;
                while (i < dt.Rows.Count)
                {
                    if (idvt.Trim()==dt.Rows[i]["Ma_Chi_Phi"].ToString().Trim())
                    {
                        dt.Rows[i]["So_Luong"] = sl;
                        dt.Rows[i]["So_Luong_KH"] = slkh;
                        DataRow[] mdtr = dtdgvt.Select("Ma_Chi_Phi = '" + idvt.Trim() + "'");
                        if (mdtr.Length > 0)
                        {
                            dt.Rows[i]["Don_Gia"] = dgvt;
                        }
                        break;
                    }
                    i++;
                }
                j++;
            }
            DBClass.UpdateTable(sqlstr, dt);
            this.LoadChietTinh();
            // add nhan cong
            DataTable dtnc = DBClass.GetTable("select * from Chi_Phi where Ma_Loai = '2' and So_Van_Ban = '" + this.WSoVanBan.Text.Trim() + "'");
            int bi = 0;
            while (bi < dtnc.Rows.Count)
            {
                dtnc.Rows[bi].Delete();
                bi++;
            }
            DBClass.UpdateTable("select * from Chi_Phi where Ma_Loai = '2' and So_Van_Ban = '" + this.WSoVanBan.Text.Trim() + "'", dt);

            DataTable dtlk = DBClass.GetTable("select * from Lien_Ket where Ma_Cong_Tac = '" + this.DDLCongTac.SelectedValue.Trim() + "'");
            DataTable dtdmnc = DBClass.GetTable("select * from DM_Chi_Phi where Ma_Loai = '2'");

            DataTableReader dttrvt = DBClass.GetTable("select * from Chi_Phi where So_Van_Ban = '" + this.WSoVanBan.Text.Trim() + "' and Ma_Loai = '1'").CreateDataReader();
            while (dttrvt.Read())
            {
                DataRow[] mdtr = dtlk.Select("Ma_Vat_Tu = '" + dttrvt["Ma_Chi_Phi"].ToString().Trim() + "'");
                bi = 0;
                while (bi < mdtr.Length)
                {
                    DataRow[] checkcp = dtnc.Select("Ma_Chi_Phi = '" + mdtr[bi]["Ma_Nhan_Cong"].ToString().Trim() + "'");
                    if (checkcp.Length < 1)
                    {
                        DataRow dtrnc = dtnc.NewRow();
                        double slkh = double.Parse(dttrvt["So_Luong_KH"].ToString().Trim());
                        double slnd = double.Parse(dttrvt["So_Luong"].ToString().Trim());
                        double tl = double.Parse(mdtr[bi]["Ti_Le"].ToString().Trim());
                        dtrnc["So_Van_Ban"] = this.WSoVanBan.Text.Trim();
                        dtrnc["Ma_Chi_Phi"] = mdtr[bi]["Ma_Nhan_Cong"].ToString().Trim();
                        dtrnc["So_Luong"] = slnd * tl;
                        dtrnc["So_Luong_KH"] = slkh * tl;
                        dtrnc["Ma_Loai"] = "2";
                        DataRow[] mdmnc = dtdmnc.Select("Ma_Chi_Phi = '" + mdtr[bi]["Ma_Nhan_Cong"].ToString().Trim() + "'");
                        if (mdmnc.Length > 0)
                        {
                            dtrnc["Don_Gia"] = mdmnc[0]["Don_Gia"];
                        }
                        dtnc.Rows.Add(dtrnc);
                    }
                    else
                    {
                        DataRow dtrnc = checkcp[0];
                        double slkh = double.Parse(dttrvt["So_Luong_KH"].ToString().Trim());
                        double slnd = double.Parse(dttrvt["So_Luong"].ToString().Trim());
                        double tl = double.Parse(mdtr[bi]["Ti_Le"].ToString().Trim());
                        dtrnc["So_Luong"] = double.Parse(dtrnc["So_Luong"].ToString().Trim()) + (slnd * tl);
                        dtrnc["So_Luong_KH"] = double.Parse(dtrnc["So_Luong_KH"].ToString().Trim()) + (slkh * tl);
                    }
                    bi++;
                }
            }
            DBClass.UpdateTable("select * from Chi_Phi where Ma_Loai = '2' and So_Van_Ban = '" + this.WSoVanBan.Text.Trim() + "'", dtnc);
        }
    }

    protected void BInChietTinh_Click(object sender, EventArgs e)
    {
        this.Response.Redirect(ResolveUrl("~/Chiet_Tinh/Report.aspx") + "?ID=" + this.WSoVanBan.Text.Trim());
    }
}

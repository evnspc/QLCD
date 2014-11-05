<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCMenuNV.ascx.cs" Inherits="CSKH_Control_WUCMenuNV" %>

<div style="text-align:left; width:100%">
    <div>
        <div class="DQ_Box_Top_Left"></div>
        <div class="DQ_Box_Top_Right"></div>
        <div class="DQ_Box_Top_Center" style="padding-left:8px;">            
            <asp:Label ID="LTieuDe" runat="server" Text="Nhân viên chiết tính" />
        </div>
    </div>
    <div class="DQ_Box_Middle" style=" padding: 5px 5px 10px 15px">
        <div style="padding: 3px;">
            <a href='<% = ResolveUrl("~/Chiet_Tinh/QLKhachHang.aspx") %>' class="DQ_Menu_Link">Quản lý khách hàng</a>
        </div>
        <div style="padding: 3px;">
            <a href='<% = ResolveUrl("~/Chiet_Tinh/TraCuuBCT.aspx") %>' class="DQ_Menu_Link">Tra cứu Bảng chiết tính</a>
        </div>
        <div style="padding: 3px;">
            <a href='<% = ResolveUrl("~/Chiet_Tinh/ThongTin.aspx") %>' class="DQ_Menu_Link">Thông tin tài khoản</a>
        </div>
        <div style="padding: 3px; display: none">
            <a href='<% = ResolveUrl("~/Chiet_Tinh/CRBaoCaoCP.aspx") %>' target="_blank" class="DQ_Menu_Link">Báo cáo vật tư</a>
        </div>
        <div style="padding: 3px; display: none">
            <a href='<% = ResolveUrl("~/Chiet_Tinh/CRBCTHCPBCT.aspx") %>' target="_blank" class="DQ_Menu_Link">Báo cáo tổng hợp</a>
        </div>
        <div style="padding: 3px;">
            <a href='<% = ResolveUrl("~/Default.aspx") %>' class="DQ_Menu_Link">Thoát</a>
        </div>
    </div>    
    <div>
        <div class="DQ_Box_Bottom_Left"></div>
        <div class="DQ_Box_Bottom_Right"></div>
        <div class="DQ_Box_Bottom_Center"></div>
    </div>
</div>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCMenuNVQL.ascx.cs" Inherits="CSKH_Control_WUCMenuNV" %>

<div style="text-align:left; width:100%">
    <div>
        <div class="DQ_Box_Top_Left"></div>
        <div class="DQ_Box_Top_Right"></div>
        <div class="DQ_Box_Top_Center" style="padding-left:8px;">            
            <asp:Label ID="LTieuDe" runat="server" Text="Nhân viên quản lý" />
        </div>
    </div>
    <div class="DQ_Box_Middle" style=" padding: 5px 5px 10px 15px">        
        <div style="padding: 3px;">
            <a href='<% = ResolveUrl("~/Chiet_Tinh/DMChiPhi.aspx") %>' class="DQ_Menu_Link">Quản lý chi phí</a>
        </div>
        <div style="padding: 3px;">
            <a href='<% = ResolveUrl("~/Chiet_Tinh/CNDonGia.aspx") %>' class="DQ_Menu_Link">Cập nhật CP theo file</a>
        </div>
        <div style="padding: 3px;">
            <a href='<% = ResolveUrl("~/Chiet_Tinh/QLNLoaiChiPhi.aspx") %>' class="DQ_Menu_Link">Quản lý nhóm chi phí</a>
        </div>
        <div style="padding: 3px;">
            <a href='<% = ResolveUrl("~/Chiet_Tinh/QLLoaiChiPhi.aspx") %>' class="DQ_Menu_Link">Quản lý chi tiết nhóm CP</a>
        </div>
        <div style="padding: 3px;">
            <a href='<% = ResolveUrl("~/Chiet_Tinh/QLHeSo.aspx") %>' class="DQ_Menu_Link">Quản lý hệ số CP</a>
        </div>
        <div style="padding: 3px;">
            <a href='<% = ResolveUrl("~/Chiet_Tinh/LoaiCongTac.aspx") %>' class="DQ_Menu_Link">Quản lý loại công tác</a>
        </div>
        <div style="padding: 3px;">
            <a href='<% = ResolveUrl("~/Chiet_Tinh/QuyetDinh.aspx") %>' class="DQ_Menu_Link">Quản lý quyết định</a>
        </div>
        <div style="padding: 3px;">
            <a href='<% = ResolveUrl("~/Chiet_Tinh/QLHSHienTai.aspx") %>' class="DQ_Menu_Link">Quyết định áp dụng</a>
        </div>
        <div style="padding: 3px;">
            <a href='<% = ResolveUrl("~/Chiet_Tinh/QLLienKet.aspx") %>' class="DQ_Menu_Link">Quản lý liên kết</a>
        </div>
        <div style="padding: 3px;">
            <a href='<% = ResolveUrl("~/Chiet_Tinh/CNLienKet.aspx") %>' class="DQ_Menu_Link">QL liên kết theo file</a>
        </div>
        <div style="padding: 3px;">
            <a href='<% = ResolveUrl("~/Chiet_Tinh/QLLoaiCTMau.aspx") %>' class="DQ_Menu_Link">Quản lý loại CT mẫu</a>
        </div>
        <div style="padding: 3px;">
            <a href='<% = ResolveUrl("~/Chiet_Tinh/QLChietTinhMau.aspx") %>' class="DQ_Menu_Link">Quản lý chiết tính mẫu</a>
        </div>
        <div style="padding: 3px;">
            <a href='<% = ResolveUrl("~/Chiet_Tinh/QLThongBao.aspx") %>' class="DQ_Menu_Link">Cập nhật thông báo</a>
        </div>        
        <div style="padding: 3px;">
            <a href='<% = ResolveUrl("~/Chiet_Tinh/ThongTin.aspx") %>' class="DQ_Menu_Link">Thông tin tài khoản</a>
        </div>
        <div style="padding: 3px;">
            <a href='<% = ResolveUrl("~/Chiet_Tinh/BaoCaoThongKe.aspx") %>' class="DQ_Menu_Link">Báo cáo thống kê</a>
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
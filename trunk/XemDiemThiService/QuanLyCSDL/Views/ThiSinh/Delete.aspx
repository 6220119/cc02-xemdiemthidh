<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QuanLyCSDL.DAL.ThiSinh>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Xóa
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Xóa</h2>

    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%: Model.Id %></div>
        
        <div class="display-label">Ngành</div>
        <div class="display-field"><%: Model.Nganh.TenNganh %></div>
        
        <div class="display-label">HoTen</div>
        <div class="display-field"><%: Model.HoTen %></div>
        
        <div class="display-label">Ngày Sinh</div>
        <div class="display-field"><%: String.Format("{0:dd/MM/yyyy}", Model.NgaySinh) %></div>
        
        <div class="display-label">Quê quán</div>
        <div class="display-field"><%: Model.QueQuan %></div>
        
        <div class="display-label">Giới Tính</div>
        <div class="display-field"><%: Model.GioiTinh == true ? "Nam" : "Nữ"%></div>
        
        <div class="display-label">Điểm 1</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.Diem1) %></div>
        
        <div class="display-label">Điểm 2</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.Diem2) %></div>
        
        <div class="display-label">Điểm 3</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.Diem3) %></div>
        
        <div class="display-label">Số Báo Danh</div>
        <div class="display-field"><%: Model.SoBaoDanh %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%: Html.ActionLink("Quay lại danh sách", "Index")%>
        </p>
    <% } %>

</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QuanLyCSDL.DAL.Nganh>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%: Model.Id %></div>
        
        <div class="display-label">Tên Trường</div>
        <div class="display-field"><%: Model.Truong.TenTruong %></div>
        
        <div class="display-label">Tên Ngành</div>
        <div class="display-field"><%: Model.TenNganh %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%: Html.ActionLink("Quay lại danh sách", "Index")%>
        </p>
    <% } %>

</asp:Content>


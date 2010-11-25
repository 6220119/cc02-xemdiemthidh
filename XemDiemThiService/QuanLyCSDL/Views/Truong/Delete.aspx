<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QuanLyCSDL.DAL.Truong>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Xóa
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Xóa</h2>

    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">MaTruong</div>
        <div class="display-field"><%: Model.MaTruong %></div>
        
        <div class="display-label">TenTruong</div>
        <div class="display-field"><%: Model.TenTruong %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%: Html.ActionLink("Quay lại danh sách", "Index")%>
        </p>
    <% } %>

</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QuanLyCSDL.Helpers.PaginatedList<QuanLyCSDL.DAL.Truong>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Danh sách các trường trong CSDL
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Danh sách các trường trong CSDL</h2>
    <h3>Tổng số trường: <%: Model.Count %></h3>

    <table>
        <tr>
            <th></th>
            <th>
                Mã Trường
            </th>
            <th>
                Tên Trường
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Sửa", "Edit", new { id = item.MaTruong })%> |
                <%: Html.ActionLink("Xóa", "Delete", new { id = item.MaTruong })%>
            </td>
            <td>
                <%: item.MaTruong %>
            </td>
            <td>
                <%: item.TenTruong %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <% if (Model.HasPreviousPage)
       { %>
        <%: Html.RouteLink("<<< Previous page  ", "ListTruong",
               new { page = (Model.PageIndex - 1) } ) %>
    <% } %>

    <% if (Model.HasNextPage)
       { %>
        <%: Html.RouteLink("  Next page >>>", "ListTruong", 
            new { page = (Model.PageIndex + 1) } ) %>
    <% } %>
    <br />
    <p>
        <%: Html.ActionLink("Thêm trường mới", "Create")%>
    </p>

</asp:Content>


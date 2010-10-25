<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QuanLyCSDL.Helpers.PaginatedList<QuanLyCSDL.DAL.Nganh>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Danh sách các ngành trong CSDL
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Danh sách các ngành trong CSDL</h2>
    <h3>Tổng số ngành: <%: Model.Count %></h3>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                Tên Trường
            </th>
            <th>
                Tên Ngành
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Sửa", "Edit", new { id = item.Id })%> |
                <%: Html.ActionLink("Xóa", "Delete", new { id = item.Id })%>
            </td>
            <td>
                <%: item.Id %>
            </td>
            <td>
                <%: item.Truong.TenTruong %>
            </td>
            <td>
                <%: item.TenNganh %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <% if (Model.HasPreviousPage)
       { %>
        <%: Html.RouteLink("<<< Previous page  ", "ListNganh",
               new { page = (Model.PageIndex - 1) } ) %>
    <% } %>

    <% if (Model.HasNextPage)
       { %>
        <%: Html.RouteLink("  Next page >>>", "ListNganh", 
            new { page = (Model.PageIndex + 1) } ) %>
    <% } %>
    <br />

    <p>
        <%: Html.ActionLink("Thêm ngành mới", "Create")%>
    </p>

</asp:Content>


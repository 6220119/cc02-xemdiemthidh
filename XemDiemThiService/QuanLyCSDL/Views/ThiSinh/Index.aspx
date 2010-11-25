<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QuanLyCSDL.Helpers.PaginatedList<QuanLyCSDL.DAL.ThiSinh>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                Số Báo Danh
            </th>
            <th>
                Trường
            </th>
            <th>
                Ngành Thi
            </th>
            <th>
                Họ Tên
            </th>
            <th>
                Ngày Sinh
            </th>
            <th>
                Quê Quán
            </th>
            <th>
                Giới Tính
            </th>
            <th>
                Điểm 1
            </th>
            <th>
                Điểm 2
            </th>
            <th>
                Điểm 3
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.Id })%>
            </td>
            <td>
                <%: item.Id %>
            </td>
            <td>
                <%: item.SoBaoDanh %>
            </td>
            <td>
                <%: item.Nganh.Truong.TenTruong %>
            </td>
            <td>
                <%: item.Nganh.TenNganh %>
            </td>
            <td>
                <%: item.HoTen %>
            </td>
            <td>
                <%: String.Format("{0:dd/MM/yyyy}", item.NgaySinh) %>
            </td>
            <td>
                <%: item.QueQuan %>
            </td>
            <td>
                <%: item.GioiTinh == true ? "Nam" : "Nữ" %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.Diem1) %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.Diem2) %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.Diem3) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <% if (Model.HasPreviousPage)
       { %>
        <%: Html.RouteLink("<<< Previous page  ", "ListThiSinh",
               new { page = (Model.PageIndex - 1) } ) %>
    <% } %>

    <% if (Model.HasNextPage)
       { %>
        <%: Html.RouteLink("  Next page >>>", "ListThiSinh", 
            new { page = (Model.PageIndex + 1) } ) %>
    <% } %>
    <br />
    <p>
        <%: Html.ActionLink("Thêm thí sinh mới", "Create")%>
    </p>

</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QuanLyCSDL.Models.NganhViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Nganh.MaTruong)%>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(m => m.Nganh.MaTruong, Model.ListTruongs ) %>
                <%: Html.ValidationMessageFor(model => model.Nganh.MaTruong) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Nganh.TenNganh)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Nganh.TenNganh)%>
                <%: Html.ValidationMessageFor(model => model.Nganh.TenNganh)%>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Quay lại danh sách", "Index")%>
    </div>

</asp:Content>


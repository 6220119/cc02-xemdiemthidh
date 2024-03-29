﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QuanLyCSDL.DAL.Truong>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Sửa
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Sửa</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.MaTruong) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.MaTruong, new { disabled = true })%>
                <%: Html.ValidationMessageFor(model => model.MaTruong) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.TenTruong) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.TenTruong) %>
                <%: Html.ValidationMessageFor(model => model.TenTruong) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Quay lại danh sách", "Index")%>
    </div>

</asp:Content>


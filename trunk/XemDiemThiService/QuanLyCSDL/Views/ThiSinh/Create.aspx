<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QuanLyCSDL.Models.ThiSinhViewModel>" %>

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
                Trường + Ngành:
            </div>
            <div class="editor-field">
                <%: Html.DropDownList("MaTruong", Model.ListTruongs) %>

                <%: Html.DropDownListFor(m => m.ThiSinh.IdNganh, Model.ListNganhs)%>
                <%: Html.ValidationMessageFor(model => model.ThiSinh.IdNganh)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ThiSinh.HoTen)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ThiSinh.HoTen)%>
                <%: Html.ValidationMessageFor(model => model.ThiSinh.HoTen)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ThiSinh.NgaySinh)%>
            </div>
            <div class="editor-field">
                <input readonly=true type="text" name="ThiSinh_NgaySinh" id="ThiSinh_NgaySinh" value="<%: Model.ThiSinh.NgaySinh.ToShortDateString() %>"/>
                <%: Html.ValidationMessageFor(model => model.ThiSinh.NgaySinh)%>

                <script type="text/javascript">
                    //

                    $('#ThiSinh_NgaySinh').DatePicker({
                        format: 'm/d/Y',
                        date: $('#ThiSinh_NgaySinh').val(),
                        current: $('#ThiSinh_NgaySinh').val(),
                        starts: 1,
                        //position: 'r',
                        onBeforeShow: function () {
                            $('#ThiSinh_NgaySinh').DatePickerSetDate($('#ThiSinh_NgaySinh').val(), true);
                        },
                        onChange: function (formated, dates) {
                            $('#ThiSinh_NgaySinh').val(formated);
                            //$('#inputDate').DatePickerHide();
                        }
                    });
                </script>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ThiSinh.QueQuan)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ThiSinh.QueQuan)%>
                <%: Html.ValidationMessageFor(model => model.ThiSinh.QueQuan)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ThiSinh.GioiTinh)%>
            </div>
            <div class="editor-field">
                Nam: <%: Html.CheckBoxFor(model => model.ThiSinh.GioiTinh)%>
                <%: Html.ValidationMessageFor(model => model.ThiSinh.GioiTinh)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ThiSinh.Diem1)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ThiSinh.Diem1, String.Format("{0:F}", Model.ThiSinh.Diem1))%>
                <%: Html.ValidationMessageFor(model => model.ThiSinh.Diem1)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ThiSinh.Diem2)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ThiSinh.Diem2, String.Format("{0:F}", Model.ThiSinh.Diem2))%>
                <%: Html.ValidationMessageFor(model => model.ThiSinh.Diem2)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ThiSinh.Diem3)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ThiSinh.Diem3, String.Format("{0:F}", Model.ThiSinh.Diem3))%>
                <%: Html.ValidationMessageFor(model => model.ThiSinh.Diem3)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ThiSinh.SoBaoDanh)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBox("SBD", Model.ThiSinh.SoBaoDanh, new {@readonly = true})%>
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


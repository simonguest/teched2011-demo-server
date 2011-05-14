<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TechEdDemoMVC.Models.Session>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

<fieldset>
    <legend>Session</legend>

    <div class="display-label">Code</div>
    <div class="display-field"><%: Model.Code %></div>

    <div class="display-label">Title</div>
    <div class="display-field"><%: Model.Title %></div>

    <div class="display-label">Room</div>
    <div class="display-field"><%: Model.Room %></div>

    <div class="display-label">Hash</div>
    <div class="display-field"><%: Model.Hash %></div>
</fieldset>
<p>

    <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>


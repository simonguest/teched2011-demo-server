<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MobileSite.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<TechEdDemoMVC.Models.Session>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Sessions On Right Now!</h2>

<ul data-role="listview" data-inset="true" data-theme="c" data-dividertheme="b">
<% foreach (var item in Model) { %>
    <li><%: Html.ActionLink(item.Code+" "+item.Title, "Details", new {id = item.Id}) %></li> 
<% } %>
</ul>

</asp:Content>


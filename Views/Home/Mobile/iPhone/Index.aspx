<%@ Page Language="C#" MasterPageFile="~/Views/Shared/MobileSite.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewBag.Message %></h2>
    <p>HELLO IPHONE!</p>
    <p>
        <%: Html.ActionLink("Sessions On Now", "Index", "Session", null, new { @data_role = "button" })%>
    </p>
</asp:Content>

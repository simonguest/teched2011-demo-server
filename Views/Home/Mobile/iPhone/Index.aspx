<%@ Page Language="C#" MasterPageFile="~/Views/Shared/iPhone.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewBag.Message %></h2>
    <p>HELLO IPHONE!</p>
    <p>If you can read this, my demo is working!</p>
    <p>You can use this site to view the list of sessions, by clicking the link below.</p>
    <p>
        <%: Html.ActionLink("Sessions On Now", "Index", "Session", null, new { @data_role = "button" })%>
    </p>

    <br />
    <br />
    <br />
</asp:Content>

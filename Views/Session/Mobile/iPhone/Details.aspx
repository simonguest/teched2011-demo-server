<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MobileSite.Master" Inherits="System.Web.Mvc.ViewPage<TechEdDemoMVC.Models.Session>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Session Details</h2>

<fieldset>
    <h4>Code: <%: Model.Code %></h4>
    <h4>Title: <%: Model.Title %></h4>
    <h4>Room:  <%: Model.Room %></h4>
    <h4>Speaker: <%: Model.PrimarySpeakers.First().Name %></h4>
    
</fieldset>

</asp:Content>


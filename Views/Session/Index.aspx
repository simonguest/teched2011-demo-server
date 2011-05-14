<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<TechEdDemoMVC.Models.Session>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Sessions On Right Now!</h2>

<table>
    <tr>
        <th></th>
        <th>
            Code
        </th>
        <th>
            Title
        </th>
        <th>
            Room
        </th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
            <%: Html.ActionLink("Details", "Details", new { id=item.Id }) %>
        </td>
        <td>
            <%: item.Code %>
        </td>
        <td>
            <%: item.Title %>
        </td>
        <td>
            <%: item.Room %>
        </td>
    </tr>  
<% } %>

</table>

<p>
    <%: Html.ActionLink("Back to Home", "Index", "Home") %>
</p>

</asp:Content>


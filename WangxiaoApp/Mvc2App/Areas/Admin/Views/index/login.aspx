<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>login</title>
</head>
<body>
    <div>
    <%=Html.ActionLink("index", "Login")%>
    <% using (Html.BeginForm("test", "index"))
             { %>
             <%=Html.TextBox("ProductName") %>
             <%= ViewData["title"] %>
             <button type="submit" value="OK">OK</button>
    <% } %>    </div>
</body>
</html>

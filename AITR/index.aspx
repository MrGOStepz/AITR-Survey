<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AITR.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hello</title>
     <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
     <%--Add CSS Framwork Bootstrap Version 4--%>
     <link href="~/Styles/bootstrap.css" rel="stylesheet" type="text/css" />
</head>
<body style ="margin-top:100px;">
    <form id="form1" runat="server">
        <nav class="navbar fixed-top navbar-expand-lg navbar-dark bg-dark justify-content-between">
            <a class="navbar-brand" href="#">AITR</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item"><asp:Label ID="lbIPAddress" runat="server" Text="IPAddress:" style="color:White;"></asp:Label></li>
                    <li class="nav-item"><asp:Label ID="lbDate" runat="server" Text="Date:" style= "color:White;"></asp:Label> </li>
                </ul>

                <asp:TextBox ID="txtUserName" runat="server" placeholder="User Name" CssClass="mr-sm-2"></asp:TextBox>
                <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" type="password" CssClass="mr-sm-2"></asp:TextBox>
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-success my-2 my-sm-0" type="submit" onclick="btnLogin_Click"></asp:Button>&nbsp
                <asp:Button ID="btnResgister" runat="server" Text="Register" CssClass="btn btn-danger my-2 my-sm-0" type="submit" onclick="btnRegister_Click"></asp:Button>     
            </div>
        </nav>
        <div class="container">
            <div class="row">
                <div class="col">
                    <div class="jumbotron" style="height:300px;">
                        <asp:Button ID="btnGoToRegister" runat="server" Text="Register" CssClass="btn btn-info" style= "width:100%;height:100%;font-size:50px; margin:auto;" OnClick="btnGoToRegister_Click"></asp:Button>
                    </div>
                </div>
                <div class="col">
                    <div class="jumbotron" style="height:300px;">
                        <asp:Button ID="btnGoToQuestion" runat="server" Text="Without Register" CssClass="btn btn-warning" style= "width:100%;height:100%;font-size:50px; margin:auto;" OnClick="btnGoToQuestion_Click"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

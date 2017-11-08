<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AITR.Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="//maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet">
    <title>Register Member</title>
</head>
<body style="margin-top:100px;">
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
    <div class="row">
        <div class="col-xl-12">
            <p style="text-align: center;""><asp:Label ID="lbLoginError" runat="server" Text="Incorrect Username or Password!" CssClass="alert alert-danger" Visible="False"></asp:Label></p>
    
        </div>
    </div>
    
    <div id="login-overlay" class="modal-dialog">
        <div class="modal-content">
            <div class="modal-body">
                <div class="row"> 
                    <div class="col-xl-12">
                        <p style="text-align: center;" class="h4">Register</p>
                        <div class="jumbotron">
                            <div class="form-group">
                                <label for="username" class="control-label">Username</label>
                                <asp:TextBox ID="txtUserNameStaff" runat="server" CssClass="form-control" title="Please enter your Username"></asp:TextBox>                                          
                            </div>
                            <div class="form-group">
                                <label for="password" class="control-label">Password</label>
                                <asp:TextBox ID="txtPasswordStaff" runat="server" CssClass="form-control" title="Please enter your password" TextMode="Password"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="password" class="control-label">Confirm Password</label>
                                <asp:TextBox ID="txtConfirmPW" runat="server" CssClass="form-control" title="Please confirm your Username" TextMode="Password"></asp:TextBox>
                            </div> 
                            <asp:Button ID="btnStaffRegister" runat="server" Text="Register" class="btn btn-danger btn-block" OnClick="btnStaffRegister_Click" /> <br />
                            <asp:Label ID="lbAlerts" runat="server" CssClass="alert alert-danger" Visible="False"></asp:Label>
                       </div>
                   </div>
               </div>
           </div>
       </div>
    </div>
    </form>
</body>
</html>

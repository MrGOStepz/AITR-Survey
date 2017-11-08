<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterMember.aspx.cs" Inherits="AITR.RegisterMember" %>

<!DOCTYPE html>

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
    
    <div id="login-overlay" class="modal-dialog">
        <div class="modal-content">
            <div class="modal-body">
                <div class="row"> 
                    <div class="col-xl-12">
                        <p style="text-align: center;" class="h4">Register</p>
                        <div class="jumbotron">
                            <div class="form-group">
                                <label for="fistname" class="control-label">First name</label>
                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" title="Please enter your first name"></asp:TextBox>                                          
                            </div>
                            <div class="form-group">
                                <label for="lastname" class="control-label">Last name</label>
                                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" title="Please enter your Last name"></asp:TextBox>                                          
                            </div>
                            <div class="form-group">
                                <label for="phonenumber" class="control-label">Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" title="Email"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ControlToValidate="txtEmail" ErrorMessage="Email is required"
                                        SetFocusOnError="True" ></asp:RequiredFieldValidator>

                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                             ErrorMessage="Invalid Email" ControlToValidate="txtEmail"
                                             SetFocusOnError="True"
                                             ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                </asp:RegularExpressionValidator>
                            </div> 
                            <div class="form-group">
                                <label for="dob" class="control-label">Date of birth</label>
                                <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" title="Date if birth"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="dateValRegex" runat="server" 
                                    ControlToValidate="txtDOB" 
                                    ErrorMessage="Please Enter a valid date in the format (mm/dd/yyyy)" 
                                    ValidationExpression="^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d">
                                </asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label for="phonenumber" class="control-label">Phone Number</label>
                                <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" title="Phone number"></asp:TextBox>
                            </div> 
                            <asp:Button ID="btnRespondentRegister" runat="server" Text="Register" class="btn btn-danger btn-block" OnClick="btnRespondentRegister_Click"/> <br />
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

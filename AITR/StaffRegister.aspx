<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffRegister.aspx.cs" Inherits="AITR.StaffRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div aria-autocomplete="list">
        &nbsp;<asp:Label ID="lbUserName" runat="server" Text=5"User Name"></asp:Label>
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="txtPW" runat="server"></asp:TextBox>
            <br />
            Confirm Password
            <asp:TextBox ID="txtConfirmPW" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="txtReset" runat="server" OnClick="txtReset_Click" Text="Reset" />
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
            <br />
            <asp:Label ID="lbShowMessage" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>

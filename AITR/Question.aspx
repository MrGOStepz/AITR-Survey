<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="AITR.Question" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Styles/bootstrap.css" rel="stylesheet" type="text/css" />

    <title>Question</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
        <div class="row justify-content-center">
        <div class="jumbotron" style="width: 400px;">
        <div class="col-12 ">
                <asp:PlaceHolder ID="phUserControl" runat="server"></asp:PlaceHolder> <br />
            </div>
        </div>
        </div>
        <div class="row justify-content-center">
        <div class="col-4">
            <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="btn btn-info" style="width:100%;" 
                onclick="btnNext_Click"/>
        </div>
        </div>
        </div>
    </form>
</body>
</html>

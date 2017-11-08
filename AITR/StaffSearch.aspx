<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffSearch.aspx.cs" Inherits="AITR.StaffSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<%--    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">--%>

    <link href="~/Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <%--<link href="~/Styles/table.scss" rel="stylesheet" type="text/css" />--%>
    <link href="Styles/table.css" rel="Stylesheet" type="text/css" />

    <title>Staff Search!</title>
</head>
<body style="margin-top:70px;">
    <form id="form1" runat="server">
        <nav class="navbar fixed-top navbar-expand-lg navbar-dark bg-dark justify-content-between">
            <a class="navbar-brand" href="#">AITR</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item"><asp:Label ID="lbUerName" runat="server" Text="Hello" style="color:White;"></asp:Label></li>
                </ul>                   
            </div>
        </nav>

        <div class="container">
            <div class="row">
                <div class="col">
                    <div class="dropdown">
                        <asp:Label ID="lbChooseQuestion" runat="server" Text="Choose Question: "></asp:Label><asp:DropDownList ID="ddList" runat="server" CssClass="btn btn-secondary dropdown-toggle" style ="width:70%;"></asp:DropDownList>
                        </div>
                    </div>
                <div class="col">
                    
                    <asp:Button ID="btnAddFilter" runat="server" CssClass="btn btn-danger my-2 my-sm-0" Text="+" type="submit" style ="width:20%;" OnClick="btnAddFilter_Click"></asp:Button>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-info my-2 my-sm-0" type="submit" style ="width:40%;" OnClick="btnSearch_Click"></asp:Button>
                    </div>   
            </div>
            <div class="jumbotron" style ="margin-top:10px;margin-bottom:10px;padding: 1rem 1rem;">
                <div class="row">
                    <asp:PlaceHolder ID="phFilter" runat="server"></asp:PlaceHolder>
                </div>
            </div>
            </div>
        <div class="row">
            <div class="col">
            <asp:GridView ID="gvSearch" runat="server" AutoGenerateColumns="False" CssClass="containertable">
                <Columns>
                    <asp:BoundField DataField="respondent_id" HeaderText="Respondent ID"  />
                    <asp:BoundField DataField="first_name" HeaderText="First Name" />
                    <asp:BoundField DataField="last_name" HeaderText="Last Name" />
                    <asp:BoundField DataField="dob" HeaderText="DOB" />
                    <asp:BoundField DataField="phone" HeaderText="Phone No." />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:BoundField DataField="ip_address" HeaderText="IP Address" />
                    <asp:BoundField DataField="do_date" HeaderText="Date" />
    </Columns>
                </asp:GridView>
                </div>
        </div>
    </form>
    
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="ww.gsha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js" integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js" integrity="sha384-h0AbiXch4ZDo7tp9hKZ4TsHbi047NrKGLO3SEJAg45jXxnGIfYzk4Si90RDIqNm1" crossorigin="anonymous"></script>
    <%--<script src="Scripts/table.js" type="text/javascript"></script>--%>
</body>
</html>

<%@ Page Title="" Language="C#" MasterPageFile="TicketMaster.master" AutoEventWireup="true"
    CodeFile="LandingPage.aspx.cs" Inherits="LandingPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--  Welcome,
    <asp:Label ID="lblUser" runat="server"></asp:Label>
    
    <asp:Button ID="btnLogOut" runat="server" CssClass="logOutBtn" OnClick="logOutButton_Click" Text="LogOut" />--%>
        <style>
        /* @import "bourbon"; */
        
        a
        {
            color: White;
        }
        
        a:hover
        {
            color: White;
        }
        
        body
        {
            font-family: Montserrat;
            font-size: large;
            line-height: 1.5em;
            font-weight: 400;
        }
        
        p, span, a, ul, li, button
        {
            font-family: inherit;
            font-size: inherit;
            font-weight: inherit;
            line-height: inherit;
        }
        
        strong
        {
            font-weight: 600;
        }
        
        h1, h2, h3, h4, h5, h6
        {
            font-family: 'Open Sans' , "Segoe UI" , Frutiger, "Frutiger Linotype" , "Dejavu Sans" , "Helvetica Neue" , Arial, sans-serif;
            line-height: 1.5em;
            font-weight: 300;
        }
        
        strong
        {
            font-weight: 400;
        }
        
        .tile
        {
            width: auto;
            display: inline-block;
            box-sizing: border-box;
            background: #fff;
            padding: 20px;
            margin-bottom: 10px;
        }
        
        .title
        {
            margin-top: 0px;
        }
        
        .purple, .blue, .red, .orange, .green
        {
            color: #fff;
        }
        
        .purple
        {
            background: #5133AB;
        }
        
        .purple a:hover
        {
            background: darken(#5133AB, 10%);
        }
        
        
        .red
        {
            background: #AC193D;
        }
        
        .red:hover
        {
            background: darken(#AC193D, 10%);
        }
        
        .green
        {
            background: #00A600;
        }
        
        
        .green a:hover
        {
            background: darken(#00A600, 10%);
        }
        
        .blue
        {
            background: #2672EC;
        }
        
        .blue a:hover
        {
            background: darken(#2672EC, 10%);
        }
        
        .orange
        {
            background: #DC572E;
        }
        
        .orange a:hover
        {
            background: darken(#DC572E, 10%);
        }
        
        .black
        {
            background-color: Black;
        }
    </style>




    <style>
        li a
        {
            background: rgba(164,179,87,1);
            background: -moz-linear-gradient(-45deg, rgba(164,179,87,1) 0%, rgba(164,179,87,1) 54%, rgba(117,137,12,1) 100%);
            background: -webkit-gradient(left top, right bottom, color-stop(0%, rgba(164,179,87,1)), color-stop(54%, rgba(164,179,87,1)), color-stop(100%, rgba(117,137,12,1)));
            background: -webkit-linear-gradient(-45deg, rgba(164,179,87,1) 0%, rgba(164,179,87,1) 54%, rgba(117,137,12,1) 100%);
            background: -o-linear-gradient(-45deg, rgba(164,179,87,1) 0%, rgba(164,179,87,1) 54%, rgba(117,137,12,1) 100%);
            background: -ms-linear-gradient(-45deg, rgba(164,179,87,1) 0%, rgba(164,179,87,1) 54%, rgba(117,137,12,1) 100%);
            background: linear-gradient(135deg, rgba(164,179,87,1) 0%, rgba(164,179,87,1) 54%, rgba(117,137,12,1) 100%);
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#a4b357', endColorstr='#75890c', GradientType=1 );
        }
        
        li a:hover
        {
            background: rgba(164,179,87,1);
            background: -moz-linear-gradient(-45deg, rgba(164,179,87,1) 0%, rgba(117,137,12,1) 45%, rgba(117,137,12,1) 100%);
            background: -webkit-gradient(left top, right bottom, color-stop(0%, rgba(164,179,87,1)), color-stop(45%, rgba(117,137,12,1)), color-stop(100%, rgba(117,137,12,1)));
            background: -webkit-linear-gradient(-45deg, rgba(164,179,87,1) 0%, rgba(117,137,12,1) 45%, rgba(117,137,12,1) 100%);
            background: -o-linear-gradient(-45deg, rgba(164,179,87,1) 0%, rgba(117,137,12,1) 45%, rgba(117,137,12,1) 100%);
            background: -ms-linear-gradient(-45deg, rgba(164,179,87,1) 0%, rgba(117,137,12,1) 45%, rgba(117,137,12,1) 100%);
            background: linear-gradient(135deg, rgba(164,179,87,1) 0%, rgba(117,137,12,1) 45%, rgba(117,137,12,1) 100%);
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#a4b357', endColorstr='#75890c', GradientType=1 );
        }
        
        #cphContent_dlAppList
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <br />
    <div class="row container" style="font-family: Montserrat; font-size: large;">
        Here are your applications that you can access:
    </div>

   <%-- <div align="center" style="margin: 80px;">--%>
      <%--  <asp:DataList ID="dlAppList" runat="server" RepeatColumns="3">
            <ItemTemplate>--%>
                <%--<div class="card-columns">--%>
                   <%-- <div class="card bg-dark text-white text-center p-3">
                        <div class="card-body">
                            <h5 class="card-title">
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("AppURL") %>' Visible="false"></asp:Label>
                            <asp:LinkButton ID="LinkButton1" runat="server" Target="_blank" Text='<%# Eval("AppName") %>'
                                OnClick="btnClick" PostBackUrl="" ForeColor="White"></asp:LinkButton></h5>
                        </div>
                    </div>--%>
                <%--</div>--%>
           <%-- </ItemTemplate>
        </asp:DataList>--%>
       <%-- <asp:DataList ID="dlAppList" runat="server">
            <ItemTemplate>--%>
                <%--<ul style="width: 100%; background-color: transparent; font-size: large; text-align: center;
                    font-weight: bold; list-style: none;" class="list-group">
                    <li style="width: 100%;">--%>
                        <%--<asp:Label ID="lblAppID" runat="server" Text='<%# Eval("AppURL") %>' Visible="false"></asp:Label>--%>
                        <%-- <asp:LinkButton ID="Hyperlink1" runat="server" CssClass="linkbottom1"  NavigateUrl='<%# EncryptQueryString(Eval("AppURL").ToString()) %>' Target="_blank" Text='<%# Eval("AppName") %>' OnClick="btnClick" ></asp:LinkButton></li>--%>
                        <%--<asp:LinkButton ID="Hyperlink1" runat="server" Target="_blank" Text='<%# Eval("AppName") %>'
                            ForeColor="White" OnClick="btnClick" PostBackUrl="" CssClass="list-group-item"
                            Width="100%"></asp:LinkButton>--%>
                 <%--   <div class="card-columns">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("AppURL") %>' Visible="false"></asp:Label></h5>
                                <asp:LinkButton ID="LinkButton1" runat="server" Target="_blank" Text='<%# Eval("AppName") %>'  OnClick="btnClick" PostBackUrl="" CssClass="list-group-item"
                                    Width="100%"></asp:LinkButton>
                           </div>
                           
                        </div>
                        </div>--%>
                    <%--</li>
                </ul>--%>
          <%--  </ItemTemplate>
        </asp:DataList>--%>
   <%-- </div>--%>

     <div style="margin: 100px;">
        <table id="tbl" style="margin: auto;">
            <tr>
                <asp:Repeater ID="dlAppList" runat="server">
                    <ItemTemplate>
                        <td id="Td1" runat="server">
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("AppURL") %>' Visible="false"></asp:Label>
                            <asp:LinkButton ID="LinkButton1" runat="server" Target="_blank" Text='<%# Eval("AppName") %>'
                                OnClick="btnClick" PostBackUrl=""></asp:LinkButton>
                        </td>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        </tr>
                        <tr>
                    </SeparatorTemplate>
                </asp:Repeater>
            </tr>
        </table>
    </div>

    <script type="text/javascript">
        var table = document.getElementById('tbl');
        var tbody = table.getElementsByTagName('tbody')[0];
        //  var rows = tbody.getElementsByTagName('tr');
        var cells = tbody.getElementsByTagName('td');
        //for (var j = 0, rowlen = rows.length; j < rowlen; j++ ) {
        for (var i = 0, len = cells.length; i < len; i++) {
            if (i % cells.length === 0) {
                cells[i].className = 'tile red';
            }
            else if (i % cells.length === 1) {
                cells[i].className = 'tile green';
            }
            else if (i % cells.length === 2) {
                cells[i].className = 'tile blue';
            }
            else if (i % cells.length === 3) {
                cells[i].className = 'tile orange';
            }
            else if (i % cells.length === 4) {
                cells[i].className = 'tile purple';
            }
            else if (i % cells.length === 5) {
                cells[i].className = 'tile black';
            }
        }
        //  }
</script>
</asp:Content>

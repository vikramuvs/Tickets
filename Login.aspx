<%@ Page Title="" Language="C#" MasterPageFile="LoginMaster.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  <link rel="Stylesheet" href="Styles/LoginCSS.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
   <%-- <div style="background-color: #e4edd1; align-items: center; position: absolute; left: 35%;
        top: 30%; min-height: 400px;">
        <table>
            <thead>
                <tr>
                    <td>
                    </td>
                    <td colspan="3">
                        Please enter your Aranya Email Credentials here
                    </td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td style="width: 50px;">
                    </td>
                    <td>
                        Username: <a style="color: Red">*</a>
                    </td>
                    <td>
                        <asp:TextBox ID="tbUserName" runat="server" Placeholder="Enter Aranya Email ID" Height="40px"
                            Width="300px" CssClass="form-control"></asp:TextBox>
                    </td>
                    <td style="width: 50px">
                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="tbUserName"
                            ValidationGroup="valid" Text="*" ErrorMessage="User Name field is empty" ForeColor="Red"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        Password: <a style="color: Red">*</a>
                    </td>
                    <td>
                        <asp:TextBox ID="tbPassword" runat="server" Placeholder="Enter Aranya Email Password"
                            Height="40px" Width="300px" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="tbPassword"
                            ValidationGroup="valid" Text="*" ErrorMessage="Password field is empty" ForeColor="Red"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px;">
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        <div align="justify">
                            <div style="float: left; width: 150px">
                                <asp:Button ID="btnLogin" OnClick="btnLogin_Click" Text="Login" runat="server" CssClass="btn btn-outline-info"
                                    Font-Underline="false" ValidationGroup="valid"></asp:Button></div>
                            <div style="float: right; width: 150px;">
                                <asp:Button ID="btnReset" OnClick="btnReset_Click" Text="Reset" runat="server" CssClass="btn btn-outline-danger"
                                    Font-Underline="false"></asp:Button></div>
                        </div>
                    </td>
                    <td>
                    </td>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:ValidationSummary ID="validSummary" DisplayMode="BulletList" HeaderText="Check the following"
                                runat="server" ForeColor="Red" ValidationGroup="valid" EnableClientScript="true"
                                ShowSummary="true" />
                        </td>
                    </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>--%>
    <div class="container">
    <div class="login-page">
        <div class="form">
           <%-- <form class="login-form">--%>
              <div class="row">
                <div class="col-md-12">
                    <h5>Enter your Aranya Email credentials here</h5>
                    <hr>
                </div>
            </div>
            <table>
                <tr>
                    <td style="width: 50px;">
                    </td>
                    <td style="padding-bottom: 10px;">
                        Username:
                    </td>
                    <td>
                        <asp:TextBox ID="tbUserName" runat="server" Placeholder="Enter Aranya Email ID" Height="40px"
                            Width="300px" CssClass="form-control" required></asp:TextBox>
                    </td>
                    <td style="width: 50px; padding-bottom: 5%; padding-right: 10%;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbUserName"
                            ValidationGroup="valid" Text="*" ErrorMessage="User Name field is empty" ForeColor="Red"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revUserName" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" runat="server" ControlToValidate="tbUserName" ValidationGroup="valid" Text="*" 
                            ErrorMessage="Please enter valid email address" Display="Dynamic">
                            </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td style="padding-bottom: 10px;">
                        Password: 
                    </td>
                    <td>
                        <asp:TextBox ID="tbPassword" runat="server" Placeholder="Enter Aranya Email Password"
                            Height="40px" Width="300px" TextMode="Password" CssClass="form-control" required></asp:TextBox>
                    </td>
                    <td style="padding-bottom: 5%; padding-right: 10%;">
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="tbPassword"
                            ValidationGroup="valid" Text="*" ErrorMessage="Password field is empty" ForeColor="Red"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px;">
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div align="justify" style="width: 100%;">
                            <%--<div style="float: left; width: 150px">
                                <asp:Button ID="btnLogin" OnClick="btnLogin_Click" Text="Login" runat="server" CssClass="btn btn-outline-info"
                                    Font-Underline="false" ValidationGroup="valid"></asp:Button></div>--%>
                            <div style="float: left; width: 100%">
                                <asp:Button ID="btnLogin" OnClick="btnLogin_Click" Text="Login" runat="server" Font-Underline="false"
                                    ValidationGroup="valid"></asp:Button></div>
                            <%-- <div style="float: right; width: 150px;">
                                <asp:Button ID="btnReset" OnClick="btnReset_Click" Text="Reset" runat="server" CssClass="btn btn-outline-danger"
                                    Font-Underline="false"></asp:Button></div>--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:ValidationSummary ID="ValidationSummary1" DisplayMode="BulletList" CssClass="valid-tooltip" HeaderText="Check the following"
                            runat="server" ForeColor="Red" ValidationGroup="valid" EnableClientScript="true"
                            Font-Names="Segoe UI" ShowSummary="true" BackColor="#efefef" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
            <%--<asp:TextBox ID="tbUserName" runat="server" Placeholder="Enter Aranya Email ID" Height="40px"
                Width="300px" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="tbUserName"
                ValidationGroup="valid" Text="*" ErrorMessage="User Name field is empty" ForeColor="Red"
                Display="Dynamic"></asp:RequiredFieldValidator>
           
            <asp:TextBox ID="tbPassword" runat="server" Placeholder="Enter Aranya Email Password"
                Height="40px" Width="300px" TextMode="Password" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="tbPassword"
                ValidationGroup="valid" Text="*" ErrorMessage="Password field is empty" ForeColor="Red"
                Display="Dynamic"></asp:RequiredFieldValidator>--%>
          <%--  <asp:Button ID="btnLogin" OnClick="btnLogin_Click" Text="Login" runat="server" Font-Underline="false"
                ValidationGroup="valid"></asp:Button>
            <asp:ValidationSummary ID="validSummary" DisplayMode="BulletList" HeaderText="Check the following"
                runat="server" ForeColor="Red" ValidationGroup="valid" EnableClientScript="true"
                ShowSummary="true" />
            <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>--%>
           <%-- </form>--%>
        </div>
    </div>
    </div>
</asp:Content>

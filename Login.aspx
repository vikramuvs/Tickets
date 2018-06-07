<%@ Page Title="" Language="C#" MasterPageFile="MainMaster.master"
    AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpimg" runat="Server">
    <style>
        .btn
        {
            background-color: Silver;
            color: Black;
            width: 60px;
            height: 30px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="center">
        <table style="background-color: #e4edd1">
            <thead>
                <tr>
                    <td colspan="4">
                        Please enter your Aranya Email Credentials here
                    </td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                    </td>
                    <td>
                        Username: <a style="color: Red">*</a>
                    </td>
                    <td>
                        <asp:TextBox ID="tbUserName" runat="server" Placeholder="Enter Aranya Email ID" Height="40px"
                            Width="300px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="tbUserName"
                            ValidationGroup="valid" Text="Required" ForeColor="Red"></asp:RequiredFieldValidator>
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
                            Height="40px" Width="300px" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="tbPassword"
                            ValidationGroup="valid" Text="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <div class="btn" align="center">
                            <asp:Button ID="btnLogin" OnClick="btnLogin_Click" Text="Login" runat="server" ForeColor="Black"
                                Font-Underline="false" Height="30px" Width="60px" ValidationGroup="valid"></asp:Button></div>
                    </td>
                    <td>
                        <div class="btn" align="center">
                            <asp:Button ID="btnReset" OnClick="btnReset_Click" Text="Reset" runat="server" ForeColor="Black"
                                Font-Underline="false" Height="30px" Width="60px"></asp:Button></div>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>

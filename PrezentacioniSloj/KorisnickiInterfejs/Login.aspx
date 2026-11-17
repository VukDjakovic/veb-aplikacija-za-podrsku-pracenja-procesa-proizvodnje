<%@ Page Title="Prijava" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KorisnickiInterfejs.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="display: flex; justify-content: center; align-items: center; height: 80vh;">
        <div style="border: 1px solid #ccc; padding: 30px; border-radius: 10px; background-color: #f9f9f9;">
            <table>
                <tr>
                    <td style="text-align: right; padding-right: 10px;">
                        <asp:Label ID="lblKorisnickoIme" runat="server" Text="Korisničko ime:" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtKorisnickoIme" runat="server" Width="200px" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; padding-right: 10px;">
                        <asp:Label ID="lblLozinka" runat="server" Text="Lozinka:" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtLozinka" runat="server" TextMode="Password" Width="200px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: right; padding-top: 15px;">
                        <asp:Button ID="btnPrijava" runat="server" Text="Prijava" 
                            OnClick="btnPrijava_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; padding-top: 10px;">
                        <asp:Label ID="lblGreska" runat="server" ForeColor="Red" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>


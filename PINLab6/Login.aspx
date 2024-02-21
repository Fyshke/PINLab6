<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PINLab6.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Login</h2>
<p>
    Korisničko ime:<asp:TextBox ID="TbKorisnik" runat="server"></asp:TextBox>
</p>
<p>
    Lozinka:<asp:TextBox ID="TbLozinka" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Button ID="BtnPrijava" runat="server" Text="Prijava" OnClick="BtnPrijava_Click" />
    <asp:Label ID="LblErrorPoruka" runat="server" ForeColor="Red" CssClass="error-message"></asp:Label>

</p>
</asp:Content>

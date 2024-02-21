<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registracija.aspx.cs" Inherits="PINLab6.Registracija" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Registriraj se</h2>
    <%--Error poruka--%>
    <asp:Label ID="lblErrorPoruka" runat="server" ForeColor="Red" CssClass="error-message"></asp:Label>
<p>
    Korisničko ime: <asp:TextBox ID="TbKorisnik" runat="server" ></asp:TextBox>
</p>
<p>
    Puno ime:<asp:TextBox ID="TbIme" runat="server" ></asp:TextBox>
</p>
<p>
    Lozinka:<asp:TextBox ID="TbLozinka" runat="server" TextMode="Password"></asp:TextBox>
</p>
<p>
    Ponovljena lozinka:<asp:TextBox ID="TbPLozinka" runat="server" TextMode="Password"></asp:TextBox>
</p>
<p>
    <asp:Button ID="BtnRegister" runat="server" OnClick="BtnRegister_Click" Text="Registriraj" />
</p>
</asp:Content>

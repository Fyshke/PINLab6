<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="PINLab6.Shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Shop</h2>
    <asp:Label ID="lblErrorPoruka" runat="server" Text="" ForeColor="Red" CssClass="error-message"></asp:Label>
<p>
    Naziv:<asp:TextBox ID="TbNaziv" runat="server"></asp:TextBox>
</p>
<p>
    Opis:
    <asp:TextBox ID="TbOpis" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Button ID="BtnSpremi" runat="server" OnClick="BtnSpremi_Click" Text="Spremi" />
    <asp:Button ID="BtnUkloni" runat="server" OnClick="BtnUkloni_Click" Text="Ukloni" />
</p>
<p>
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"  AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WebFormsConnectionString %>" SelectCommand="SELECT [Id], [Name], [Description] FROM [Products]"></asp:SqlDataSource>
</p>
</asp:Content>

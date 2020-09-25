<%@ Page Title="About" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.vb" Inherits="Michelin.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
       All Users</h2>
    <p>

        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="http://10.25.3.80/ReportServer/Pages/ReportViewer.aspx?%2fMembers%2fMembers&amp;rs:Command=Render">See Users in Roles</asp:HyperLink>

    </p>
    <p>

        <asp:ObjectDataSource ID="UserDataSource" runat="server" 
            SelectMethod="CustomGetAllUsers" TypeName="WSATTest.GetAllUsers" />
        <asp:GridView ID="UserGrid" runat="server" AllowPaging="True" 
            AllowSorting="True" CellPadding="4" DataSourceID="UserDataSource" 
            ForeColor="#333333" GridLines="None" 
             Width="915px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>

   <br />    
    
  <br /> 
   
    </p>
</asp:Content>

<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <asp:Table ID="MAIN_Table_of_Contents" runat="server" CssClass="contents_table" Visible="false">


       <asp:TableRow runat="server" CssClass="table_title">
           <asp:TableCell runat="server" Text="Table Of Contents" ColumnSpan="2" CssClass="title_cell"></asp:TableCell>
       </asp:TableRow>

       <asp:TableRow runat="server" CssClass="content_row">
           <asp:TableCell runat="server" Text="Family Lookup" CssClass="content_cell">
           </asp:TableCell>
           
       </asp:TableRow>



       <asp:TableRow runat="server" CssClass="content_row">
           <asp:TableCell runat="server" Text ="Child Lookup" CssClass="content_cell"></asp:TableCell>

       </asp:TableRow>

       <asp:TableRow runat="server" CssClass="content_row">
           <asp:TableCell runat="server" Text ="Family Additions" CssClass="content_cell"></asp:TableCell>

       </asp:TableRow>


   </asp:Table>

</asp:Content>

<asp:Content ID="secondaryContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Button ID="logout_button" runat="server" Text="Logout" CssClass="button_style" OnClick="logout_button_Click" style="margin-inline:4.9em; margin-top:2em" />
</asp:Content>

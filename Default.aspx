<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <asp:Table ID="MAIN_Table_of_Contents" runat="server" CssClass="contents_table" Visible="false">


       <asp:TableRow runat="server" CssClass="table_title">
           <asp:TableCell runat="server" Text="Table Of Contents" ColumnSpan="2" CssClass="title_cell"></asp:TableCell>
       </asp:TableRow>

       <asp:TableRow runat="server" CssClass="content_row">
           <asp:TableCell runat="server" Text="Family Lookup - Search for a family based on last name" CssClass="content_cell">
               <asp:TableCell runat="server" CssClass="content_cell">
                   <asp:TextBox runat="server" ID="lastNameTB" CssClass="textbox" style="vertical-align:middle"></asp:TextBox>
                   <asp:Button runat="server" ID="searchLastNameButton" CssClass="button_style" Text="Submit" OnClick="searchLastNameButton_Click" style="width:25%; vertical-align:middle; margin-left:5%" />
               </asp:TableCell>

           </asp:TableCell>
           
       </asp:TableRow>

       <asp:TableRow runat="server" CssClass="content_row">
           <asp:TableCell runat="server" Text="Add Family" CssClass="content_cell"></asp:TableCell>
           <asp:TableCell runat="server" CssClass="content_cell">
               <asp:Button runat="server" ID="showFamilyTableButton" CssClass="button_style" Text="Add Family" OnClick="showFamilyTableButton_Click" style="width:25%; vertical-align:middle; margin-left:5%" />
           </asp:TableCell>
       </asp:TableRow>


   </asp:Table>

   
    
    <asp:Table ID="parentOptionsTable" runat="server" CssClass="contents_table" Visible="false">
        <asp:TableRow runat="server" CssClass="table_title">
            <asp:TableCell runat="server" Text="Please click on one of the options below to view family details" ColumnSpan="2" CssClass="title_cell"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>

</asp:Content>

<asp:Content ID="secondaryContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Button ID="logout_button" runat="server" Text="Logout" CssClass="button_style" OnClick="logout_button_Click" style="margin-inline:4.9em; margin-top:2em" />
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AdminAuthentication.aspx.cs" Inherits="WebApplication1.AdminAuthentication" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Label runat="server" Text="Please Log In To Access Parish Records" Style="margin:auto; font-size:x-large; font-weight:800; display:table"></asp:Label>

          <asp:Table ID="authentication_table" runat="server" CssClass="contents_table" Style="width:60%" Visible="false">
        <asp:TableRow CssClass="table_title">
            <asp:TableCell ID="title_Cell" runat="server" Text="AUTHENTICATION" ColumnSpan="2" CssClass="title_cell"></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow CssClass="content_row">
            <asp:TableCell Text="Username:" CssClass="content_cell" Style="width:30%"></asp:TableCell>
            <asp:TableCell CssClass="content_cell" Style="width:70%" >
                <asp:TextBox runat="server" ID="username_entry" CssClass="textbox"> </asp:TextBox>
            </asp:TableCell>

           
        </asp:TableRow>

         <asp:TableRow CssClass="content_row" >
            <asp:TableCell Text="Password:" CssClass="content_cell" Style="width:30%"></asp:TableCell>
            <asp:TableCell CssClass="content_cell" Style="width:70%" >
                <asp:TextBox runat="server" ID="password_entry_box" CssClass="textbox" TextMode="Password"> </asp:TextBox>
            </asp:TableCell>

           
        </asp:TableRow>

        <asp:TableRow CssClass="table_title">
            <asp:TableCell runat="server" ColumnSpan="2" Style="width:100%">
                <asp:Button runat="server" ID="login_button" Text="Login" CssClass="login_button" OnClick="login_button_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>


     </asp:Content>



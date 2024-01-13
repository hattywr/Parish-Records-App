<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FamilyInfo.aspx.cs" Inherits="WebApplication1.FamilyInfo" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Table ID="FamilyInformationTable" runat="server" CssClass="contents_table" >

        <asp:TableRow runat="server" CssClass="table_title">
            <asp:TableCell runat="server" Text="Family Information" ColumnSpan="2" CssClass="title_cell"></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="FamilyID" CssClass="left_content_cell" ></asp:TableCell>

            <asp:TableCell runat="server" ID="FamilyIDCell" CssClass="right_content_cell">
                <asp:Label runat="server" ID="familyIDLabel"></asp:Label>
            </asp:TableCell>
        
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Parents" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="parentNames" CssClass="right_content_cell">
                <asp:Label runat="server" ID="parentNameLabel"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Address" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="AddressCell" CssClass="right_content_cell">
                <asp:Label runat="server" ID="AddressLabel"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="City" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="CityCell" CssClass="right_content_cell">
                <asp:Label runat="server" ID="CityLabel"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="State" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="StateCell" CssClass="right_content_cell">
                <asp:Label runat="server" ID="StateLabel"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Country" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="CountryCell" CssClass="right_content_cell">
                <asp:Label runat="server" ID="CountryLabel"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="ZIP Code" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="ZipCell" CssClass="right_content_cell">
                <asp:Label runat="server" ID="ZipLabel"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>


        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Married Date" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="marriedCell" CssClass="right_content_cell">
                <asp:Label runat="server" ID="marriedLabel"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>


        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Phone 1" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="phone1Cell" CssClass="right_content_cell">
                <asp:Label runat="server" ID="phone1Label"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>


        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Phone 2" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="phone2Cell" CssClass="right_content_cell">
                <asp:Label runat="server" ID="phone2Label"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Phone 3" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="phone3Cell" CssClass="right_content_cell">
                <asp:Label runat="server" ID="phone3Label"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Phone 4" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="phone4Cell" CssClass="right_content_cell">
                <asp:Label runat="server" ID="phone4Label"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Email 1" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="email1Cell" CssClass="right_content_cell">
                <asp:Label runat="server" ID="email1Label"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Email 2" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="email2Cell" CssClass="right_content_cell">
                <asp:Label runat="server" ID="email2Label"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Father Baptized" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="fbapCell" CssClass="right_content_cell">
                <asp:Label runat="server" ID="fbapLabel"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Mother Baptized" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="mbapCell" CssClass="right_content_cell">
                <asp:Label runat="server" ID="mbapLabel"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Father Communion" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="fcomCell" CssClass="right_content_cell">
                <asp:Label runat="server" ID="fcomLabel"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Mother Communion" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="mcomCell" CssClass="right_content_cell">
                <asp:Label runat="server" ID="mcomLabel"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Father Confirmed" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="fconfCell" CssClass="right_content_cell">
                <asp:Label runat="server" ID="fconfLabel"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Mother Confirmed" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="mconfCell" CssClass="right_content_cell">
                <asp:Label runat="server" ID="mconfLabel"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        

    </asp:Table>

     <asp:PlaceHolder runat="server" ID="childrenTablePlaceHolder"></asp:PlaceHolder>
     </asp:Content>

<asp:Content ID="secondaryContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Button ID="logout_button" runat="server" Text="Logout" CssClass="button_style" OnClick="logout_button_Click" style="margin-inline:4.9em; margin-top:2em" />
</asp:Content>
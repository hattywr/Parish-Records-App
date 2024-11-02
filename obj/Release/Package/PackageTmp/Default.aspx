<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Table ID="MAIN_Table_of_Contents" runat="server" CssClass="contents_table" Visible="false">


        <asp:TableRow runat="server" CssClass="table_title">
            <asp:TableCell runat="server" Text="Table Of Contents" ColumnSpan="2" CssClass="title_cell"></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Family Lookup - Search for a family based on last name" CssClass="content_cell">
                <asp:TableCell runat="server" CssClass="content_cell">
                    <asp:TextBox runat="server" ID="lastNameTB" CssClass="textbox" Style="vertical-align: middle"></asp:TextBox>
                    <asp:Button runat="server" ID="searchLastNameButton" CssClass="button_style" Text="Submit" OnClick="searchLastNameButton_Click" Style="width: 25%; vertical-align: middle; margin-left: 5%" />
                </asp:TableCell>

            </asp:TableCell>

        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Add Family" CssClass="content_cell"></asp:TableCell>
            <asp:TableCell runat="server" CssClass="content_cell">
                <asp:Button runat="server" ID="showFamilyTableButton" CssClass="button_style" Text="Add Family" OnClick="showFamilyTableButton_Click" Style="width: 25%; vertical-align: middle; margin-left: 5%" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="View All Families" CssClass="content_cell"></asp:TableCell>
            <asp:TableCell runat="server" CssClass="content_cell">
                <asp:Button runat="server" ID="showAllFamilies" CssClass="button_style" Text="Show All Families" OnClick="showAllFamilies_Click" Style="width: 35%; vertical-align: middle; margin-left: 5%" />
            </asp:TableCell>
        </asp:TableRow>


    </asp:Table>

    <asp:Table ID="FamilyInformationTable" runat="server" CssClass="contents_table" Visible="false">

        <asp:TableRow runat="server" CssClass="table_title">
            <asp:TableCell runat="server" Text="Family Information" ColumnSpan="2" CssClass="title_cell"></asp:TableCell>
        </asp:TableRow>


        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Father Name" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="fathersNameCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="fatherNameTB" CssClass="textbox" Text="First Middle-Initial Last or First Last"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Mother" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="motherNameCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="motherNameTB" CssClass="textbox" Text="First Middle-Initial Last or First Last"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Occupation" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="occupationCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="fatherOccupationTB" CssClass="textbox" Text="Enter Father's Occupation"></asp:TextBox>
                <asp:TextBox runat="server" ID="motherOccupationTB" CssClass="textbox" Text="Enter Mother's Occupation" Style="margin-top: 1%"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Address" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="AddressCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="AddressTB" CssClass="textbox"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="City" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="CityCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="CityTB" CssClass="textbox"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="State" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="StateCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="StateTB" CssClass="textbox"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Country" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="CountryCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="CountryTB" CssClass="textbox"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="ZIP Code" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="ZipCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="ZipTB" CssClass="textbox"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>


        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Married Date" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="marriedCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="marriedTB" CssClass="textbox" Text="yyyy/mm/dd"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>


        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Phone 1" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="phone1Cell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="phone1TB" CssClass="textbox"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>


        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Phone 2" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="phone2Cell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="phone2TB" CssClass="textbox"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Phone 3" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="phone3Cell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="phone3TB" CssClass="textbox"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Phone 4" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="phone4Cell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="phone4TB" CssClass="textbox"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Email 1" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="email1Cell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="email1TB" CssClass="textbox"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Email 2" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="email2Cell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="email2TB" CssClass="textbox"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Father Baptized" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="fbapCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="fbapTB" CssClass="textbox" Text="YES or NO"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Mother Baptized" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="mbapCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="mbapTB" CssClass="textbox" Text="YES or NO"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Father Communion" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="fcomCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="fcomTB" CssClass="textbox" Text="YES or NO"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Mother Communion" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="mcomCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="mcomTB" CssClass="textbox" Text="YES or NO"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Father Confirmed" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="fconfCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="fconfTB" CssClass="textbox" Text="YES or NO"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Mother Confirmed" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="mconfCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="mconfTB" CssClass="textbox" Text="YES or NO"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" CssClass="title_cell" ColumnSpan="2">
                <asp:Button runat="server" ID="addFamilyCompleted" Text="Submit" CssClass="login_button" OnClick="addFamilyCompleted_Click" />
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
    <asp:Button ID="logout_button" runat="server" Text="Logout" CssClass="button_style" OnClick="logout_button_Click" Style="margin-inline: 4.9em; margin-top: 2em" />
</asp:Content>

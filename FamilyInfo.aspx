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
                <asp:TextBox runat="server" ID="AddressTB" CssClass="textbox"></asp:TextBox>
                <asp:Button runat="server" ID="AddressUpdateButton" Text ="Update" CssClass="button_style" OnClick="AddressUpdateButton_Click" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="City" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="CityCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="CityTB" CssClass="textbox"></asp:TextBox>
                <asp:Button runat="server" ID="CityUpdateButton" Text ="Update" CssClass="button_style" OnClick="CityUpdateButton_Click" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="State" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="StateCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="StateTB" CssClass="textbox"></asp:TextBox>
                <asp:Button runat="server" ID="StateUpdateButton" Text ="Update" CssClass="button_style" OnClick="StateUpdateButton_Click" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Country" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="CountryCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="CountryTB" CssClass="textbox"></asp:TextBox>
                <asp:Button runat="server" ID="CountryUpdateButton" Text ="Update" CssClass="button_style" OnClick="CountryUpdateButton_Click" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="ZIP Code" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="ZipCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="ZipTB" CssClass="textbox"></asp:TextBox>
                <asp:Button runat="server" ID="ZipUpdateButton" Text ="Update" CssClass="button_style" OnClick="ZipUpdateButton_Click" />
            </asp:TableCell>
        </asp:TableRow>


        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Married Date" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="marriedCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="marriedTB" CssClass="textbox"></asp:TextBox>
                <asp:Button runat="server" ID="marriedUpdateButton" Text ="Update" CssClass="button_style" OnClick="marriedUpdateButton_Click" />
            </asp:TableCell>
        </asp:TableRow>


        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Phone 1" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="phone1Cell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="phone1TB" CssClass="textbox"></asp:TextBox>
                <asp:Button runat="server" ID="phone1UpdateButton" Text ="Update" CssClass="button_style" OnClick="phone1UpdateButton_Click" />
            </asp:TableCell>
        </asp:TableRow>


        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Phone 2" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="phone2Cell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="phone2TB" CssClass="textbox"></asp:TextBox>
                <asp:Button runat="server" ID="phone2UpdateButton" Text ="Update" CssClass="button_style" OnClick="phone2UpdateButton_Click" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Phone 3" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="phone3Cell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="phone3TB" CssClass="textbox"></asp:TextBox>
                <asp:Button runat="server" ID="phone3UpdateButton" Text ="Update" CssClass="button_style" OnClick="phone3UpdateButton_Click" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Phone 4" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="phone4Cell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="phone4TB" CssClass="textbox"></asp:TextBox>
                <asp:Button runat="server" ID="phone4UpdateButton" Text ="Update" CssClass="button_style" OnClick="phone4UpdateButton_Click" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Email 1" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="email1Cell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="email1TB" CssClass="textbox"></asp:TextBox>
                <asp:Button runat="server" ID="email1UpdateButton" Text ="Update" CssClass="button_style" OnClick="email1UpdateButton_Click" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Email 2" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="email2Cell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="email2TB" CssClass="textbox"></asp:TextBox>
                <asp:Button runat="server" ID="email2UpdateButton" Text ="Update" CssClass="button_style" OnClick="email2UpdateButton_Click" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Father Baptized" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="fbapCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="fbapTB" CssClass="textbox"></asp:TextBox>
                <asp:Button runat="server" ID="fbapUpdateButton" Text ="Update" CssClass="button_style" OnClick="fbapUpdateButton_Click" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Mother Baptized" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="mbapCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="mbapTB" CssClass="textbox"></asp:TextBox>
                <asp:Button runat="server" ID="mbapUpdateButton" Text ="Update" CssClass="button_style" OnClick="mbapUpdateButton_Click" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Father Communion" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="fcomCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="fcomTB" CssClass="textbox"></asp:TextBox>
                <asp:Button runat="server" ID="fcomUpdateButton" Text ="Update" CssClass="button_style" OnClick="fcomUpdateButton_Click" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Mother Communion" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="mcomCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="mcomTB" CssClass="textbox"></asp:TextBox>
                <asp:Button runat="server" ID="mcomUpdateButton" Text ="Update" CssClass="button_style" OnClick="mcomUpdateButton_Click" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Father Confirmed" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="fconfCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="fconfTB" CssClass="textbox"></asp:TextBox>
                <asp:Button runat="server" ID="fconfUpdateButton" Text ="Update" CssClass="button_style" OnClick="fconfUpdateButton_Click" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Mother Confirmed" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="mconfCell" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="mconfTB" CssClass="textbox"></asp:TextBox>
                <asp:Button runat="server" ID="mconfUpdateButton" Text ="Update" CssClass="button_style" OnClick="mconfUpdateButton_Click" />
            </asp:TableCell>
        </asp:TableRow>

        

    </asp:Table>

      <asp:Table ID="childTable" runat="server" CssClass="contents_table" >
              <asp:TableRow runat="server" CssClass="content_row">
                    <asp:TableCell runat="server" Text ="Add Child" CssClass="left_content_cell"></asp:TableCell>
                    <asp:TableCell runat="server" ID="AddChildCell" CssClass="right_content_cell">
                        <asp:Button runat="server" ID="addChildButton" Text="Add Child" CssClass="button_style" OnClick="addChildButton_Click" />
                    </asp:TableCell>
                </asp:TableRow>
    </asp:Table>

    <asp:Table ID="addChildTable" runat="server" CssClass="contents_table" Visible="false">
        <asp:TableRow runat="server" CssClass="table_title">
            <asp:TableCell runat="server" Text="Please enter all necessary details for the new child" ColumnSpan="2" CssClass="title_cell"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="First Name" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="firstNameTB" CssClass="textbox"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Middle Name" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="middleNameTB" CssClass="textbox"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Last Name" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="lastNameTB" CssClass="textbox"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="DOB" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="dobTB" CssClass="textbox"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Baptized? (1 = Yes, 0 = No)" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="baptizedTB" CssClass="textbox"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="First Communion? (1 = Yes, 0 = No)" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="fstCommTB" CssClass="textbox"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Confirmed? (1 = Yes, 0 = No)" CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" CssClass="right_content_cell">
                <asp:TextBox runat="server" ID="confirmTB" CssClass="textbox"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">
            <asp:TableCell runat="server" Text="Please press 'Save' to add the child." CssClass="left_content_cell"></asp:TableCell>
            <asp:TableCell runat="server" CssClass="right_content_cell">
                <asp:Button runat="server" ID="saveChildButton" Text="Save" CssClass="login_button" OnClick="saveChildButton_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    

     <asp:PlaceHolder runat="server" ID="childrenTablePlaceHolder"></asp:PlaceHolder>
     </asp:Content>



<asp:Content ID="secondaryContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Button ID="logout_button" runat="server" Text="Logout" CssClass="button_style" OnClick="logout_button_Click" style="margin-inline:4.9em; margin-top:2em" />
</asp:Content>
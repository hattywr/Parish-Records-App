using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class FamilyInfo : System.Web.UI.Page
    {
        DatabaseConnections connections = new DatabaseConnections();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["authenticated"] != null)
            {
                bool authenticated = (bool)Session["authenticated"];

                if (authenticated != true)
                {
                    Response.Redirect("AdminAuthentication.aspx");
                }
            }
            else
            {
                Response.Redirect("AdminAuthentication.aspx");
            }

            // Only do this if still authenticated
            string familyID = Request.QueryString["famID"].ToString();
            generateFamilyTable(familyID);

        }

        protected void logout_button_Click(object sender, EventArgs e)
        {
            Session["authenticated"] = null;
            Response.Redirect("AdminAuthentication.aspx");
        }

        protected void generateFamilyTable(string famID)
        {
            familyIDLabel.Text = famID;
            Family family = connections.createFamily(famID);
            parentNameLabel.Text = $"{family.fatherName} & {family.motherName} {family.familyLastName}";
            AddressTB.Text = family.familyAddress;
            CityTB.Text = family.familyCity;
            StateTB.Text = family.familyState;
            CountryTB.Text = family.familyCountry;
            ZipTB.Text = family.familyZIP;
            marriedTB.Text = family.marriedDate;
            phone1TB.Text = family.phoneOne;
            phone2TB.Text = family.phoneTwo;
            phone3TB.Text = family.phoneThree;
            phone4TB.Text = family.phoneFour;
            email1TB.Text = family.emailOne;
            email2TB.Text = family.emailTwo;
            fbapTB.Text = family.fatherBaptized.Replace(" ", "");
            mbapTB.Text = family.motherBaptized.Replace(" ", "");
            fcomTB.Text = family.fatherCommunion.Replace(" ", "");
            mcomTB.Text = family.motherCommunion.Replace(" ", "");
            fconfTB.Text = family.fatherConfirmed.Replace(" ", "");
            mconfTB.Text = family.motherConfirmed.Replace(" ", "");


            foreach (FamilyMember member in  family.members)
            {
                generateChildTable(member);
            }
        }


        protected void generateChildTable(FamilyMember member)
        {
            Table table = new Table();
            table.CssClass = "contents_table";


            
            //Create our title row
            TableRow row = new TableRow();
            row.CssClass = "table_title";
            TableCell cell = new TableCell();
            cell.CssClass = "title_cell";
            cell.ColumnSpan = 2;
            cell.ID = member.childID.ToString();
            cell.Text = $"Information for : {member.firstName} {member.lastName}";
            row.Cells.Add(cell);

            //Row 1
            TableRow row1 = new TableRow();
            row1.CssClass = "content_row";
            TableCell cell1 = new TableCell();
            cell1.CssClass = "left_content_cell";
            cell1.Text = "Name";
            TableCell cell2 = new TableCell();
            cell2.CssClass = "right_content_cell";
            TextBox box = new TextBox();
            box.CssClass = "textbox";
            box.Text = $"{member.firstName} {member.middleName} {member.lastName}";
            cell2.Controls.Add(box);

            Button button = new Button();
            button.CssClass = "button_style";
            button.Text = "Update Name";
            button.ID = "UpdateName" + member.childID;
            button.Click += UpdateName_Click;
            cell2.Controls.Add(button);
            row1.Cells.Add(cell1);
            row1.Cells.Add(cell2);
            

            //Row 2
            TableRow row2 = new TableRow();
            row2.CssClass = "content_row";
            TableCell cell3 = new TableCell();
            cell3.CssClass = "left_content_cell";
            cell3.Text = "DOB";
            TableCell cell4 = new TableCell();
            cell4.CssClass = "right_content_cell";

            TextBox box2 = new TextBox();
            box2.CssClass = "textbox";
            box2.Text = $"{member.DOB}";
            cell4.Controls.Add(box2);

            Button button2 = new Button();
            button2.CssClass = "button_style";
            button2.Text = "Update DOB";
            button2.ID = "UpdateDOB" + member.childID;
            button2.Click += UpdateDOB_Click;
            cell4.Controls.Add(button2);
            row2.Cells.Add(cell3);
            row2.Cells.Add(cell4);

            
            //Row 3
            TableRow row3 = new TableRow();
            row3.CssClass = "content_row";
            TableCell cell5 = new TableCell();
            cell5.CssClass = "left_content_cell";
            cell5.Text = "Baptized";
            TableCell cell6 = new TableCell();
            cell6.CssClass = "right_content_cell";
            TextBox box3 = new TextBox();
            box3.CssClass = "textbox";
            box3.Text = $"{member.isBaptized}";
            cell6.Controls.Add(box3);

            Button button3 = new Button();
            button3.CssClass = "button_style";
            button3.Text = "Update Bap";
            button3.ID = "UpdateBaptized" + member.childID;
            button3.Click += UpdateBaptized_Click;
            cell6.Controls.Add(button3);
            row3.Cells.Add(cell5);
            row3.Cells.Add(cell6);
            
            //Row 4
            TableRow row4 = new TableRow();
            row4.CssClass = "content_row";
            TableCell cell7 = new TableCell();
            cell7.CssClass = "left_content_cell";
            cell7.Text = "First Communion";
            TableCell cell8 = new TableCell();
            cell8.CssClass = "right_content_cell";
            TextBox box4 = new TextBox();
            box4.CssClass = "textbox";
            box4.Text = $"{member.fstCommunion}";
            cell8.Controls.Add(box4);

            Button button4 = new Button();
            button4.CssClass = "button_style";
            button4.Text = "Update Comm";
            button4.ID = "UpdateCommunion" + member.childID;
            button4.Click += UpdateCommunion_Click;
            cell8.Controls.Add(button4);
            row4.Cells.Add(cell7);
            row4.Cells.Add(cell8);


            //Row 5
            TableRow row5 = new TableRow();
            row5.CssClass = "content_row";
            TableCell cell9 = new TableCell();
            cell9.CssClass = "left_content_cell";
            cell9.Text = "Confirmed";
            TableCell cell10 = new TableCell();
            cell10.CssClass = "right_content_cell";
            TextBox box5 = new TextBox();
            box5.CssClass = "textbox";
            box5.Text = $"{member.isConfirmed}";
            cell10.Controls.Add(box5);

            Button button5 = new Button();
            button5.CssClass = "button_style";
            button5.Text = "Update Conf";
            button5.ID = "UpdateConfirmed" + member.childID;
            button5.Click += UpdateConfirmed_Click;
            cell10.Controls.Add(button5);

            row5.Cells.Add(cell9);
            row5.Cells.Add(cell10);

            //Row 6
            TableRow row6 = new TableRow();
            row6.CssClass = "content_row";
            TableCell cell11 = new TableCell();
            cell11.CssClass = "left_content_cell";
            cell11.Text = "Status";
            TableCell cell12 = new TableCell();
            cell12.CssClass = "right_content_cell";
            TextBox box6 = new TextBox();
            box6.CssClass = "textbox";
            box6.Text = $"{member.status}";
            cell12.Controls.Add(box6);

            Button button6 = new Button();
            button6.CssClass = "button_style";
            button6.Text = "Update Status";
            button6.ID = "UpdateStatus";
            button6.Click += UpdateStatus_Click;
            cell12.Controls.Add(button6);
            row6.Cells.Add(cell11);
            row6.Cells.Add(cell12);


            table.Rows.Add(row);
            table.Rows.Add(row1);
            table.Rows.Add(row2);
            table.Rows.Add(row3);
            table.Rows.Add(row4);
            table.Rows.Add(row5);
            table.Rows.Add(row6);

            childrenTablePlaceHolder.Controls.Add(table);

        }


        protected void UpdateName_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // get the button that was pressed via the sender event
            string buttonId = button.ID; // retrieve the button ID

        }

        protected void UpdateDOB_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // get the button that was pressed via the sender event
            string buttonId = button.ID; // retrieve the button ID

        }

        protected void UpdateBaptized_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // get the button that was pressed via the sender event
            string buttonId = button.ID; // retrieve the button ID

        }

        protected void UpdateCommunion_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // get the button that was pressed via the sender event
            string buttonId = button.ID; // retrieve the button ID

        }

        protected void UpdateConfirmed_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // get the button that was pressed via the sender event
            string buttonId = button.ID; // retrieve the button ID

        }

        protected void UpdateStatus_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // get the button that was pressed via the sender event
            string buttonId = button.ID; // retrieve the button ID

        }
        protected void AddressUpdateButton_Click(object sender, EventArgs e)
        {

        }

        protected void CityUpdateButton_Click(object sender, EventArgs e)
        {

        }

        protected void StateUpdateButton_Click(object sender, EventArgs e)
        {

        }

        protected void CountryUpdateButton_Click(object sender, EventArgs e)
        {

        }

        protected void ZipUpdateButton_Click(object sender, EventArgs e)
        {

        }

        protected void marriedUpdateButton_Click(object sender, EventArgs e)
        {

        }

        protected void phone1UpdateButton_Click(object sender, EventArgs e)
        {

        }

        protected void phone2UpdateButton_Click(object sender, EventArgs e)
        {

        }

        protected void phone3UpdateButton_Click(object sender, EventArgs e)
        {

        }

        protected void phone4UpdateButton_Click(object sender, EventArgs e)
        {

        }

        protected void email1UpdateButton_Click(object sender, EventArgs e)
        {

        }

        protected void email2UpdateButton_Click(object sender, EventArgs e)
        {

        }

        protected void fbapUpdateButton_Click(object sender, EventArgs e)
        {

        }

        protected void mbapUpdateButton_Click(object sender, EventArgs e)
        {

        }

        protected void fcomUpdateButton_Click(object sender, EventArgs e)
        {

        }

        protected void mcomUpdateButton_Click(object sender, EventArgs e)
        {

        }

        protected void fconfUpdateButton_Click(object sender, EventArgs e)
        {

        }

        protected void mconfUpdateButton_Click(object sender, EventArgs e)
        {

        }

        private Control FindControlRecursive(Control root_controls, string id) // find a control in a page
        {
            if (root_controls.ID == id) // control wanted was the root control
            {
                return root_controls; // return the control 
            }

            foreach (Control c in root_controls.Controls) // for all controls in the master controller
            {
                Control found = FindControlRecursive(c, id); // recursve across list until control is found
                if (found != null) // the control exists
                {
                    return found; // return the specified control
                }
            }

            return null; // no controls that matched the wanted one were found
        }
    }
}
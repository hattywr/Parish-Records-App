﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class FamilyInfo : System.Web.UI.Page
    {
        DatabaseConnections connections = new DatabaseConnections();
        Family currentFamily;
        string familyID;
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
            familyID = Request.QueryString["famID"].ToString();

            currentFamily = connections.createFamily(familyID);

            if (!IsPostBack)
            {
                // Store the initial scroll position in ViewState
                ViewState["ScrollPosition"] = Request["ScrollTop"];
                // Only do this if still authenticated
                
                generateFamilyTable();
            }


            foreach (FamilyMember member in currentFamily.members)
            {
                generateChildTable(member);
            }



        }

        protected void logout_button_Click(object sender, EventArgs e)
        {
            Session["authenticated"] = null;
            Response.Redirect("AdminAuthentication.aspx");
        }

        protected void generateFamilyTable()
        {
            familyIDLabel.Text = familyID;
            if (currentFamily.motherName == "" || currentFamily.motherName == null)
            {
                parentNameLabel.Text = $"{currentFamily.fatherName} {currentFamily.familyLastName}";
            }
            else
            {
                parentNameLabel.Text = $"{currentFamily.fatherName} & {currentFamily.motherName} {currentFamily.familyLastName}";
            }
            
            AddressTB.Text = currentFamily.familyAddress;
            CityTB.Text = currentFamily.familyCity;
            StateTB.Text = currentFamily.familyState;
            CountryTB.Text = currentFamily.familyCountry;
            ZipTB.Text = currentFamily.familyZIP;
            marriedTB.Text = currentFamily.marriedDate;
            phone1TB.Text = currentFamily.phoneOne;
            phone2TB.Text = currentFamily.phoneTwo;
            phone3TB.Text = currentFamily.phoneThree;
            phone4TB.Text = currentFamily.phoneFour;
            email1TB.Text = currentFamily.emailOne;
            email2TB.Text = currentFamily.emailTwo;
            fbapTB.Text = currentFamily.fatherBaptized.Replace(" ", "");
            mbapTB.Text = currentFamily.motherBaptized.Replace(" ", "");
            fcomTB.Text = currentFamily.fatherCommunion.Replace(" ", "");
            mcomTB.Text = currentFamily.motherCommunion.Replace(" ", "");
            fconfTB.Text = currentFamily.fatherConfirmed.Replace(" ", "");
            mconfTB.Text = currentFamily.motherConfirmed.Replace(" ", "");
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
            cell.Text = $"Information for child: {member.childID}";
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
            box.ID = member.childID.ToString() + "NameTB";
            cell2.Controls.Add(box);

            Button button = new Button();
            button.CssClass = "button_style";
            button.Text = "Update Name";
            button.ID = member.childID.ToString() + "UpdateName";
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
            box2.ID = member.childID.ToString() + "DOBTB";
            cell4.Controls.Add(box2);

            Button button2 = new Button();
            button2.CssClass = "button_style";
            button2.Text = "Update DOB";
            button2.ID = member.childID.ToString() + "UpdateDOB";
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
            box3.ID = member.childID.ToString() + "BaptizedTB";
            cell6.Controls.Add(box3);

            Button button3 = new Button();
            button3.CssClass = "button_style";
            button3.Text = "Update Bap";
            button3.ID = member.childID.ToString() + "UpdateBaptized";
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
            box4.ID = member.childID.ToString() + "FirstCommunionTB";
            cell8.Controls.Add(box4);

            Button button4 = new Button();
            button4.CssClass = "button_style";
            button4.Text = "Update Comm";
            button4.ID = member.childID.ToString() + "UpdateCommunion";
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
            box5.ID = member.childID.ToString() + "ConfirmedTB";
            cell10.Controls.Add(box5);

            Button button5 = new Button();
            button5.CssClass = "button_style";
            button5.Text = "Update Conf";
            button5.ID = member.childID.ToString() + "UpdateConfirmed";
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
            box6.ID = member.childID.ToString() + "StatusTB";
            cell12.Controls.Add(box6);

            Button button6 = new Button();
            button6.CssClass = "button_style";
            button6.Text = "Update Status";
            button6.ID = member.childID.ToString() + "UpdateStatus";
            button6.Click += UpdateStatus_Click;
            cell12.Controls.Add(button6);
            row6.Cells.Add(cell11);
            row6.Cells.Add(cell12);


            //Row 7
            TableRow row7 = new TableRow();
            row7.CssClass = "content_row";
            TableCell cell13 = new TableCell();
            cell13.CssClass = "left_content_cell";
            cell13.Text = "Remove Child";
            TableCell cell14 = new TableCell();
            cell14.CssClass = "right_content_cell";
            Button button7 = new Button();
            button7.CssClass = "button_style";
            button7.Text = "Remove Child";
            button7.ID = member.childID.ToString() + "DeleteChild";
            button7.Click += DeleteChild_Click;
            cell14.Controls.Add(button7);
            row7.Cells.Add(cell13);
            row7.Cells.Add(cell14);

            table.Rows.Add(row);
            table.Rows.Add(row1);
            table.Rows.Add(row2);
            table.Rows.Add(row3);
            table.Rows.Add(row4);
            table.Rows.Add(row5);
            table.Rows.Add(row6);
            table.Rows.Add(row7);

            childrenTablePlaceHolder.Controls.Add(table);

        }


        protected void UpdateName_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // get the button that was pressed via the sender event
            string buttonId = button.ID; // retrieve the button ID
            string childID = buttonId.Replace("UpdateName", ""); // strip extra string to get childID
            TextBox newNameTB = (TextBox)FindControlRecursive(Page, childID + "NameTB");
            string newName = newNameTB.Text.Replace(";","");
            if(newName != string.Empty)
            {
                String[] names = newName.Split(' ');
                if (names.Length < 3) // not in first, middle, last name format
                {
                    if (names.Length == 2)
                    {
                        string first = names[0];
                        string last = names[1];
                        // do code stuff 
                        bool completed = connections.UpdateChildName(childID, first, last);
                        if(completed == false)
                        {
                            string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                            ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
                        }
                        else
                        {
                            string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                            ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
                        }    
                        //first and last format - no middle
                    }
                    else
                    {
                        string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                        ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
                    }
                }
                else if (names.Length == 3)
                {
                    string first = names[0];
                    string middle = names[1];
                    string last = names[2];
                    bool completed = connections.UpdateChildName(childID, first, last, middle);
                    if (completed == false)
                    {
                        string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                        ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
                    }
                    else
                    {
                        string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                        ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
                    }
                    // do database stuff
                }
                else
                {
                    string script = "setTimeout(function() { alert('Please enter a name in the format of first middle last - spaces required between each word. If there is no middle name, enter the name in first last (one space between words)'); }, 25);";
                    ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
                }
            }
            else
            {
                string script = "setTimeout(function() { alert('Please enter a name in the format of first middle last - spaces required between each word. If there is no middle name, enter the name in first last (one space between words)'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }

            try
            {
                // Your SQL-related task here

                // Retrieve the stored scroll position from ViewState
                int scrollPosition = Convert.ToInt32(ViewState["ScrollPosition"]);

                // Set the scroll position back after the task is executed
                ScriptManager.RegisterStartupScript(this, GetType(), "setScrollPosition", $"window.scrollTo(0, {scrollPosition});", true);
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }

        }

        protected void UpdateDOB_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // get the button that was pressed via the sender event
            string buttonId = button.ID; // retrieve the button ID
            string childID = buttonId.Replace("UpdateDOB", "");
            TextBox newDOBTB = (TextBox)FindControlRecursive(Page, childID + "DOBTB");
            string newDOB = newDOBTB.Text.Replace(";", "");
            if(newDOB != string.Empty)
            {
                String[] date = newDOB.Split('/');
                if (date.Length != 3)
                {
                    string script = "setTimeout(function() { alert('Please enter a date in the mm/dd/yyyy format. This is the only accepted format.'); }, 25);";
                    ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
                }
                else
                {
                    bool completed = connections.updateChildDOB(childID, newDOB);
                    if (completed == false)
                    {
                        string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                        ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
                    }
                    else
                    {
                        string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                        ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
                    }
                    // do database stuff
                }
            }
            else
            {
                string script = "setTimeout(function() { alert('Please enter a date in the mm/dd/yyyy format. This is the only accepted format.'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }


            try
            {
                // Your SQL-related task here

                // Retrieve the stored scroll position from ViewState
                int scrollPosition = Convert.ToInt32(ViewState["ScrollPosition"]);

                // Set the scroll position back after the task is executed
                ScriptManager.RegisterStartupScript(this, GetType(), "setScrollPosition", $"window.scrollTo(0, {scrollPosition});", true);
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }

        protected void UpdateBaptized_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // get the button that was pressed via the sender event
            string buttonId = button.ID; // retrieve the button ID
            string childID = buttonId.Replace("UpdateBaptized", "");
            TextBox newBaptizedTB = (TextBox)FindControlRecursive(Page, childID + "BaptizedTB");
            string newBaptized = newBaptizedTB.Text.Replace(";", "");
            if(newBaptized != string.Empty && ( newBaptized.ToLower().Equals("true") || newBaptized.ToLower().Equals("false")))
            {
                bool completed =  connections.updateChildBaptized(childID, newBaptized.ToLower());
                if (completed == false)
                {
                    string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                    ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
                }
                else
                {
                    string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                    ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
                }
                // do database stuff
            }
            else
            {
                string script = "setTimeout(function() { alert('Please enter either True or False.'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }

            try
            {
                // Your SQL-related task here

                // Retrieve the stored scroll position from ViewState
                int scrollPosition = Convert.ToInt32(ViewState["ScrollPosition"]);

                // Set the scroll position back after the task is executed
                ScriptManager.RegisterStartupScript(this, GetType(), "setScrollPosition", $"window.scrollTo(0, {scrollPosition});", true);
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }

        protected void UpdateCommunion_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // get the button that was pressed via the sender event
            string buttonId = button.ID; // retrieve the button ID
            string childID = buttonId.Replace("UpdateCommunion", "");
            TextBox newCommunionTB = (TextBox)FindControlRecursive(Page, childID + "FirstCommunionTB");
            string newCommunion = newCommunionTB.Text.Replace(";", "");
            if (newCommunion != string.Empty && (newCommunion.ToLower().Equals("true") || newCommunion.ToLower().Equals("false")))
            {
                bool completed = connections.updateChildCommunion(childID, newCommunion.ToLower());
                if (completed == false)
                {
                    string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                    ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
                }
                else
                {
                    string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                    ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
                }
                // do database stuff
            }
            else
            {
                string script = "setTimeout(function() { alert('Please enter either True or False.'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }

            try
            {
                // Your SQL-related task here

                // Retrieve the stored scroll position from ViewState
                int scrollPosition = Convert.ToInt32(ViewState["ScrollPosition"]);

                // Set the scroll position back after the task is executed
                ScriptManager.RegisterStartupScript(this, GetType(), "setScrollPosition", $"window.scrollTo(0, {scrollPosition});", true);
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }

        protected void UpdateConfirmed_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // get the button that was pressed via the sender event
            string buttonId = button.ID; // retrieve the button ID
            string childID = buttonId.Replace("UpdateConfirmed", "");
            TextBox newConfirmedTB = (TextBox)FindControlRecursive(Page, childID + "ConfirmedTB");
            string newConfirmed = newConfirmedTB.Text.Replace(";", "");
            if (newConfirmed!= string.Empty &&( newConfirmed.ToLower().Equals("true") || newConfirmed.ToLower().Equals("false")))
            {
                bool completed = connections.updateChildConfirmation(childID, newConfirmed.ToLower());
                if (completed == false)
                {
                    string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                    ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
                }
                else
                {
                    string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                    ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
                }
                // do database stuff
            }
            else
            {
                string script = "setTimeout(function() { alert('Please enter either True or False.'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }

            try
            {
                // Your SQL-related task here

                // Retrieve the stored scroll position from ViewState
                int scrollPosition = Convert.ToInt32(ViewState["ScrollPosition"]);

                // Set the scroll position back after the task is executed
                ScriptManager.RegisterStartupScript(this, GetType(), "setScrollPosition", $"window.scrollTo(0, {scrollPosition});", true);
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }

        protected void DeleteChild_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonId = button.ID;
            int childId = Convert.ToInt32(buttonId.Replace("DeleteChild", ""));
            connections.deleteChild(childId);
            string famId = familyIDLabel.Text;
            //reload page, should no longer have this specific child we deleted
            Response.Redirect("FamilyInfo.aspx?famID=" + famId);
        }

        protected void UpdateStatus_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // get the button that was pressed via the sender event
            string buttonId = button.ID; // retrieve the button ID
            string childID = buttonId.Replace("UpdateStatus", "");
            TextBox newStatusTB = (TextBox)FindControlRecursive(Page, childID + "StatusTB");
            string newStatus = newStatusTB.Text.Replace(";", "");
            if(newStatus != null && newStatus != String.Empty && Convert.ToInt32(newStatus) < 10)
            {
                bool completed = connections.updateChildStatus(childID, Convert.ToInt32(newStatus));
                if (completed == false)
                {
                    string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                    ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
                }
                else
                {
                    string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                    ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
                }
                // do database stuff
            }
            else
            {
                string script = "setTimeout(function() { alert('Please enter a digit'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }

            try
            {
                // Your SQL-related task here

                // Retrieve the stored scroll position from ViewState
                int scrollPosition = Convert.ToInt32(ViewState["ScrollPosition"]);

                // Set the scroll position back after the task is executed
                ScriptManager.RegisterStartupScript(this, GetType(), "setScrollPosition", $"window.scrollTo(0, {scrollPosition});", true);
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }
        protected void AddressUpdateButton_Click(object sender, EventArgs e)
        {
            string familyID = familyIDLabel.Text;
            string newAddress = AddressTB.Text.Replace(";", "");
            bool completed = connections.updateAddress(Convert.ToInt32(familyID), newAddress);
            if (completed == false)
            {
                string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
            else
            {
                string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }


        }

        protected void CityUpdateButton_Click(object sender, EventArgs e)
        {
            string familyID = familyIDLabel.Text;
            string newCity = CityTB.Text.Replace(";", "");
            bool completed = connections.updateCity(Convert.ToInt32(familyID), newCity);
            if (completed == false)
            {
                string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
            else
            {
                string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
        }

        protected void StateUpdateButton_Click(object sender, EventArgs e)
        {
            string familyID = familyIDLabel.Text;
            string newState = StateTB.Text.Replace(";", "");
            bool completed = connections.updateState(Convert.ToInt32(familyID), newState);
            if (completed == false)
            {
                string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
            else
            {
                string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
        }

        protected void CountryUpdateButton_Click(object sender, EventArgs e)
        {
            string familyID = familyIDLabel.Text;
            string newCountry = CountryTB.Text.Replace(";", "");
            bool completed = connections.updateCountry(Convert.ToInt32(familyID), newCountry);
            if (completed == false)
            {
                string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
            else
            {
                string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
        }

        protected void ZipUpdateButton_Click(object sender, EventArgs e)
        {
            string familyID = familyIDLabel.Text;
            string newZip = ZipTB.Text.Replace(";", "");
            bool completed = connections.updateZip(Convert.ToInt32(familyID), newZip);
            if (completed == false)
            {
                string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
            else
            {
                string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
        }

        protected void marriedUpdateButton_Click(object sender, EventArgs e)
        {
            string familyID = familyIDLabel.Text;
            string newMarriedDate = marriedTB.Text.Replace(";", "");
            bool completed = connections.updateMarried(Convert.ToInt32(familyID), newMarriedDate);
            if (completed == false)
            {
                string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
            else
            {
                string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
        }

        protected void phone1UpdateButton_Click(object sender, EventArgs e)
        {
            string familyID = familyIDLabel.Text;
            string newPhone = phone1TB.Text.Replace(";", "");
            bool completed = connections.updatePhone1(Convert.ToInt32(familyID), newPhone);
            if (completed == false)
            {
                string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
            else
            {
                string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
        }

        protected void phone2UpdateButton_Click(object sender, EventArgs e)
        {
            string familyID = familyIDLabel.Text;
            string newPhone = phone2TB.Text.Replace(";", "");
            bool completed = connections.updatePhone2(Convert.ToInt32(familyID), newPhone);
            if (completed == false)
            {
                string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
            else
            {
                string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
        }

        protected void phone3UpdateButton_Click(object sender, EventArgs e)
        {
            string familyID = familyIDLabel.Text;
            string newPhone = phone3TB.Text.Replace(";", "");
            bool completed = connections.updatePhone3(Convert.ToInt32(familyID), newPhone);
            if (completed == false)
            {
                string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
            else
            {
                string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
        }

        protected void phone4UpdateButton_Click(object sender, EventArgs e)
        {
            string familyID = familyIDLabel.Text;
            string newPhone = phone4TB.Text.Replace(";", "");
            bool completed = connections.updatePhone4(Convert.ToInt32(familyID), newPhone);
            if (completed == false)
            {
                string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
            else
            {
                string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
        }

        protected void email1UpdateButton_Click(object sender, EventArgs e)
        {
            string familyID = familyIDLabel.Text;
            string newEmail = email1TB.Text.Replace(";", "");
            bool completed = connections.updateEmail1(Convert.ToInt32(familyID), newEmail);
            if (completed == false)
            {
                string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
            else
            {
                string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
        }

        protected void email2UpdateButton_Click(object sender, EventArgs e)
        {
            string familyID = familyIDLabel.Text;
            string newEmail = email2TB.Text.Replace(";", "");
            bool completed = connections.updateEmail2(Convert.ToInt32(familyID), newEmail);
            if (completed == false)
            {
                string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
            else
            {
                string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
        }

        protected void fbapUpdateButton_Click(object sender, EventArgs e)
        {
            string familyID = familyIDLabel.Text;
            string newfbap = fbapTB.Text.Replace(";", "");
            bool completed = connections.updateFbap(Convert.ToInt32(familyID), newfbap);
            if (completed == false)
            {
                string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
            else
            {
                string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
        }

        protected void mbapUpdateButton_Click(object sender, EventArgs e)
        {
            string familyID = familyIDLabel.Text;
            string newmbap = mbapTB.Text.Replace(";", "");
            bool completed = connections.updateMbap(Convert.ToInt32(familyID), newmbap);
            if (completed == false)
            {
                string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
            else
            {
                string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
        }

        protected void fcomUpdateButton_Click(object sender, EventArgs e)
        {
            string familyID = familyIDLabel.Text;
            string newfcom = fcomTB.Text.Replace(";", "");
            bool completed = connections.updateFcom(Convert.ToInt32(familyID), newfcom);
            if (completed == false)
            {
                string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
            else
            {
                string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
        }

        protected void mcomUpdateButton_Click(object sender, EventArgs e)
        {
            string familyID = familyIDLabel.Text;
            string newmcom = mcomTB.Text.Replace(";", "");
            bool completed = connections.updateMcom(Convert.ToInt32(familyID), newmcom);
            if (completed == false)
            {
                string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
            else
            {
                string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
        }

        protected void fconfUpdateButton_Click(object sender, EventArgs e)
        {
            string familyID = familyIDLabel.Text;
            string newfconf = fconfTB.Text.Replace(";", "");
            bool completed = connections.updateFconf(Convert.ToInt32(familyID), newfconf);
            if (completed == false)
            {
                string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
            else
            {
                string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
        }

        protected void mconfUpdateButton_Click(object sender, EventArgs e)
        {
            string familyID = familyIDLabel.Text;
            string newmconf = mconfTB.Text.Replace(";", "");
            bool completed = connections.updateMconf(Convert.ToInt32(familyID), newmconf);
            if (completed == false)
            {
                string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
            else
            {
                string script = "setTimeout(function() { alert('Record successfully updated!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
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

        protected void addChildButton_Click(object sender, EventArgs e)
        {
            addChildTable.Visible = true;
        }

        protected void saveChildButton_Click(object sender, EventArgs e)
        {
            bool allFilled = checkIfAnyNull();
            if(allFilled)
            {
                String[] date = dobTB.Text.Split('/');
                if (date.Length != 3)
                {
                    string script = "setTimeout(function() { alert('Please enter a date in the mm/dd/yyyy format. This is the only accepted format.'); }, 25);";
                    ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
                }
                else
                {
                    int familyID = Convert.ToInt32(familyIDLabel.Text);
                    string first = firstNameTB.Text.Replace(";", "");
                    string middle = middleNameTB.Text.Replace(";", "");
                    string last = lastNameTB.Text.Replace(";", "");
                    string DOB = dobTB.Text.Replace(";", "");
                    string baptized = baptizedTB.Text.Replace(";", "");
                    string fstCommunion = fstCommTB.Text.Replace(";", "");
                    string confirmation = confirmTB.Text.Replace(";", "");
                    bool completed = connections.addChildToFamily(familyID, first, middle, last, DOB, baptized, fstCommunion, confirmation);
                    if (completed == false)
                    {
                        string script = "setTimeout(function() { alert('An error occurred, please try again!'); }, 25);";
                        ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);


                    }
                    else
                    {
                        string script = "setTimeout(function() { alert('Child SuccessFully Added!'); }, 25);";
                        ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
                        Response.Redirect(Request.RawUrl);
                    }
                }

                
            }
            else
            {
                string script = "setTimeout(function() { alert('Please ensure all boxes are filled in before adding the child!!!!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
                //message to user - FILL IN BOXES PLEASE
            }
        }

        private bool checkIfAnyNull()
        {
            if(firstNameTB.Text.Replace(";", "").Length != 0 
                && middleNameTB.Text.Replace(";", "").Length != 0
                && lastNameTB.Text.Replace(";", "").Length != 0
                && dobTB.Text.Replace(";", "").Length != 0
                && baptizedTB.Text.Replace(";", "").Length != 0
                && fstCommTB.Text.Replace(";", "").Length != 0
                && confirmTB.Text.Replace(";", "").Length != 0) 
            { 
                return true;
            }

            return false;
        }

        protected void RemoveFamilyButton_Click(object sender, EventArgs e)
        {
            //Convert ID string to int 
            int familyID = Convert.ToInt32(familyIDLabel.Text);
            bool success = connections.deleteFamily(familyID);
            Response.Redirect("Default.aspx");

        }
    }
}
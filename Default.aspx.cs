using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        DatabaseConnections connections = new DatabaseConnections();
        protected void Page_Load(object sender, EventArgs e)
        {
            // temporary for testing purposes only
            Session["authenticated"] = true;

            if (Session["authenticated"] != null)
            {
                bool authenticated = (bool)Session["authenticated"];

                if (authenticated != true)
                {
                    Response.Redirect("AdminAuthentication.aspx");
                }
                else
                {
                    MAIN_Table_of_Contents.Visible = true;
                }
            }
            else
            {
                Response.Redirect("AdminAuthentication.aspx");
            }
        }

        protected void logout_button_Click(object sender, EventArgs e)
        {
            Session["authenticated"] = null;
            Response.Redirect("AdminAuthentication.aspx");
        }

        protected void searchLastNameButton_Click(object sender, EventArgs e)
        {
            string lastName = lastNameTB.Text;

            if(lastName.Length == 0)
            {

                string script = "setTimeout(function() { alert('Please enter a last name to search by'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
            else
            {
                List<ParentOption> possibleMatches = new List<ParentOption>();

                possibleMatches = connections.searchLastName(lastName);
                if (possibleMatches.Count != 0)
                {
                    parentOptionsTable.Visible = true;
                    foreach (ParentOption possibleMatch in possibleMatches)
                    {
                        HyperLink link = new HyperLink();
                        link.NavigateUrl = ("FamilyInfo.aspx?famID=" + possibleMatch.familyID);
                        link.Text = possibleMatch.parentNames + " " + possibleMatch.familyName;

                        TableRow row = new TableRow();
                        row.CssClass = "content_row";

                        TableCell cell1 = new TableCell();
                        cell1.CssClass = "content_cell";
                        cell1.ColumnSpan = 2;
                        cell1.Controls.Add(link);
                        row.Cells.Add(cell1);
                        parentOptionsTable.Rows.Add(row);

                    }
                }
                else
                {
                    // Generate JavaScript to display an alert box
                    string script = "alert('No family matches. Please try again');";

                    // Register the script with the page
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "AlertScript", script, true);
                }
            }

            


            


        }

        protected void showFamilyTableButton_Click(object sender, EventArgs e)
        {
            parentOptionsTable.Visible = false;
            FamilyInformationTable.Visible = true;
        }

        protected void addFamilyCompleted_Click(object sender, EventArgs e)
        {
            bool goodInput = checkFamilyInputs();
        }

        protected bool checkFamilyInputs()
        {
            if((fatherNameTB.Text == "First Middle-Initial Last or First Last" || fatherNameTB.Text == "") 
                && (motherNameTB.Text == "First Middle-Initial Last or First Last" || motherNameTB.Text == ""))
            {
                return false;
            }
            else if ((fatherOccupationTB.Text == "Enter Father's Occupation" || fatherOccupationTB.Text == "")
                && (motherOccupationTB.Text == "Enter Mother's Occupation" || motherOccupationTB.Text == ""))
            {
                return false;
            }
            else if (
                   AddressTB.Text == "" 
                || CityTB.Text == ""
                || StateTB.Text == ""
                || CountryTB.Text == ""
                || ZipTB.Text == ""
                || phone1TB.Text == ""
                || phone2TB.Text == ""
                || phone3TB.Text == ""
                || phone4TB.Text == ""
                || email1TB.Text == ""
                || email2TB.Text == ""
                || (fbapTB.Text == "YES or NO" || fbapTB.Text == "")
                || (mbapTB.Text == "YES or NO" || mbapTB.Text == "")
                || (fcomTB.Text == "YES or NO" || fcomTB.Text == "")
                || (mcomTB.Text == "YES or NO" || mcomTB.Text == "")
                || (fconfTB.Text == "YES or NO" || fconfTB.Text == "")
                || (mconfTB.Text == "YES or NO" || mconfTB.Text == ""))
            {
                return false;
            }


                return true;
        }
    }
}
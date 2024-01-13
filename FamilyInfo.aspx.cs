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
            AddressLabel.Text = family.familyAddress;
            CityLabel.Text = family.familyCity;
            StateLabel.Text = family.familyState;
            CountryLabel.Text = family.familyCountry;
            ZipLabel.Text = family.familyZIP;
            marriedLabel.Text = family.marriedDate;
            phone1Label.Text = family.phoneOne;
            phone2Label.Text = family.phoneTwo;
            phone3Label.Text = family.phoneThree;
            phone4Label.Text = family.phoneFour;
            email1Label.Text = family.emailOne;
            email2Label.Text = family.emailTwo;
            fbapLabel.Text = family.fatherBaptized;
            mbapLabel.Text = family.motherBaptized;
            fcomLabel.Text = family.fatherCommunion;
            mcomLabel.Text = family.motherCommunion;
            fconfLabel.Text = family.fatherConfirmed;
            mconfLabel.Text = family.motherConfirmed;

            foreach(FamilyMember member in  family.members)
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

            TableRow row1 = new TableRow();
            row1.CssClass = "content_row";
            TableCell cell1 = new TableCell();
            cell1.CssClass = "left_content_cell";
            cell1.Text = "Name";
            TableCell cell2 = new TableCell();
            cell2.CssClass = "right_content_cell";
            Label label = new Label();
            label.Text = $"{member.firstName} {member.middleName} {member.lastName}";
            cell2.Controls.Add(label);
            row1.Cells.Add(cell1);
            row1.Cells.Add(cell2);

            TableRow row2 = new TableRow();
            row2.CssClass = "content_row";
            TableCell cell3 = new TableCell();
            cell3.CssClass = "left_content_cell";
            cell3.Text = "DOB";
            TableCell cell4 = new TableCell();
            cell4.CssClass = "right_content_cell";
            Label label1 = new Label();
            label1.Text = $"{member.DOB}";
            cell4.Controls.Add(label1);
            row2.Cells.Add(cell3);
            row2.Cells.Add(cell4);

            TableRow row3 = new TableRow();
            row3.CssClass = "content_row";
            TableCell cell5 = new TableCell();
            cell5.CssClass = "left_content_cell";
            cell5.Text = "Baptized";
            TableCell cell6 = new TableCell();
            cell6.CssClass = "right_content_cell";
            Label label2 = new Label();
            label2.Text = $"{member.isBaptized}";
            cell6.Controls.Add(label2);
            row3.Cells.Add(cell5);
            row3.Cells.Add(cell6);

            TableRow row4 = new TableRow();
            row4.CssClass = "content_row";
            TableCell cell7 = new TableCell();
            cell7.CssClass = "left_content_cell";
            cell7.Text = "First Communion";
            TableCell cell8 = new TableCell();
            cell8.CssClass = "right_content_cell";
            Label label3 = new Label();
            label3.Text = $"{member.fstCommunion}";
            cell8.Controls.Add(label3);
            row4.Cells.Add(cell7);
            row4.Cells.Add(cell8);

            TableRow row5 = new TableRow();
            row5.CssClass = "content_row";
            TableCell cell9 = new TableCell();
            cell9.CssClass = "left_content_cell";
            cell9.Text = "Confirmed";
            TableCell cell10 = new TableCell();
            cell10.CssClass = "right_content_cell";
            Label label4 = new Label();
            label4.Text = $"{member.isConfirmed}";
            cell10.Controls.Add(label4);
            row5.Cells.Add(cell9);
            row5.Cells.Add(cell10);

            TableRow row6 = new TableRow();
            row6.CssClass = "content_row";
            TableCell cell11 = new TableCell();
            cell11.CssClass = "left_content_cell";
            cell11.Text = "Status";
            TableCell cell12 = new TableCell();
            cell12.CssClass = "right_content_cell";
            Label label5 = new Label();
            label5.Text = $"{member.status}";
            cell12.Controls.Add(label5);
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
    }
}
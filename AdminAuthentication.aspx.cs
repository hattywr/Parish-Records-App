using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApplication1
{
    public partial class AdminAuthentication : System.Web.UI.Page
    {
        DatabaseConnections connections = new DatabaseConnections();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["authenticated"] != null)
            {
                bool authenticated = (bool)Session["authenticated"];

                if (authenticated == true)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    authentication_table.Visible = true;
                    username_entry.Focus();
                }
            }
            else
            {
                //Authentication();
                authentication_table.Visible = true;
                username_entry.Focus();
            }
            

        }

        protected void login_button_Click(object sender, EventArgs e)
        {
            //string result = ComputeSHA256Hash()
            // Authentication development in progress - planning to utilize a hash to securely check passwords - allow user to set up an account
            if (username_entry.Text == "")
            {
                // Generate JavaScript to display an alert box
                string script = "alert('Please enter a username');";

                // Register the script with the page
                Page.ClientScript.RegisterStartupScript(this.GetType(), "AlertScript", script, true);

                //pass through a state as well --> maybe work with a text file to make it hard to get into and ensure the username is set as "cleared"
            }
            else if (password_entry_box.Text == "")
            {
                string script = "alert('Please enter a password');";

                // Register the script with the page
                Page.ClientScript.RegisterStartupScript(this.GetType(), "AlertScript", script, true);
            }
            else
            {
                bool userExists = connections.checkUser(username_entry.Text);
                if (userExists)
                {
                    string hashed = ComputeSHA256Hash(password_entry_box.Text);
                    bool passwordCorrect = connections.checkPassword(username_entry.Text, hashed);
                    if (passwordCorrect)
                    {
                        Session["authenticated"] = true;
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        string script = "alert('Username or password incorrect. Please try again!');";

                        // Register the script with the page
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "AlertScript", script, true);
                    }
                }
                else
                {
                    string script = "alert('Username not found, please try again');";

                    // Register the script with the page
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "AlertScript", script, true);
                }
                //authentication failed --> somehow tell the user and make them try again
                //use deskreg javascript to do these
            }
        }

        static string ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convert the input string to a byte array
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                // Compute the hash
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // Convert the byte array to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }

        }
    }
}
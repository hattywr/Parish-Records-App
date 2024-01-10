using System;
using System.Data.SqlClient;
using System.IO;

using Newtonsoft.Json.Linq;


namespace WebApplication1
{
    
    public class DatabaseConnections
    {
        SqlConnection connection;
        public DatabaseConnections() 
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Properties/serviceDependencies.json");

            // Read the entire JSON file as a string
            string jsonContent = File.ReadAllText(filePath);

            // Parse the JSON string into a JObject
            JObject jsonObject = JObject.Parse(jsonContent);

            // Access the "DefaultConnection" property from the "ConnectionStrings" section
            string defaultConnectionString = jsonObject["dependencies"]["ConnectionStrings"]["DefaultConnection"].ToString();
            Console.WriteLine("Default Connection String: " + defaultConnectionString);


            connection = new SqlConnection(defaultConnectionString.ToString()); 
        }

        public void getRecord()
        {
            try
            {
                // Open the connection
                connection.Open();

                // The connection is open, you can perform database operations here

                // Example: Execute a SQL command
                using (SqlCommand command = new SqlCommand("SELECT * FROM BVMFamilies", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Process the data retrieved from the database
                            Console.WriteLine(reader["fathName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Ensure the connection is closed, whether an exception occurs or not
                connection.Close();
            }


        }


    }
}
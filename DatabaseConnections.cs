using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.IO.Packaging;
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

        public bool checkUser(string username)
        {
            bool found = false;
            try
            {
                connection.Open();
                string query = $"select * from BVMUsers x where x.userName = '{username.ToLower()}'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string user = reader["username"].ToString();
                            if (user != null)
                            {
                                found = true;
                                break;
                            }

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
                connection.Close();
            }

            return found;

        }

        public bool checkPassword(string username, string hashed)
        {
            bool correct = false;
            try
            {
                connection.Open();
                string query = $"select * from BVMUsers x where x.userName = '{username.ToLower()}' and x.password = '{hashed}'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //string user = reader.GetString("userName");
                            string password = reader["password"].ToString();
                            if (password != null && password == hashed)
                            {
                                correct = true;
                                break;
                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return correct;

        }

        public List<ParentOption> searchLastName(string lastName)
        {
            List<ParentOption> parentOptions = new List<ParentOption>();
            try
            {
                connection.Open();
                string query = $"select * from BVMFamilies x where x.sir like '%{lastName}%'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //string user = reader.GetString("userName");
                            string familyID = reader["fid"].ToString();
                            string parentNames = reader["parents"].ToString();
                            string parentLastName = reader["sir"].ToString();
                            if (parentNames != null)
                            {
                                ParentOption option = new ParentOption(familyID, parentNames, parentLastName);

                                parentOptions.Add(option);
                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return parentOptions;
        }

        public Family createFamily(string familyID)
        {
            Family family = null;
            try
            {
                connection.Open();
                string query = $"select * from BVMFamilies x where x.fid = '{familyID}'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string fatherName = reader["fathName"].ToString();
                            string motherName = reader["mothName"].ToString();
                            string familyName = reader["sir"].ToString();
                            string familyAddress = reader["address"].ToString();
                            string familyCity = reader["city"].ToString();
                            string familyState = reader["state"].ToString();
                            string familyCountry = reader["country"].ToString();
                            string familyZIP = reader["postal"].ToString();
                            string fatherBaptized = reader["fbap"].ToString();
                            string motherBaptized = reader["mbap"].ToString(); ;
                            string fatherCommunion = reader["fcom"].ToString();
                            string motherCommunion = reader["mcom"].ToString();
                            string fatherConfirmed = reader["fconf"].ToString();
                            string motherConfirmed = reader["mconf"].ToString();
                            string phoneOne = reader["phone1"].ToString();
                            string phoneTwo = reader["phone2"].ToString();
                            string phoneThree = reader["phone3"].ToString();
                            string phoneFour = reader["phone4"].ToString();
                            string emailOne = reader["email1"].ToString();
                            string emailTwo = reader["email2"].ToString();
                            string marriedDate = reader["marrdate"].ToString();

                            family = new Family(
                                Convert.ToInt32(familyID),
                                fatherName,
                                motherName,
                                familyName,
                                familyAddress,
                                familyCity,
                                familyState,
                                familyCountry,
                                familyZIP,
                                fatherBaptized,
                                motherBaptized,
                                fatherCommunion,
                                motherCommunion,
                                fatherConfirmed,
                                motherConfirmed,
                                marriedDate,
                                phoneOne,
                                phoneTwo,
                                phoneThree,
                                phoneFour,
                                emailOne,
                                emailTwo);
                        }
                    }
                }

                string kidsQuery = $"select * from BVMChildren x where x.fid = {familyID} order by CONVERT(datetime, dob, 101)";

                using (SqlCommand command = new SqlCommand(kidsQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            int famID = Convert.ToInt32(reader["fid"].ToString());
                            int childID = Convert.ToInt32(reader["chid"].ToString());
                            string firstName = reader["fname"].ToString();
                            string middleName = reader["mname"].ToString();
                            string lastName = reader["lname"].ToString();
                            string DOB = reader["dob"].ToString();
                            string baptized = reader["baptized"].ToString().Replace(" ", "");
                            bool isBaptized = baptized.Equals("1") ? true : false;
                            string communion = reader["fstcomm"].ToString().Replace(" ", "");
                            bool fstCommunion = communion.Equals("1") ? true : false;
                            string confirmed = reader["confirm"].ToString().Replace(" ", "");
                            bool isConfirmed = confirmed.Equals("1") ? true : false;
                            int status = Convert.ToInt32(reader["status"].ToString());

                            FamilyMember member = new FamilyMember(
                                famID,
                                childID,
                                firstName,
                                middleName,
                                lastName,
                                DOB,
                                isBaptized,
                                fstCommunion,
                                isConfirmed,
                                status);

                            // add members to family
                            family.members.Add(member);
                        }
                    }
                }


            }
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error: " + ex.Message);
            //    return null;
            //}
            finally
            {
                connection.Close();
            }
            return family;
        }

        public bool UpdateChildName(string childID, string firstName, string lastname, string middleName = "")
        {
            bool success = false;
            try
            {
                connection.Open();
                string query = $"UPDATE BVMChildren SET fname = '{firstName}', lname = '{lastname}', mname = '{middleName}' where chid = {childID}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        success = true;

                    }
                    catch (Exception ex)
                    {
                        // update failed somehow
                        success = false;

                    }
                }
            }
            finally
            {
                connection.Close();
            }
            return success;
        }

        public bool updateChildDOB(string childID, string newDOB)
        {
            bool success = false;
            try
            {
                connection.Open();
                string query = $"UPDATE BVMChildren SET dob = '{newDOB}' where chid = {childID}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        success = true;

                    }
                    catch (Exception ex)
                    {
                        // update failed somehow
                        success = false;

                    }
                }
            }
            finally
            {
                connection.Close();
            }
            return success;
        }

        public bool updateChildBaptized(string childID, string baptizedStatus)
        {
            bool success = false;
            try
            {
                // convert true or false back to 1 or 0
                baptizedStatus = baptizedStatus.Equals("true") ? "1" : "0";
                connection.Open();
                string query = $"UPDATE BVMChildren SET baptized = '{baptizedStatus}' where chid = {childID}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        success = true;

                    }
                    catch (Exception ex)
                    {
                        // update failed somehow
                        success = false;

                    }
                }
            }
            finally
            {
                connection.Close();
            }
            return success;
        }

        public bool updateChildCommunion(string childID, string communionStatus)
        {
            bool success = false;
            try
            {
                // convert true or false back to 1 or 0
                communionStatus = communionStatus.Equals("true") ? "1" : "0";
                connection.Open();
                string query = $"UPDATE BVMChildren SET fstcomm = '{communionStatus}' where chid = {childID}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        success = true;

                    }
                    catch (Exception ex)
                    {
                        // update failed somehow
                        success = false;

                    }
                }
            }
            finally
            {
                connection.Close();
            }
            return success;
        }

        public bool updateChildConfirmation(string childID, string confirmationStatus)
        {
            bool success = false;
            try
            {
                // convert true or false back to 1 or 0
                confirmationStatus = confirmationStatus.Equals("true") ? "1" : "0";
                connection.Open();

                string query = $"UPDATE BVMChildren SET confirm = '{confirmationStatus}' where chid = {childID}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        success = true;

                    }
                    catch (Exception ex)
                    {
                        // update failed somehow
                        success = false;

                    }
                }
            }
            finally
            {
                connection.Close();
            }
            return success;
        }

        public bool updateChildStatus(string childID, int newStatus)
        {
            bool success = false;
            try
            {
                // convert true or false back to 1 or 0
                //confirmationStatus = confirmationStatus.Equals("true") ? "1" : "0";
                connection.Open();

                string query = $"UPDATE BVMChildren SET status = {newStatus} where chid = {childID}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        success = true;

                    }
                    catch (Exception ex)
                    {
                        // update failed somehow
                        success = false;

                    }
                }
            }
            finally
            {
                connection.Close();
            }
            return success;
        }

        public bool updateAddress(int familyID, string newAddress)
        {
            bool success = false;
            return success;
        }

        public bool updateCity(int familyID, string newCity)
        {
            bool success = false;
            return success;
        }

        public bool updateState(int familyID, string newState)
        {
            bool success = false;
            return success;
        }

        public bool updateCountry(int familyID, string newCountry)
        {
            bool success = false;
            return success;
        }

        public bool updateZip(int familyID, string newZip)
        {
            bool success = false;
            return success;
        }

        public bool updateMarried(int familyID, string newMarried)
        {
            bool success = false;
            return success;
        }
        public bool updatePhone1(int familyID, string newPhone)
        {
            bool success = false;
            return success;
        }
        public bool updatePhone2(int familyID, string newPhone)
        {
            bool success = false;
            return success;
        }
        public bool updatePhone3(int familyID, string newPhone)
        {
            bool success = false;
            return success;
        }
        public bool updatePhone4(int familyID, string newPhone)
        {
            bool success = false;
            return success;
        }
        public bool updateEmail1(int familyID, string newEmail)
        {
            bool success = false;
            return success;
        }
        public bool updateEmail2(int familyID, string newEmail)
        {
            bool success = false;
            return success;
        }

        public bool updateFbap(int familyID, string newBap)
        {
            bool success = false;
            return success;
        }
        public bool updateMbap(int familyID, string newBap)
        {
            bool success = false;
            return success;
        }
        public bool updateFcom(int familyID, string newCom)
        {
            bool success = false;
            return success;
        }
        public bool updateMcom(int familyID, string newCom)
        {
            bool success = false;
            return success;
        }
        public bool updateFconf(int familyID, string newConf)
        {
            bool success = false;
            return success;
        }
        public bool updateMconf(int familyID, string newConf)
        {
            bool success = false;
            return success;
        }


    }

}

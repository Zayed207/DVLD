using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using DataAccessSettings;
using System.Text;


namespace DVLD_DataAccess
{
    public class clsCountryData
    {
        public enum enGendor { Male = 0, Female = 1 };

        public static bool GetCountryInfoByID(int ID, ref string CountryName)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(AccessSettings.ConnectionString)) {

                string query = "SELECT * FROM Countries WHERE CountryID = @CountryID";

                using (SqlCommand command = new SqlCommand(query, connection)) {

                    command.Parameters.AddWithValue("@CountryID", ID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                // The record was found
                                isFound = true;

                                CountryName = (string)reader["CountryName"];

                            }
                            else
                            {
                                // The record was not found
                                isFound = false;
                            }




                        }
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("Error: " + ex.Message);
                        isFound = false;
                    }
                

                    return isFound;
                }
            }
        }

        public static bool GetCountryInfoByName(string CountryName, ref int ID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(AccessSettings.ConnectionString)) {

                string query = "SELECT * FROM Countries WHERE CountryName = @CountryName";

                using (SqlCommand command = new SqlCommand(query, connection)) {

                    command.Parameters.AddWithValue("@CountryName", CountryName);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                // The record was found
                                isFound = true;

                                ID = (int)reader["CountryID"];

                            }
                            else
                            {
                                // The record was not found
                                isFound = false;
                            }




                        }
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("Error: " + ex.Message);
                        isFound = false;
                    }


                    return isFound;
                }
            }
        }

        public static DataTable GetAllCountries()
        {

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(AccessSettings.ConnectionString))
            {

                string query = "SELECT * FROM Countries order by CountryName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.HasRows)

                            {
                                dt.Load(reader);
                            }




                        }
                    }

                    catch (Exception ex)
                    {
                        // Console.WriteLine("Error: " + ex.Message);
                    }


                    return dt;

                }
            }
        }

    }
}

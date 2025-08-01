﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using DataAccessSettings;
using System.Text;

using static DVLD_DataAccess.clsCountryData;
using System.Net;
using System.Security.Policy;

namespace DVLD_DataAccess
{
    public class clsDetainedLicenseData
    {

        public static bool GetDetainedLicenseInfoByID(int DetainID,
            ref int LicenseID, ref DateTime DetainDate,
            ref float FineFees, ref int CreatedByUserID,
            ref bool IsReleased, ref DateTime ReleaseDate,
            ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(AccessSettings.ConnectionString)) {

                string query = "SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID";

                using (SqlCommand command = new SqlCommand(query, connection)) {

                    command.Parameters.AddWithValue("@DetainID", DetainID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                // The record was found
                                isFound = true;

                                LicenseID = (int)reader["LicenseID"];
                                DetainDate = (DateTime)reader["DetainDate"];
                                FineFees = Convert.ToSingle(reader["FineFees"]);
                                CreatedByUserID = (int)reader["CreatedByUserID"];

                                IsReleased = (bool)reader["IsReleased"];

                                if (reader["ReleaseDate"] == DBNull.Value)

                                    ReleaseDate = DateTime.MaxValue;
                                else
                                    ReleaseDate = (DateTime)reader["ReleaseDate"];


                                if (reader["ReleasedByUserID"] == DBNull.Value)

                                    ReleasedByUserID = -1;
                                else
                                    ReleasedByUserID = (int)reader["ReleasedByUserID"];

                                if (reader["ReleaseApplicationID"] == DBNull.Value)

                                    ReleaseApplicationID = -1;
                                else
                                    ReleaseApplicationID = (int)reader["ReleaseApplicationID"];

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
                    finally
                    {
                        connection.Close();
                    }

                    return isFound;
                }
            } }


        public static bool GetDetainedLicenseInfoByLicenseID(int LicenseID,
         ref int DetainID, ref DateTime DetainDate,
         ref float FineFees, ref int CreatedByUserID,
         ref bool IsReleased, ref DateTime ReleaseDate,
         ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(AccessSettings.ConnectionString))
            {

                string query = "SELECT top 1 * FROM DetainedLicenses WHERE LicenseID = @LicenseID order by DetainID desc";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@LicenseID", LicenseID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                // The record was found
                                isFound = true;

                                DetainID = (int)reader["DetainID"];
                                DetainDate = (DateTime)reader["DetainDate"];
                                FineFees = Convert.ToSingle(reader["FineFees"]);
                                CreatedByUserID = (int)reader["CreatedByUserID"];

                                IsReleased = (bool)reader["IsReleased"];

                                if (reader["ReleaseDate"] == DBNull.Value)

                                    ReleaseDate = DateTime.MaxValue;
                                else
                                    ReleaseDate = (DateTime)reader["ReleaseDate"];


                                if (reader["ReleasedByUserID"] == DBNull.Value)

                                    ReleasedByUserID = -1;
                                else
                                    ReleasedByUserID = (int)reader["ReleasedByUserID"];

                                if (reader["ReleaseApplicationID"] == DBNull.Value)

                                    ReleaseApplicationID = -1;
                                else
                                    ReleaseApplicationID = (int)reader["ReleaseApplicationID"];

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
                    finally
                    {
                        connection.Close();
                    }

                    return isFound;
                }
            }
        }

        public static DataTable GetAllDetainedLicenses()
        {

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(AccessSettings.ConnectionString)) {

                string query = "\t\t\t\t  SELECT dbo.DetainedLicenses.DetainID, dbo.Licenses.LicenseID, dbo.DetainedLicenses.DetainDate, dbo.DetainedLicenses.IsReleased, dbo.DetainedLicenses.FineFees, dbo.DetainedLicenses.ReleaseDate, dbo.People.NationalNo, \r\n                   dbo.People.FirstName+' '+  dbo.People.SecondName+' '+ \r\n                  dbo.People.ThirdName+' '+ dbo.People.LastName as Fullname, dbo.DetainedLicenses.ReleaseApplicationID\r\nFROM     dbo.DetainedLicenses INNER JOIN\r\n                  dbo.Licenses ON dbo.DetainedLicenses.LicenseID = dbo.Licenses.LicenseID CROSS JOIN\r\n                  dbo.People   order by IsReleased ,DetainID;";

                using (SqlCommand command = new SqlCommand(query, connection)) {

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

        public static int AddNewDetainedLicense(
            int LicenseID, DateTime DetainDate,
            float FineFees, int CreatedByUserID)
        {
            int DetainID = -1;

            using (SqlConnection connection = new SqlConnection(AccessSettings.ConnectionString)) {

                string query = @"INSERT INTO dbo.DetainedLicenses
                               (LicenseID,
                               DetainDate,
                               FineFees,
                               CreatedByUserID,
                               IsReleased
                               )
                            VALUES
                               (@LicenseID,
                               @DetainDate, 
                               @FineFees, 
                               @CreatedByUserID,
                               0
                             );
                            
                            SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection)) {

                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@DetainDate", DetainDate);
                    command.Parameters.AddWithValue("@FineFees", FineFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            DetainID = insertedID;
                        }
                    }

                    catch (Exception ex)
                    {
                        //Console.WriteLine("Error: " + ex.Message);

                    }




                    return DetainID;

                }
            }
        }

        public static bool UpdateDetainedLicense(int DetainID,
            int LicenseID, DateTime DetainDate,
            float FineFees, int CreatedByUserID)
        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(AccessSettings.ConnectionString)) {

                string query = @"UPDATE dbo.DetainedLicenses
                              SET LicenseID = @LicenseID, 
                              DetainDate = @DetainDate, 
                              FineFees = @FineFees,
                              CreatedByUserID = @CreatedByUserID,   
                              WHERE DetainID=@DetainID;";

                using (SqlCommand command = new SqlCommand(query, connection)) {

                    command.Parameters.AddWithValue("@DetainedLicenseID", DetainID);
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@DetainDate", DetainDate);
                    command.Parameters.AddWithValue("@FineFees", FineFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("Error: " + ex.Message);
                        return false;
                    }



                    return (rowsAffected > 0);
                }
            }
        }


        public static bool ReleaseDetainedLicense(int DetainID,
                 int ReleasedByUserID, int ReleaseApplicationID)
        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(AccessSettings.ConnectionString)) {

                string query = @"UPDATE dbo.DetainedLicenses
                              SET IsReleased = 1, 
                              ReleaseDate = @ReleaseDate, 
                              ReleaseApplicationID = @ReleaseApplicationID   
                              WHERE DetainID=@DetainID;";

                using (SqlCommand command = new SqlCommand(query, connection)) {

                    command.Parameters.AddWithValue("@DetainID", DetainID);
                    command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                    command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
                    command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("Error: " + ex.Message);
                        return false;
                    }



                    return (rowsAffected > 0);
                }
            }
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            bool IsDetained = false;

            using (SqlConnection connection = new SqlConnection(AccessSettings.ConnectionString))
            {

                string query = @"select IsDetained=1 
                            from detainedLicenses 
                            where 
                            LicenseID=@LicenseID 
                            and IsReleased=0;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@LicenseID", LicenseID);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            IsDetained = Convert.ToBoolean(result);
                        }
                    }

                    catch (Exception ex)
                    {
                        //Console.WriteLine("Error: " + ex.Message);

                    }




                    return IsDetained;


                }
            } }

    }
}

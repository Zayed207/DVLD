using System;
using System.Configuration;

namespace DVLD_DataAccess
{
    static class clsDataAccessSettings
    {
        
        public static string ConnectionString = "Server=.;Database=DVLD;User Id=sa; Password=Sql12345678;";

        //public static string ConnectionString = ConfigurationManager.ConnectionStrings["DVLDConnection"].ConnectionString;



    }
}

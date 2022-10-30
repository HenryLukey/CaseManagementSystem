using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ManagerLibrary
{
    static class MySQLDatabase
    {
        //The string used to connect to our database
        const string connectionString = @"server=localhost;userid=root;password=RootPassword;database=NEA Database;";

        /// <summary>
        /// Creates and opens a connection to our SQL database
        /// </summary>
        public static MySqlConnection GetConnection()
        {
            //Creates a MySQLConnection using our connection string
            var connection = new MySqlConnection(connectionString);

            //Opens the connection
            connection.Open();

            //Returns the connection ready to be used
            return connection;
        }
    }
}

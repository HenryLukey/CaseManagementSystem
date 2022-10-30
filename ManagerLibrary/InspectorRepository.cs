using MySql.Data.MySqlClient;
using Renci.SshNet.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerLibrary
{
    public class InspectorRepository
    {
        /// <summary>
        /// Gets an Inspector object using the id as a parameter to get the relevant inspector with that id from the SQL database
        /// </summary>
        public Inspector GetInspectorByID(long id)
        {
            var connection = MySQLDatabase.GetConnection();

            Inspector inspector = new Inspector();

            //SQL command, get all from the inspector table with the given id
            string query = "SELECT * FROM inspector WHERE ID = @ID";

            var command = new MySqlCommand(query, connection);

            command.Parameters.Add("@ID", MySqlDbType.Int64).Value = id;

            //Reads the data given
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                //Assigns the Inspector properties the relevant data
                while (reader.Read())
                {
                    inspector.ID = (long)reader["ID"];
                    inspector.FirstName = reader["FirstName"].ToString();
                    inspector.LastName = reader["LastName"].ToString();
                    inspector.NumberCode = reader["NumberCode"].ToString();
                    inspector.MobileNumber = reader["MobileNumber"].ToString();
                }
            }

            connection.Close();

            return inspector;
        }

        /// <summary>
        /// Gets the inspector from the database if it finds it, adds it to the database if it doesn't find it
        /// </summary>
        public long AddInspectorWithCheck(Inspector inspector)
        {
            //If we can find the given Inspector in our database then return it
            if (CheckInspectorExists(inspector))
            {
                return GetInspectorID(inspector);
            }

            //Otherwise add the Inspector and return its id
            else
            {
                return AddInspector(inspector);
            }
        }

        /// <summary>
        /// Adds an inspector object to the inspector table
        /// </summary>
        public long AddInspector(Inspector inspector)
        {
            var connection = MySQLDatabase.GetConnection();

            //This is the SQL command (it essentially says: add a new row to the database with these values in the columns listed)
            string query = "INSERT INTO inspector (FirstName, LastName, NumberCode, MobileNumber) VALUES (@FirstName, @LastName, @NumberCode, @MobileNumber)";

            var command = new MySqlCommand(query, connection);

            //Gives the command parameters actual data
            command.Parameters.Add("@FirstName", MySqlDbType.String).Value = inspector.FirstName;
            command.Parameters.Add("@LastName", MySqlDbType.String).Value = inspector.LastName;
            command.Parameters.Add("@NumberCode", MySqlDbType.String).Value = inspector.NumberCode;
            command.Parameters.Add("@MobileNumber", MySqlDbType.String).Value = inspector.MobileNumber;

            command.ExecuteNonQuery();

            connection.Close();

            //Gets the id of the inspector we just added
            long id = command.LastInsertedId;

            return id;
        }

        /// <summary>
        /// updates an existing listing in the SQL database uses an Inspector object (essentially overwriting every field)
        /// </summary>
        public void UpdateInspector(Inspector inspector)
        {
            var connection = MySQLDatabase.GetConnection();

            //this is the SQL command (it essentially says: update the listing in the database with the given ID with these values in the columns listed)
            string query = "UPDATE inspector SET FirstName = @FirstName, LastName = @LastName, NumberCode = @NumberCode, MobileNumber = @MobileNumber WHERE ID = @ID";

            var command = new MySqlCommand(query, connection);

            //Gives the command parameters actual data
            command.Parameters.Add("@ID", MySqlDbType.Int64).Value = inspector.ID;
            command.Parameters.Add("@FirstName", MySqlDbType.String).Value = inspector.FirstName;
            command.Parameters.Add("@LastName", MySqlDbType.String).Value = inspector.LastName;
            command.Parameters.Add("@NumberCode", MySqlDbType.String).Value = inspector.NumberCode;
            command.Parameters.Add("@MobileNumber", MySqlDbType.String).Value = inspector.MobileNumber;

            //Executes the command
            command.ExecuteNonQuery();

            connection.Close();
        }

        /// <summary>
        /// Checks whether the given inspector object can be found in the database or not
        /// </summary>
        public bool CheckInspectorExists(Inspector inspector)
        {
            var connection = MySQLDatabase.GetConnection();

            //SQL command, gets any instances from the inspector table where the first name, last name and code are equal to their respective values in the inspector parameter
            string query = "SELECT * FROM inspector WHERE NumberCode = @NumberCode AND FirstName = @FirstName AND LastName = @LastName";

            var command = new MySqlCommand(query, connection);

            //Gives command parameters data from the inspector parameter
            command.Parameters.Add("@NumberCode", MySqlDbType.String).Value = inspector.NumberCode;
            command.Parameters.Add("@FirstName", MySqlDbType.String).Value = inspector.FirstName;
            command.Parameters.Add("@LastName", MySqlDbType.String).Value = inspector.LastName;

            //Reads through the response
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                //If there are any courts given back matching our request then return true
                if (reader.HasRows)
                {
                    return true;
                }

                //Otherwise returns false
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Gets an inspector id matching the inspector parameter, from the database
        /// </summary>
        public long GetInspectorID(Inspector inspector)
        {
            var connection = MySQLDatabase.GetConnection();

            //SQL query, get any instance from the inspector table where the frist name, last name and code are the same as our inspector parameter's properties
            string query = "SELECT * FROM inspector WHERE NumberCode = @NumberCode AND FirstName = @FirstName AND LastName = @LastName";

            long id;

            var command = new MySqlCommand(query, connection);

            command.Parameters.Add("@NumberCode", MySqlDbType.String).Value = inspector.NumberCode;
            command.Parameters.Add("@FirstName", MySqlDbType.String).Value = inspector.FirstName;
            command.Parameters.Add("@LastName", MySqlDbType.String).Value = inspector.LastName;

            //Reads the response SQL data to get the id
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                reader.Read();
                id = (long)reader["ID"];
            }

            return id;
        }
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary
{
    public class CourtRepository
    {
        /// <summary>
        /// Gets a court object from the database using an id
        /// </summary>
        public Court GetCourtByID(long id)
        {
            var connection = MySQLDatabase.GetConnection();

            Court court = new Court();

            //SQL command, selects every instance from the court table with the given id
            string query = "SELECT * FROM court WHERE ID = @ID";

            var command = new MySqlCommand(query, connection);

            command.Parameters.Add("@ID", MySqlDbType.Int64).Value = id;

            //Reads through the given SQL data
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                //Assigns all the court properties to be equal to the relevant data given
                while (reader.Read())
                {
                    court.ID = (long)reader["ID"];
                    court.CourtName = reader["CourtName"].ToString();
                    court.CourtCode = reader["CourtCode"].ToString();
                }
            }

            connection.Close();

            return court;
        }

        /// <summary>
        /// Gets the court if it finds it, adds it to the database if it doesn't find it (adds a layer of robustness to ensure we don't add duplicate courts to the database)
        /// </summary>
        public long AddCourtWithCheck(Court court)
        {
            //If we can find the given court in our database then return it
            if (CheckCourtExists(court))
            {
                return GetCourtID(court);
            }

            //Else, add the court and return its id
            else
            {
                return AddCourt(court);
            }
        }

        /// <summary>
        /// Adds a court object to the database
        /// </summary>
        public long AddCourt(Court court)
        {
            var connection = MySQLDatabase.GetConnection();

            //SQL command to insert into the table
            string query = "INSERT INTO court (CourtName, CourtCode) VALUES (@CourtName, @CourtCode)";

            var command = new MySqlCommand(query, connection);

            //Assigns the parameters actual data
            command.Parameters.Add("@CourtName", MySqlDbType.String).Value = court.CourtName;
            command.Parameters.Add("@CourtCode", MySqlDbType.String).Value = court.CourtCode;

            command.ExecuteNonQuery();

            connection.Close();
            
            //Gets the id of the court we just added
            long id = command.LastInsertedId;

            return id;
        }

        /// <summary>
        /// Checks whether the given court object can be found in the database or not
        /// </summary>
        public bool CheckCourtExists(Court court)
        {
            var connection = MySQLDatabase.GetConnection();

            //SQL command, gets any instances from the court table where the name and code are equal to the name and code of our court parameter
            string query = "SELECT * FROM court WHERE CourtName = @CourtName AND CourtCode = @CourtCode";

            var command = new MySqlCommand(query, connection);

            //Assigns the command parameters relevant data
            command.Parameters.Add("@CourtName", MySqlDbType.String).Value = court.CourtName;
            command.Parameters.Add("@CourtCode", MySqlDbType.String).Value = court.CourtCode;

            //Reads through the response
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                //If there are any courts given back matching our request then return true
                if (reader.HasRows)
                {
                    return true;
                }

                //Otherwise return false
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Gets a court id matching the court parameter from the database
        /// </summary>
        public long GetCourtID(Court court)
        {
            var connection = MySQLDatabase.GetConnection();

            long id;

            //SQL query, get any instance from the court table where the name and code are the same as our court parameters code and name
            string query = "SELECT * FROM court WHERE CourtName = @CourtName AND CourtCode = @CourtCode";

            var command = new MySqlCommand(query, connection);

            command.Parameters.Add("@CourtName", MySqlDbType.String).Value = court.CourtName;
            command.Parameters.Add("@CourtCode", MySqlDbType.String).Value = court.CourtCode;

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

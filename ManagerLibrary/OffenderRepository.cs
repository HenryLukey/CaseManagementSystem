using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary
{
    public class OffenderRepository
    {
        /// <summary>
        /// Gets an offender object using the id as a parameter to get the relevant offender with that id from the SQL database
        /// </summary>
        public Offender GetOffenderByID(long id)
        {
            var connection = MySQLDatabase.GetConnection();

            Offender offender = new Offender();

            //SQL command to get the instance from the offender table with the given id
            string query = "SELECT * FROM offender WHERE ID = @ID";

            var command = new MySqlCommand(query, connection);

            command.Parameters.Add("@ID", MySqlDbType.Int64).Value = id;

            //Reads the data given back
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                //Assigns the offender objects properties the data we get from the database
                while (reader.Read())
                {
                    offender.ID = (long)reader["ID"];
                    offender.FirstNames = reader["FirstNames"].ToString();
                    offender.LastName = reader["LastName"].ToString();
                    offender.Address = reader["Address"].ToString();
                    offender.Postcode = reader["Postcode"].ToString();
                    offender.NINumber = reader["NINumber"].ToString();
                    offender.DateOfBirth = (DateTime)reader["DateOfBirth"];
                    offender.Gender = (Gender)Enum.Parse(typeof(Gender), reader["Gender"].ToString());
                }
            }

            connection.Close();

            return offender;
        }

        /// <summary>
        /// adds an instance of offender to the SQL database
        /// </summary>
        public long AddOffender(Offender offender)
        {
            var connection = MySQLDatabase.GetConnection();

            //this is the SQL command (it essentially says: add a new row to the database with these values in the columns listed)
            string query = "INSERT INTO offender (FirstNames, LastName, Address, Postcode, NINumber, Occupation, DateOfBirth, Gender) " +
                           "VALUES (@FirstNames, @LastName, @Address, @Postcode, @NINumber, @Occupation, @DateOfBirth, @Gender)";

            var command = new MySqlCommand(query, connection);

            //Assigns command parameters actual data
            command.Parameters.Add("@FirstNames", MySqlDbType.String).Value = offender.FirstNames;
            command.Parameters.Add("@LastName", MySqlDbType.String).Value = offender.LastName;
            command.Parameters.Add("@Address", MySqlDbType.String).Value = offender.Address;
            command.Parameters.Add("@Postcode", MySqlDbType.String).Value = offender.Postcode;
            command.Parameters.Add("@NINumber", MySqlDbType.String).Value = offender.NINumber;
            command.Parameters.Add("@Occupation", MySqlDbType.String).Value = offender.Occupation;
            command.Parameters.Add("@DateOfBirth", MySqlDbType.DateTime).Value = offender.DateOfBirth;
            command.Parameters.Add("@Gender", MySqlDbType.String).Value = offender.Gender;

            command.ExecuteNonQuery();

            connection.Close();

            //Gets the id of the offender we just added to the database
            long id = command.LastInsertedId;

            return id;
        }
    }
}

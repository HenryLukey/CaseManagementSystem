using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ManagerLibrary
{
    public class AnimalRepository
    {
        /// <summary>
        /// queries the animal table within the database using a given ID. It then populates the properties of a new instance of Animal with the results of the query and
        /// returns this animal.
        /// </summary>
        public Animal GetAnimalByID(long id)
        {
            var connection = MySQLDatabase.GetConnection();

            Animal animal = new Animal();

            //this is the SQL query (it essentially means: select every animal from the table that has the given ID)
            string query = "SELECT * FROM animal WHERE ID = @ID";

            var command = new MySqlCommand(query, connection);

            command.Parameters.Add("@ID", MySqlDbType.Int64).Value = id;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                //goes through every column in the selected animal and sets the objects parameters to be equal to the tables respective values
                while (reader.Read())
                {
                    animal.ID = reader.GetInt64(0);
                    animal.ExhibitNumber = reader["ExhibitNumber"].ToString();
                    animal.Species = reader["Species"].ToString();
                    animal.Breed = reader["Breed"].ToString();
                    animal.OriginalName = reader["OriginalName"].ToString();
                    animal.Description = reader["Description"].ToString();
                    animal.Status = (Status)Enum.Parse(typeof(Status), reader["Status"].ToString());
                    animal.Date = reader["Date"].ToString();
                    animal.CurrentLocation = reader["CurrentLocation"].ToString();
                    animal.SignedOver = (bool)reader["SignedOver"];
                    animal.PTS = (bool)reader["PTS"];
                    animal.Dead = (bool)reader["Dead"];
                }
            }

            connection.Close();
            return animal;
        }

        /// <summary>
        /// adds an instance of animal to the SQL database
        /// </summary>
        public long AddAnimal(Animal animal)
        {
            var connection = MySQLDatabase.GetConnection();

            //this is the SQL command (it essentially says: add a new row to the database with these values in the columns listed)
            string query = "INSERT INTO animal (ExhibitNumber, Species, Breed, OriginalName, Description, Status, Date, CurrentLocation, SignedOver, PTS, Dead)" +
                           " VALUES (@ExhibitNumber, @Species, @Breed, @OriginalName, @Description, @Status, @Date, @CurrentLocation, @SignedOver, @PTS, @Dead)";

            var command = new MySqlCommand(query, connection);

            //assigns the SQL commands parameters the actual values
            command.Parameters.Add("@ExhibitNumber", MySqlDbType.String).Value = animal.ExhibitNumber;
            command.Parameters.Add("@Species", MySqlDbType.String).Value = animal.Species;
            command.Parameters.Add("@Breed", MySqlDbType.String).Value = animal.Breed;
            command.Parameters.Add("@OriginalName", MySqlDbType.String).Value = animal.OriginalName;
            command.Parameters.Add("@Description", MySqlDbType.String).Value = animal.Description;
            command.Parameters.Add("@Status", MySqlDbType.Enum).Value = animal.Status;
            command.Parameters.Add("@Date", MySqlDbType.String).Value = animal.Date;
            command.Parameters.Add("@CurrentLocation", MySqlDbType.String).Value = animal.CurrentLocation;
            command.Parameters.Add("@SignedOver", MySqlDbType.Bit).Value = animal.SignedOver;
            command.Parameters.Add("@PTS", MySqlDbType.Bit).Value = animal.PTS;
            command.Parameters.Add("@Dead", MySqlDbType.Bit).Value = animal.Dead;

            command.ExecuteNonQuery();

            connection.Close();

            long id = command.LastInsertedId;

            //the id is returned so we can know how to access it again
            return id;
        }

        /// <summary>
        /// updates an existing listing in the SQL database uses an instance of animal (essentially overwriting every field)
        /// </summary>
        public void UpdateAnimal(Animal animal)
        {
            var connection = MySQLDatabase.GetConnection();

            //this is the SQL command (it essentially says: update the listing in the database with the given ID with these values in the columns listed)
            string query = "UPDATE animal SET ExhibitNumber = @ExhibitNumber, Species = @Species, Breed = @Breed, OriginalName = @OriginalName, Description = @Description, " +
                           "Status = @Status, Date = @Date, CurrentLocation = @CurrentLocation, SignedOver = @SignedOver, PTS = @PTS, Dead = @Dead WHERE ID = @ID";

            var command = new MySqlCommand(query, connection);

            command.Parameters.Add("@ExhibitNumber", MySqlDbType.String).Value = animal.ExhibitNumber;
            command.Parameters.Add("@Species", MySqlDbType.String).Value = animal.Species;
            command.Parameters.Add("@Breed", MySqlDbType.String).Value = animal.Breed;
            command.Parameters.Add("@OriginalName", MySqlDbType.String).Value = animal.OriginalName;
            command.Parameters.Add("@Description", MySqlDbType.String).Value = animal.Description;
            command.Parameters.Add("@Status", MySqlDbType.Enum).Value = animal.Status;
            command.Parameters.Add("@Date", MySqlDbType.String).Value = animal.Date;
            command.Parameters.Add("@CurrentLocation", MySqlDbType.String).Value = animal.CurrentLocation;
            command.Parameters.Add("@SignedOver", MySqlDbType.Bit).Value = animal.SignedOver;
            command.Parameters.Add("@PTS", MySqlDbType.Bit).Value = animal.PTS;
            command.Parameters.Add("@Dead", MySqlDbType.Bit).Value = animal.Dead;
            command.Parameters.Add("@ID", MySqlDbType.Int64).Value = animal.ID;

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}

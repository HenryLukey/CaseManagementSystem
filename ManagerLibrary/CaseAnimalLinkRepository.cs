using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary
{
    public class CaseAnimalLinkRepository
    {
        /// <summary>
        /// Gets a list of animals that are linked to the same given case id
        /// </summary>
        public List<Animal> GetAnimalsFromCaseID(long id)
        {
            var connection = MySQLDatabase.GetConnection();
            AnimalRepository animalRepo = new AnimalRepository();

            List<long> animalIDs = new List<long>();
            List<Animal> animals = new List<Animal>();

            //SQL command to  get every instance in the case_animal_link table that has the given case id
            string query = "SELECT * FROM case_animal_link WHERE CaseID = @ID";

            var command = new MySqlCommand(query, connection);

            command.Parameters.Add("@ID", MySqlDbType.Int64).Value = id;

            //Reads the data sent as a response from the command and adds the animal id values to a list
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long tempID = (long)reader["AnimalID"];
                    animalIDs.Add(tempID);
                }
            }

            //Uses animal id list to get all the relevant animal objects and adds them to a list
            for (int i = 0; i < animalIDs.Count; i++)
            {
                animals.Add(animalRepo.GetAnimalByID(animalIDs[i]));
            }

            connection.Close();

            return animals;
        }

        /// <summary>
        /// Adds an instance to the case_animal_link table
        /// </summary>
        public void AddCaseAnimalLink(Animal animal, long id)
        {
            var connection = MySQLDatabase.GetConnection();

            AnimalRepository animalRepo = new AnimalRepository();

            long animalID = animalRepo.AddAnimal(animal);

            //SQL command to add the instance to the table
            string query = "INSERT INTO case_animal_link (CaseID, AnimalID) VALUES (@CaseID, @AnimalID)";

            var command = new MySqlCommand(query, connection);

            //assigns the SQL commands parameters the actual values
            command.Parameters.Add("@CaseID", MySqlDbType.Int64).Value = id;
            command.Parameters.Add("@AnimalID", MySqlDbType.Int64).Value = animalID;

            command.ExecuteNonQuery();

            connection.Close();
        }

        

        /// <summary>
        /// Essentially a way of creating a list of animals associated with a case
        /// </summary>
        public void AddListOfCaseAnimalLinks(List<Animal> animals, long id)
        {
            //loops through every animal in the list
            for (int i = 0; i < animals.Count; i++)
            {
                //Adds the link
                AddCaseAnimalLink(animals[i], id);
            }
        }
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary
{
    class CaseOffenderLinkRepository
    {
        /// <summary>
        /// Gets a list of offenders that are linked to the same given case id
        /// </summary>
        public List<Offender> GetOffendersFromCaseID(long id)
        {
            var connection = MySQLDatabase.GetConnection();
            OffenderRepository offenderRepo = new OffenderRepository();

            List<long> offenderIDs = new List<long>();
            List<Offender> offenders = new List<Offender>();

            //SQL command to  get every instance in the case_offender_link table that has the given case id
            string query = "SELECT * FROM case_offender_link WHERE CaseID = @ID";

            var command = new MySqlCommand(query, connection);

            command.Parameters.Add("@ID", MySqlDbType.Int64).Value = id;

            //Reads the data sent as a response from the command and adds the offender id values to a list
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long tempID = (long)reader["OffenderID"];
                    offenderIDs.Add(tempID);
                }
            }

            //Uses offender id list to get all the relevant offender objects and adds them to a list
            for (int i = 0; i < offenderIDs.Count; i++)
            {
                offenders.Add(offenderRepo.GetOffenderByID(offenderIDs[i]));
            }

            connection.Close();

            return offenders;
        }

        /// <summary>
        /// Adds an instance to the case_offender_link table
        /// </summary>
        public void AddCaseOffenderLink(Offender offender, long id)
        {
            var connection = MySQLDatabase.GetConnection();

            OffenderRepository offenderRepo = new OffenderRepository();

            long offenderID = offenderRepo.AddOffender(offender);

            //SQL command to add the instance to the table
            string query = "INSERT INTO case_offender_link (CaseID, OffenderID) VALUES (@CaseID, @OffenderID)";

            var command = new MySqlCommand(query, connection);

            //assigns the SQL commands parameters the actual values
            command.Parameters.Add("@CaseID", MySqlDbType.Int64).Value = id;
            command.Parameters.Add("@OffenderID", MySqlDbType.Int64).Value = offenderID;

            command.ExecuteNonQuery();

            connection.Close();
        }

        /// <summary>
        /// Essentially a way of creating a list of offenders associated with a case
        /// </summary>
        public void AddListOfCaseOffenderLinks(List<Offender> offenders, long id)
        {
            //loops through every offender in the list
            for (int i = 0; i < offenders.Count; i++)
            {
                //Adds the link
                AddCaseOffenderLink(offenders[i], id);
            }
        }
    }
}

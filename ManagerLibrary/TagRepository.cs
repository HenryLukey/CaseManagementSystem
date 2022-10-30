using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary
{
    public class TagRepository
    {
        /// <summary>
        /// Adds a row to the tag table with the relevant case id to link it
        /// </summary>
        public void AddTag(string tag, long caseID)
        {
            var connection = MySQLDatabase.GetConnection();

            //SQL command meaning, add a row to the tag table inserting data into the CaseID and Tag columns
            string query = "INSERT INTO tag (CaseID, Tag) VALUES (@CaseID, @Tag)";

            var command = new MySqlCommand(query, connection);

            command.Parameters.Add("@CaseID", MySqlDbType.Int64).Value = caseID;
            command.Parameters.Add("@Tag", MySqlDbType.String).Value = tag;

            command.ExecuteNonQuery();

            connection.Close();
        }

        /// <summary>
        /// Adds a list of tags to the SQL database (all linked to the same case so only uses one case id)
        /// </summary>
        public void AddListOfTags(List<string> tags, long caseID)
        {
            //For every tag in the list
            for (int i = 0; i < tags.Count; i++)
            {
                //Add to the table
                AddTag(tags[i], caseID);
            }
        }

        /// <summary>
        /// Gets all the IDs that are connected to a specific string tag value
        /// </summary>
        public List<long> GetIDsFromTag(string tag)
        {
            var connection = MySQLDatabase.GetConnection();

            List<long> idList = new List<long>();

            //SQL query, get all rows from the tag table were the tag column is equal to our tag parameter
            string query = "SELECT * FROM tag WHERE Tag = @Tag";

            var command = new MySqlCommand(query, connection);

            command.Parameters.Add("@Tag", MySqlDbType.String).Value = tag;

            //Reads the SQL response data
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                //Adds all the case IDs we get to a list
                while (reader.Read())
                {
                    long tempID = (long)reader["CaseID"];
                    idList.Add(tempID);
                }
            }

            return idList;
        } 
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary
{
    public class CaseManagerRepository
    {
        /// <summary>
        /// queries the CaseManager table within the database using a given ID. It then populates the properties of a new instance of CaseManager with the results of the query
        /// and returns this CaseManager object.
        /// </summary>
        public CaseManager GetCaseManagerByID(long id)
        {
            var connection = MySQLDatabase.GetConnection();

            CaseManager caseManager = new CaseManager();

            //this is the SQL query (it essentially means: select every caseManager from the table that has the given ID)
            string query = "SELECT * FROM case_manager WHERE ID = @ID";

            var command = new MySqlCommand(query, connection);

            command.Parameters.Add("@ID", MySqlDbType.Int64).Value = id;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                //goes through every column in the selected caseManager and sets the objects parameters to be equal to the tables respective values
                while (reader.Read())
                {
                    caseManager.ID = (long)reader["ID"];
                    caseManager.FirstName = reader["FirstName"].ToString();
                    caseManager.LastName = reader["LastName"].ToString();
                }
            }

            connection.Close();

            return caseManager;
        }

        /// <summary>
        /// adds an instance of CaseManager to the SQL database
        /// </summary>
        public long AddCaseManager(CaseManager caseManager)
        {
            var connection = MySQLDatabase.GetConnection();

            //this is the SQL command (it essentially says: add a new row to the database with these values in the columns listed)
            string query = "INSERT INTO case_manager (FirstName, LastName) VALUES (@FirstName, @LastName)";

            var command = new MySqlCommand(query, connection);

            command.Parameters.Add("@FirstName", MySqlDbType.String).Value = caseManager.FirstName;
            command.Parameters.Add("@LastName", MySqlDbType.String).Value = caseManager.LastName;

            command.ExecuteNonQuery();

            connection.Close();

            long id = command.LastInsertedId;

            //the id is returned so we can know how to access it again
            return id;
        }

        /// <summary>
        /// updates an existing listing in the SQL database uses an instance of CaseManager (essentially overwriting every field)
        /// </summary>
        public void UpdateCaseManager(CaseManager caseManager)
        {
            var connection = MySQLDatabase.GetConnection();

            //this is the SQL command (it essentially says: update the listing in the database with the given ID with these values in the columns listed)
            string query = "UPDATE case_manager SET FirstName = @FirstName, LastName = @LastName WHERE ID = @ID";

            var command = new MySqlCommand(query, connection);

            command.Parameters.Add("@FirstName", MySqlDbType.String).Value = caseManager.FirstName;
            command.Parameters.Add("@LastName", MySqlDbType.String).Value = caseManager.LastName;
            command.Parameters.Add("@ID", MySqlDbType.Int64).Value = caseManager.ID;

            command.ExecuteNonQuery();

            connection.Close();
        }

        /// <summary>
        /// loops through every row in the case_manager table and returns the results as a list of CaseManager objects
        /// </summary>
        public List<CaseManager> GetAllCaseManagers()
        {
            var connection = MySQLDatabase.GetConnection();

            List<long> idList = new List<long>();

            List<CaseManager> caseManagerList = new List<CaseManager>();

            //selects every entry in the case_manager table
            string query = "SELECT * FROM case_manager";

            var command = new MySqlCommand(query, connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                //loops through all the entries an adds their IDs to a list
                while (reader.Read())
                {
                    long tempID = (long)reader["ID"];
                    idList.Add(tempID);
                }
            }

            //calls GetCaseManager for every id in the list and adds them to a list
            for (int i = 0; i < idList.Count; i++)
            {
                caseManagerList.Add(GetCaseManagerByID(idList[i]));
            }
            return caseManagerList;
        }
    }
}

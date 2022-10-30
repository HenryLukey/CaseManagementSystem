using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary
{
    public class ChecklistRepository
    {
        /// <summary>
        /// Gets a checklist object from the database using a checklist id as a parameter
        /// </summary>
        public Checklist GetChecklistByID(long id)
        {
            var connection = MySQLDatabase.GetConnection();

            Checklist checklist = new Checklist();

            //SQL command, selects every instance from the checklist table with the given id
            string query = "SELECT * FROM checklist WHERE ID = @ID";

            var command = new MySqlCommand(query, connection);

            command.Parameters.Add("@ID", MySqlDbType.Int64).Value = id;

            //Reads the data
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                //Assigns all the checklist properties to be equal to the data given by the reader
                while (reader.Read())
                {
                    checklist.ID = (long)reader["ID"];
                    checklist.Wilberforce = (bool)reader["Wilberforce"];
                    checklist.Infos = (bool)reader["Infos"];
                    checklist.ASNRequested = (bool)reader["ASNRequested"];
                    checklist.ASNReceived = (bool)reader["ASNReceived"];
                    checklist.SharingRights = (bool)reader["SharingRights"];
                    checklist.HearingDate = (bool)reader["HearingDateRequested"];
                    checklist.DeliveryReceipt = (bool)reader["DeliveryReceipt"];
                    checklist.AuthorisationReceived = (bool)reader["AuthorisationReceived"];
                    checklist.Diary = (bool)reader["Diary"];
                    checklist.Inform = (bool)reader["Inform"];
                    checklist.HearingSent = (bool)reader["HearingSent"];
                    checklist.SummonsServed = (bool)reader["SummonsServed"];
                    checklist.BriefSent = (bool)reader["BriefSent"];
                }
            }

            connection.Close();

            return checklist;
        }

        /// <summary>
        /// Adds a checklist object to the checklist table in the SQL database
        /// </summary>
        public long AddChecklist(Checklist checklist)
        {
            var connection = MySQLDatabase.GetConnection();

            //The SQL command, it says to add a row to the checklist table putting the listed values in the listed columns
            string query = "INSERT INTO checklist (Wilberforce, Infos, ASNRequested, ASNReceived, SharingRights, HearingDateRequested, DeliveryReceipt, AuthorisationReceived, Diary, " +
                           "Inform, HearingSent, SummonsServed, BriefSent) VALUES (@Wilberforce, @Infos, @ASNRequested, @ASNReceived, @SharingRights, @HearingDateRequested, " +
                           "@DeliveryReceipt, @AuthorisationReceived, @Diary, @Inform, @HearingSent, @SummonsServed, @BriefSent)";

            var command = new MySqlCommand(query, connection);

            //Assigns all the command's parameters real values from the checklist parameter
            command.Parameters.Add("@Wilberforce", MySqlDbType.Bit).Value = checklist.Wilberforce;
            command.Parameters.Add("@Infos", MySqlDbType.Bit).Value = checklist.Infos;
            command.Parameters.Add("@ASNRequested", MySqlDbType.Bit).Value = checklist.ASNRequested;
            command.Parameters.Add("@ASNReceived", MySqlDbType.Bit).Value = checklist.ASNReceived;
            command.Parameters.Add("@SharingRights", MySqlDbType.Bit).Value = checklist.SharingRights;
            command.Parameters.Add("@HearingDateRequested", MySqlDbType.Bit).Value = checklist.HearingDate;
            command.Parameters.Add("@DeliveryReceipt", MySqlDbType.Bit).Value = checklist.DeliveryReceipt;
            command.Parameters.Add("@AuthorisationReceived", MySqlDbType.Bit).Value = checklist.AuthorisationReceived;
            command.Parameters.Add("@Diary", MySqlDbType.Bit).Value = checklist.Diary;
            command.Parameters.Add("@Inform", MySqlDbType.Bit).Value = checklist.Inform;
            command.Parameters.Add("@HearingSent", MySqlDbType.Bit).Value = checklist.HearingSent;
            command.Parameters.Add("@SummonsServed", MySqlDbType.Bit).Value = checklist.SummonsServed;
            command.Parameters.Add("@BriefSent", MySqlDbType.Bit).Value = checklist.BriefSent;

            command.ExecuteNonQuery();

            connection.Close();

            //Gets the id of the checklist we just added to the database
            long id = command.LastInsertedId;

            return id;
        }

        /// <summary>
        /// Updates an existing listing in the checklist table using a Checklist object (essentially overwriting every field)
        /// </summary>
        public void UpdateChecklist(Checklist checklist)
        {
            var connection = MySQLDatabase.GetConnection();

            //this is the SQL command (it essentially says: update the listing in the database with the given ID with these values in the columns listed)
            string query = "UPDATE checklist SET Wilberforce = @Wilberforce, Infos = @Infos, ASNRequested = @ASNRequested, ASNReceived = @ASNReceived, " +
                           "SharingRights = @SharingRights, HearingDateRequested = @HearingDateRequested, DeliveryReceipt = @DeliveryReceipt, AuthorisationReceived = @AuthorisationReceived, " +
                           "Diary = @Diary, Inform = @Inform, HearingSent = @HearingSent, SummonsServed = @SummonsServed, BriefSent = @BriefSent WHERE ID = @ID";

            var command = new MySqlCommand(query, connection);

            //Assigns the command parameters to be equal to the relevant values from the checklist parameter
            command.Parameters.Add("@Wilberforce", MySqlDbType.Bit).Value = checklist.Wilberforce;
            command.Parameters.Add("@Infos", MySqlDbType.Bit).Value = checklist.Infos;
            command.Parameters.Add("@ASNRequested", MySqlDbType.Bit).Value = checklist.ASNRequested;
            command.Parameters.Add("@ASNReceived", MySqlDbType.Bit).Value = checklist.ASNReceived;
            command.Parameters.Add("@SharingRights", MySqlDbType.Bit).Value = checklist.SharingRights;
            command.Parameters.Add("@HearingDateRequested", MySqlDbType.Bit).Value = checklist.HearingDate;
            command.Parameters.Add("@DeliveryReceipt", MySqlDbType.Bit).Value = checklist.DeliveryReceipt;
            command.Parameters.Add("@AuthorisationReceived", MySqlDbType.Bit).Value = checklist.AuthorisationReceived;
            command.Parameters.Add("@Diary", MySqlDbType.Bit).Value = checklist.Diary;
            command.Parameters.Add("@Inform", MySqlDbType.Bit).Value = checklist.Inform;
            command.Parameters.Add("@HearingSent", MySqlDbType.Bit).Value = checklist.HearingSent;
            command.Parameters.Add("@SummonsServed", MySqlDbType.Bit).Value = checklist.SummonsServed;
            command.Parameters.Add("@BriefSent", MySqlDbType.Bit).Value = checklist.BriefSent;
            command.Parameters.Add("@ID", MySqlDbType.Int64).Value = checklist.ID;

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}

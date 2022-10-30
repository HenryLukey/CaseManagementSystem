using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerLibrary
{
    public class CaseRepository
    {
        /// <summary>
        /// Gets a case object using the id as a parameter to get the relevant case with that id from the SQL database
        /// </summary>
        public Case GetCaseByID(long id)
        {
            //Opens a connection to the database
            var connection = MySQLDatabase.GetConnection();

            //Creates a new case object and initialises all the required repositories
            Case @case = new Case();
            CaseAnimalLinkRepository animalLink = new CaseAnimalLinkRepository();
            CaseOffenderLinkRepository offenderLink = new CaseOffenderLinkRepository();
            InspectorRepository inspectorRepo = new InspectorRepository();
            CourtRepository courtRepo = new CourtRepository();
            CaseManagerRepository caseManagerRepo = new CaseManagerRepository();
            ChecklistRepository checklistRepo = new ChecklistRepository();

            //SQL command to get the instance from the case table with the given id
            string query = "SELECT * FROM `case` WHERE ID = @ID";

            var command = new MySqlCommand(query, connection);

            command.Parameters.Add("@ID", MySqlDbType.Int64).Value = id;

            //Reads the data given as a response to the command
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                //Loops through every line and assigns the new case object the relevant data for each parameter
                while (reader.Read())
                {
                    @case.ID = (long)reader["ID"];
                    @case.HQCaseNumber = reader["HQCaseNumber"].ToString();
                    @case.IncidentNumber = reader["IncidentNumber"].ToString();
                    @case.GroupNumber = reader["GroupNumber"].ToString();
                    @case.PlaceOfOffence = reader["PlaceOfOffence"].ToString();
                    @case.ASN = reader["ASN"].ToString();
                    @case.Solicitor = reader["Solicitor"].ToString();

                    //This value must be parsed to an enum
                    if (reader["Region"] != DBNull.Value)
                    {
                        @case.Region = (Region)Enum.Parse(typeof(Region), reader["Region"].ToString());
                    }
                    //Use the InspectorID given by the request to get an inspector object using the inspectorRepository instance
                    if (reader["InspectorID"] != DBNull.Value)
                    {
                        @case.Inspector = inspectorRepo.GetInspectorByID((long)reader["InspectorID"]);
                    }
                    //Use the CourtID given by the request to get a court object using the courtRepository instance
                    if (reader["CourtID"] != DBNull.Value)
                    {
                        @case.Court = courtRepo.GetCourtByID((long)reader["CourtID"]);
                    }
                    //This value must be converted to the DateTime data type
                    if (reader["DateOfOffence"] != DBNull.Value)
                    {
                        @case.DateOfOffence = (DateTime)reader["DateOfOffence"];
                    }
                    //This value must be converted to the DateTime data type
                    if (reader["DateFirstInvestigated"] != DBNull.Value)
                    {
                        @case.DateFirstInvestigated = (DateTime)reader["DateFirstInvestigated"];
                    }
                    //This value must be converted to the DateTime data type
                    if (reader["DateSubmitted"] != DBNull.Value)
                    {
                        @case.DateSubmitted = (DateTime)reader["DateSubmitted"];
                    }
                    //Use the CaseManagerID given by the request to get a CaseManager object using the CaseManagerRepository instance
                    if (reader["CaseManagerID"] != DBNull.Value)
                    {
                        @case.CaseManager = caseManagerRepo.GetCaseManagerByID((long)reader["CaseManagerID"]);
                    }
                    //This value must be converted to a boolean
                    if (reader["IsOpen"] != DBNull.Value)
                    {
                        @case.IsOpen = Convert.ToBoolean(reader["IsOpen"]);
                    }
                    //This value must be parsed to an enum
                    if (reader["Status"] != DBNull.Value)
                    {
                        @case.Status = (CaseStatus)Enum.Parse(typeof(CaseStatus), reader["Status"].ToString());
                    }
                    //This value must be converted to the DateTime data type
                    if (reader["FurtherActionBy"] != DBNull.Value)
                    {
                        @case.FurtherActionBy = (DateTime)reader["FurtherActionBy"];
                    }
                    //This value must be converted to the DateTime data type
                    if (reader["ReviewDate"] != DBNull.Value)
                    {
                        @case.ReviewDate = (DateTime)reader["ReviewDate"];
                    }
                    //Use the ChecklistID given by the request to get a Checklist object using the ChecklistRepository instance
                    if (reader["ChecklistID"] != DBNull.Value)
                    {
                        @case.Checklist = checklistRepo.GetChecklistByID((long)reader["ChecklistID"]);
                    }
                    //Uses the AnimalRepository and OffenderRepository to get the Animals and Offenders properties for the case
                    @case.Animals = animalLink.GetAnimalsFromCaseID(@case.ID);
                    @case.Offenders = offenderLink.GetOffendersFromCaseID(@case.ID);
                }
            }

            //closes the connection and returns the populated case object
            connection.Close();
            return @case;
        }

        /// <summary>
        /// Adds a case object to the case table in the SQL database
        /// </summary>
        public void AddCase(Case @case)
        {
            //Initialises all the required repositories
            CaseAnimalLinkRepository animalLink = new CaseAnimalLinkRepository();
            CaseOffenderLinkRepository offenderLink = new CaseOffenderLinkRepository();
            TagRepository tagRepo = new TagRepository();
            InspectorRepository inspectorRepo = new InspectorRepository();
            CourtRepository courtRepo = new CourtRepository();
            CaseManagerRepository caseManagerRepo = new CaseManagerRepository();
            ChecklistRepository checklistRepo = new ChecklistRepository();

            var connection = MySQLDatabase.GetConnection();

            //This is the SQL command, it says to add a row to the case table putting the listed values in the listed columns
            string query = "INSERT INTO `case` (HQCaseNumber, IncidentNumber, GroupNumber, Region, InspectorID, CourtID, DateOfOffence, DateFirstInvestigated, DateSubmitted, " +
                           "PlaceOfOffence, ASN, CaseManagerID, IsOpen, Status, FurtherActionBy, ReviewDate, Solicitor) VALUES (@HQCaseNumber, " +
                           "@IncidentNumber, @GroupNumber, @Region, @InspectorID, @CourtID, @DateOfOffence, @DateFirstInvestigated, @DateSubmitted, @PlaceOfOffence, " +
                           "@ASN, @CaseManagerID, @IsOpen, @Status, @FurtherActionBy, @ReviewDate, @Solicitor)";

            var command = new MySqlCommand(query, connection);

            //Assigns all the command's parameters the actual values
            command.Parameters.Add("@HQCaseNumber", MySqlDbType.String).Value = @case.HQCaseNumber;
            command.Parameters.Add("@IncidentNumber", MySqlDbType.String).Value = @case.IncidentNumber;
            command.Parameters.Add("@GroupNumber", MySqlDbType.String).Value = @case.GroupNumber;
            command.Parameters.Add("@Region", MySqlDbType.String).Value = @case.Region; //might be wrong
            command.Parameters.Add("@InspectorID", MySqlDbType.Int64).Value = inspectorRepo.AddInspectorWithCheck(@case.Inspector); //change this for new method that'll check for existing ... in table
            command.Parameters.Add("@CourtID", MySqlDbType.Int64).Value = courtRepo.AddCourtWithCheck(@case.Court); //change this for new method that'll check for existing ... in table
            command.Parameters.Add("@DateOfOffence", MySqlDbType.DateTime).Value = @case.DateOfOffence;
            command.Parameters.Add("@DateFirstInvestigated", MySqlDbType.DateTime).Value = @case.DateFirstInvestigated;
            command.Parameters.Add("@DateSubmitted", MySqlDbType.DateTime).Value = @case.DateSubmitted;
            command.Parameters.Add("@PlaceOfOffence", MySqlDbType.String).Value = @case.PlaceOfOffence;
            command.Parameters.Add("@ASN", MySqlDbType.String).Value = @case.ASN;
            command.Parameters.Add("@CaseManagerID", MySqlDbType.Int64).Value = @case.CaseManager.ID; //change this for new method that'll check for existing ... in table
            command.Parameters.Add("@IsOpen", MySqlDbType.Bit).Value = @case.IsOpen;
            command.Parameters.Add("@Status", MySqlDbType.Enum).Value = @case.Status;
            command.Parameters.Add("@FurtherActionBy", MySqlDbType.DateTime).Value = @case.FurtherActionBy;
            command.Parameters.Add("@ReviewDate", MySqlDbType.DateTime).Value = @case.ReviewDate;
            command.Parameters.Add("@Solicitor", MySqlDbType.String).Value = @case.Solicitor;

            command.ExecuteNonQuery();

            connection.Close();

            //Gets the id of the case we just added to the case table
            long id = command.LastInsertedId;

            //Adds tags relating to to the case so users can search for them later
            List<string> tags = new List<string>();
            for (int i = 0; i < @case.Offenders.Count; i++)
            {
                tags.Add(@case.Offenders[i].LastName);
                tags.Add(@case.Offenders[i].FirstNames);
            }
            tags.Add(@case.Solicitor);
            tags.Add(@case.Court.CourtCode);
            tags.Add(@case.Court.CourtName);
            tags.Add(@case.Inspector.FirstName);
            tags.Add(@case.Inspector.LastName);
            tags.Add(@case.Inspector.NumberCode);
            tagRepo.AddListOfTags(tags, id);

            //Uses CaseAnimalLinkRepository and CaseOffenderLinkRepository to add to the link tables so we can later get the lists of offenders/animals relevant to this case
            animalLink.AddListOfCaseAnimalLinks(@case.Animals, id);
            offenderLink.AddListOfCaseOffenderLinks(@case.Offenders, id);
        }

        /// <summary>
        /// Updates an existing listing in the case table using an instance of Case (essentially overwriting every field)
        /// </summary>
        public void UpdateCase(Case @case)
        {
            var connection = MySQLDatabase.GetConnection();

            //this is the SQL command (it essentially says: update the listing in the database with the given ID with these values in the columns listed)
            string query = "UPDATE `case` SET ASN = @ASN, IsOpen = @IsOpen, Status = @Status, FurtherActionBy = @FurtherActionBy, ReviewDate = @ReviewDate, " +
                           "Solicitor = @Solicitor, CaseManagerID = @CaseManagerID, ChecklistID = @ChecklistID WHERE ID = @ID";

            var command = new MySqlCommand(query, connection);

            //Assigns all the command's parameters the actual values
            command.Parameters.Add("@ASN", MySqlDbType.String).Value = @case.ASN;
            command.Parameters.Add("@IsOpen", MySqlDbType.Bit).Value = @case.IsOpen;
            command.Parameters.Add("@Status", MySqlDbType.Enum).Value = @case.Status;
            command.Parameters.Add("@FurtherActionBy", MySqlDbType.DateTime).Value = @case.FurtherActionBy;
            command.Parameters.Add("@ReviewDate", MySqlDbType.DateTime).Value = @case.ReviewDate;
            command.Parameters.Add("@Solicitor", MySqlDbType.String).Value = @case.Solicitor;
            command.Parameters.Add("@CaseManagerID", MySqlDbType.Int64).Value = @case.CaseManager.ID;
            command.Parameters.Add("@ID", MySqlDbType.Int64).Value = @case.ID;
            command.Parameters.Add("@ChecklistID", MySqlDbType.Int64).Value = @case.Checklist.ID;

            command.ExecuteNonQuery();

            //Closes the connection to the database
            connection.Close();
        }

        /// <summary>
        /// Gets a list of cases using a list of case ids
        /// </summary>
        public List<Case> GetListOfCasesFromIDs(List<long> idList)
        {
            List<Case> caseList = new List<Case>();

            //Loops through every case id
            for (int i = 0; i < idList.Count; i++)
            {
                //Gets the case in the database with that id and adds it to the new list
                Case tempCase = GetCaseByID(idList[i]);
                caseList.Add(tempCase);
            }

            return caseList;
        }

        /// <summary>
        /// Gets a list of every case id in the SQL database
        /// </summary>
        /// <returns></returns>
        public List<long> GetAllIDs()
        {
            string query = "SELECT * FROM `case`";

            return GetIDsFromQuery(query);
        }

        /// <summary>
        /// Gets all the IDs relevant to a specific query
        /// </summary>
        public List<long> GetIDsFromQuery(string query)
        {
            var connection = MySQLDatabase.GetConnection();

            List<long> idList = new List<long>();

            //Creates a command using the query parameter
            var command = new MySqlCommand(query, connection);

            //Reads the data given back
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                //Adds all id values to a list
                while (reader.Read())
                {
                    long tempID = (long)reader["ID"];
                    idList.Add(tempID);
                }
            }

            return idList;
        }   
    }
}

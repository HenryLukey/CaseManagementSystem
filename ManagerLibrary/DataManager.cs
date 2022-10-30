using Google.Apis.Auth.OAuth2;
using Google.Apis.Docs.v1;
using Google.Apis.Docs.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ManagerLibrary
{
    public class DataManager
    {
        //Relevant data for the requests we'll make to the Google api
        string[] scopes = { DocsService.Scope.Drive };
        string applicationName = "NEA Project";

        /// <summary>
        /// Returns a Google Document from a given URL
        /// </summary>
        public Document GetDocFromURL(string url)
        {
            UserCredential credential;

            //Opens the credentials json file and uses the contents to create a UserCredential so we're authorised to access the Google Drive
            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            //Create Google Docs API service
            var service = new DocsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = applicationName,
            });

            //Gets the Document by making a request to the Docs Service using the id given from the url
            String documentId = GetIDFromURL(url);
            DocumentsResource.GetRequest request = service.Documents.Get(documentId);
            Document doc = request.Execute();

            return doc;
        }

        /// <summary>
        /// Creates a FrontSheet object from the URL of a pre-existing front sheet document on Google Drive
        /// </summary>
        public FrontSheet GetFrontSheetFromURL(string url)
        {
            FrontSheet frontSheet = new FrontSheet();

            //Gets a list of all content elements as strings
            List<string> unfixedContentList = GetContentListFromDoc(GetDocFromURL(url));
            List<string> contentList = RemoveNewLines(unfixedContentList);

            //Assigns the front sheet properties to be the relevant data from the content list using their indexes
            frontSheet.HQCaseNumber = contentList[1];
            frontSheet.IncidentNumber = contentList[3];
            frontSheet.Region = contentList[5];
            frontSheet.Group = contentList[7];
            frontSheet.DateOfOffence = contentList[9];
            frontSheet.CourtName = contentList[11];
            frontSheet.DateFirstInvestigated = contentList[13];
            frontSheet.CourtCode = contentList[15];
            frontSheet.DateSubmitted = contentList[17];
            frontSheet.InspectorFirstName = contentList[22];
            frontSheet.InspectorLastName = contentList[24];
            frontSheet.InspectorNumber = contentList[26];
            frontSheet.InspectorMobile = contentList[28];
            frontSheet.OffenderLastName = contentList[92];
            frontSheet.OffenderFirstNames = contentList[94];
            frontSheet.OffenderAddress = contentList[96];
            frontSheet.OffenderPostcode = contentList[98];
            frontSheet.OffenderOccupation = contentList[100];
            frontSheet.OffenderDateOfBirth = contentList[102];
            frontSheet.OffenderNINumber = contentList[104];
            frontSheet.OffenderGender = contentList[106];
            frontSheet.PlaceOfOffence = contentList[109];
            
            //Have to use a seperate method because the number of animals can vary
            frontSheet.Animals = GetAnimalListFromContentList(contentList);

            return frontSheet;
        }

        /// <summary>
        /// Removes the \n parts (which represent when to go to a new line) of the content elements
        /// </summary>
        public List<string> RemoveNewLines(List<string> stringList)
        {
            List<string> correctedList = new List<string>();

            //Add every string to a new list without the '\n' part
            for (int i = 0; i < stringList.Count; i++)
            {
                string correctedString = stringList[i].Replace("\n", "");
                correctedList.Add(correctedString);
            }

            return correctedList;
        }

        /// <summary>
        /// Gets a list of animals from the content list
        /// </summary>
        public List<Animal> GetAnimalListFromContentList(List<string> contentList)
        {
            List<Animal> animalList = new List<Animal>();

            //Creates animal object for each row in the animal table on the front sheet Document
            Animal animal1 = GetAnimalFromContentList(contentList, 43); 
            Animal animal2 = GetAnimalFromContentList(contentList, 55);
            Animal animal3 = GetAnimalFromContentList(contentList, 67);
            Animal animal4 = GetAnimalFromContentList(contentList, 79);

            //If the 1st row was empty this animal won't be added
            if (animal1 != null)
            {
                animalList.Add(animal1);
            }

            //If the 2nd row was empty this animal won't be added
            if (animal2 != null)
            {
                animalList.Add(animal2);
            }

            //If the 3rd row was empty this animal won't be added
            if (animal3 != null)
            {
                animalList.Add(animal3);
            }

            //If the 4th row was empty this animal won't be added
            if (animal4 != null)
            {
                animalList.Add(animal4);
            }

            //Returns the list of animals
            return animalList;
        }

        /// <summary>
        /// Gets an animal from the content list
        /// </summary>
        public Animal GetAnimalFromContentList(List<string> contentList, int startIndex)
        {
            //If the given start element and the one after that of the content list aren't empty then run the following code
            if (!String.IsNullOrEmpty(contentList[startIndex]) && !String.IsNullOrEmpty(contentList[startIndex+1]))
            {
                //Create a new animal and populate its properties from the data contained in the content list
                Animal animal = new Animal();
                animal.ExhibitNumber = contentList[startIndex];
                animal.Species = contentList[startIndex+1];
                animal.Breed = contentList[startIndex+2];
                animal.OriginalName = contentList[startIndex+3];
                animal.Description = contentList[startIndex+4];
                animal.Status = (Status)Enum.Parse(typeof(Status), contentList[startIndex+5]);
                animal.Date = contentList[startIndex+6];
                animal.CurrentLocation = contentList[startIndex+7];

                //Needs to be converted to a boolean
                if (contentList[startIndex+8].ToLower() == "yes")
                {
                    animal.SignedOver = true;
                }
                else if (contentList[startIndex+8].ToLower() == "no")
                {
                    animal.SignedOver = false;
                }
                //Needs to be converted to a boolean
                if (contentList[startIndex+9].ToLower() == "yes")
                {
                    animal.PTS = true;
                }
                else if (contentList[startIndex+9].ToLower() == "no")
                {
                    animal.PTS = false;
                }
                //Needs to be converted to a boolean
                if (contentList[startIndex+10].ToLower() == "yes")
                {
                    animal.Dead = true;
                }
                else if (contentList[startIndex+10].ToLower() == "no")
                {
                    animal.Dead = false;
                }
                return animal;
            }

            //Will return null if the elements of the content list are empty
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Breaks a Google Document down into a list of content elements and returns them as string values in a list
        /// </summary>
        public List<string> GetContentListFromDoc(Document doc)
        {
            List<string> cellContentList = new List<string>();

            //Gets a list of structural elements from the Document
            List<StructuralElement> structuralElements = doc.Body.Content.ToList();

            //Loops through every structural element in the document
            for (int i = 0; i < structuralElements.Count; i++)
            {
                //Only interested if it's a table
                if (structuralElements[i].Table != null)
                {
                    //Get the rows of this table
                    List<TableRow> tableRows = structuralElements[i].Table.TableRows.ToList();

                    for (int x = 0; x < tableRows.Count; x++)
                    {
                        //Get the cells of this row
                        List<TableCell> tableCells = tableRows[x].TableCells.ToList();

                        for (int y = 0; y < tableCells.Count; y++)
                        {
                            //Get the structural elements of this cell
                            List<StructuralElement> cellElements = tableCells[y].Content.ToList();

                            for (int k = 0; k < cellElements.Count; k++)
                            {
                                //Only interested if the element is a paragraph
                                if (cellElements[k].Paragraph != null)
                                {
                                    //Get the elements of this paragraph
                                    List<ParagraphElement> paragraphElements = cellElements[k].Paragraph.Elements.ToList();

                                    for (int j = 0; j < paragraphElements.Count; j++)
                                    {
                                        //Add the text of the paragraph element to the content list
                                        cellContentList.Add(paragraphElements[j].TextRun.Content);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return cellContentList;
        }

        /// <summary>
        /// Gets an ID from a URL by splitting it and taking the relevant portion
        /// </summary>
        public static string GetIDFromURL(string url)
        {
            string[] urlSplit = url.Split('/');

            return urlSplit[5];
        }
    }
}

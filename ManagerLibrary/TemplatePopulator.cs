using Google.Apis.Auth.OAuth2;
using Google.Apis.Docs.v1;
using Google.Apis.Docs.v1.Data;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManagerLibrary
{
    public class TemplatePopulator
    {
        //Info needed to connect to the Google services
        string[] Scopes = { DriveService.Scope.Drive };
        string ApplicationName = "NEA Project";

        //The document IDs of the summons and caution templates
        string cautionTemplateId = @"1WQCaSRK-05Ts0XZ9Zm8xl2YqYGDhn3UCeu_hZVqYmKU";
        string summonsTemplateId = @"14fBIvQCGYssoxMzxQktu6wsOBC6nbVRsPW7m6vtHvdU";

        DocsService docsService;
        DriveService driveService;

        public TemplatePopulator()
        {
            docsService = GetDocsService();
            driveService = GetDriveService();
        }

        /// <summary>
        /// Creates a new Drive service to be used
        /// </summary>
        /// <returns></returns>
        private DriveService GetDriveService()
        {
            UserCredential credential;

            //Opens the credentials json file and uses it to create a UserCredential variable so we can access the Drive
            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            //Create Google Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            //Return the service ready to be used
            return service;
        }

        /// <summary>
        /// Creates a new Docs service to be used
        /// </summary>
        /// <returns></returns>
        private DocsService GetDocsService()
        {
            UserCredential credential;

            //Opens the credentials json file and uses it to create a UserCredential variable so we can access the Docs
            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            //Create Google Docs API service.
            var service = new DocsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            //Returns the service ready to be used
            return service;
        }

        /// <summary>
        /// Duplicates a file using its ID and moves it to the given folder
        /// </summary>
        private Google.Apis.Drive.v3.Data.File CopyFile(string originFileId, string copyTitle, string folderId)
        {
            //Creates a new list and adds the folder location to it
            List<string> parentList = new List<string>();
            parentList.Add(folderId);
            
            //Creates a blank file
            var copyMetadata = new Google.Apis.Drive.v3.Data.File();
            //Sets it's title to be equal to our title parameter
            copyMetadata.Name = copyTitle;
            //Sets the parents property to be equal to our list containing the folder id
            copyMetadata.Parents = parentList;

            //Copies the original file to our blank one
            var documentCopyFile = driveService.Files.Copy(copyMetadata, originFileId).Execute();

            return documentCopyFile;
        }

        /// <summary>
        /// Gets an ID from a URL by splitting it and taking the relevant portion
        /// </summary>
        private string GetFolderIDFromURL(string url)
        {
            string[] urlSplit = url.Split('/');

            return urlSplit[7];
        }

        /// <summary>
        /// Uses a docs service to get a Document from a document id
        /// </summary>
        private Document GetDocumentFromId(string id)
        {
            DocumentsResource.GetRequest request = docsService.Documents.Get(id);

            return request.Execute();
        }

        /// <summary>
        /// Creates a new document in a given folder using another document as a template
        /// </summary>
        private Document CreateDocumentFromTemplate(string folderUrl, string title, string templateId)
        {
            Google.Apis.Drive.v3.Data.File file = CopyFile(templateId, title, GetFolderIDFromURL(folderUrl));

            return GetDocumentFromId(file.Id);
        }

        /// <summary>
        /// Creates a new Caution document and populates it with the data from the given offender
        /// </summary>
        public void PopulateCaution(Offender offender, string folderUrl, string asn)
        {
            List<Request> requestList = new List<Request>();

            //Creates a request to change any strings with the value "{{name-field}}" to be the given offender's name
            Request nameRequest = new Request();
            var nameSubstringMatchCriteria = new SubstringMatchCriteria();
            var nameReplaceAllText = new ReplaceAllTextRequest();
            nameReplaceAllText.ReplaceText = offender.FirstNames + " " + offender.LastName;
            nameSubstringMatchCriteria.Text = "{{name-field}}";
            nameReplaceAllText.ContainsText = nameSubstringMatchCriteria;
            nameRequest.ReplaceAllText = nameReplaceAllText;

            //Creates a request to change any strings with the value "{{address-field}}" to be the given offender's address
            Request addressRequest = new Request();
            var addressSubstringMatchCriteria = new SubstringMatchCriteria();
            var addressReplaceAllText = new ReplaceAllTextRequest();
            addressReplaceAllText.ReplaceText = offender.Address;
            addressSubstringMatchCriteria.Text = "{{address-field}}";
            addressReplaceAllText.ContainsText = addressSubstringMatchCriteria;
            addressRequest.ReplaceAllText = addressReplaceAllText;

            //Creates a request to change any strings with the value "{{date-of-birth-field}}" to be the given offender's date of birth
            Request dateOfBirthRequest = new Request();
            var dobSubstringMatchCriteria = new SubstringMatchCriteria();
            var dobReplaceAllText = new ReplaceAllTextRequest();
            dobReplaceAllText.ReplaceText = offender.DateOfBirth.ToString();
            dobSubstringMatchCriteria.Text = "{{date-of-birth-field}}";
            dobReplaceAllText.ContainsText = dobSubstringMatchCriteria;
            dateOfBirthRequest.ReplaceAllText = dobReplaceAllText;

            //Creates a request to change any strings with the value "{{occupation-field}}" to be the given offender's occupation
            Request occupationRequest = new Request();
            var occupationSubstringMatchCriteria = new SubstringMatchCriteria();
            var occupationReplaceAllText = new ReplaceAllTextRequest();
            occupationReplaceAllText.ReplaceText = offender.Occupation;
            occupationSubstringMatchCriteria.Text = "{{occupation-field}}";
            occupationReplaceAllText.ContainsText = occupationSubstringMatchCriteria;
            occupationRequest.ReplaceAllText = occupationReplaceAllText;

            //Adds all the seperate requests to a list
            requestList.Add(nameRequest);
            requestList.Add(addressRequest);
            requestList.Add(dateOfBirthRequest);
            requestList.Add(occupationRequest);

            //Makes a customised title based on the offender's name
            string title = offender.FirstNames + " " + offender.LastName + " - Caution";
            //Creates copy of the caution template
            Document doc = CreateDocumentFromTemplate(folderUrl, title, cautionTemplateId);

            //Updates the copy with all the relevant details using our request list
            BatchUpdateDocumentRequest body = new BatchUpdateDocumentRequest();
            body.Requests = requestList;
            docsService.Documents.BatchUpdate(body, doc.DocumentId).Execute();
        }

        /// <summary>
        /// Creates a new Summons document and populates it with the data from the given offender (and ASN)
        /// </summary>
        public void PopulateSummons(Offender offender, string folderUrl, string asn)
        {
            List<Request> requestList = new List<Request>();

            //Creates a request to change any strings with the value "{{name-field}}" to be the given offender's name
            Request nameRequest = new Request();
            var nameSubstringMatchCriteria = new SubstringMatchCriteria();
            var nameReplaceAllText = new ReplaceAllTextRequest();
            nameReplaceAllText.ReplaceText = offender.FirstNames + " " + offender.LastName;
            nameSubstringMatchCriteria.Text = "{{name-field}}";
            nameReplaceAllText.ContainsText = nameSubstringMatchCriteria;
            nameRequest.ReplaceAllText = nameReplaceAllText;

            //Creates a request to change any strings with the value "{{asn-field}}" to be the given offender's asn
            Request asnRequest = new Request();
            var asnSubstringMatchCriteria = new SubstringMatchCriteria();
            var asnReplaceAllText = new ReplaceAllTextRequest();
            asnReplaceAllText.ReplaceText = asn;
            asnSubstringMatchCriteria.Text = "{{asn-field}}";
            asnReplaceAllText.ContainsText = asnSubstringMatchCriteria;
            asnRequest.ReplaceAllText = asnReplaceAllText;

            //Creates a request to change any strings with the value "{{date-of-birth-field}}" to be the given offender's date of birth
            Request dateOfBirthRequest = new Request();
            var dobSubstringMatchCriteria = new SubstringMatchCriteria();
            var dobReplaceAllText = new ReplaceAllTextRequest();
            dobReplaceAllText.ReplaceText = offender.DateOfBirth.ToString();
            dobSubstringMatchCriteria.Text = "{{date-of-birth-field}}";
            dobReplaceAllText.ContainsText = dobSubstringMatchCriteria;
            dateOfBirthRequest.ReplaceAllText = dobReplaceAllText;

            //Creates a request to change any strings with the value "{{nin-field}}" to be the given offender's national insurance number
            Request ninRequest = new Request();
            var ninSubstringMatchCriteria = new SubstringMatchCriteria();
            var ninReplaceAllText = new ReplaceAllTextRequest();
            ninReplaceAllText.ReplaceText = offender.NINumber;
            ninSubstringMatchCriteria.Text = "{{nin-field}}";
            ninReplaceAllText.ContainsText = ninSubstringMatchCriteria;
            ninRequest.ReplaceAllText = ninReplaceAllText;

            //Creates a request to change any strings with the value "{{address-field}}" to be the given offender's address
            Request addressRequest = new Request();
            var addressSubstringMatchCriteria = new SubstringMatchCriteria();
            var addressReplaceAllText = new ReplaceAllTextRequest();
            addressReplaceAllText.ReplaceText = offender.Address;
            addressSubstringMatchCriteria.Text = "{{address-field}}";
            addressReplaceAllText.ContainsText = addressSubstringMatchCriteria;
            addressRequest.ReplaceAllText = addressReplaceAllText;

            //Adds all the seperate requests to a list
            requestList.Add(nameRequest);
            requestList.Add(asnRequest);
            requestList.Add(dateOfBirthRequest);
            requestList.Add(ninRequest);
            requestList.Add(addressRequest);

            //Makes a customised title based on the offender's name
            string title = offender.FirstNames + " " + offender.LastName + " - Summons";
            //Creates copy of the summons template
            Document doc = CreateDocumentFromTemplate(folderUrl, title, summonsTemplateId);

            //Updates the copy with all the relevant details using our request list
            BatchUpdateDocumentRequest body = new BatchUpdateDocumentRequest();
            body.Requests = requestList;
            docsService.Documents.BatchUpdate(body, doc.DocumentId).Execute();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary
{
    public class CaseFilter
    {
        /// <summary>
        /// Gets a list of case IDs based on a user's search query
        /// </summary>
        public List<long> GetCaseIDsFromSearch(string search)
        {
            CaseRepository caseRepo = new CaseRepository();

            //if there is a search query then return results of GetIDsFromTag from a new TagRepository instance
            if (!string.IsNullOrEmpty(search))
            {
                TagRepository tagRepo = new TagRepository();
                return tagRepo.GetIDsFromTag(search);
            }

            //if theres no search query then return every case id in the database
            else
            {
                return caseRepo.GetAllIDs();
            }
        }

        /// <summary>
        /// Gets all the cases related to the user's search, selected case manager, and selected status
        /// </summary>
        public List<Case> GetCases(string searchString, CaseManager selectedManager, string status)
        {
            CaseRepository caseRepo = new CaseRepository();

            List<long> IDs = GetCaseIDsFromSearch(searchString);
            List<Case> cases = caseRepo.GetListOfCasesFromIDs(IDs);

            //If a case manager has been selected and it isn't the "All managers" object, then removes any cases not linked the to the given case manager
            if (selectedManager != null)
            {
                if (selectedManager.FirstName != "###" && selectedManager.LastName != "All managers")
                {
                    cases = SortByCaseManager(cases, selectedManager);
                }
            }
            
            //If the status isn't listed as "All" then removes any cases that aren't of the given status
            if (status != "All")
            {
                cases = SortByStatus(cases, status);
            }

            //returns the list of sorted cases
            return cases;
        }

        /// <summary>
        /// Adjusts the order of the case list based on the selected ordering parameter
        /// </summary>
        public List<Case> OrderCases(List<Case> cases, string selectedOrder)
        {
            //If selected order is "Alphabetical" then use Linq to reorder list based on the case's HQCaseNumber property 
            if (selectedOrder == "Alphabetical")
            {
                List<Case> sortedList = cases.OrderBy(x => x.HQCaseNumber).ToList();

                return sortedList;
            }

            //If selected order is "Further action date" then use Linq to reorder list based on the case's FurtherActionBy property
            else if (selectedOrder == "Further action date")
            {
                List<Case> sortedList = cases.OrderBy(x => x.FurtherActionBy).ToList();

                return sortedList;
            }

            //If selected order is "Review / hearing date" then use Linq to reorder list based on the case's ReviewDate property
            else if (selectedOrder == "Review / hearing date")
            {
                List<Case> sortedList = cases.OrderBy(x => x.ReviewDate).ToList();

                return sortedList;
            }

            //Returns the ordered cases
            return cases;
        }

        /// <summary>
        /// Returns a list of all the cases in the given list with the given case manager as their CaseManager property
        /// </summary>
        public List<Case> SortByCaseManager(List<Case> cases, CaseManager caseManager)
        {
            List<Case> caseList = new List<Case>();

            //Checks if every case has the right case manager and adds it to the new list if it does
            for (int i = 0; i < cases.Count; i++)
            {
                if (cases[i].CaseManager.FirstName == caseManager.FirstName && cases[i].CaseManager.LastName == caseManager.LastName)
                {
                    caseList.Add(cases[i]);
                }
            }

            return caseList;
        }

        /// <summary>
        /// Returns a list of all the cases in the given list with the status paramater linked to their Status property
        /// </summary>
        public List<Case> SortByStatus(List<Case> cases, string status)
        {
            List<Case> caseList = new List<Case>();

            //checks if every case in the given list has the same status as the given status and adds it to the new list if it does
            for (int i = 0; i < cases.Count; i++)
            {
                if (cases[i].Status == CaseStatus.Caution && status.ToLower() == "caution")
                {
                    caseList.Add(cases[i]);
                }
                else if (cases[i].Status == CaseStatus.FurtherAction && status.ToLower() == "further action")
                {
                    caseList.Add(cases[i]);
                }
                else if (cases[i].Status == CaseStatus.NoProceedings && status.ToLower() == "no proceedings")
                {
                    caseList.Add(cases[i]);
                }
                else if (cases[i].Status == CaseStatus.Summons && status.ToLower() == "summons")
                {
                    caseList.Add(cases[i]);
                }
            }

            return caseList;
        }
    }
}

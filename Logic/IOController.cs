using System.Collections.Generic;
using Domain;
using DataAccess;

namespace Logic
{
    public class IOController
    {
        List<RouteNumber> routeNumberList;
        List<Contractor> contractorList;

        public IOController()
        {
            routeNumberList = new List<RouteNumber>();
        }
       
        public void InitializeExportToPublishList(string filePath)
        {
            CSVExportToPublishList ExportToPublishList = new CSVExportToPublishList(filePath);
            ExportToPublishList.CreateFile(); 
        }
        public void InitializeExportToCallingList(string filePath)
        {
            CSVExportToCallList ExportCallList = new CSVExportToCallList(filePath);
            ExportCallList.CreateFile();
        }

        //Starts the import of data when import is clicked
        public void InitializeImport(string masterDataFilepath, string routeNumberFilepath)
        {
            CSVImport csvImport = new CSVImport();

            //only import from excel file if database is empty and there are excel files to import
            if (masterDataFilepath != null || routeNumberFilepath != null)
            {   
                //Import data from excel files
                csvImport.ImportContractors(masterDataFilepath);
                csvImport.ImportRouteNumbers();
                csvImport.ImportOffers(routeNumberFilepath);
            }
            //Import data from database
            contractorList = csvImport.SendContractorListToListContainer();
            routeNumberList = csvImport.SendRouteNumberListToListContainer();
            ListContainer listContainer = ListContainer.GetInstance();
            listContainer.GetLists(routeNumberList, contractorList);
        }
    }
}

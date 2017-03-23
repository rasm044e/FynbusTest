using System.Collections.Generic;

namespace Domain
{
    public sealed class ListContainer
    {
        public List<RouteNumber> routeNumberList;   // Liste af Rutenumre
        public List<Contractor> contractorList;     // Liste af vognmænd (der sender tilbud)
        public List<Offer> outputList;              // ??
        public List<Offer> conflictList;            // Liste hvis der er mere end 1 vinder. 
        static readonly ListContainer listContainer = new ListContainer(); // ListContainer med de fire lister, se ovenover.

        private ListContainer() //constructor der instanciere listerne (som tomme), inputter listerne i en listContainer.
        {
            routeNumberList = new List<RouteNumber>(); 
            contractorList = new List<Contractor>();
            outputList = new List<Offer>();
            conflictList = new List<Offer>();
        }

        public static ListContainer GetInstance() // Returnerer listcontaineren(public metode)
        {
          return listContainer;
        }
        public void GetLists(List<RouteNumber> routeNumberList, List<Contractor> contractorList) 
        {
            this.routeNumberList = routeNumberList;
            this.contractorList = contractorList;
        }
    }
}

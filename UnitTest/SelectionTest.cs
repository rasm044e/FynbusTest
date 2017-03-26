using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using Domain;

namespace UnitTest
{
    [TestClass]
    public class SelectionTest
    {
        Selection selection = new Selection();
        List<Offer> offers = new List<Offer>();
        List<RouteNumber> routenumbers = new List<RouteNumber>();

        List<Offer> WinnerList = new List<Offer>();
        RouteNumber routenumber = new RouteNumber();
        SelectionController selectioncontroller = new SelectionController();

        [TestMethod]
        public void Selection_FindWinner_ShouldFindCheapestOfferAnMakeItTheWinner()
        {
            //Create offer1
            Offer offer1 = new Offer();
            offer1.OperationPrice = 150;
            offer1.IsEligible = true;

            //Create offer2
            Offer offer2 = new Offer();
            offer2.OperationPrice = 140;
            offer2.IsEligible = true;
            offers.Add(offer1);
            offers.Add(offer2);

            //Calculate Winner is Cheapest
            offers.Sort((Offer x, Offer y) => x.OperationPrice.CompareTo(y.OperationPrice));
            routenumber.RouteID = 1;
            routenumber.RequiredVehicleType = 1;
            routenumber.offers = offers;


            List<Offer> FindWinner = selection.FindWinner(routenumber);

            //Test
            foreach (var winner in FindWinner)
            {
                Assert.AreEqual(winner.OperationPrice, offer2.OperationPrice);
            }

            Assert.AreEqual(true, FindWinner.Contains(offer2));
            Assert.AreEqual(1, FindWinner.Count);
        }

        [TestMethod]
        public void SelectionController_SortRouteNumberList_ShouldSortTheListByRouteNumberAndOperationPrice()
        {
            //Create offer1
            Offer offer1 = new Offer();
            offer1.OperationPrice = 150;
            offer1.IsEligible = true;

            //Create offer2
            Offer offer2 = new Offer();
            offer2.OperationPrice = 140;
            offer2.IsEligible = true;

            //Add offers to list
            offers.Add(offer1);
            offers.Add(offer2);

            //Creat routenumber and add offers list
            routenumber.RouteID = 1;
            routenumber.RequiredVehicleType = 1;
            routenumber.offers = offers;
            routenumbers.Add(routenumber);

            //Calculate cheapest using the method
            selectioncontroller.SortRouteNumberList(routenumbers);

            Assert.AreEqual(offer2.OperationPrice, routenumbers[0].offers[0].OperationPrice);
        }


        [TestMethod]
        public void Selection_CheckForMultipleWinnersForEachRouteNumber_ShouldThrowAnException()
        {

            //Create offer1
            Offer offer1 = new Offer();
            offer1.OperationPrice = 150;
            offer1.IsEligible = true;

            //Create offer2
            Offer offer2 = new Offer();
            offer2.OperationPrice = 150;
            offer2.IsEligible = true;

            //Add offers to winnerlist
            WinnerList.Add(offer1);
            WinnerList.Add(offer2);

            //Calculate Winner is Cheapest
            WinnerList.Sort((Offer x, Offer y) => x.OperationPrice.CompareTo(y.OperationPrice));
            routenumber.RouteID = 1;
            routenumber.RequiredVehicleType = 1;
            routenumber.offers = WinnerList;

            NUnit.Framework.Assert.Throws<Exception>(() => selection.CheckForMultipleWinnersForEachRouteNumber(WinnerList));
        }



        [TestMethod]
        public void Selection_CalculateOperationPriceDifferenceForOffers_ShouldSetDifferenceToMaxIntWhenOnlyOneOffer()
        {
            routenumbers.Add(new RouteNumber());
            routenumbers[0].offers.Add(new Offer());

            selection.CalculateOperationPriceDifferenceForOffers(routenumbers);

            Assert.AreEqual(routenumbers[0].offers[0].DifferenceToNextOffer, int.MaxValue);
        }

        [TestMethod]
        public void Selection_CalculateOperationPriceDifferenceForOffers_ShouldSetDifferenceToMaxIntWhenTwoOffersAreEqual()
        {
            routenumbers.Add(new RouteNumber());
            routenumbers[0].offers.Add(new Offer());
            routenumbers[0].offers.Add(new Offer());

            selection.CalculateOperationPriceDifferenceForOffers(routenumbers);

            Assert.AreEqual(routenumbers[0].offers[0].DifferenceToNextOffer, int.MaxValue);
            Assert.AreEqual(routenumbers[0].offers[1].DifferenceToNextOffer, int.MaxValue);
        }

        [TestMethod]
        public void Selection_CalculateOperationPriceDifferenceForOffers_ShouldSetDifferenceTo1()
        {
            routenumbers.Add(new RouteNumber());
            routenumbers[0].offers.Add(new Offer());
            routenumbers[0].offers.Add(new Offer());

            routenumbers[0].offers[0].OperationPrice = 1;
            routenumbers[0].offers[1].OperationPrice = 2;

            selection.CalculateOperationPriceDifferenceForOffers(routenumbers);

            Assert.AreEqual(routenumbers[0].offers[0].DifferenceToNextOffer, 1);
        }

    }
}
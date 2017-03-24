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
        List<Offer> offer = new List<Offer>();
        List<RouteNumber> routenumber = new List<RouteNumber>();

        [TestMethod]
        public void Selection_CalculateOperationPriceDifferenceForOffers_ShouldSetDifferenceToMaxIntWhenOnlyOneOffer()
        {
            routenumber.Add(new RouteNumber());
            routenumber[0].offers.Add(new Offer());

            selection.CalculateOperationPriceDifferenceForOffers(routenumber);

            Assert.AreEqual(routenumber[0].offers[0].DifferenceToNextOffer, int.MaxValue);
        }

        [TestMethod]
        public void Selection_CalculateOperationPriceDifferenceForOffers_ShouldSetDifferenceToMaxIntWhenTwoOffersAreEqual()
        {
            routenumber.Add(new RouteNumber());
            routenumber[0].offers.Add(new Offer());
            routenumber[0].offers.Add(new Offer());

            selection.CalculateOperationPriceDifferenceForOffers(routenumber);

            Assert.AreEqual(routenumber[0].offers[0].DifferenceToNextOffer, int.MaxValue);
            Assert.AreEqual(routenumber[0].offers[1].DifferenceToNextOffer, int.MaxValue);
        }

        [TestMethod]
        public void Selection_CalculateOperationPriceDifferenceForOffers_ShouldSetDifferenceTo1()
        {
            routenumber.Add(new RouteNumber());
            routenumber[0].offers.Add(new Offer());
            routenumber[0].offers.Add(new Offer());

            routenumber[0].offers[0].OperationPrice = 1;
            routenumber[0].offers[1].OperationPrice = 2;

            selection.CalculateOperationPriceDifferenceForOffers(routenumber);

            Assert.AreEqual(routenumber[0].offers[0].DifferenceToNextOffer, 1);
        }
        
    }
}
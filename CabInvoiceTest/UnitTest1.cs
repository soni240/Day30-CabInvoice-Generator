using CabInvoice;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CabInvoiceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        /// <summary>
        /// Adding class to do tests for program
        /// </summary>
        public class Tests
        {
            /// <summary>
            /// Test1s this instance.
            /// </summary>
            [TestMethod]
            public void GivenDistanceAndTimeShouldReturnTotalFare()
            {
                //Creting Object of InvoiceGenerator
                InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
                double distance = 2.0;
                int time = 5;
                //For calculating fare
                double fare = invoiceGenerator.CalculateFare(distance, time);
                double expected = 25;
                Assert.AreEqual(expected, fare);
            }
        }
    }
    public class Tests
    {
        /// <summary>
        /// Givens the multiple rides should return invoice summary.  UC2
        /// </summary>
        [TestMethod]
        public void GivenMultipleRidesShouldReturnInvoiceSummary()
        {
            //Creating instance of invoice generator 
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            //Generating Summary for rides
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);

            //Asserting values
            Assert.AreEqual(expectedSummary, summary);
        }
    }
    public class Test
    {
        /// <summary>
        /// Givens the multiple rides should return invoice summary with average fare.  UC3
        /// </summary>
        [TestMethod]
        public void GivenMultipleRidesShouldReturnInvoiceSummarywithAverageFare()
        {
            //Creating instance of invoice generator 
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            RideRepository rideRepository = new RideRepository();
            string userId = "Dhiraj";
            rideRepository.AddRide(userId, rides);
            Ride[] rideData = rideRepository.GetRides(userId);
            //Generating Summary for rides
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0, 15);
            //Asserting values with average in equals to formula in invoice summary
            Assert.AreEqual(expectedSummary, summary);
        }
    }
}

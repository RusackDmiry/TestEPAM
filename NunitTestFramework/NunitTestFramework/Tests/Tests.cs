using NUnit.Framework;
using System;
using System.Globalization;
using System.Threading;


namespace NunitTestFramework.Tests
{
    [TestFixture]
    public class Tests
    {
        private static Steps.Steps steps = new Steps.Steps();
        private static bool ReturnNextMonth;

        private string nameFrom = "Belfast, ME";
        private string nameTo = "Lodi, CA (LOD)";
        private string nameInvalid = "aaaaaa";

        private string errorName = "Enter a valid station code or city.";
        private string errorConfirm = "COM-1923";
        private string errorEmptyData = "Please Enter Valid Date";
        private string errorAdults = "Call 1-800-USA-RAIL to make reservations for 9 to 14 people.For reservations with 15 or more, complete a Group Travel Request.";
        
        [SetUp]
        public static void Init()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            steps.InitBrowser();
            steps.InitMainPage();
            steps.OpenMainPage();
        }

        [TearDown]
        public static void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void NegativeTestInvalidStationTo()
        {
            steps.InputStation(nameFrom, nameInvalid);
            Assert.IsTrue(steps.ErrorNameTo(errorName));
        }

       

        [Test]
        public void NegativeTestInvalidStationFrom()
        {
            steps.InputStation(nameInvalid, nameTo);
            Assert.IsTrue(steps.ErrorNameFrom(errorName));
        }

        [Test]
        public void NegativeTestEmptyStationFrom()
        {
            steps.InputStation(" ", nameTo);
            steps.ClickSerch();
            Assert.IsTrue(steps.ErrorNameFrom(errorName));
        }

        [Test]
        public void NegativeTestEmptyStationTo()
        {
            steps.InputStation(nameFrom, " ");
            steps.ClickSerch();
            Assert.IsTrue(steps.ErrorNameTo(errorName));
        }

        [Test]
        public void NegativeTestEmptyStationToAndFrom()
        {
            steps.ClickSerch();
            Assert.IsTrue(steps.ErrorNameFrom(errorName) && steps.ErrorNameTo(errorName));
        }

        [Test]
        public void NegativeTestEqualsStation()
        {
            steps.InputStation(nameTo, nameTo);
            steps.ClickSerch();
            Assert.IsTrue(steps.ErrorConfirm(errorConfirm));
        }

        [Test]
        public void NegativeTestEmptyData()
        {
            steps.InputStation(nameFrom, nameTo);
            steps.ClickSerch();
            Assert.IsTrue(steps.ErrorEmptyData(errorEmptyData));
        }

        [Test]
        public void NegativeTestEmptyDataReturn()
        {
            steps.Return();
            steps.ClickSerch();
            Assert.IsTrue(steps.ErrorEmptyDataReturn(errorEmptyData));
        }

        [Test]
        public void NegativeTestInvalidStationToAndFrom()
        {
            steps.InputStation(nameInvalid, nameInvalid);
            Assert.IsTrue(steps.ErrorNameTo(errorName) && steps.ErrorNameFrom(errorName));
        }

        [Test]
        public void NegativeTestInvalidAdults()
        {
            steps.InputStation(nameInvalid, nameInvalid);
            steps.SetData(new DateTime());
            steps.AddAdults(9);
            Assert.IsTrue(steps.ErrorAdults(errorAdults));
        }
    }
}
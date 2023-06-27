using CompanyCoreLib.dll;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class AnalyticsTest
        {
            static Analytics AnalyticsClass = null;

            [ClassInitialize]
            static public void Init(TestContext tc)
            {
                AnalyticsClass = new Analytics();
            }


            [TestMethod]
            public void PopularMonths_CountTest()
            {
                List<DateTime> dates = new List<DateTime>() {
                new DateTime(2020, 11, 17),
                new DateTime(2020, 12, 17),
                new DateTime(2020, 10, 1) };

                dates = AnalyticsClass.PopularMonths(dates);


                Assert.AreEqual(dates.Count, 3);
            }

            [TestMethod]
            public void PopularMonths_ValidDataWithAdditionalSortByDate()
            {
                List<DateTime> dates = new List<DateTime>() {
                new DateTime(2020, 12, 17),
                new DateTime(2020, 12, 15),
                new DateTime(2020, 11, 17),
                new DateTime(2020, 10, 1) };

                dates = AnalyticsClass.PopularMonths(dates);

         
                Assert.AreEqual(dates.Count, 3);

                Assert.AreEqual(dates[0], new DateTime(2020, 12, 1));
            }

        }
    }
}

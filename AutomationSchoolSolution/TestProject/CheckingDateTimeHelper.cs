using ConsoleProject.Lessons.DateTimeMethods;
using NUnit.Framework;
using TestStack.BDDfy;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TestProject
{
    [Story(
        AsA = "different start dates",
        IWant = "to call method GetNumberOfDaysPassedFromStartDate",
        SoThat = "for startDate = yesterday result should be more that 0 and less than 2" +
                 "for startDate > today result should be 0")]

    [TestFixture]
    public class CheckingDateTimeHelper
    {
        private const string PastStartDate = "04 nov 2020";
        private const string FutureStartDate = "06 nov 2020";

        private const string CheckNumberOfDaysForYesterday = "CheckNumberOfDaysForYesterday";
        private double _actualResult;

        [TestCase(PastStartDate, CheckNumberOfDaysForYesterday, TestName = CheckNumberOfDaysForYesterday)]
        [TestCase(FutureStartDate, "CheckNumberOfDaysForTomorrow", TestName = "CheckNumberOfDaysForTomorrow")]
        public void CheckingGetNumberOfDaysPassedFromStartDate(string startDate, string testName)
        {
            this.When(_ => ReceivingPassesDays(startDate))
                .Then(_ => NumberOfPassedDaysShouldBeAsExpected(testName))
                .BDDfy();
        }

        [When]
        public void ReceivingPassesDays(string startDate)
        {
           _actualResult = DateTimeHelper.GetNumberOfDaysPassedFromStartDate(startDate);
        }

        [Then]
        public void NumberOfPassedDaysShouldBeAsExpected(string testName)
        {
            if (testName == "CheckNumberOfDaysForYesterday")
            {
                Assert.IsTrue( _actualResult > 0 && _actualResult < 2, "_actual result is not as expected");
            }
            else
            {
                Assert.AreEqual(0, _actualResult, "actual result is wrong");
            }
        }

    }
}

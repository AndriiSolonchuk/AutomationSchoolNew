using System;
using ConsoleProject.Lessons.DateTimeMethods;
using NUnit.Framework;
using TestStack.BDDfy;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using TestContext = NUnit.Framework.TestContext;

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
        private const string CheckNumberOfDaysForYesterday = "CheckNumberOfDaysForYesterday";
        private const string CheckNumberOfDaysForTomorrow = "CheckNumberOfDaysForTomorrow";

        private double _actualResult;
        private string _startDate;

        [SetUp]
        public void SetUp()
        {
            switch (TestContext.CurrentContext.Test.Name)
            {
                case CheckNumberOfDaysForYesterday:
                    _startDate = DateTime.Now.AddDays(-1).ToString("F");
                    break;
                case "CheckNumberOfDaysForTomorrow":
                    _startDate = DateTime.Now.AddDays(1).ToString("F");
                    break;
                default:
                    Console.WriteLine("Test name is wrong");
                    break;
            }
        }

        [TestCase(TestName = CheckNumberOfDaysForYesterday)]
        [TestCase(TestName = CheckNumberOfDaysForTomorrow)]
        public void CheckingGetNumberOfDaysPassedFromStartDate()
        {
            this.When(_ => ReceivingPassesDays(_startDate))
                .Then(_ => NumberOfPassedDaysShouldBeAsExpected())
                .BDDfy();
        }

        [When]
        public void ReceivingPassesDays(string startDate)
        {
           _actualResult = DateTimeHelper.GetNumberOfDaysPassedFromStartDate(startDate);
        }

        [Then]
        public void NumberOfPassedDaysShouldBeAsExpected()
        {
            switch (TestContext.CurrentContext.Test.Name)
            {
                case CheckNumberOfDaysForYesterday:
                    Assert.IsTrue( _actualResult > 0 && _actualResult < 2, "actual result is not as expected");
                    break;
                case CheckNumberOfDaysForTomorrow:
                    Assert.AreEqual(0, _actualResult, "actual result is wrong");
                    break;
                default:
                    Console.WriteLine("Test name is wrong");
                    break;
            }
        }
    }
}

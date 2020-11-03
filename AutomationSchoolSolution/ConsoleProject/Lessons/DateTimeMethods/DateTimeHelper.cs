using System;

namespace ConsoleProject.Lessons.DateTimeMethods
{
    public class DateTimeHelper
    {
        public static double GetNumberOfDaysPassedFromStartDate(string startDate)
        {
            DateTime today = DateTime.Now;
            DateTime startDateTime = DateTime.Parse(startDate);
            TimeSpan subtractionResult = today - startDateTime;
            return subtractionResult.TotalDays;
        }
    }
}

using System;

namespace ConsoleProject.Lessons.DateTimeMethods
{
    public class DateTimeHelper
    {
        public static double GetNumberOfDaysPassedFromStartDate(string startDate)
        {
            var now = DateTime.Now;
            var startDateTime = DateTime.Parse(startDate);

            if (startDateTime > now)
            {
                return 0;
            }

            var subtractionResult = now - startDateTime;
            return subtractionResult.TotalDays;
        }
    }
}

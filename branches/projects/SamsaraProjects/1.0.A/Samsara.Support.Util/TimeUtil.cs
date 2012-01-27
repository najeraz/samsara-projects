
using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using System.Linq;

namespace Samsara.Support.Util
{
    public class TimeUtil
    {
        public enum Months
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

        private static string januaryName = "Enero";
        private static string februaryName = "Febrero";
        private static string marchName = "Marzo";
        private static string aprilName = "Abril";
        private static string mayName = "Mayo";
        private static string juneName = "Junio";
        private static string julyName = "Julio";
        private static string augustName = "Agosto";
        private static string septemberName = "Septiembre";
        private static string octoberName = "Octubre";
        private static string novemberName = "Noviembre";
        private static string decemberName = "Diciembre";

        public static string MonthName(Months month)
        {
            string monthName = null;

            switch (month)
            {
                case Months.January:
                    return januaryName;
                case Months.February:
                    return februaryName;
                case Months.March:
                    return marchName;
                case Months.April:
                    return aprilName;
                case Months.May:
                    return mayName;
                case Months.June:
                    return juneName;
                case Months.July:
                    return julyName;
                case Months.August:
                    return augustName;
                case Months.September:
                    return septemberName;
                case Months.October:
                    return octoberName;
                case Months.November:
                    return novemberName;
                case Months.December:
                    return decemberName;
                default:
                    break;
            }

            return monthName;
        }

        public static IList<Months> GetMonthsRange(DateTime startTime, DateTime endTime)
        {
            IList<Months> monthsRange = new List<Months>();

            int monthsInterval = Convert.ToInt32(DateAndTime.DateDiff(DateInterval.Month, startTime, endTime));

            if (monthsInterval > 0)
            {
                foreach (int monthIndex in Enumerable.Range(0, monthsInterval))
                {
                    monthsRange.Add((Months)((monthIndex + startTime.Month) % 12 + 1));
                }
            }

            return monthsRange;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

namespace Samsara.Support.Util
{
    public class TimeUtil
    {
        public enum MonthEnum
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

        public class Month
        {
            public int Index
            {
                get;
                set;
            }

            public string Name
            {
                get;
                set;
            }
        }


        private static IList<Month> months;

        public static IList<Month> Months
        {
            get
            {
                if (months == null)
                {
                    months = new List<Month>();

                    foreach (int monthIndex in Enumerable.Range(1, 12))
                    {
                        Month month = new Month() { Index = monthIndex, Name = MonthName((MonthEnum)monthIndex) };

                        months.Add(month);
                    }
                }

                return new List<Month>(months);
            }
        }

        public static string MonthName(MonthEnum month)
        {
            string monthName = null;

            switch (month)
            {
                case MonthEnum.January:
                    return januaryName;
                case MonthEnum.February:
                    return februaryName;
                case MonthEnum.March:
                    return marchName;
                case MonthEnum.April:
                    return aprilName;
                case MonthEnum.May:
                    return mayName;
                case MonthEnum.June:
                    return juneName;
                case MonthEnum.July:
                    return julyName;
                case MonthEnum.August:
                    return augustName;
                case MonthEnum.September:
                    return septemberName;
                case MonthEnum.October:
                    return octoberName;
                case MonthEnum.November:
                    return novemberName;
                case MonthEnum.December:
                    return decemberName;
                default:
                    break;
            }

            return monthName;
        }

        public static IList<MonthEnum> GetMonthsRange(DateTime startTime, DateTime endTime)
        {
            IList<MonthEnum> monthsRange = new List<MonthEnum>();

            int monthsInterval = Convert.ToInt32(DateAndTime.DateDiff(DateInterval.Month, startTime, endTime));

            if (monthsInterval > 0)
            {
                foreach (int monthIndex in Enumerable.Range(0, monthsInterval))
                {
                    monthsRange.Add((MonthEnum)((monthIndex + startTime.Month - 1) % 12 + 1));
                }
            }
            else
            {
                monthsRange.Add((MonthEnum)startTime.Month);
            }

            return monthsRange;
        }
    }
}

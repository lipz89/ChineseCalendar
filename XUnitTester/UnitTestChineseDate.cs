using ChineseCalendar;
using System;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTester
{
    public class UnitTestChineseDate
    {
        private readonly ITestOutputHelper Console;

        public UnitTestChineseDate(ITestOutputHelper tempOutput)
        {
            this.Console = tempOutput;
        }
        [Fact]
        public void Test()
        {
            var date = DateTime.Today;
            Console.WriteLine(date.ToShortDateString());
            var cdate = ChineseDate.From(date);
            Console.WriteLine(cdate.ToString());
            Console.WriteLine("日历名称：" + cdate.CalendarName);
            Console.WriteLine("天干：" + cdate.CelestialStem);
            Console.WriteLine("地支：" + cdate.TerrestrialBranch);
            Console.WriteLine("干支：" + cdate.ChineseEra);
            Console.WriteLine("生肖：" + cdate.AnimalSign);
            Console.WriteLine("年份：" + cdate.YearString);
            Console.WriteLine("月份：" + cdate.MonthString);
            Console.WriteLine("月：" + cdate.Month);
            Console.WriteLine("月序号：" + cdate.MonthIndex);
            Console.WriteLine("当年总月份数：" + cdate.MonthsInYear);
            Console.WriteLine("农历日：" + cdate.DayString);
            Console.WriteLine("日：" + cdate.Day);
            Console.WriteLine("当年总天数：" + cdate.DayInYear);
            Console.WriteLine("当月总天数：" + cdate.DayInMonth);
            Console.WriteLine("星期：" + cdate.DayOfWeek);
            Console.WriteLine("当年第几天：" + cdate.DayOfYear);
            Console.WriteLine("是否闰年：" + cdate.IsLeapMonth);
            Console.WriteLine("当年的闰月份：" + cdate.LeapMonthOfYear);
        }
        [Fact]
        public void Test2()
        {
            for(int i = 1; i <= 12; i++)
            {
                var cdate = ChineseDate.From(2020, i, 1);
                Console.WriteLine(cdate.ToString());
                var cdate2 = ChineseDate.From(2020, i, -1);
                Console.WriteLine(cdate2.ToString());
            }
            for(int i = 1; i <= 13; i++)
            {
                var cdate = ChineseDate.FromIndex(2020, i, 1);
                Console.WriteLine(cdate.ToString());
                var cdate2 = ChineseDate.FromIndex(2020, i, -1);
                Console.WriteLine(cdate2.ToString());
            }
        }

        [Fact]
        public void FromDate()
        {
            var date = DateTime.Today;
            Console.WriteLine(date.ToShortDateString());
            var cdate = ChineseDate.From(date);
            Console.WriteLine(cdate.ToString());
            var date2 = cdate.ToDate();
            var date3 = cdate.ToDate();
            Console.WriteLine(date2.ToShortDateString());
            Assert.Equal(date, date2);
            for(int i = 0; i < 100; i++)
            {
                date = date.AddDays(97);
                date3 = cdate.AddDays(97).ToDate();
                cdate = ChineseDate.From(date);
                date2 = cdate.ToDate();
                Assert.Equal(date, date2);
                Assert.Equal(date, date3);
            }
            date = DateTime.Today;
            cdate = ChineseDate.From(date);
            for(int i = 0; i < 100; i++)
            {
                date = date.AddDays(-73);
                date3 = cdate.AddDays(-73).ToDate();
                cdate = ChineseDate.From(date);
                date2 = cdate.ToDate();
                Assert.Equal(date, date2);
                Assert.Equal(date, date3);
            }
        }
        [Fact]
        public void FromYearMonthDay()
        {
            var year = 1901;
            var cdate = ChineseDate.From(year, 1, 1);
            while(year < 2100)
            {
                year += 1;
                var cd2 = ChineseDate.From(year, 1, 1);
                cdate = cdate.AddYears(1);
                Console.WriteLine(cdate.ToString());
                Assert.Equal(cd2, cdate);

                var cd3 = ChineseDate.From(year, -1, -1);
                Console.WriteLine(cd3.ToString());
                Assert.True(cd3.MonthIndex == cd3.MonthsInYear);
                Assert.True(cd3.Day == cd3.DayInMonth);
                var cd4 = ChineseDate.FromIndex(cd3.Year, cd3.MonthIndex, cd3.Day);
                Assert.Equal(cd3, cd4);
            }
        }
    }
}

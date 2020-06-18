using ChineseCalendar;
using System;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTester
{
    public class UnitTestChineseDate
    {
        private readonly ITestOutputHelper Output;

        public UnitTestChineseDate(ITestOutputHelper tempOutput)
        {
            this.Output = tempOutput;
        }
        [Fact]
        public void Test()
        {
            var date = DateTime.Today;
            Output.WriteLine(date.ToShortDateString());
            var cdate = ChineseDate.From(date);
            Output.WriteLine(cdate.ToString());
            Output.WriteLine("�������ƣ�" + cdate.CalendarName);
            Output.WriteLine("��ɣ�" + cdate.CelestialStem);
            Output.WriteLine("��֧��" + cdate.TerrestrialBranch);
            Output.WriteLine("��֧��" + cdate.ChineseEra);
            Output.WriteLine("��Ф��" + cdate.AnimalSign);
            Output.WriteLine("��ݣ�" + cdate.YearString);
            Output.WriteLine("�·ݣ�" + cdate.MonthString);
            Output.WriteLine("�£�" + cdate.Month);
            Output.WriteLine("����ţ�" + cdate.MonthIndex);
            Output.WriteLine("�������·�����" + cdate.MonthsInYear);
            Output.WriteLine("ũ���գ�" + cdate.DayString);
            Output.WriteLine("�գ�" + cdate.Day);
            Output.WriteLine("������������" + cdate.DayInYear);
            Output.WriteLine("������������" + cdate.DayInMonth);
            Output.WriteLine("���ڣ�" + cdate.DayOfWeek);
            Output.WriteLine("����ڼ��죺" + cdate.DayOfYear);
            Output.WriteLine("�Ƿ����꣺" + cdate.IsLeapMonth);
            Output.WriteLine("��������·ݣ�" + cdate.LeapMonthOfYear);
        }
        [Fact]
        public void FromDate()
        {
            var date = DateTime.Today;
            Output.WriteLine(date.ToShortDateString());
            var cdate = ChineseDate.From(date);
            Output.WriteLine(cdate.ToString());
            var date2 = cdate.ToDate();
            var date3 = cdate.ToDate();
            Output.WriteLine(date2.ToShortDateString());
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
                Output.WriteLine(cdate.ToString());
                Assert.Equal(cd2, cdate);

                var cd3 = ChineseDate.From(year, -1, -1);
                Output.WriteLine(cd3.ToString());
                Assert.True(cd3.MonthIndex == cd3.MonthsInYear);
                Assert.True(cd3.Day == cd3.DayInMonth);
                var cd4 = ChineseDate.FromIndex(cd3.Year, cd3.MonthIndex, cd3.Day);
                Assert.Equal(cd3, cd4);
            }
        }
    }
}

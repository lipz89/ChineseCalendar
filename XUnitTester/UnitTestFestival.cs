using ChineseCalendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTester
{
    public class UnitTestFestival
    {
        private readonly ITestOutputHelper Output;

        public UnitTestFestival(ITestOutputHelper tempOutput)
        {
            this.Output = tempOutput;
        }
        [Fact]
        public void Test()
        {
            var type = typeof(Festival);
            var ass = type.Assembly;
            var types = ass.GetTypes().Where(x => x.IsClass && !x.IsAbstract && x.IsSubclassOf(type)).ToList();

            var festivals = new List<Festival>();
            foreach(var item in types)
            {
                var ps = item.GetFields(BindingFlags.Static | BindingFlags.Public).Where(x => x.FieldType.IsSubclassOf(type));
                var vals = ps.Select(x => x.GetValue(null)).OfType<Festival>();
                if(vals.Any())
                {
                    festivals.AddRange(vals);
                }
            }


            var festivals2 = new List<Festival>
            {
                ChineseFestival.DoubleNinthFestival,
                ChineseFestival.DragonBoatFestival,
                ChineseFestival.DragonHeadraisingDay,
                ChineseFestival.GhostFestival,
                ChineseFestival.LanternFestival,
                ChineseFestival.MidAutumnFestival,
                ChineseFestival.NewYearsEve,
                ChineseFestival.QixiFestival,
                ChineseFestival.SpringFestival,
                GregorianFestival.ArborDay,
                GregorianFestival.InternationalWorkersDay,
                GregorianFestival.NewYearsDay,
                GregorianFestival.TheNationalDay,
                GregorianFestival.TheTombWeepingDay
            };

            Assert.Equal(festivals.Count(), festivals2.Count());

            Assert.All<Festival>(festivals, item =>
            {
                Output.WriteLine(item.Name + " -- " + item.Description);
                Output.WriteLine($"{ item.FirstYear}-{ item.Month}-{ item.Day}");
                var last = item.GetLastDate(DateTime.Today, false);
                Output.WriteLine($"上一个{ item.Name} 在 {last:yyyy-MM-dd}");
                var next = item.GetNextDate(DateTime.Today, true);
                Output.WriteLine($"下一个{ item.Name} 在 {next:yyyy-MM-dd}");
            });
        }


        [Fact]
        public void TestFixFestival()
        {
            var fes = new FixDateFestival("大阅兵", 2015, 9, 3, "抗战暨反法西斯胜利70周年大阅兵");
            Output.WriteLine(fes.Name + " -- " + fes.Description);
            Output.WriteLine($"{ fes.FirstYear}-{ fes.Month}-{ fes.Day}");
            var last = fes.GetLastDate(DateTime.Today, false);
            Output.WriteLine($"上一个{ fes.Name} 在 {last:yyyy-MM-dd}");
            var next = fes.GetNextDate(DateTime.Today, true);
            Output.WriteLine($"下一个{ fes.Name} 在 {next:yyyy-MM-dd}");
        }

        [Fact]
        public void TestBirthday()
        {
            var fes = new GregorianFestival("李君妍生日", 5, 12, 2017);
            Output.WriteLine(fes.Name + " -- " + fes.Description);
            Output.WriteLine($"{ fes.FirstYear}-{ fes.Month}-{ fes.Day}");
            DateTime? date = DateTime.Today;
            while(true)
            {
                date = fes.GetLastDate(date, false);
                if(!date.HasValue)
                {
                    break;
                }
                Output.WriteLine($"上一个{ fes.Name} 在 {date:yyyy-MM-dd}");
            }
            date = DateTime.Today;
            while(true)
            {
                date = fes.GetNextDate(date, false);
                if(!date.HasValue || date.Value.Year > 2050)
                {
                    break;
                }
                Output.WriteLine($"下一个{ fes.Name} 在 {date:yyyy-MM-dd}");
            }
        }
    }
}

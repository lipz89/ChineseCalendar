# ChineseCalendar
农历日期和公历农历节假日

### ChineseDate 农历日期

```cs
var cdate = ChineseDate.From(DateTime.Today);
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
```
```
庚子[鼠]年闰四月廿七
日历名称：农历
天干：庚
地支：子
干支：庚子
生肖：鼠
年份：二〇二〇
月份：闰四
月：4
月序号：5
当年总月份数：13
农历日：廿七
日：27
当年总天数：384
当月总天数：29
星期：Thursday
当年第几天：146
是否闰年：True
当年的闰月份：4
```

```cs
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
```

```
庚子[鼠]年正月初一
庚子[鼠]年正月廿九
庚子[鼠]年二月初一
庚子[鼠]年二月三十
庚子[鼠]年三月初一
庚子[鼠]年三月三十
庚子[鼠]年四月初一
庚子[鼠]年四月三十
庚子[鼠]年五月初一
庚子[鼠]年五月三十
庚子[鼠]年六月初一
庚子[鼠]年六月廿九
庚子[鼠]年七月初一
庚子[鼠]年七月廿九
庚子[鼠]年八月初一
庚子[鼠]年八月三十
庚子[鼠]年九月初一
庚子[鼠]年九月廿九
庚子[鼠]年十月初一
庚子[鼠]年十月三十
庚子[鼠]年冬月初一
庚子[鼠]年冬月廿九
庚子[鼠]年腊月初一
庚子[鼠]年腊月三十
庚子[鼠]年正月初一
庚子[鼠]年正月廿九
庚子[鼠]年二月初一
庚子[鼠]年二月三十
庚子[鼠]年三月初一
庚子[鼠]年三月三十
庚子[鼠]年四月初一
庚子[鼠]年四月三十
庚子[鼠]年闰四月初一
庚子[鼠]年闰四月廿九
庚子[鼠]年五月初一
庚子[鼠]年五月三十
庚子[鼠]年六月初一
庚子[鼠]年六月廿九
庚子[鼠]年七月初一
庚子[鼠]年七月廿九
庚子[鼠]年八月初一
庚子[鼠]年八月三十
庚子[鼠]年九月初一
庚子[鼠]年九月廿九
庚子[鼠]年十月初一
庚子[鼠]年十月三十
庚子[鼠]年冬月初一
庚子[鼠]年冬月廿九
庚子[鼠]年腊月初一
庚子[鼠]年腊月三十
```



### Festival 节假日

```
Festival  节假日基类
  -- FixDateFestival	固定日期节假日
  -- LoopFestival		循环节假日
  	 -- GregorianFestival	公历节假日
  	 -- ChineseFestival		农历节假日
```

```cs
// 预定义节假日
 var festivals = new List<Festival>
 {
    ChineseFestival.SpringFestival,				// 春节
    ChineseFestival.LanternFestival,			//元宵节
    ChineseFestival.DragonHeadraisingDay,		//龙抬头
    ChineseFestival.DragonBoatFestival,			//端午
    ChineseFestival.QixiFestival,				//七夕
    ChineseFestival.GhostFestival,				//中元节
    ChineseFestival.MidAutumnFestival,			//中秋
    ChineseFestival.DoubleNinthFestival,		//重阳节
    ChineseFestival.NewYearsEve,				//除夕

    GregorianFestival.NewYearsDay,				//元旦
    GregorianFestival.ArborDay,					//植树节
    GregorianFestival.TheTombWeepingDay,		//清明节
    GregorianFestival.InternationalWorkersDay,	//劳动节
    GregorianFestival.TheNationalDay,			//国庆节
};
Assert.All<Festival>(festivals, item =>
{
    Output.WriteLine(item.Name + " -- " + item.Description);
    var last = item.GetLastDate(DateTime.Today, false);
    Output.WriteLine($"上一个{ item.Name} 在 {last:yyyy-MM-dd}");
    var next = item.GetNextDate(DateTime.Today, true);
    Output.WriteLine($"下一个{ item.Name} 在 {next:yyyy-MM-dd}");
});
```

```
春节 -- 正月初一
上一个春节 在 2020-01-25
下一个春节 在 2021-02-12
元宵节 -- 正月十五
上一个元宵节 在 2020-02-08
下一个元宵节 在 2021-02-26
龙抬头 -- 二月初二
上一个龙抬头 在 2020-02-24
下一个龙抬头 在 2021-03-14
端午 -- 五月初五
上一个端午 在 2019-06-07
下一个端午 在 2020-06-25
七夕 -- 七月初七
上一个七夕 在 2019-08-07
下一个七夕 在 2020-08-25
中元节 -- 七月十五
上一个中元节 在 2019-08-15
下一个中元节 在 2020-09-02
中秋 -- 八月十五
上一个中秋 在 2019-09-13
下一个中秋 在 2020-10-01
重阳节 -- 九月初九
上一个重阳节 在 2019-10-07
下一个重阳节 在 2020-10-25
除夕 -- 大年三十
上一个除夕 在 2020-01-24
下一个除夕 在 2021-02-11
元旦 -- 1月1日
上一个元旦 在 2020-01-01
下一个元旦 在 2021-01-01
植树节 -- 3月12日
上一个植树节 在 2020-03-12
下一个植树节 在 2021-03-12
清明 -- 4月5日
上一个清明 在 2020-04-05
下一个清明 在 2021-04-05
劳动节 -- 5月1日
上一个劳动节 在 2020-05-01
下一个劳动节 在 2021-05-01
国庆节 -- 10月1日
上一个国庆节 在 2019-10-01
下一个国庆节 在 2020-10-01
```

#### 固定节假日

```cs
        public void TestFixFestival()
        {
            var fes = new FixDateFestival("大阅兵", 2015, 9, 3, "抗战暨反法西斯胜利70周年大阅兵");
            Output.WriteLine(fes.Name + " -- " + fes.Description);
            var last = fes.GetLastDate(DateTime.Today, false);
            Output.WriteLine($"上一个{ fes.Name} 在 {last:yyyy-MM-dd}");
            var next = fes.GetNextDate(DateTime.Today, true);
            Output.WriteLine($"下一个{ fes.Name} 在 {next:yyyy-MM-dd}");
        }
```

```
大阅兵 -- 抗战暨反法西斯胜利70周年大阅兵
上一个大阅兵 在 2015-09-03
下一个大阅兵 在
```

#### 生日

```cs
        public void TestBirthday()
        {
            var fes = new GregorianFestival("李五月生日", 5, 17, 2017);
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
```

```
李五月生日 -- 
2017-5-17
上一个李五月生日 在 2020-05-17
上一个李五月生日 在 2019-05-17
上一个李五月生日 在 2018-05-17
上一个李五月生日 在 2017-05-17
下一个李五月生日 在 2021-05-17
下一个李五月生日 在 2022-05-17
.....
下一个李五月生日 在 2050-05-17
```


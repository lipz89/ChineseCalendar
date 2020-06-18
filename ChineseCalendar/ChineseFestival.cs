﻿using System;

namespace ChineseCalendar
{

    /// <summary>
    /// 农历节假日
    /// </summary>
    public class ChineseFestival : LoopFestival
    {
        private ChineseFestival() { }
        public ChineseFestival(string name, int month, int day, int firstYear = 0, string description = null)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            if(month == 0 || month > 12 || month < -12)
            {
                throw new ArgumentOutOfRangeException(nameof(month), "[-12,-1],[1,12]", "月份超出范围");
            }
            if(day == 0 || day > 30 || day < -30)
            {
                throw new ArgumentOutOfRangeException(nameof(day), "[-30,-1],[1,30]", "日期超出范围");
            }
            this.Name = name;
            this.Month = month;
            this.Day = day;
            this.FirstYear = firstYear;
            this.Description = description;
        }
        /// <summary>
        /// 春节
        /// </summary>
        public static readonly ChineseFestival SpringFestival = new ChineseFestival
        {
            Name = "春节",
            Description = "正月初一",
            Month = 1,
            Day = 1,
        };
        /// <summary> 元宵节 </summary>
        public static readonly ChineseFestival LanternFestival = new ChineseFestival
        {
            Name = "元宵节",
            Description = "正月十五",
            Month = 1,
            Day = 15,
        };
        /// <summary> 龙抬头 </summary>
        public static readonly ChineseFestival DragonHeadraisingDay = new ChineseFestival
        {
            Name = "龙抬头",
            Description = "二月初二",
            Month = 2,
            Day = 2,
        };
        /// <summary> 端午 </summary>
        public static readonly ChineseFestival DragonBoatFestival = new ChineseFestival
        {
            Name = "端午",
            Description = "五月初五",
            Month = 5,
            Day = 5,
        };
        /// <summary> 七夕 </summary>
        public static readonly ChineseFestival QixiFestival = new ChineseFestival
        {
            Name = "七夕",
            Description = "七月初七",
            Month = 7,
            Day = 7,
        };
        /// <summary> 中元节 </summary>
        public static readonly ChineseFestival GhostFestival = new ChineseFestival
        {
            Name = "中元节",
            Description = "七月十五",
            Month = 7,
            Day = 15,
        };
        /// <summary> 中秋 </summary>
        public static readonly ChineseFestival MidAutumnFestival = new ChineseFestival
        {
            Name = "中秋",
            Description = "八月十五",
            Month = 8,
            Day = 15,
        };
        /// <summary> 重阳节 </summary>
        public static readonly ChineseFestival DoubleNinthFestival = new ChineseFestival
        {
            Name = "重阳节",
            Description = "九月初九",
            Month = 9,
            Day = 9,
        };
        /// <summary> 除夕 </summary>
        public static readonly ChineseFestival NewYearsEve = new ChineseFestival
        {
            Name = "除夕",
            Description = "大年三十",
            Month = -1,
            Day = -1,
        };

        protected override bool TryGetDate(int year, int month, int day, out DateTime date)
        {
            try
            {
                date = ChineseDate.From(year, month, day).ToDate();
                return true;
            }
            catch(Exception)
            {
                date = DateTime.Now;
                return false;
            }
        }
        public override bool IsThisFestival(DateTime date)
        {
            var cdate = ChineseDate.From(date);
            var festival = ChineseDate.From(cdate.Year, Month, Day);
            return cdate == festival;
        }
    }
}

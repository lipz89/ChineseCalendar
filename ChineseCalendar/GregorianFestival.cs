﻿using System;
using System.Collections.Generic;

namespace ChineseCalendar
{
    /// <summary>
    /// 公历节假日
    /// </summary>
    public class GregorianFestival : LoopFestival
    {
        private GregorianFestival() { }

        private static readonly Dictionary<int, int> monthDays = new Dictionary<int, int> {
            { 1,31},{ 2,29},{ 3,31},{ 4,30},{ 5,31},{ 6,30},{ 7,31},{ 8,31},{ 9,30},{ 10,31},{ 11,30},{ 12,31},
        };
        public GregorianFestival(string name, int month, int day, int firstYear = 0, string description = null)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            if(month < 1 || month > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(month), "[1,12]", "月份超出范围");
            }
            var maxDays = monthDays[month];
            if(day < 1 || day > maxDays)
            {
                throw new ArgumentOutOfRangeException(nameof(day), $"[1,{maxDays}]", "日期超出范围");
            }

            this.Name = name;
            this.Month = month;
            this.Day = day;
            this.FirstYear = firstYear;
            this.Description = description;
        }
        /// <summary> 元旦 </summary>
        public static readonly GregorianFestival NewYearsDay = new GregorianFestival
        {
            Name = "元旦",
            Description = "1月1日",
            Month = 1,
            Day = 1,
        };
        /// <summary> 植树节 </summary>
        public static readonly GregorianFestival ArborDay = new GregorianFestival
        {
            Name = "植树节",
            Description = "3月12日",
            Month = 3,
            Day = 12,
            FirstYear= 1979
        };
        /// <summary> 清明 </summary>
        public static readonly GregorianFestival TheTombWeepingDay = new GregorianFestival
        {
            Name = "清明",
            Description = "4月5日",
            Month = 4,
            Day = 5,
        };
        /// <summary> 劳动节 </summary>
        public static readonly GregorianFestival InternationalWorkersDay = new GregorianFestival
        {
            Name = "劳动节",
            Description = "5月1日",
            Month = 5,
            Day = 1,
            FirstYear= 1890
        };
        /// <summary> 国庆节 </summary>
        public static readonly GregorianFestival TheNationalDay = new GregorianFestival
        {
            Name = "国庆节",
            Description = "10月1日",
            Month = 10,
            Day = 1,
            FirstYear = 1949
        };

        public override bool IsThisFestival(DateTime date)
        {
            return date.Month == this.Month && date.Day == this.Day;
        }
    }
}
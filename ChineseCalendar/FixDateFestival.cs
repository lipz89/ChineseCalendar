using System;

namespace ChineseCalendar
{
    /// <summary>
    /// 固定日期节假日
    /// </summary>
    public class FixDateFestival : Festival
    {
        /// <summary>
        /// 年份
        /// </summary>
        public int Year { get; private set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date { get; private set; }
        public FixDateFestival(string name, int year, int month, int day, string description = null)
        {
            try
            {
                this.Name = name;
                this.Year = year;
                this.Month = month;
                this.Day = day;
                this.Description = description;
                this.Date = new DateTime(year, month, day);
            }
            catch(Exception ex)
            {
                throw new ArgumentOutOfRangeException("日期参数不正确", ex);
            }
        }

        public override DateTime? GetLastDate(DateTime? date, bool containsThisDate = false)
        {
            DateTime date2 = date.HasValue ? date.Value.Date : DateTime.Today;
            if(containsThisDate && IsThisFestival(date2))
            {
                return date2;
            }
            if(this.Date < date2)
            {
                return this.Date;
            }
            return null;
        }

        public override DateTime? GetNextDate(DateTime? date, bool containsThisDate = false)
        {
            DateTime date2 = date.HasValue ? date.Value.Date : DateTime.Today;
            if(containsThisDate && IsThisFestival(date2))
            {
                return date2;
            }
            if(this.Date > date2)
            {
                return this.Date;
            }
            return null;
        }
        public override bool IsThisFestival(DateTime date)
        {
            return date.Date == Date.Date;
        }
    }
}

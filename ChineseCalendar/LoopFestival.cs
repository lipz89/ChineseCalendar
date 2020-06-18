using System;

namespace ChineseCalendar
{
    /// <summary>
    /// 循环节假日
    /// </summary>
    public abstract class LoopFestival : Festival
    {
        protected virtual bool TryGetDate(int year, int month, int day, out DateTime date)
        {
            try
            {
                date = new DateTime(year, month, day);
                return true;
            }
            catch(Exception)
            {
                date = DateTime.Now;
                return false;
            }
        }

        public override DateTime? GetLastDate(DateTime? date, bool containsThisDate = false)
        {
            DateTime date2 = date.HasValue ? date.Value.Date : DateTime.Today;
            if(containsThisDate && IsThisFestival(date2))
            {
                return date2;
            }
            if(TryGetDate(date2.Year, Month, Day, out DateTime date3) && date3 < date2)
            {
                return date3;
            }
            var year = date2.Year - 1;
            while(year >= DateTime.MinValue.Year && year >= FirstYear)
            {
                if(TryGetDate(year, Month, Day, out DateTime date4))
                {
                    return date4;
                }
                year--;
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
            if(TryGetDate(date2.Year, Month, Day, out DateTime date3) && date3 > date2)
            {
                return date3;
            }
            var year = date2.Year + 1;
            while(year <= DateTime.MaxValue.Year)
            {
                if(TryGetDate(year, Month, Day, out DateTime date4))
                {
                    return date4;
                }
                year++;
            }
            return null;
        }

        public override bool IsThisFestival(DateTime date)
        {
            return date.Month == this.Month && date.Day == this.Day;
        }
    }
}

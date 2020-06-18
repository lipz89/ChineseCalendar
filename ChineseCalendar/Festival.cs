using System;

namespace ChineseCalendar
{
    /// <summary>
    /// 节日
    /// </summary>
    public abstract class Festival
    {
        /// <summary> 节日名称 </summary>
        public string Name { get; protected set; }
        /// <summary> 描述 </summary>
        public string Description { get; protected set; }
        /// <summary> 节日设立年份 </summary>
        public int FirstYear { get; protected set; }
        /// <summary> 月份 </summary>
        public int Month { get; protected set; }
        /// <summary> 日期 </summary>
        public int Day { get; protected set; }
        /// <summary>
        /// 获取指定日期前一个节日
        /// </summary>
        /// <param name="date">指定日期</param>
        /// <param name="containsThisDate">是否包含指定日期</param>
        /// <returns></returns>
        public abstract DateTime? GetLastDate(DateTime? date = null, bool containsThisDate = false);
        /// <summary>
        /// 获取指定日期后一个节日
        /// </summary>
        /// <param name="date">指定日期</param>
        /// <param name="containsThisDate">是否包含指定日期</param>
        /// <returns></returns>
        public abstract DateTime? GetNextDate(DateTime? date = null, bool containsThisDate = false);
        /// <summary>
        /// 判断指定日期是否本节日
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public abstract bool IsThisFestival(DateTime date);
        public override string ToString()
        {
            return this.Name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiHomeMoney.Coomon
{
    public class Util
    {
        public static int getLastDay(int Month)
        {
            if(Month <= 0 | Month > 12)
            {
                return 0;
            }
            else if(Month == 1 | Month == 3 | Month == 5 | Month == 7 | Month == 8 | Month == 10 | Month == 12)
            {
                return 31;
            }
            else if(Month == 4 | Month == 6 | Month == 9 | Month == 11)
            {
                return 30;
            }
            else
            {
                return 28;
            }
        }

        public static DateTime BrasilDate()
        {
            return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
        }
    }
}

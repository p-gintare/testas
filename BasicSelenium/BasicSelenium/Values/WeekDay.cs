using System;
using System.Collections.Generic;
using System.Text;

namespace BasicSelenium.Values
{
    public class WeekDay
    {
        public static WeekDay MONDAY = new WeekDay("Monday");
        public static WeekDay TUESDAY = new WeekDay("Tuesday");


        public string day;

        public WeekDay(string day)
        {
            this.day = day;
        }
    }
}

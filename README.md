# C-Get-number-of-weeks-in-a-year
<p>Code reuse</p>

<p>get number of weeks the beginning of this year to now</p>
<code>
       public static int LayTuanTrongNam(DateTime time)
        {
            CultureInfo myCI = CultureInfo.CurrentCulture;
            Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
            // so tuan hien tai
            return myCal.GetWeekOfYear(time, myCWR, myFirstDOW);
        }
  </code>

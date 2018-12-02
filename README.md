# C-Get-number-of-weeks-in-a-year
<p>Code reuse</p>

<p>[Get number of weeks the beginning of this year to now]</p>
<p>First you need to use this</p> 
<pre>using System.Globalization;</pre>
<p>Function:</p>
<pre>
       public static int LayTuanTrongNam(DateTime time)
        {
            CultureInfo myCI = CultureInfo.CurrentCulture;
            Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
            return myCal.GetWeekOfYear(time, myCWR, myFirstDOW);
        }
  </pre>

<p> How to use: </p> 
<pre>
       int getNumberOfWeeksInYear = LayTuanTrongNam(DateTime.Now); // example today is 2/12/2018 then the result is 49
       getNumberOfWeeksInYear--;// so if you want accurate you need to minus 1
</pre>

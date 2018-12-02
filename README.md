# C-Get-number-of-weeks-in-a-year
<p>Code reuse</p>

<p>get number of weeks the beginning of this year to now</p>
<p>First you need to use this</p> 
<pre>using System.Globalization;</pre>
<p>function:</p>
<pre>
       public static int LayTuanTrongNam(DateTime time)
        {
            CultureInfo myCI = CultureInfo.CurrentCulture;
            Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
            // so tuan hien tai
            return myCal.GetWeekOfYear(time, myCWR, myFirstDOW);
        }
  </pre>

<p> How to use: </p> 
<pre>
       int getNumberOfWeeksInYear = LayTuanTrongNam(DateTime.Now); // example today is 2/12/2018 then the result is 49
</pre>

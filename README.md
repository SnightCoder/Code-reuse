# Code Reuse

<h2>I.Get number of weeks from the beginning of this year to now</h2>
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
       int getNumberOfWeeksInYear = LayTuanTrongNam(DateTime.Now);
       // example today is 2/12/2018 then the result is 49
       
       getNumberOfWeeksInYear--;
       // if you want accurate you need to minus 1
       
       int getNumberOfWeeksInMonth = LayTuanTrongNam(new DateTime(DateTime.Now.Year, 1, DateTime.Now.Day));
       // set month to 1 if you want to get number of weeks in this month

</pre>

<h2>II. Fix injection mysql php</h2>
<pre>
        public static String fixInjection(String s)
        {
            // for php $_GET method
            s = s.Replace("&", "%26");
            s = s.Replace("\\", "\\\\");
            
            // for prevent injection query
            s = s.Trim().Replace("'", "''");
            
            return s;
        }
        public static String fixLink(String s)
        {
            s = s.Replace(" ", "%20");
            return s;
        }
</pre>

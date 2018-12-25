# Code Reuse c#

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
</pre>   
<pre>
       getNumberOfWeeksInYear--;
       // if you want accurate you need to minus 1
      </pre> 
      <pre>
       int getNumberOfWeeksInMonth = LayTuanTrongNam(new DateTime(DateTime.Now.Year, 1, DateTime.Now.Day));
       // set month to 1 if you want to get number of weeks in this month

</pre>

<h2>II. Fix injection mysql php</h2>
<p>Function:</p>
<pre>
        public static String fixInjection(String s)
        {
            // for php $_GET method
            s = s.Replace("&", "%26");
            s = s.Replace("\\", "\\\\");
            // for prevent from injection query
            s = s.Trim().Replace("'", "''");
            return s;
        }
</pre>
<p>Example</p>
     <pre>  String name = fixInjection(@"/ 'Hello Nam & You' \");
     /* the result is:  
     / ''Hello Nam %26 You'' \\
     */
     </pre>
# Code Reuse JavaScript
<p>
show html string on website:</p>
<pre>"&lt;pre&gt;"+s.replace(/&lt;/g,"&lt;")+"&lt;pre&gt;";<pre></pre></pre>

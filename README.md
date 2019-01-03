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
  <h2>III. Algorithm for simplifying decimal to fractions</h2>
<p>Function:</p>   
<pre>
            public static String SimplifyingFraction(double n,double d)
        {
            double num = n / d;
            String s = DoubleToFraction(num);
            return s;
        }

        public static string DoubleToFraction(double num, double epsilon = 0.0001, int maxIterations =20)
        {
            double[] d = new double[maxIterations + 2];
            d[1] = 1;
            double z = num;
            double n = 1;
            int t = 1;

            int wholeNumberPart = (int)num;
            double decimalNumberPart = num - Convert.ToDouble(wholeNumberPart);

            while (t < maxIterations && Math.Abs(n / d[t] - num) > epsilon)
            {
                t++;
                z = 1 / (z - (int)z);
                d[t] = d[t - 1] * (int)z + d[t - 2];
                n = (int)(decimalNumberPart * d[t] + 0.5);
            }

            return string.Format((wholeNumberPart > 0 ? wholeNumberPart.ToString() + " " : "") + "{0}/{1}",
                                 n.ToString(),
                                 d[t].ToString()
                                );
        }
</pre>
</p>Example</p>
<pre>
String s= SimplifyingFraction(2,8);//Numerator is 2 and Denominator is 8, => s="1/4"
s= DoubleToFraction(0.25);//=>s="1/4"
</pre>
<h1><b> Code Reuse JavaScript</b></h1>
<p><br>
Show html string on website:</p>
<pre>"&lt;pre&gt;"+s.replace(/&lt;/g,"&lt;")+"&lt;pre&gt;";<pre></pre></pre>
<p>Example:</p>
<pre>var s="&lt;button&gt;Click me&lt;/button&gt;";
    function preventXSS(s){
    s=s.replace("&","&amp");
    return "<pre>"+s.replace(/</g,"&lt")+"<pre>";
    }
 <pre></pre></pre>

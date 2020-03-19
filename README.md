# Code Reuse c# 
***My English is not good, have sympathy for me!!!***
<h2>I.Getting number of week from the beginning of this year to now</h2>
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

<h2>II. Fixing injection mysql php</h2>
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
Show html string on website (prevent XSS):</p>
<pre>
// 1:string,2:class in css
  function preventXSS(s,cl){
    s=s.replace(&#x22;&#x26;&#x22;,&#x22;&#x26;amp&#x22;);
    s=&#x22;&#x3C;pre class=\&#x22;&#x22;+cl+&#x22;\&#x22;&#x3E;&#x22;+s.replace(/&#x3C;/g,&#x22;&#x26;lt&#x22;)+&#x22;&#x3C;pre&#x3E;&#x22;;
    return s;
    }
<pre></pre></pre>
<p>Example:</p>
<pre>
var s="&lt;button&gt;Click me&lt;/button&gt;";
s=preventXSS(s,"YourCssClass");
document.write(s);
 <pre></pre></pre>
 <h1>PHP XSS</h1>
 
 <pre>
             echo htmlspecialchars($string, ENT_QUOTES, 'UTF-8');

 </pre>
 <h1>Xamarin. Getting weather temp in LS city</h1>
<pre>
  async Task<int> GetWeatherTemp(String url)
        {   
            //GetWeatherTemp("https://api.openweathermap.org/data/2.5/weather?q=Lang%20Son&units=metric&appid=df2521d538fc3664cfeae4a6491e63c1");
            HttpClient client = new HttpClient();
            Task getStringTask = client.GetStringAsync(url);
            string urlContents = await getStringTask;
            int i= urlContents.IndexOf("\"temp\"");
            int a= urlContents.IndexOf("\"pressure\"");
            urlContents = urlContents.Substring(i);
            char[] c = urlContents.ToCharArray();
            string s = "";
            foreach (char item in c)
            {
                if (item == ',') break;
                else s += item;
            }
            s = s.Replace("\"temp\":", "");
            return Convert.ToInt32(s);
        }
</pre>
<h1>Xamarin convert datatable from json</h1>
<pre>DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));</pre>

<h1>Shared preferences</h1>
<pre>
Application.Current.Properties ["id"] = someClass.ID;

if (Application.Current.Properties.ContainsKey("id"))
{
    var id = Application.Current.Properties ["id"] as int;
    // do something with id
}
</pre>
<h1> Unity timer</h1>
<pre>
IEnumerator Lose()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            //code
        }
           StopCoroutine("Lose");
           StartCoroutine("Lose");
    }
</pre>
#php
<pre>
  $dt=mysql_real_escape_string($dt);//prevent injection
        //$dt=str_replace("'","''",$dt);
        date_default_timezone_set('Asia/Ho_Chi_Minh').//
        $timezone = date_default_timezone_get();
        $date = date('Y-m-d H:i:s ', time());
        </pre>
        
        
        Opt("TrayIconHide", 1)
 <h1> HTML Tab</h1>      
Type <pre>&nbsp; `& emsp ;`</pre> to add a single space.
Type <pre>&ensp; `& ensp ; `</pre> to add 2 spaces.
Type <pre>&emsp; `& emsp ; `</pre> to add 4 spaces.

https://i.imgur.com/x4OD9J0.png

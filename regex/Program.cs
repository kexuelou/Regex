using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace regex
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = "^http(s)?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);

            //string redirectUrl = @"http://www.bachelorleague.com/thanks-for-signing-up-for-bachelor-league/";


            string redirectUrl = @"http://www.bachelorleague.com/testforslash{0}/";
            string slash = "";
            for (int i = 0; i < 6; i++)
            {

                slash += "-";
                slash += i.ToString();
                slash += i.ToString();
                slash += i.ToString();

                string testURL = string.Format(redirectUrl, slash);

                Console.WriteLine(testURL);

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                if (regex.IsMatch(testURL))
                {
                    Console.WriteLine("matched");
                }
                else
                {
                    Console.WriteLine("not matched");
                }
                stopWatch.Stop();

                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value. 
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine("RunTime " + elapsedTime);
            }
        }
    }
}

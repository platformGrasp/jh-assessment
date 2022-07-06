using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Timers;
using Console_API_Client.Infrastructure;
using Console_API_Client.Interfaces;
using Console_API_Client.Model;

namespace Console_API_Client
{
    class Program
    {
        private static System.Timers.Timer _aTimer;

        static void Main(string[] args)
        {
            Console.WriteLine($"Press Enter to pull report");
            SetTimer();
            string inp;
            do
            {
                inp = Console.ReadLine();
            } while (inp != "Q");
        }

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            _aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            _aTimer.Elapsed += OnTimedEvent;
            _aTimer.AutoReset = true;
            _aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            ReportBo report = PullReport();
            if (report != null && report.tweetsAmount > 0)
            {
                Console.Clear();
                Console.WriteLine($"Amount of tweets in the queue {report.tweetsAmount}");
                Console.WriteLine($"Average tweets per minute { report.tweetsPerMinutes}");
                Console.WriteLine($"Average tweets per seconds { report.tweetsPerSecond}");
            }
        }

        static ReportBo PullReport()
        {
            IHttpFactory factory = new HttpFactory();
            var webRequest = factory.MakeGetWebRequest("https://localhost:5001/Report");
            string jsonText = "";
            try
            {
                var encode = Encoding.GetEncoding("utf-8");
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                var responseStream = new StreamReader(webResponse.GetResponseStream(), encode);
                jsonText = responseStream.ReadToEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                webRequest.Abort();
            }

            ServiceResult<ReportBo> report = JsonSerializer.Deserialize<ServiceResult<ReportBo>>(jsonText);
            return report.result;
        }
    }
}

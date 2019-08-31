using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoteBot;
using System.Timers;
using System.Threading;


namespace QuoteBotTester
{
    class Program
    {
        static QuoteBotLibrary qbl;

        static Program()
        {
            qbl = new QuoteBotLibrary(); 
        }

        static void Main(string[] args)
        {

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1 * 60 * 1000; 
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            QuoteBot.QuoteBot qb = new QuoteBot.QuoteBot();
            qb.Connect();
            
            while(!qb.Ready)
            {
                Thread.Sleep(2000);
            }

            qb.SendMessage(qbl.GetRandomQuote());

            while (true)
            { }
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            QuoteBot.QuoteBot qb = new QuoteBot.QuoteBot();
            qb.Connect();

            while (!qb.Ready)
            {
                Thread.Sleep(2000);
            }

            qb.SendMessage(qbl.GetRandomQuote());
        }
    }
}

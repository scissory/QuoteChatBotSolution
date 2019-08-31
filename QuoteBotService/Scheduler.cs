using System.Text;
using System.Threading.Tasks;
using QuoteBot;

using System.Timers;
using System.Threading;

namespace QuoteBotService
{
    public class Scheduler
    {

        private static QuoteBotLibrary qbl = new QuoteBotLibrary();
        private System.Timers.Timer timer;

        public Scheduler()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 5 * 60 * 1000;
            timer.Elapsed += Timer_Elapsed;

        }

        public void Start()
        {

            timer.Start();


        }

        public void Stop()
        {
            this.timer.Stop();
            this.timer.Dispose();
        }

        



        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            QuoteBot.QuoteBot qb = new QuoteBot.QuoteBot();
            qb.Connect();

            while (!qb.Ready)
            {
                
            }

            qb.SendMessage(qbl.GetRandomQuote());
        }


    }
}

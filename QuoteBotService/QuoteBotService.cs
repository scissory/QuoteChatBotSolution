using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using QuoteBot;
using System.Timers;
using System.Threading;

namespace QuoteBotService
{
    public partial class QuoteBotService : ServiceBase
    {

        private Scheduler scheduler = null;
        public QuoteBotService()
        {
            InitializeComponent();
            
        }

        protected override void OnStart(string[] args)
        {
            if (this.scheduler == null)
            {
                this.scheduler = new Scheduler();
            }
            scheduler.Start();
        
        }

        protected override void OnStop()
        {
            scheduler.Stop();
            scheduler = null;
            
        }

       
       
    }
}

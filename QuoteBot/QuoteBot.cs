using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.IO;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;

namespace QuoteBot
{

    public class QuoteBot
    {
        private const string TWITCH_HOST = "irc.chat.twitch.tv";
        private const int TWITCH_PORT = 6667;
        private const string NICKNAME = "davesquotebot";
        //private const string PASSWORD = "oauth:snbu5dbbt1dgoyzmiu2aqldbtn596h";
        private const string PASSWORD = "dvn7gv8pbh07tycrzidcf4vz5pkvba";
        private const string CHANNEL = "brazen_twitch_jobseeker";

        public TwitchClient Client { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }
        public bool Ready { get; set; }

        public QuoteBot()
        {

            Server = TWITCH_HOST;
            Port = TWITCH_PORT;

        }

        public QuoteBot(string server, int port)
        {
            Server = server;
            Port = port;

        }


        public void Connect()
        {

            ConnectionCredentials credentials = new ConnectionCredentials(NICKNAME, PASSWORD);

            Client = new TwitchClient();
            Client.Initialize(credentials, CHANNEL);

            Client.OnLog += Client_OnLog;
            Client.OnJoinedChannel += Client_OnJoinedChannel;
            Client.OnConnected += Client_OnConnected;
            this.Ready = false;
            Client.Connect();
            


        }


        private void Client_OnLog(object sender, OnLogArgs e)
        {
            Console.WriteLine($"{e.DateTime.ToString()}: {e.BotUsername} - {e.Data}");
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Console.WriteLine($"Connected to {e.AutoJoinChannel}");
        }

        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            Console.WriteLine("Hey guys! I am a bot connected via TwitchLib!");
            //Client.SendMessage(e.Channel, "Hey guys! I am a bot connected via TwitchLib!");
            this.Ready = true;
        }

        
        public void SendMessage(string quote)
        {
            try
            {
                Client.SendMessage(Client.JoinedChannels[0], quote);
                
            }
            finally
            {
                Client.Disconnect();
            }
        }
      

    }
}

    
using System;
using System.Diagnostics;
using Discord;
using Discord.WebSocket;

namespace Caretaker
{
    static class Init
    {
        private static DiscordSocketClient? _client;

        public static async Task Main()
        {
            var config = new DiscordSocketConfig
            {
                AlwaysDownloadUsers = true,
                MessageCacheSize = 100,
                GatewayIntents = GatewayIntents.All,
            };
            _client = new DiscordSocketClient(config);

            _client.Log += Log;
            _client.MessageReceived += MessageReceived;

            var token = File.ReadAllText("./token.txt");

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // Block this task until the program is closed.
            Process.GetCurrentProcess().WaitForExit();
            
        }

        private static Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private static async Task MessageReceived(SocketMessage socketMsg)
        {
            if (socketMsg.Author.IsBot) return;

            switch (socketMsg)
            {
                case SocketUserMessage msg:
                    await msg.ReplyAsync("You said: \"" + msg.Content + "\"");
                    break;
                default:
                    break;
            }
        }
    }
}
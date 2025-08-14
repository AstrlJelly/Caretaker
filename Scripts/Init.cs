namespace Caretaker;

using System;
using System.Diagnostics;

using Amalgam;

using Discord;
using Discord.WebSocket;
using RevoltSharp;
using RevoltSharp.Rest;

static class Init
{
    private static readonly DiscordSocketConfig _configD = new()
    {
        AlwaysDownloadUsers = true,
        MessageCacheSize = 100,
        GatewayIntents = GatewayIntents.All,
    };
    private static readonly ClientConfig _configR = new()
    {
        
    };

    private static readonly DiscordSocketClient _clientD = new(_configD);
    private static readonly RevoltClient _clientR = new(ClientMode.Http, _configR);

    public static async Task Main()
    {
        _clientD.Log += Log;
        _clientD.MessageReceived += MessageReceived;

        _clientR.OnLog += Log;

        string tokenD = File.ReadAllText("./discord_token.txt");

        await _clientD.LoginAsync(TokenType.Bot, tokenD);
        await _clientD.StartAsync();

        // block this task until the program is closed
        Process.GetCurrentProcess().WaitForExit();
    }

    private static Task Log(LogMessageAm msg)
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
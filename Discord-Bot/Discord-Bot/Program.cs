using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Authentication.ExtendedProtection;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;



namespace Discord_Bot;
public class Program
{
    
    private DiscordSocketClient _client;
    private CommandService _commands;
    private IServiceProvider _services;
    
    
    //Main class
    static void Main(string[] args) => new Program().BotRun().GetAwaiter().GetResult();
   
    //Bot class
    private async Task BotRun()
{   
        
        _client = new DiscordSocketClient();
        _commands = new CommandService();

        _services = new ServiceCollection()
            .AddSingleton(_client)
            .AddSingleton(_commands)
            .BuildServiceProvider();

       // DotNetEnv.Env.Load();
        var token = Environment.GetEnvironmentVariable("Token");
        //var token = GetToken(); 
       
        _client.Log += _client_Log;

        await RegisterCommandsAsync();

        await _client.LoginAsync(TokenType.Bot, token);

        await _client.SetGameAsync("In development , use .help for commands list");

        await _client.StartAsync();

        await Task.Delay(-1);

    }

    private Task _client_Log(LogMessage arg)
    {
        Console.WriteLine(arg);
        return Task.CompletedTask;
    }

    //Task registration method
    private async Task RegisterCommandsAsync()
    {
        _client.MessageReceived += HandleCommandAsync;
        await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
    }

    //Method where the bot is handling commands
    private async Task HandleCommandAsync(SocketMessage arg)
    {
        var message = arg as SocketUserMessage;
        var context = new SocketCommandContext(_client, message);
        if (message.Author.IsBot) return;

        int argPos = 0;
        if (message.HasStringPrefix(".", ref argPos))
        {
            var result = await _commands.ExecuteAsync(context, argPos, _services);
            if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
            if (result.Error.Equals(CommandError.UnmetPrecondition))
                await message.Channel.SendMessageAsync(result.ErrorReason);
        }


    }
    

}
using Discord;
using Discord.Commands;
using Discord.Net;
using Discord.WebSocket;
using M9_Discord_Bot.HumorAPI.API;
using M9_Discord_Bot.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace M9_Discord_Bot
{
    partial class Program
    {
        private DiscordSocketClient _client;
        private readonly CommandService _commands;
        private readonly IServiceProvider _services;

        private readonly Dictionary<string, string> _commandsDictionary = new Dictionary<string, string>()
        {
            {"start","First run this command before call another one. For init bot." },
            {"random_joke","Get random joke" },
            {"random_mem","Get random mem" },
            {"list","Output list attached files" }
        };

        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        private Program()
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Info
            });

            _commands = new CommandService(new CommandServiceConfig
            {
                LogLevel = LogSeverity.Info,
                CaseSensitiveCommands = false,
            });

            _services = BuildServiceProvider();

            _client.Ready += ClientReady;
            _client.SlashCommandExecuted += SlashCommandHandler;
            _client.Log += LogAsync;
            _commands.Log += LogAsync;
        }

        public IServiceProvider BuildServiceProvider() => new ServiceCollection()
            .AddSingleton(_client)
            .AddSingleton(_commands)
            .AddSingleton<JokesApi>()
            .AddSingleton<MemesApi>()
            .AddSingleton<HumorApiModule>()
            .AddSingleton<WebClient>()
            .AddSingleton<CloudStorageModule>()
            .AddSingleton<CommandHandler>()
            .BuildServiceProvider();

        private async Task ClientReady()
        {
            List<ApplicationCommandProperties> applicationCommandProperties = new List<ApplicationCommandProperties>();

            try
            {
                foreach (var commandName in _commandsDictionary.Keys)
                {
                    SlashCommandBuilder initHumorApiCommand = new SlashCommandBuilder();
                    initHumorApiCommand.WithName(commandName);
                    initHumorApiCommand.WithDescription(_commandsDictionary[commandName]);
                    applicationCommandProperties.Add(initHumorApiCommand.Build());
                }

                await _client.BulkOverwriteGlobalApplicationCommandsAsync(applicationCommandProperties.ToArray());

            }
            catch (HttpException exception)
            {
                var json = JsonConvert.SerializeObject(exception.Errors, Formatting.Indented);

                Log.Error(json);
            }
        }
        private async Task SlashCommandHandler(SocketSlashCommand command)
        {
            if (!_commandsDictionary.ContainsKey(command.CommandName))
                await command.RespondAsync($"Command with name {command.CommandName} doesn't exist.");

            var humorApi = _services.GetService<HumorApiModule>();
            var cloudStorageApi = _services.GetService<CloudStorageModule>();

            switch (command.CommandName)
            {
                case "start":
                    await humorApi.InitAsync(command);
                    break;
                case "random_joke":
                    await humorApi.RandomJokeAsync(command);
                    break;
                case "random_mem":
                    await humorApi.RandomMemAsync(command);
                    break;
                case "list":
                    await cloudStorageApi.GetAttachmentFilesAsync(command);
                    break;
                default:
                    break;
            }
        }

        private async Task MainAsync()
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

            // Centralize the logic for commands into a separate method.
            await _services.GetService<CommandHandler>().InstallCommandsAsync();

            // Login and connect.
            await _client.LoginAsync(TokenType.Bot, GetToken().Value);
            await _client.StartAsync();

            // Wait infinitely so your bot actually stays connected.
            await Task.Delay(Timeout.Infinite);
        }

        private IConfigurationSection GetToken()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddUserSecrets<Program>()
                .Build();
            return config.GetSection("DiscordToken");
        }

        private static async Task LogAsync(LogMessage message)
        {
            var severity = message.Severity switch
            {
                LogSeverity.Critical => LogEventLevel.Fatal,
                LogSeverity.Error => LogEventLevel.Error,
                LogSeverity.Warning => LogEventLevel.Warning,
                LogSeverity.Info => LogEventLevel.Information,
                LogSeverity.Verbose => LogEventLevel.Verbose,
                LogSeverity.Debug => LogEventLevel.Debug,
                _ => LogEventLevel.Information
            };

            Log.Write(severity, message.Exception, "[{Source}] {Message}", message.Source, message.Message);

            await Task.CompletedTask;
        }
    }
}

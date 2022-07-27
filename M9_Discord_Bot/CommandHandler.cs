using Discord.Commands;
using Discord.WebSocket;
using M9_Discord_Bot.Modules;
using Serilog;
using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace M9_Discord_Bot
{
    public class CommandHandler
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;
        private readonly IServiceProvider _services;

        public CommandHandler(IServiceProvider services, DiscordSocketClient client, CommandService commands)
        {
            _commands = commands;
            _client = client;
            _services = services;
        }

        public async Task InstallCommandsAsync()
        {
            await _commands.AddModulesAsync(assembly: Assembly.GetEntryAssembly(),
                                            services: _services);

            _client.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage messageParam)
        {
            // Don't process the command if it was a system message
            var message = messageParam as SocketUserMessage;

            if(!message.Author.IsBot && message.Attachments.Count > 0)
            {
                var attachFiles = string.Join(", ", message.Attachments.Select(a => a.Filename));
                Log.Debug($"Get message with attach files from {message.Author}: {attachFiles}");
                var cloudStorageModule = _services.GetService<CloudStorageModule>();
                await cloudStorageModule.AttachAsync(message.Attachments);
                return;
            }

            Log.Debug($"Get message from {message.Author}: {message}");
            if (message == null) return;

            // Create a number to track where the prefix ends and the command begins
            int argPos = 0;

            // Determine if the message is a command based on the prefix and make sure no bots trigger commands
            if (!(message.HasCharPrefix('/', ref argPos) ||
                message.HasMentionPrefix(_client.CurrentUser, ref argPos)) ||
                message.Author.IsBot)
                return;

            // Create a WebSocket-based command context based on the message
            var context = new SocketCommandContext(_client, message);

            // Execute the command with the command context we just
            // created, along with the service provider for precondition checks.
            await _commands.ExecuteAsync(
                context: context,
                argPos: argPos,
                services: _services);
        }
    }
}

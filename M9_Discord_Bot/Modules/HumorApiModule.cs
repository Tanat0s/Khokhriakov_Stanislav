using Discord.WebSocket;
using M9_Discord_Bot.HumorAPI.API;
using M9_Discord_Bot.HumorAPI.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace M9_Discord_Bot.Modules
{
    public class HumorApiModule
    {
        private JokesApi _jokesApi;
        private MemesApi _memesApi;
        private Random _random;

        public HumorApiModule(JokesApi jokesApi, MemesApi memesApi)
        {
            _jokesApi = jokesApi;
            _memesApi = memesApi;
        }

        public async Task InitAsync(SocketSlashCommand command)
        {
            if (!Configuration.ApiKey.ContainsKey("api-key"))
            {
                var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddUserSecrets<Program>()
                .Build();

                Configuration.ApiKey.Add("api-key", config.GetSection("HumarApiKey").Value);
            }

            await command.RespondAsync("Init completed!");
        }

        public async Task RandomJokeAsync(SocketSlashCommand command)
        {
            _random = new Random();
            var response = await Task.Run(() => _jokesApi.RandomJoke(null, null, null, _random.Next(0, 11), int.MaxValue));

            await command.RespondAsync(response.Joke);
        }

        public async Task<string> RandomMemAsync(SocketSlashCommand command)
        {
            _random = new Random();
            var response = await Task.Run(() => _memesApi.RandomMeme(null, null, null, _random.Next(1, 11), _random.Next(0, 11)));

            await command.RespondAsync(response.Url);
            return response.Url;
        }
    }
}

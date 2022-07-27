using Discord;
using Discord.WebSocket;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace M9_Discord_Bot.Modules
{
    public class CloudStorageModule
    {
        private WebClient _webClient;
        private readonly string storageDirectory = Path.Combine(Environment.CurrentDirectory, "Storage");

        public CloudStorageModule(WebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task AttachAsync(IEnumerable<Attachment> attachments)
        {
            foreach (var attachFile in attachments)
            {
                if (!Directory.Exists(storageDirectory))
                    Directory.CreateDirectory(storageDirectory);

                var fullFilePath = Path.Combine(storageDirectory, attachFile.Filename);
                _webClient.Headers.Add(HttpRequestHeader.ContentType, attachFile.ContentType);

                await _webClient.DownloadFileTaskAsync(attachFile.Url, fullFilePath);

                Log.Information($"Save file {attachFile.Filename}");
            }
        }

        public async Task GetAttachmentFilesAsync(SocketSlashCommand command)
        {
            if (!Directory.Exists(storageDirectory))
            {
                await command.RespondAsync("Storage folder is empty.");
                return;
            }

            var attechmentFiles = new List<FileAttachment>();

            foreach (var file in Directory.EnumerateFiles(storageDirectory))
            {
                var fileAttachment = new FileAttachment(file);
                attechmentFiles.Add(fileAttachment);
            }

            if(attechmentFiles.Count == 0)
            {
                await command.RespondAsync("Storage folder is empty.");
                return;
            }

            await command.RespondWithFilesAsync(attechmentFiles);
        }
    }
}

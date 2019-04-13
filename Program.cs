using DSharpPlus;
using DSharpPlus.EventArgs;
using System;
using System.Threading.Tasks;

namespace DiscordBotDemo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var discordClient = new DiscordClient(new DiscordConfiguration
            {
                Token = "[YOUR TOKEN HERE]",
                TokenType = TokenType.Bot
            });

            discordClient.MessageCreated += OnMessageCreated;

            await discordClient.ConnectAsync();
            await Task.Delay(-1);
        }

        private static async Task OnMessageCreated(MessageCreateEventArgs e)
        {
            if(string.Equals(e.Message.Content, "hello", StringComparison.OrdinalIgnoreCase))
            {
                await e.Message.RespondAsync(e.Message.Author.Username);
            }
        }
    }
}

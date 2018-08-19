using Discord;
using Discord.WebSocket;

namespace Volvox.Helios.Core.Bot
{
    public class DiscordSocketClientFactory
    {
        public DiscordSocketClient Create()
        {
            // TODO: Convert logging to command
            return new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose
            });
        }
    }
}
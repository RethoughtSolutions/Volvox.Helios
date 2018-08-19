using System.Collections.Generic;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using Volvox.Helios.Core.Bot.Connector;
using Volvox.Helios.Core.Modules.Common;

namespace Volvox.Helios.Core.Bot
{
    /// <summary>
    ///     Discord bot.
    /// </summary>
    public interface IBot
    {
        /// <summary>
        ///     Start the bot.
        /// </summary>
        Task Start();

        /// <summary>
        ///     Stop the bot.
        /// </summary>
        Task Stop();

        /// <summary>
        ///     Get a list of the guilds the bot is in.
        /// </summary>
        /// <returns>List of the guilds the bot is in.</returns>
        List<SocketGuild> GetGuilds();

        /// <summary>
        ///     Log an event.
        /// </summary>
        /// <param name="message">Message to log.</param>
        Task Log(LogMessage message);
    }
}
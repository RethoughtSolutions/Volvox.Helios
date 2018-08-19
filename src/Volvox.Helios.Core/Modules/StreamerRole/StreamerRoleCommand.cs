using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using Volvox.Helios.Core.Modules.Common;
using Volvox.Helios.Core.Modules.DiscordFacing;
using Volvox.Helios.Core.Utilities;

namespace Volvox.Helios.Core.Modules.StreamerRole
{
    /// <summary>
    ///     Assign a user the streaming role.
    /// </summary>
    public class StreamerRoleCommand : ICommand
    {
        private readonly IDiscordSettings discordSettings;
        private readonly DiscordSocketClient discordSocketClient;
        private readonly ILogger<StreamerRoleCommand> logger;

        /// <summary>
        ///     Assign a user the streaming role.
        /// </summary>
        /// <param name="discordSettings">Settings used to connect to Discord.</param>
        /// <param name="logger">Logger.</param>
        public StreamerRoleCommand(DiscordSocketClient discordSocketClient, IDiscordSettings discordSettings,
            ILogger<StreamerRoleCommand> logger)
        {
            this.discordSocketClient = discordSocketClient;
            this.discordSettings = discordSettings;
            this.logger = logger;
        }

        public Task InvokeAsync(DiscordFacingContext discordFacingContext)
        {
            throw new NotImplementedException();
        }

        public void Enable()
        {
            // Subscribe to the GuildMemberUpdated event.
            discordSocketClient.GuildMemberUpdated += OnDiscordSocketClientOnGuildMemberUpdated;
        }

        public void Disable()
        {
            discordSocketClient.GuildMemberUpdated -= OnDiscordSocketClientOnGuildMemberUpdated;
        }

        /// <summary>
        ///     Add the specified used to the specified streaming role.
        /// </summary>
        /// <param name="guildUser">User to add to role.</param>
        /// <param name="streamingRole">Role to add the user to.</param>
        private async Task AddUserToStreamingRole(IGuildUser guildUser, IRole streamingRole)
        {
            await guildUser.AddRoleAsync(streamingRole);

            logger.LogDebug($"StreamingRole Module: Adding {guildUser.Username}");
        }

        /// <summary>
        ///     Remove the specified used to the specified streaming role.
        /// </summary>
        /// <param name="guildUser">User to add to role.</param>
        /// <param name="streamingRole">Role to add the user to.</param>
        private async Task RemoveUserFromStreamingRole(IGuildUser guildUser, IRole streamingRole)
        {
            await guildUser.RemoveRoleAsync(streamingRole);

            logger.LogDebug($"StreamingRole Module: Removing {guildUser.Username}");
        }

        private async Task OnDiscordSocketClientOnGuildMemberUpdated(SocketGuildUser user, SocketGuildUser guildUser)
        {
            // Get the streaming role.
            var streamingRole = guildUser.Guild.Roles.FirstOrDefault(r => r.Name == "Streaming");

            // Add user to role.
            if (guildUser.Game != null && guildUser.Game.Value.StreamType == StreamType.Twitch)
            {
                await AddUserToStreamingRole(guildUser, streamingRole);
            }

            // Remove user from role.
            else if (guildUser.Roles.Any(r => r == streamingRole))
            {
                await RemoveUserFromStreamingRole(guildUser, streamingRole);
            }
        }
    }
}
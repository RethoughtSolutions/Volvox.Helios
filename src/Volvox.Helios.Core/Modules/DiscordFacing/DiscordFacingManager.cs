using System.Collections.Generic;
using System.Threading.Tasks;
using Discord;
using Volvox.Helios.Core.Modules.Common;

namespace Volvox.Helios.Core.Modules.DiscordFacing
{
    public class DiscordFacingManager : ICommand
    {
        private readonly IList<TriggerableCommandDecorator> modules;

        public DiscordFacingManager(IList<TriggerableCommandDecorator> modules)
        {
            this.modules = modules;
        }

        public async Task InvokeAsync(DiscordFacingContext discordFacingContext)
        {
            if (!(discordFacingContext.Channel is IDMChannel || discordFacingContext.Message.Author.IsBot)) return;

            foreach (var module in modules)
            {
                await module.InvokeAsync(discordFacingContext).ConfigureAwait(false);
            }
        }
    }
}
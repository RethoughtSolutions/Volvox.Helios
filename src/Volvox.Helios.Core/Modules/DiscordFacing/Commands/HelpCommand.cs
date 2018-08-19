using System.Threading.Tasks;
using Volvox.Helios.Core.Modules.Common;

namespace Volvox.Helios.Core.Modules.DiscordFacing.Commands
{
    public class HelpCommand : ICommand
    {
        public async Task InvokeAsync(DiscordFacingContext discordFacingContext)
        {
            // TODO
            await discordFacingContext.Channel.SendMessageAsync("TODO: Provide Help Message").ConfigureAwait(false);
        }
    }
}
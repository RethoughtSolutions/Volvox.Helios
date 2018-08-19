using System.Threading.Tasks;
using Volvox.Helios.Core.Modules.DiscordFacing;

namespace Volvox.Helios.Core.Modules.Common
{
    /// <summary>
    ///     Unit of the bot.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        ///     Executes the command.
        /// </summary>
        Task InvokeAsync(DiscordFacingContext discordFacingContext);
    }
}
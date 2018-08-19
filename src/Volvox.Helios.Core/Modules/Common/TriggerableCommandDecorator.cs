using System.Threading.Tasks;
using Volvox.Helios.Core.Modules.DiscordFacing;

namespace Volvox.Helios.Core.Modules.Common
{
    public class TriggerableCommandDecorator : ICommand
    {
        private readonly ICommand command;

        public TriggerableCommandDecorator(ITrigger trigger, ICommand command)
        {
            Trigger = trigger;
            this.command = command;
        }

        public ITrigger Trigger { get; }

        public async Task InvokeAsync(DiscordFacingContext discordFacingContext)
        {
            if (Trigger.Valid(discordFacingContext))
            {
                await command.InvokeAsync(discordFacingContext);
            }
        }
    }
}
using System.Threading.Tasks;
using Volvox.Helios.Core.Modules.DiscordFacing;

namespace Volvox.Helios.Core.Modules.Common
{
    public class TriggerableModuleDecorator : IModule
    {
        private readonly IModule module;

        public TriggerableModuleDecorator(ITrigger trigger, IModule module)
        {
            Trigger = trigger;
            this.module = module;
        }

        public ITrigger Trigger { get; }

        public async Task InvokeAsync(DiscordFacingContext discordFacingContext)
        {
            if (Trigger.Valid(discordFacingContext))
            {
                await module.InvokeAsync(discordFacingContext);
            }
        }
    }
}
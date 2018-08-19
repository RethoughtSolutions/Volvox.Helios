using System.Threading.Tasks;
using Discord;
using Volvox.Helios.Core.Modules.Common;
using Volvox.Helios.Core.Modules.DiscordFacing;
using Volvox.Helios.Domain.ModuleSettings;
using Volvox.Helios.Service.ModuleSettings;

namespace Volvox.Helios.Core.Bot
{
    public class GuildEnabledCommandDecorator<TSettings> : ICommand where TSettings : ModuleSettings
    {
        private readonly IModuleSettingsService<TSettings> settingsService;
        private readonly ICommand command;

        public GuildEnabledCommandDecorator(IModuleSettingsService<TSettings> settings, ICommand command)
        {
            this.settingsService = settings;
            this.command = command;
        }

        public async Task InvokeAsync(DiscordFacingContext discordFacingContext)
        {
            if (discordFacingContext.Channel is IGuildChannel guildChannel)
            {
                var settings = await settingsService.GetSettingsByGuild(guildChannel.GuildId);

                if (settings.Enabled) await this.command.InvokeAsync(discordFacingContext);
            }
        }
    }
}
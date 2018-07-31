﻿using System.Threading.Tasks;

namespace Volvox.Helios.Service.ModuleSettings
{
    /// <summary>
    /// Service to handle module settings.
    /// </summary>
    /// <typeparam name="T">Type of module setting.</typeparam>
    public interface IModuleSettingsService<T> where T : Domain.ModuleSettings.ModuleSettings
    {
        /// <summary>
        /// Save the module settings to the database. Replace the settings if it is already stored for that particular guild.
        /// </summary>
        /// <param name="settings">Module settings to save.</param>
        Task SaveSettings(T settings);

        /// <summary>
        /// Get the module settings from the database for the specified guild and cache it.
        /// </summary>
        /// <param name="guildId">Guild settings to get.</param>
        /// <returns>Settings from the specified guild.</returns>
        Task<T> GetSettingsByGuild(ulong guildId);
    }
}
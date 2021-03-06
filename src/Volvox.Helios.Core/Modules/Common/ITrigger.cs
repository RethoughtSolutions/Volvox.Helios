﻿using Volvox.Helios.Core.Modules.DiscordFacing;

namespace Volvox.Helios.Core.Modules.Common
{
    /// <summary>
    ///     ITrigger describes a type that decides whether a command should be invoked or not.
    /// </summary>
    public interface ITrigger
    {
        /// <summary>
        ///     Evaluates if the given context is sufficient to invoke the checking command.
        /// </summary>
        /// <param name="context">Given context to check</param>
        /// <returns></returns>
        bool Valid(DiscordFacingContext context);
    }
}
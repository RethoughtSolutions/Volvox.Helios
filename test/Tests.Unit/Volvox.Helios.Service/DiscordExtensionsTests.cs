﻿using System.Collections.Generic;
using Volvox.Helios.Domain.Discord;
using Volvox.Helios.Service.Extensions;
using Xunit;

namespace Tests.Unit.Volvox.Helios.Service
{
    /// <summary>
    /// Q&D sample unit test class
    /// </summary>
    public class DiscordExtensionsTests
    {
        private const int AdminPermission = 0x00000008;
        private const int NotAdminPermission = 0x00000000;

        /// <summary>
        /// Sample Test
        /// </summary>
        [Fact]
        public void ReturnFilteredList()
        {
            //Arrange 
            #region arrange
            
            var testGuilds = new List<Guild>
            {
                new Guild
                {
                    Id = 1,
                    Name = "NotAdmin",
                    Permissions = NotAdminPermission
                },

                new Guild
                {
                    Id = 1,
                    Name = "NotAdmin2",
                    Permissions = NotAdminPermission
                },

                new Guild
                {
                    Id = 1,
                    Name = "Admin",
                    Permissions = AdminPermission
                }
            };
            
            #endregion

            //Act
            var result = testGuilds.FilterAdministrator();

            //Assert
            Assert.True(result.Count == 1);
            Assert.Equal("Admin", result[0].Name);
        }

        [Fact]
        public void FilterChannelType()
        {
            //Arrange 
            #region arrange

            var testChannels = new List<Channel>
            {
                new Channel
                {
                    Type = 1
                },
                new Channel
                {
                    GuildId = 123,
                    Type = 2
                },
                new Channel
                {
                    Type = 3
                }
            };
            
            #endregion

            //Act
            var result = testChannels.FilterChannelType(2);

            //Assert
            Assert.True(result.Count == 1);
            Assert.Equal((ulong)123, result[0].GuildId);
        }
        
        [Fact]
        public void FilterGuildsByIds()
        {
            //Arrange 
            #region arrange

            var testGuilds = new List<Guild>
            {
                new Guild
                {
                    Id = 1,
                    Name = "NotAdmin",
                    Permissions = NotAdminPermission
                },

                new Guild
                {
                    Id = 2,
                    Name = "NotAdmin2",
                    Permissions = NotAdminPermission
                },

                new Guild
                {
                    Id = 3,
                    Name = "Admin",
                    Permissions = AdminPermission
                }
            };

            var testIds = new List<ulong>
            {
                2,
                3
            };
            
            #endregion

            //Act
            var result = testGuilds.FilterGuildsByIds(testIds);

            //Assert
            Assert.True(result.Count == 2);
            Assert.Equal((ulong)2, result[0].Id);
            Assert.Equal((ulong)3, result[1].Id);
        }
    }
}

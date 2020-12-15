using System;

namespace OrionManager.Common.Constants
{
    public static class GlobalConstants
    {
        #region Max

        public const int MaxPlayerCount = 4;
        public const int MaxLoyaltyTrackerSize = 20;
        public const int MaxMinPointTrackerSize = 100;

        #endregion

        #region Default

        public const int DefaultRoundCount = 8;
        public const string DefaultPlayerName = "New Player";
        public const string DefaultConfigurationName = "Default Configuration";
        public static readonly Guid DefaultGameConfigurationId = new Guid();

        #endregion
    }
}
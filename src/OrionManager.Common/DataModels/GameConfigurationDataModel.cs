using System;

namespace OrionManager.Common.DataModels
{
    public class GameConfigurationDataModel
    {
        public Guid Id { get; set; }
        public DateTime SaveTime { get; set; }
        public string Name { get; set; }
        public int WinPointTrackerSize { get; set; }
        public int LoyaltyTrackerSize { get; set; }
        public PlayerPresetDataModel[] PlayerPresets { get; set; }
    }
}
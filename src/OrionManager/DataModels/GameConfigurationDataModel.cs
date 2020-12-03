using System;

namespace OrionManager.DataModels
{
    internal class GameConfigurationDataModel
    {
        public Guid Id { get; set; }
        public DateTime SaveTime { get; set; }
        public string Name { get; set; }
        public int NumberOfRounds { get; set; }
        public int NumberOfCounselors { get; set; }
        public int WinPointTrackerSize { get; set; }
        public int LoyaltyTrackerSize { get; set; }
    }
}
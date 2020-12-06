namespace OrionManager.DataModels
{
    internal class GameDataModel
    {
        public PlayerDataModel[] Players { get; set; }
        public int Round { get; set; }
        public int WinPointTrackerSize { get; set; }
        public int LoyaltyTrackerSize { get; set; }
    }
}
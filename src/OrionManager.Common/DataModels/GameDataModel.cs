namespace OrionManager.Common.DataModels
{
    public class GameDataModel
    {
        public PlayerDataModel[] Players { get; set; }
        public int Round { get; set; }
        public int WinPointTrackerSize { get; set; }
        public int LoyaltyTrackerSize { get; set; }
    }
}
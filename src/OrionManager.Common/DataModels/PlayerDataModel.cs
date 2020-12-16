using OrionManager.Common.Enums;

namespace OrionManager.Common.DataModels
{
    public class PlayerDataModel
    {
        public string Name { get; set; }
        public PlayerColors Color { get; set; }
        public Races Race { get; set; }
        public int LoyaltyPoints { get; set; }
        public int WinPoints { get; set; }
        public Counselors Counselor { get; set; }
    }
}
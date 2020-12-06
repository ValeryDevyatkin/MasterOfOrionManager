using OrionManager.Enums;

namespace OrionManager.DataModels
{
    internal class PlayerDataModel
    {
        public string Name { get; set; }
        public PlayerColor Color { get; set; }
        public Race Race { get; set; }
        public int LoyaltyPoints { get; set; }
        public int WinPoints { get; set; }
        public Counselor Counselor { get; set; }
        public bool HasInitiative { get; set; }
    }
}
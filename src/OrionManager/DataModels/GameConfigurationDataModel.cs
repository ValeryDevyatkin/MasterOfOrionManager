using System;

namespace OrionManager.DataModels
{
    internal class GameConfigurationDataModel
    {
        public string Name { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime SaveTime { get; set; }
    }
}
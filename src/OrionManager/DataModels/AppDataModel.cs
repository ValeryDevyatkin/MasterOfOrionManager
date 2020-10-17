using System;

namespace OrionManager.DataModels
{
    internal class AppDataModel
    {
        public bool IsGameStarted { get; set; }
        public Guid CurrentConfigurationId { get; set; }
    }
}
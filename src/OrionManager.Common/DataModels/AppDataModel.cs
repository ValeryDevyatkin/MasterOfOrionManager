using System;

namespace OrionManager.Common.DataModels
{
    public class AppDataModel
    {
        public bool IsGameStarted { get; set; }
        public Guid CurrentConfigurationId { get; set; }
    }
}
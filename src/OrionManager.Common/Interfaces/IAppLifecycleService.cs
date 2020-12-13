using System;
using OrionManager.Common.Enums;

namespace OrionManager.Common.Interfaces
{
    public interface IAppLifecycleService
    {
        Action ExitApp { get; set; }
        void LoadData();
        void SaveData();
        void NavigateToRegion(UiRegions region);
    }
}
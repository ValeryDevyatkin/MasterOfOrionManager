using System;
using OrionManager.DataModels;
using OrionManager.ViewModels;
using OrionManager.ViewModels.Main;

namespace OrionManager.ExtensionMethods
{
    internal static class DataModelCopyEx
    {
        public static void CopyFrom(this MainViewModel viewModel, AppDataModel dataModel)
        {
            viewModel.IsGameStarted = dataModel.IsGameStarted;
        }

        public static void CopyFrom(this GameDataViewModel viewModel, GameDataModel dataModel)
        {
        }
    }
}
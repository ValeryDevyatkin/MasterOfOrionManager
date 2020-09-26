using OrionManager.ViewModels;

namespace OrionManager.DataModels
{
    internal class AppDataModel
    {
        public AppDataModel(bool isGameStarted)
        {
            IsGameStarted = isGameStarted;
        }

        public AppDataModel(AppDataViewModel viewModel)
        {
            IsGameStarted = viewModel.IsGameStarted;
        }

        public bool IsGameStarted { get; }
    }
}
namespace OrionManager.Interfaces
{
    internal interface IPathProvider
    {
        string GetAppDataDirectoryPath(string relativeDirectoryPath = "");
    }
}
namespace OrionManager.Common.Interfaces
{
    public interface IPathProvider
    {
        string GetAppDataDirectoryPath(string relativeDirectoryPath = "");
    }
}
using System;
using System.IO;
using OrionManager.Common.Interfaces;
using Unity;

namespace OrionManager.Services.Services.SaveLoad
{
    internal class PathProvider : IPathProvider
    {
        private const string AppDataDirectoryName = "AppData";

        private readonly string _appDataDirectoryPath =
            Path.Combine(Environment.CurrentDirectory, AppDataDirectoryName);

        public PathProvider(IUnityContainer container)
        {
            container.RegisterInstance(this);
        }

        public string GetAppDataDirectoryPath(string relativeDirectoryPath)
        {
            var directoryPath = Path.Combine(_appDataDirectoryPath, relativeDirectoryPath);

            Directory.CreateDirectory(directoryPath);

            return directoryPath;
        }
    }
}
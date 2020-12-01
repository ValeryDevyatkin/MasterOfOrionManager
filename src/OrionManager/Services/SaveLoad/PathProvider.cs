using System;
using System.IO;
using OrionManager.Interfaces;
using Unity;

namespace OrionManager.Services.SaveLoad
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

        public string GetAppDataDirectoryPath() => _appDataDirectoryPath;
    }
}
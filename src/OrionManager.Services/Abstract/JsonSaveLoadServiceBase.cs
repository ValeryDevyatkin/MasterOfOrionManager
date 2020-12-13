using System.IO;
using Newtonsoft.Json;
using OrionManager.Common.Interfaces;
using Unity;

namespace OrionManager.Services.Abstract
{
    internal abstract class JsonSaveLoadServiceBase<T> : ISaveLoadService<T>
    {
        private readonly IUnityContainer _container;

        protected JsonSaveLoadServiceBase(IUnityContainer container)
        {
            _container = container;
        }

        protected abstract string FileName { get; }

        public T Load()
        {
            var filePath = GetFilePath();

            if (!File.Exists(filePath))
            {
                return default;
            }

            var json = File.ReadAllText(filePath);
            var dataModel = JsonConvert.DeserializeObject<T>(json);

            return dataModel;
        }

        public void Save(T dataModel)
        {
            var json = JsonConvert.SerializeObject(dataModel);

            File.WriteAllText(GetFilePath(), json);
        }

        protected string GetFilePath() =>
            Path.Combine(_container.Resolve<IPathProvider>().GetAppDataDirectoryPath(), FileName);
    }
}
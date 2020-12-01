using System.IO;
using Newtonsoft.Json;
using OrionManager.Interfaces;

namespace OrionManager.Services.SaveLoad
{
    internal abstract class JsonSaveLoadServiceBase<T> : ISaveLoadService<T>
    {
        protected string FilePath { get; set; }

        public T Load()
        {
            if (!File.Exists(FilePath))
            {
                return default;
            }

            var json = File.ReadAllText(FilePath);
            var dataModel = JsonConvert.DeserializeObject<T>(json);

            return dataModel;
        }

        public void Save(T dataModel)
        {
            var json = JsonConvert.SerializeObject(dataModel);

            File.WriteAllText(FilePath, json);
        }
    }
}
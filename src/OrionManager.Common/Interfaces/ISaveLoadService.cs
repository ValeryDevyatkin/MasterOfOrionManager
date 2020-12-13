namespace OrionManager.Common.Interfaces
{
    public interface ISaveLoadService<T>
    {
        T Load();
        void Save(T dataModel);
    }
}
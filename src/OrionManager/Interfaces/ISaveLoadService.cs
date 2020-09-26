namespace OrionManager.Interfaces
{
    internal interface ISaveLoadService<T>
    {
        T Load();
        void Save(T dataModel);
    }
}
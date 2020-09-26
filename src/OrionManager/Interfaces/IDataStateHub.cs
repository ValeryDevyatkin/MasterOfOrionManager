namespace OrionManager.Interfaces
{
    internal interface IDataStateHub<T>
    {
        void SaveState(T item);
        bool DetectChanges(T item);
    }
}
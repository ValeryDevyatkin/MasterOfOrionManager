namespace OrionManager.Interfaces
{
    internal interface IDataStateHub<T>
    {
        void CommitState(T item);
        bool DetectChanges(T item);
    }
}
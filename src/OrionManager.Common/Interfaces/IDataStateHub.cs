namespace OrionManager.Common.Interfaces
{
    public interface IDataStateHub<T>
    {
        void CommitState(T item);
        bool HasChanges(T item);
    }
}
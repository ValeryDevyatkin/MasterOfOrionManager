using OrionManager.Interfaces;

namespace OrionManager.Abstract
{
    internal abstract class DataStateHubBase<T> : IDataStateHub<T>
    {
        private T _committedState;

        public void CommitState(T item)
        {
            _committedState = item;
        }

        public bool HasChanges(T item) => HasDifference(_committedState, item);

        protected abstract bool HasDifference(T item1, T item2);
    }
}
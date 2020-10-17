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

        public bool DetectChanges(T item) => DetectChanges(_committedState, item);

        protected abstract bool DetectChanges(T item1, T item2);
    }
}
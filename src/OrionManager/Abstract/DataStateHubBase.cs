using OrionManager.Interfaces;

namespace OrionManager.Abstract
{
    internal abstract class DataStateHubBase<T> : IDataStateHub<T>
    {
        private T _savedState;

        public void SaveState(T item)
        {
            _savedState = item;
        }

        public bool DetectChanges(T item) => DetectChanges(_savedState, item);

        protected abstract bool DetectChanges(T item1, T item2);
    }
}
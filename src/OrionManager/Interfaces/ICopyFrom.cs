namespace OrionManager.Interfaces
{
    internal interface ICopyFrom<T>
    {
        void CopyFrom(T dataModel);
    }
}
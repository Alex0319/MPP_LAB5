using System;

namespace STM
{
    public interface IStmRef : IStmUnmanagedClone
    {
        void SetAsObject(object value);
        object GetAsObject();
    }
}

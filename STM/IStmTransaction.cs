using System;

namespace STM
{
    public interface IStmTransaction
    {
        void Begin();
        bool TryCommit();
        void Rollback();
        void TryAddComponent(IStmRef stmRef, StmRefSavedState stmRefSavedState);
    }
}

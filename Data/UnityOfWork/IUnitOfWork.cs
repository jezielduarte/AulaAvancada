using System;
using System.Collections.Generic;
using System.Text;

namespace Data.UnityOfWork
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}

using Data.SqLite;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.UnityOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextSQLite _context;
        private IDbContextTransaction _transaction;
        public UnitOfWork(ContextSQLite context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }
    }
}

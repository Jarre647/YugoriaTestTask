﻿using System.Threading.Tasks;

namespace YugoriaTestTask.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class;

        Task<int> CommitAsync();

        int Commit();

        bool AutoDetectChanges { get; set; }

        bool CheckConnection();
    }
}

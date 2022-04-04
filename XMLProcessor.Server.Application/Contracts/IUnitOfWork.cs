﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace XMLProcessor.Server.Application.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}

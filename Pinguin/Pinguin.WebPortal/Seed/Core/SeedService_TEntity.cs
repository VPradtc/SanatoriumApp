﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pinguin.API.Seed.Core
{
    public abstract class SeedService<TEntity> : ISeedService<TEntity>
    {
        protected abstract ICollection<TEntity> CreateSeedData();

        protected abstract Task ExecuteInternalAsync(ICollection<TEntity> data);

        public Task ExecuteAsync()
        {
            var data = CreateSeedData();

            return ExecuteInternalAsync(data);
        }
    }
}
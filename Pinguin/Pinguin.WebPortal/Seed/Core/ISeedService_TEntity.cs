﻿using System;
using System.Threading.Tasks;

namespace Pinguin.API.Seed.Core
{
    public interface ISeedService<out TEntity>
    {
        Task ExecuteAsync();
    }
}

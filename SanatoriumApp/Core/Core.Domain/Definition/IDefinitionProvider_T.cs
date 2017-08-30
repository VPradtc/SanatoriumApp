using System;
using System.Collections.Generic;

namespace Core.Domain.Definition
{
    public interface IDefinitionProvider<T>
    {
        ICollection<T> GetAll();
    }
}

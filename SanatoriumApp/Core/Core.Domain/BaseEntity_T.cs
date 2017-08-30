using System;

namespace Core.Domain
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}

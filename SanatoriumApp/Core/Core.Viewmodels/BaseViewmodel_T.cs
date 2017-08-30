using System;

namespace Core.Viewmodels
{
    public abstract class BaseViewmodel<TKey>
    {
        public TKey Id { get; set; }
    }
}

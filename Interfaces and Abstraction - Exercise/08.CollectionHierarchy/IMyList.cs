using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    interface IMyList<T> : IAddRemoveCollection<T>
    {
        IReadOnlyCollection<T> Used { get; }
    }
}

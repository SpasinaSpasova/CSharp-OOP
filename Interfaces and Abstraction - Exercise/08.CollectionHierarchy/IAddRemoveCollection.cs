using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    interface IAddRemoveCollection<T> :IAddCollection<T>
    {
        T Remove();
    }
}

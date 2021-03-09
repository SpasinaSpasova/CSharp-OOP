using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.CollectionHierarchy
{
    public class MyList<T> : AddRemoveCollection<T>, IMyList<T>
    {
        public IReadOnlyCollection<T> Used => this.Data as IReadOnlyCollection<T>;
        public override T Remove()
        {
            var firstElemennt = this.Data.First();
            this.Data.RemoveAt(0);
            return firstElemennt;
        }
    }
}

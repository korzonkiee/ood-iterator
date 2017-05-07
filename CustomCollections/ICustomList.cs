using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.CustomCollections
{
    public interface ICustomList<T> : ITraversableCollection
    {
        int Size { get; }
        T Get(int n);
    }
}

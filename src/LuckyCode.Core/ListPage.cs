using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteCode.Core
{
    public class ListPage<T>:List<T>
    {
        public int Total { get; set; }

    }
}

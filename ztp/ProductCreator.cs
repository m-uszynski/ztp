using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztp
{
    public abstract class ProductCreator
    {
        public abstract IProduct Create(int Id, string Name, int Count, float Price, int VAT);
    }
}

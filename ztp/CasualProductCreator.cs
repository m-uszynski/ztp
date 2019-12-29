using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztp
{
    class CasualProductCreator : ProductCreator
    {
        public override IProduct Create(string Name, int Count, float Price, int VAT)
        {
            return new CasualProduct(Name,Count,Price,VAT);
        }
    }
}

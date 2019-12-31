using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztp
{
    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        int Count { get; set; }
        float Price { get; set; }
        int VAT { get; set; }

        float Sum { get; }
    }
}

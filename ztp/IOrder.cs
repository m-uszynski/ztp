using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztp
{
    interface IOrder
    {
        string Firstname { get; set; }
        string Lastname { get; set; }
        string Pesel { get; set; }
    }
}

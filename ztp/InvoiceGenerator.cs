using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztp
{
    abstract class InvoiceGenerator
    {
        protected IDocument document;

        public InvoiceGenerator(IDocument document)
        {
            this.document = document;
        }

        public abstract void Generate(int id);
    }
}

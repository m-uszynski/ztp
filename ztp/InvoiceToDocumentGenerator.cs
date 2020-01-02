using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztp
{
    class InvoiceToDocumentGenerator : InvoiceGenerator
    {
        public InvoiceToDocumentGenerator(IDocument document) : base(document) { }

        public override void Generate(int id)
        {
            document.Generate(id);
        }
    }
}

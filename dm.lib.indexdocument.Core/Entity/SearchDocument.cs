using System;
using System.Collections.Generic;
using System.Text;

namespace dm.lib.indexdocument.core.Entity
{
    public class SearchDocument
    {
        public int DocumentId { get; set; }

        public string DocumentType { get; set; }

        public Object BasicDetails { get; set; }

        public IList<Object> LineItems { get; set; }

    }
}

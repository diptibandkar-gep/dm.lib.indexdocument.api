using dm.lib.indexdocument.core.Entity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace dm.lib.indexdocument.DataAccess.Interface
{
    public interface IIndexDataAccess
    {
        JObject IngestESData(SearchDocument document, string token);
    }
}

using dm.lib.indexdocument.core.Entity;
using dm.lib.indexdocument.DataAccess.Interface;
using dm.lib.indexdocument.Service.Interface;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace dm.lib.indexdocument.Service
{
    public class IndexService : IIndexService
    {
        IIndexDataAccess _bomSearchDataAccess;

        public IndexService(IIndexDataAccess SearchDataAccess)
        {
            _bomSearchDataAccess = SearchDataAccess;
        }
    
        public JObject IngestESData(SearchDocument document, string token)
        {
            return _bomSearchDataAccess.IngestESData(document,token);
        }
    }
}

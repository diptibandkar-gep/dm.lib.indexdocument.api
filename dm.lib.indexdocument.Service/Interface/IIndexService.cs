
using dm.lib.indexdocument.core.Entity;
using Newtonsoft.Json.Linq;

namespace dm.lib.indexdocument.Service.Interface
{
    public interface IIndexService
    {
        JObject IngestESData(SearchDocument document, string token);
    }
}

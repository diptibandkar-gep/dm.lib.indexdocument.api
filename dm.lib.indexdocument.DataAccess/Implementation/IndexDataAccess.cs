
using dm.lib.core.nuget;
using dm.lib.indexdocument.core.Entity;
using dm.lib.indexdocument.Core;
using dm.lib.indexdocument.DataAccess.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace dm.lib.indexdocument.DataAccess.Implementation
{
    public class IndexDataAccess : BaseSqlDataAccess, IIndexDataAccess
    {
        ISearchService _searchService;

        public IndexDataAccess(IGepService gepService, ISearchService searchService) : base(gepService)
        {
            _searchService = searchService;
        }


        public JObject IngestESData(SearchDocument document, string token)
        {
            JArray injestJson = new JArray();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", gepService.GetApplicationConfiguration(ClientConfigKey.APIMSubscriptionKey));
            client.DefaultRequestHeaders.Add("Authorization", token);
            try
            {
                var apiBaseURL = gepService.GetConfiguration().GetApplicationConfiguration(ClientConfigKey.APIBaseURL);
                var uri = string.Empty;
                if (document.DocumentType == DMApplicationId.ApplicationIdGI)
                {
                    uri = apiBaseURL + ClientConfigKey.InvGIBasicDetailsUrl + document.DocumentId;
                    dynamic result =client.GetAsync(uri).Result.Content;
                    string jsonContent = result.ReadAsStringAsync().Result;

                    var BasicDetails = JsonConvert.DeserializeObject<dynamic>(jsonContent).returnValue;
                    injestJson.Add(BasicDetails);

                    uri = apiBaseURL + ClientConfigKey.InvGILineDetailsUrl + document.DocumentId;
                    result = client.GetAsync(uri).Result.Content;
                    jsonContent = result.ReadAsStringAsync().Result;
                    var LineItems = JsonConvert.DeserializeObject<dynamic>(jsonContent).returnValue;
                    injestJson.Add(LineItems);

                }
            }
            catch (Exception ex)
            {
                LogError("SearchDataAccess", "IngestESData", "Error", ex);
                //throw new GepBusinessException("Ingestion API Error", SeverityLevel.Critical, ex);
            }
            return _searchService.IngestDocuments(injestJson, "DirectMaterials", DMApplicationName.ApplicationNameGI);

        }

        private List<string> GetSourceIncludesFields()
        {

            return new List<string>(){
                                        "DocumentCode",
                                        "DocumentNumber",
                                        "ItemName",
                                        "ItemNumber",
                                        "VersionNumber",
                                        "RevisionNumber",
                                        "BOMType",
                                        "CreatedBy",
                                        "CreatedDate",
                                        "DocumentStatusCode",
                                        "DocumentStatusInfo",
                                        "isTemplate"
                                        };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace dm.lib.indexdocument.Core
{
    public class ClientConfigKey
    {
        public static readonly string EndpointBillofMaterail = "EndpointBillofMaterail";
        public static readonly string EndpointShoouldCost = "EndpointShoouldCost";
        public static readonly string LogoutUrl = "LogoutUrl";
        public static readonly string APIBaseURL = "APIBaseURL";
        public static readonly string SendViewToDL = "sebapi/SendViewToDL";
        public static readonly string SendMessageToBrokerForDL = "sebapi/SendMessageToBrokerForDL";
        public static readonly string SendMessageToBrokerForElasticSearch = "sebapi/SendMessage";
        public static readonly string SearchCoreApiUrl = "/DMSearchCore/api/core/search";
        public static readonly string IngestionApiUrl = "/DMIngestion/api/core/ingest";
        public static readonly string SCAPIMSubKey = "SCAPIMSubKey";
        public static readonly string APIMSubscriptionKey = "APIMSubscriptionKey";
        public static readonly string InvGIBasicDetailsUrl = "/inventorygi/api/v1/GoodsIssue/BasicDetails/";
        public static readonly string InvGILineDetailsUrl = "/inventorygi/api/v1/GoodsIssue/LineDetails/";
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace dm.lib.indexdocument.Core
{
    public class ApplicationConfigKey
    {

        public static readonly string LOG_CONNECTION = "LogConnection";
        public static readonly string LOG_CONNECTION_DM = "LogConnection_Smart";
        public static readonly string LOG_TABLE_APPENDER = "LogAppender";
        public static readonly string LOG_CONFIG = "LogConfig";
        public static readonly string CACHE_CONNECTION = "CacheConnection";
    }
    public class DMApplicationId
    {
        public const string ApplicationIdGI = "6";
    }

    public class DMApplicationName
    {
        public const string ApplicationNameGI = "InvertoryGI-Ingestion";
    }
}
using dm.lib.azuresqlstorage.nuget;
using dm.lib.core.nuget;
using dm.lib.indexdocument.Core;

namespace dm.lib.indexdocument.DataAccess
{
    public abstract class BaseSqlDataAccess : BaseDataAccess
    {
        public ReliableSqlDatabase sqlHelper;
        protected BaseSqlDataAccess(IGepService gepservice) : base(gepservice)
        {
            string constring = UserContext.GetConfig(PartnerConfigKey.SQL_CONNECTION);
            
            // This condition will not be there in real world scenario
            if (!string.IsNullOrEmpty(constring)) 
                sqlHelper = new ReliableSqlDatabase(constring, internalLogger);
        }
    }
}

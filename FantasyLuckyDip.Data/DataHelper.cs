using System.Configuration;
using FantasyLuckyDip.Data.Interfaces;

namespace FantasyLuckyDip.Data
{
    public class DataHelper : IDataHelper
    {        
        public string ConnectionString { get; } = ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString;
    }
}

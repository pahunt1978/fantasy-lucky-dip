using System.Collections.Generic;
using FantasyLuckyDip.DataTransferObjects;

namespace FantasyLuckyDip.BusinessLogicInterfaces
{
    public interface ICountryBusinessLogic
    {
        List<Country> GetList(long eventId);

        List<EventCountryResult> GetResults(long eventId);
    }    
}
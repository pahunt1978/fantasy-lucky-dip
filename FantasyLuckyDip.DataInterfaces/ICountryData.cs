using System.Collections.Generic;
using FantasyLuckyDip.DataTransferObjects;

namespace FantasyLuckyDip.DataInterfaces
{
    public interface ICountryData
    {
        List<Country> GetList(long eventId);

        List<EventCountryResult> GetResults(long eventId);
    }
}
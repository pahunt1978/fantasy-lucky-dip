using System.Collections.Generic;
using FantasyLuckyDip.BusinessLogicInterfaces;
using FantasyLuckyDip.DataInterfaces;
using FantasyLuckyDip.DataTransferObjects;

namespace FantasyLuckyDip.BusinessLogic
{
    public class CountryBusinessLogic : ICountryBusinessLogic
    {
        private readonly ICountryData countryData;

        public CountryBusinessLogic(ICountryData countryData)
        {
            this.countryData = countryData;
        }

        public List<Country> GetList(long eventId)
        {
            return this.countryData.GetList(eventId);
        }

        public List<EventCountryResult> GetResults(long eventId)
        {
            return this.countryData.GetResults(eventId);
        }
    }
}
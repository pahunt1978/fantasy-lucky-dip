using System.Collections.Generic;
using FantasyLuckyDip.BusinessLogicInterfaces;
using FantasyLuckyDip.DataInterfaces;
using FantasyLuckyDip.DataTransferObjects;

namespace FantasyLuckyDip.BusinessLogic
{
    public class DisciplineBusinessLogic : IDisciplineBusinessLogic
    {
        private readonly IDisciplineData disciplineData;

        public DisciplineBusinessLogic(IDisciplineData disciplineData)
        {
            this.disciplineData = disciplineData;
        }

        public List<Discipline> GetList(long eventId)
        {
            return this.disciplineData.GetList(eventId);
        }
    }
}
using System.Collections.Generic;
using FantasyLuckyDip.DataTransferObjects;

namespace FantasyLuckyDip.BusinessLogicInterfaces
{
    public interface IDisciplineBusinessLogic
    {
        List<Discipline> GetList(long eventId);
    }
}
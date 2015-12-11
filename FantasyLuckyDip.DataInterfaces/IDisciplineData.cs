using System.Collections.Generic;
using FantasyLuckyDip.DataTransferObjects;

namespace FantasyLuckyDip.DataInterfaces
{
    public interface IDisciplineData
    {
        List<Discipline> GetList(long eventId);
    }
}
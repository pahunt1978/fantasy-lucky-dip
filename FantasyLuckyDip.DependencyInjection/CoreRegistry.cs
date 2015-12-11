using FantasyLuckyDip.BusinessLogic;
using FantasyLuckyDip.Data;
using StructureMap;

namespace FantasyLuckyDip.DependencyInjection
{
    internal class CoreRegistry : Registry
    {
        public CoreRegistry()
        {
            this.Scan(x =>
            {                
                x.AssemblyContainingType<ContestantBusinessLogic>();
                x.AssemblyContainingType<TwitterData>();
                x.WithDefaultConventions();
            });
        }
    }
}
using System;
using StructureMap;

namespace FantasyLuckyDip.DependencyInjection
{
    public static class StructureMapCoreSetup
    {
        public static IContainer Configure()
        {
            Action<ConfigurationExpression> configurationExpression = x =>
            {               
                x.AddRegistry<CoreRegistry>();             
            };

            return new Container(configurationExpression);
        }
    }
}

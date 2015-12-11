using FantasyLuckyDip.BusinessLogicInterfaces;
using FantasyLuckyDip.DataInterfaces;

namespace FantasyLuckyDip.BusinessLogic
{
    public class TwitterBusinessLogic : ITwitterBusinessLogic
    {
        private readonly ITwitterData twitterData;

        public TwitterBusinessLogic(ITwitterData twitterData)
        {
            this.twitterData = twitterData;
        }

        public byte[] GetProfileImage(string twitterHandle)
        {
            return this.twitterData.GetProfileImage(twitterHandle);
        }
    }
}
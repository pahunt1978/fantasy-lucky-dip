namespace FantasyLuckyDip.DataInterfaces
{
    public interface ITwitterData
    {
        /// <summary>
        /// Get the profile image for a user
        /// </summary>
        /// <param name="twitterHandle">The user's handle</param>
        /// <returns>The profile image as a byte array</returns>
        byte[] GetProfileImage(string twitterHandle);
    }
}

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using FantasyLuckyDip.DataInterfaces;
using Newtonsoft.Json;

namespace FantasyLuckyDip.Data
{
    public class TwitterData : ITwitterData
    {
        private const string BaseUrl = "https://api.twitter.com";
        private const string ConsumerKey = "z04Y8QbRab3uQZzh0YGJIqBMR";
        private const string ConsumerSecret = "RRFDsWkPlNfEV7vpugd0Gk8aOihwS2tRjkTuHd02EVZwto7UkN";
        private static readonly string EncodedConsumerKeySecret;
        private static readonly byte[] NotFoundImage;        

        static TwitterData()
        {
            EncodedConsumerKeySecret = GetEncodedConsumerKeySecret();
            NotFoundImage = GetNotFoundImage();
        }        

        public byte[] GetProfileImage(string twitterHandle)
        {
            byte[] profileImage = null;

            var bearerToken = GetBearerToken();            

            if (bearerToken != null)
            {
                var userData = GetDataFromApi<TwitterApiUser>($"users/show.json?screen_name={twitterHandle}", bearerToken);

                if (userData != null)
                {
                    var profileImageRequest = WebRequest.Create(userData.Profile_Image_Url_Https);
                    profileImageRequest.Method = "GET";
                    var profileImageResponse = profileImageRequest.GetResponse();
                    var profileImageResponseStream = profileImageResponse.GetResponseStream();

                    if (profileImageResponseStream != null)
                    {
                        using (var profileImageStream = new MemoryStream())
                        {
                            profileImageResponseStream.CopyTo(profileImageStream);
                            profileImage = profileImageStream.ToArray();
                        }
                    }
                }
            }          

            if (profileImage == null)
            {
                profileImage = NotFoundImage;
            }

            return profileImage ?? NotFoundImage;
        }

        /// <summary>
        /// Load the "not found" image into a static variable
        /// </summary>
        private static byte[] GetNotFoundImage()
        {
            var notFoundImageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("FantasyLuckyDip.Data.NotFound.png");

            if (notFoundImageStream != null)
            {
                var image = Image.FromStream(notFoundImageStream);

                using (var notFoundImageByteArray = new MemoryStream())
                {
                    image.Save(notFoundImageByteArray, ImageFormat.Png);
                    return notFoundImageByteArray.ToArray();
                }
            }

            return new byte[0];
        }

        /// <summary>
        /// Get data from the Twitter API
        /// </summary>
        /// <typeparam name="T">The type of object</typeparam>
        /// <param name="method">The name of the API method to call</param>
        /// <param name="bearerToken">The bearer token</param>
        /// <returns>The result of the API call</returns>
        private static T GetDataFromApi<T>(string method, string bearerToken) where T : TwitterApiUser
        {
            var webRequest = WebRequest.Create($"{BaseUrl}/1.1/{method}");
            webRequest.Method = "GET";
            webRequest.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {bearerToken}");
            Stream responseStream;

            try
            {
                var response = webRequest.GetResponse();
                responseStream = response.GetResponseStream();
            }
            catch (Exception)
            {
                responseStream = null;
            }

            if (responseStream != null)
            {
                var responseStreamReader = new StreamReader(responseStream);
                var responseJson = responseStreamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(responseJson);
            }

            return null;
        }

        /// <summary>
        /// Get the Twitter bearer token
        /// </summary>
        /// <returns>The bearer token</returns>
        private static string GetBearerToken()
        {
            var postDataBytes = Encoding.UTF8.GetBytes("grant_type=client_credentials");
            var webRequest = WebRequest.Create($"{BaseUrl}/oauth2/token");
            webRequest.Method = "POST";
            webRequest.Headers.Add(HttpRequestHeader.Authorization, $"Basic {EncodedConsumerKeySecret}");
            webRequest.ContentLength = postDataBytes.Length;
            webRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";

            using (var requestStream = webRequest.GetRequestStream())
            {
                requestStream.Write(postDataBytes, 0, postDataBytes.Length);
            }

            var response = webRequest.GetResponse();
            var responseStream = response.GetResponseStream();

            if (responseStream == null)
            {
                return null;
            }

            var responseStreamReader = new StreamReader(responseStream);
            var responseJson = responseStreamReader.ReadToEnd();
            var bearerToken = JsonConvert.DeserializeObject<TwitterApiBearerToken>(responseJson);

            return bearerToken.Access_Token;
        }

        /// <summary>
        /// Get the encoded consumer key secret
        /// </summary>
        /// <returns>The encoded consumer secret key</returns>
        private static string GetEncodedConsumerKeySecret()
        {
            var consumerKey = HttpUtility.UrlEncode(ConsumerKey);
            var consumerSecret = HttpUtility.UrlEncode(ConsumerSecret);
            var consumerKeySecret = $"{consumerKey}:{consumerSecret}";
            var consumerKeySecretBytes = System.Text.Encoding.UTF8.GetBytes(consumerKeySecret);
            var consumerKeySecretBase64 = Convert.ToBase64String(consumerKeySecretBytes);
            return consumerKeySecretBase64;
        }
    }
}

using System;
using System.IO;
using System.Net;
using System.Text;

namespace Stylelabs.MQA.WebApiTesting.Tests
{
    public class ApiResponse
    {
        private const string ApiUrlString = "http://api.openweathermap.org/data/2.5/weather?q=";
        private string ApiUrlStringWithKey;

        public string GetResponse(string city)
        {
            StringBuilder responseString = new StringBuilder();
            ApiUrlStringWithKey = String.Format(ApiUrlString + "{0}", city);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ApiUrlString);

            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            try
            {
                Stream receiveStream = response.GetResponseStream();

                if (receiveStream != null)
                {
                    StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                    string line = "";
                    while ((line = readStream.ReadLine()) != null)
                    {
                        responseString.Append(line);
                    }
                    response.Close();
                    readStream.Close();
                }
            }
            catch (Exception)
            {
                responseString.Append("Can't get response");

            }
            return responseString.ToString();
        }
    }
}
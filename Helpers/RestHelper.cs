namespace Highlight.API.Tests.Helpers
{
    using System;
    using System.Configuration;
    using System.Net;
    using RestSharp;
    using RestSharp.Deserializers;
    using System.Collections.Generic;

    /// <summary>
    // Helper class to perform API actions
    /// </summary>

    public class RestHelper
    {
        internal RestClient Endpoint { get; set; }
        internal CookieContainer Cookiecon { set; get; }

        public RestHelper()
        {
            Cookiecon = new CookieContainer();
        }

        public void SetUp()
        {
            SetEndpoint();
        }

        public RestClient SetEndpoint()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var baseUrl = appSettings.Get("baseUrl");

            Endpoint = new RestClient();
            Endpoint.ClearHandlers();
            Endpoint.BaseUrl = new Uri(baseUrl);
            Endpoint.AddHandler("text/html", new JsonDeserializer());
            Endpoint.CookieContainer = Cookiecon;
            return Endpoint;
        }

        /// <summary>
        /// Raw content string is output
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public string GetQuery(string query)
        {
            var request = new RestRequest(query, Method.GET);
            IRestResponse response = Endpoint.Execute(request);
            var content = response.Content; // raw content as string
            return content;
        }

        /// <summary>
        /// Structured content is output
        /// </summary>
        /// <param name="filtering"></param>
        /// <returns></returns>
        public PowerPlantsDTO GetParameterisedQuery(Dictionary<string, string> filtering)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "api/1.1/searchPlants";

            foreach (var filter in filtering)
            {
                request.AddParameter(filter.Key, filter.Value);                
            }

            var response = Endpoint.Execute<PowerPlantsDTO>(request).Data;
            return response;
        }


        #region Example POST and DELETE
        public void UpdatePrice(string query, string price)
        {
            var request = new RestRequest(query, Method.POST) { RequestFormat = DataFormat.Xml };
            var body = ("<resource><PRICE>" + price + "</PRICE></resource>");

            // client.Authenticator = new HttpBasicAuthenticator("UserA", "123");
            // request.AddParameter("Authorization", "data", ParameterType.HttpHeader);
            request.AddParameter("text/xml", body, ParameterType.RequestBody);
            Endpoint.Execute(request);
        }

        public void DeleteCustomer(string query)
        {
            var request = new RestRequest(query, Method.DELETE);
            Endpoint.Execute(request);
        }
        #endregion
    }
}
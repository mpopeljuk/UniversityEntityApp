using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;

namespace UniversityWeb.Helpers
{
    public class RequestHelper
    {
        public static RestClient client;

        static RequestHelper()
        {
            client = new RestClient();
            client.BaseUrl = new Uri("http://localhost:51056/api/");
        }

        public static IRestResponse<T> Get<T>(string url) where T : new()
        {
            var request = new RestRequest(url, Method.GET);
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                /// logic how to get token if user authenticated
                var claims = HttpContext.Current.User.Identity as System.Security.Claims.ClaimsIdentity;
                var token = 0;
            }

            var result = client.Execute<T>(request);

            return result;
        }
    }
}
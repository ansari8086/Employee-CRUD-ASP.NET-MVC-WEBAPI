using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Mvc
{
    public static class GlobalVariables
    {
        public static HttpClient webApiCleint = new HttpClient();

        static GlobalVariables()
        {
            webApiCleint.BaseAddress = new Uri("http://localhost:54063/api/");
            webApiCleint.DefaultRequestHeaders.Clear();
            webApiCleint.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
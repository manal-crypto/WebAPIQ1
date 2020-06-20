using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Net.Http.Headers;

namespace WebAPI
{
    public static class GlobalVariable
    {
        public static HttpClient Webapiclient = new HttpClient();
        static GlobalVariable()
        {
            Webapiclient.BaseAddress = new Uri("http://localhost:51685/api/");
            Webapiclient.DefaultRequestHeaders.Clear();
            Webapiclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));
        }
    }
}
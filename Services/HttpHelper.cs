using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GuardianSyncConsole.Services
{
    public class HttpHelper
    {
        private static async Task<HttpClient> GetAuthenticatedClientAsync()
        {
            HttpClient httpClient = new HttpClient();
            try
            {
                string empty = string.Empty;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://guardian.360facility.net/MobileWebServices/");
                    HttpResponseMessage httpResponseMessage = await client.PostAsync("api/login", (HttpContent)new StringContent(JsonConvert.SerializeObject((object)new ApiLogin()
                    {
                        UserName = ConfigurationManager.AppSettings["ApiUser"],
                        Password = ConfigurationManager.AppSettings["ApiPass"]
                    }), Encoding.UTF8, "application/json"));
                    httpResponseMessage.EnsureSuccessStatusCode();
                    empty = ((object)JObject.Parse(await httpResponseMessage.Content.ReadAsStringAsync())["Item"][(object)"access_token"]).ToString();
                }
                httpClient.BaseAddress = new Uri("https://guardian.360facility.net/MobileWebServices/");
                if (!string.IsNullOrEmpty(empty))
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", empty);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            HttpClient authenticatedClientAsync = httpClient;
            httpClient = (HttpClient)null;
            return authenticatedClientAsync;
        }

        public static async Task<List<T>> GetEntities<T>(string entityName)
        {
            ILog mLoggerHttpHelper = LogManager.GetLogger("servicelog");
            List<T> mapped_content = new List<T>();
            List<T> objList = new List<T>();
            using (HttpClient client = await HttpHelper.GetAuthenticatedClientAsync())
            {
                int num1 = 0;
                int num2 = num1 - 1;
                try
                {
                    int z = 0;
                    int limit = 0;
                    List<T> values;
                    do
                    {
                        HttpResponseMessage async = await client.GetAsync("apis/360facility/v1/" + entityName + string.Format("?%24skip={0}", (object)z));
                        async.EnsureSuccessStatusCode();
                        string content = await async.Content.ReadAsStringAsync();
                        values = HttpHelper.GetValues<T>(content, JObject.Parse(content));
                        foreach (T obj in values)
                            mapped_content.Add(obj);
                        z += values.Count;
                    }
                    while (values.Count > limit);
                    return mapped_content;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("HttpHelper get Entities Exception :{0} ", (object)ex.Message);
                    mLoggerHttpHelper.Info((object)("-GetEntities Error: [" + ex.Message + "]"));
                    return mapped_content;
                }
            }
        }

        public static async Task<List<T>> GetEntitiesNew<T>(string entityName, int skip)
        {
            ILog mLoggerHttpHelper = LogManager.GetLogger("servicelog");
            List<T> objList = new List<T>();
            using (HttpClient client = await HttpHelper.GetAuthenticatedClientAsync())
            {
                int num1 = 0;
                int num2 = num1 - 1;
                try
                {
                    HttpResponseMessage async = await client.GetAsync("apis/360facility/v1/" + entityName + "?%24skip=" + Convert.ToString(skip) + " " + ("workorders".Equals(entityName) ? "&%24filter=CreateDate gt 2021-01-01T00:00:00Z" : ""));
                    async.EnsureSuccessStatusCode();
                    string content = await async.Content.ReadAsStringAsync();
                    objList = HttpHelper.GetValues<T>(content, JObject.Parse(content));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("HttpHelper get Entities Exception :{0} ", (object)ex.Message);
                    mLoggerHttpHelper.Error((object)("[GetEntitiesNew] Error: [" + ex.Message + "]"));
                    objList = new List<T>();
                }
            }
            List<T> entitiesNew = objList;
            mLoggerHttpHelper = (ILog)null;
            return entitiesNew;
        }

        public static async Task<List<T>> GetEntities_WorkOrderChargeToAccounts<T>(
          string entityName,
          long ReqID)
        {
            ILog mLoggerHttpHelper = LogManager.GetLogger("servicelog");
            List<T> objList = new List<T>();
            using (HttpClient client = await HttpHelper.GetAuthenticatedClientAsync())
            {
                int num1 = 0;
                int num2 = num1 - 1;
                try
                {
                    HttpResponseMessage async = await client.GetAsync("apis/360facility/v1/" + entityName + "?%24filter=RequestId eq " + Convert.ToString(ReqID));
                    async.EnsureSuccessStatusCode();
                    string content = await async.Content.ReadAsStringAsync();
                    objList = HttpHelper.GetValues<T>(content, JObject.Parse(content));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("HttpHelper get Entities Exception :{0} ", (object)ex.Message);
                    mLoggerHttpHelper.Error((object)("[GetEntitiesNew] Error: [" + ex.Message + "]"));
                    objList = new List<T>();
                }
            }
            List<T> chargeToAccounts = objList;
            mLoggerHttpHelper = (ILog)null;
            return chargeToAccounts;
        }

        private static List<T> GetValues<T>(string content, JObject x)
        {
            List<T> values = new List<T>();
            if (x.ContainsKey("value"))
            {
                JToken source = x.GetValue("value");
                if (((IEnumerable<JToken>)source).Count<JToken>() > 0)
                {
                    foreach (JToken jtoken in (IEnumerable<JToken>)source)
                    {
                        T obj = jtoken.ToObject<T>();
                        values.Add(obj);
                    }
                }
            }
            return values;
        }
    }
}

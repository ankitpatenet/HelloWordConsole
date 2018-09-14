using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using HelloWord.API.Client.Core.Json;
using Newtonsoft.Json;

namespace HelloWord.API.Client.Core
{
    public class CallApi
    {
        private static readonly string ApiUrlAppSetting = ConfigurationManager.AppSettings["HelloWordUrl"];

        /// <summary>
        ///     This method will read Hello word from API
        ///     we should move standard API url etc when we
        ///     call new endpoint to insert data
        /// </summary>
        public static void GetHelloWord()
        {
            var client = GetHttpClient();
            HelloWordResponseJson model = null;
            var task = client.GetAsync($"{ApiUrlAppSetting}/GetAllHelloWord")
                .ContinueWith(taskwithresponse =>
                {
                    var response = taskwithresponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    model = JsonConvert.DeserializeObject<HelloWordResponseJson>(jsonString.Result);
                });
            task.Wait();
            Console.WriteLine(model?.Word);
            Console.Read();
        }

        /// <summary>
        ///     Common HTTPClient which has response json Response Type
        /// </summary>
        /// <returns></returns>
        private static HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
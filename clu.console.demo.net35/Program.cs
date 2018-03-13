using clu.console.library;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using System;
using System.Collections.Generic;
using System.Net;

namespace clu.console.demo.net35
{
    class Program
    {
        private class PostData
        {
            public string Message { get; set; }
        }

        private static object Post(object data, Uri webApiUrl)
        {
            var client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";

            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            string serialisedData = JsonConvert.SerializeObject(data, serializerSettings);

            var response = client.UploadString(webApiUrl, serialisedData);

            return JsonConvert.DeserializeObject(response);
        }

        private static void TestSomeLogging()
        {
            try
            {
                var data = new PostData { Message = "of course this api works!" };

                var result = Post(data, new Uri("http://localhost/clu.logging.webapi/Logging/Debug"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void TestRandomLogging()
        {
            try
            {
                var data = new PostData { Message = "it needs more implementation though..." };

                var result = Post(data, new Uri("http://localhost/clu.logging.webapi/Logging/Debug"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static void Main(string[] args)
        {
            ConsoleHelper.Initialize(".NET 3.5.0");
            ConsoleHelper.ShowMenu(
                 new List<MenuItem>
                 {
                    new MenuItem(1, "Test some logging", TestSomeLogging),
                    new MenuItem(2, "Test random logging", TestRandomLogging),
                 });
        }
    }
}

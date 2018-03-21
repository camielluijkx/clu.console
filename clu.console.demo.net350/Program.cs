using clu.console.library.net350;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using System;
using System.Collections.Generic;
using System.Net;

namespace clu.console.demo.net350
{
    class Program
    {
        private class PostData
        {
            public string Message { get; set; }
        }

        private static object Get(Uri webApiUrl)
        {
            var client = new WebClient { Headers = { [HttpRequestHeader.ContentType] = "application/json" } };

            var response = client.DownloadString(webApiUrl);

            return JsonConvert.DeserializeObject(response);
        }

        private static object Post(object data, Uri webApiUrl)
        {
            var client = new WebClient {Headers = {[HttpRequestHeader.ContentType] = "application/json"}};

            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var serialisedData = JsonConvert.SerializeObject(data, serializerSettings);

            var response = client.UploadString(webApiUrl, serialisedData);

            return JsonConvert.DeserializeObject(response);
        }

        private static void TestSomeLogging()
        {
            //GlobalContext.Properties["correlationId"] = Guid.NewGuid(); // [TODO] 1)

            try
            {
                Post(new PostData { Message = "some debug message" }, new Uri("http://localhost/clu.logging.webapi/Logging/Debug"));
                Post(new PostData { Message = "some error message" }, new Uri("http://localhost/clu.logging.webapi/Logging/Error"));
                Post(new PostData { Message = "some fatal message" }, new Uri("http://localhost/clu.logging.webapi/Logging/Fatal"));
                Post(new PostData { Message = "some info message" }, new Uri("http://localhost/clu.logging.webapi/Logging/Info"));
                Post(new PostData { Message = "some warn message" }, new Uri("http://localhost/clu.logging.webapi/Logging/Warn"));

                Post(new PostData { Message = "some secret password" }, new Uri("http://localhost/clu.logging.webapi/Logging/Info"));

                //throw new Exception("some exception occurred");

                //await Log4netLogger.Instance.LogErrorAsync("kaboom!", new ApplicationException("The application exploded!!")); // [TODO] 1)
            }
            catch (Exception ex)
            {
                //await Log4netLogger.Instance.LogErrorAsync("Error trying to do something:", ex); // [TODO] 1)
            }
        }

        private static void TestRandomLogging()
        {
            //GlobalContext.Properties["correlationId"] = Guid.NewGuid(); // [TODO] 1)

            try
            {
                var ipsum = Get(new Uri("https://baconipsum.com/api/?type=all-meat&paras=1&start-with-lorem=0&format=text")); // [TODO] 1)

                var random = new Random();

                var dice = random.Next(1, 7);

                switch (dice)
                {
                    case 1:
                    {
                        Post(new PostData { Message = ipsum.ToString() }, new Uri("http://localhost/clu.logging.webapi/Logging/Debug")); // [TODO] 1)
                        break;
                    }
                    case 2:
                    {
                        Post(new PostData { Message = ipsum.ToString() }, new Uri("http://localhost/clu.logging.webapi/Logging/Error")); // [TODO] 1)
                        break;
                    }
                    case 3:
                    {
                        Post(new PostData { Message = ipsum.ToString() }, new Uri("http://localhost/clu.logging.webapi/Logging/Fatal")); // [TODO] 1)
                        break;
                    }
                    case 4:
                    {
                        Post(new PostData { Message = ipsum.ToString() }, new Uri("http://localhost/clu.logging.webapi/Logging/Info")); // [TODO] 1)
                        break;
                    }
                    case 5:
                    {
                        Post(new PostData { Message = ipsum.ToString() }, new Uri("http://localhost/clu.logging.webapi/Logging/Warn")); // [TODO] 1)
                        break;
                    }
                    //case 6:
                    //{
                    //    await Log4netLogger.Instance.LogErrorAsync("bad luck", new Exception("no meat today")); // [TODO] 1)
                    //    break;
                    //}
                }
            }
            catch (Exception ex)
            {
                //await Log4netLogger.Instance.LogErrorAsync("Error trying to do something", ex); // [TODO] 1)
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

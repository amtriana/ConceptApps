using Aliencube.XslMapper.FunctionApp.Models;
using System;
using System.Net;
using System.Net.Http;
using Aliencube.AzureFunctions.Extensions.DependencyInjection;
using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using Aliencube.XslMapper.FunctionApp.Functions;
using Aliencube.XslMapper.FunctionApp.Models;
using Aliencube.XslMapper.FunctionApp.Modules;

using Microsoft.Azure.WebJobs;
//using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static IFunctionFactory Factory { get; set; } = new FunctionFactory(new AppModule());
        public static ILoggerFactory LogFactory { get; set; } = new LoggerFactory();
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var result = (HttpResponseMessage)null;
            try
            {
                var req = new HttpRequestMessage(HttpMethod.Get, "http://example.com");
                               
                ILogger log = LogFactory.CreateLogger("XXX");
                result = await Factory.Create<IXmlToXmlMapperFunction, ILogger>(log)
                                      .InvokeAsync<HttpRequestMessage, HttpResponseMessage>(req)
                                      .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var statusCode = HttpStatusCode.InternalServerError;
                var response = new ErrorResponse((int)statusCode, ex.Message, ex.StackTrace);

               // result = req.CreateResponse(statusCode, response);
            }

        }
    }
}

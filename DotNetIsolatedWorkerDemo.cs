using Newtonsoft.Json;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using My.Function.Business;
using My.Function.Models;

namespace My.Function
{
    public class DotNetIsolatedWorkerDemo
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ILogger _logger;

        public DotNetIsolatedWorkerDemo(ILoggerFactory loggerFactory, ITodoRepository todoRepository)
        {
            _logger = loggerFactory.CreateLogger<DotNetIsolatedWorkerDemo>();
            _todoRepository = todoRepository;
        }

        [Function("todos")]
        public async Task<HttpResponseData> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "todos/{method}")] HttpRequestData req, string method)
        {
            _logger.LogInformation($"C# HTTP trigger function processed a request. Method is {method}");

            var response = req.CreateResponse(HttpStatusCode.OK);

            if(method.Equals("add"))
            {
                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var payload = JsonConvert.DeserializeObject<Todo>(requestBody);
                var todo = _todoRepository.Add(payload);
                _logger.LogInformation("Todo added to DB");
                await response.WriteAsJsonAsync(todo);
            }
            else if(method.Equals("getall"))
            {
                var todoList = _todoRepository.GetAll();
                _logger.LogInformation("List of Todos returned from DB");
                await response.WriteAsJsonAsync(todoList);
            }

            return response;
        }
    }
}
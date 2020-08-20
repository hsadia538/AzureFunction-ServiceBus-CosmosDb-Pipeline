using Microsoft.Azure.Documents.SystemFunctions;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

namespace RecieveFromTopic
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([ServiceBusTrigger("practicetopic", "sub1", Connection = "MyServiceBus")]string mySbMsg,
            [CosmosDB(
            databaseName:"Company",
            collectionName:"Employee",
            ConnectionStringSetting = "myCosmosDB")]out dynamic document,ILogger log)
        {

            
            document = new { Description = mySbMsg, id = Guid.NewGuid() };
            log.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");

            

            
        }
    }
}

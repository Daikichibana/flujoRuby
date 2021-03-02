namespace apiProductor.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using Azure.Messaging.ServiceBus;
    using apiProductor.Models;
    using Newtonsoft.Json;

    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpPost]
        public async Task<bool> enviarAsync([FromBody] Data data)
        {
            string connectionString = "Endpoint=sb://queuedaiki.servicebus.windows.net/;SharedAccessKeyName=enviar;SharedAccessKey=pZhNPly8pe73HUW4wt8PC62YEPZ3iZn9HDmwveTWAhw=;EntityPath=cola1";
            string queueName = "cola1";
            String mensaje  = JsonConvert.SerializeObject(data);

            // create a Service Bus client 
            await using (ServiceBusClient client = new ServiceBusClient(connectionString))
            {
                // create a sender for the queue 
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage(mensaje);

                // send the message
                await sender.SendMessageAsync(message);
                Console.WriteLine($"Sent a single message to the queue: {queueName}");
            }


            return true;
        } 
    }
}

using Azure.Storage.Queues;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;

namespace TicketHub_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcertTicketsController : ControllerBase
    {
        private readonly ILogger<ConcertTicketsController> _logger;
        private IConfiguration _configuration;

        public ConcertTicketsController(ILogger<ConcertTicketsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from ConcertTicketsController - GET");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Ticket ticket)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            string queueName = "tickets";

            string? connectionString = _configuration["AzureStorageConnectionString"];

            if (string.IsNullOrEmpty(connectionString)) 
            {
                return BadRequest("An error was encountered");
            }
            
            QueueClient queueClient = new QueueClient(connectionString, queueName);

            // serialize an object to json
            string message = JsonSerializer.Serialize(ticket);

            // send string message to queue
            await queueClient.SendMessageAsync("Hello from my api");

            return Ok("Hello " + ticket.Name + ". Ticket sent to storage queue.");
        }
    }
}

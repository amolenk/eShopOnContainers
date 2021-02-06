using System;
using System.Threading.Tasks;
using Dapr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Payment.API.IntegrationEvents.EventHandling;
using Payment.API.IntegrationEvents.Events;

namespace Payment.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IntegrationEventController : ControllerBase
    {
        private const string DaprPubSubName = "pubsub";

        private readonly IServiceProvider _serviceProvider;

        public IntegrationEventController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost("OrderStatusChangedToStockConfirmed")]
        [Topic(DaprPubSubName, "OrderStatusChangedToStockConfirmedIntegrationEvent")]
        public async Task OrderStarted(OrderStatusChangedToStockConfirmedIntegrationEvent @event)
        {
            var handler = _serviceProvider.GetRequiredService<OrderStatusChangedToStockConfirmedIntegrationEventHandler>();
            await handler.Handle(@event);
        }
    }
}
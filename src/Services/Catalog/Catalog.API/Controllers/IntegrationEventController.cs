using System;
using System.Threading.Tasks;
using Dapr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.eShopOnContainers.Services.Catalog.API.IntegrationEvents.EventHandling;
using Microsoft.eShopOnContainers.Services.Catalog.API.IntegrationEvents.Events;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.API.Controllers
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

        [HttpPost("OrderStatusChangedToAwaitingValidation")]
        [Topic(DaprPubSubName, "OrderStatusChangedToAwaitingValidationIntegrationEvent")]
        public async Task OrderStatusChangedToAwaitingValidationIntegrationEvent(OrderStatusChangedToAwaitingValidationIntegrationEvent @event)
        {
            var handler = _serviceProvider.GetRequiredService<OrderStatusChangedToAwaitingValidationIntegrationEventHandler>();
            await handler.Handle(@event);
        }

        [HttpPost("OrderStatusChangedToPaid")]
        [Topic(DaprPubSubName, "OrderStatusChangedToPaidIntegrationEvent")]
        public async Task OrderStatusChangedToPaidIntegrationEvent(OrderStatusChangedToPaidIntegrationEvent @event)
        {
            var handler = _serviceProvider.GetRequiredService<OrderStatusChangedToPaidIntegrationEventHandler>();
            await handler.Handle(@event);
        }
    }
}

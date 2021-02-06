using System;
using System.Threading.Tasks;
using Dapr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Ordering.SignalrHub.IntegrationEvents;
using Ordering.SignalrHub.IntegrationEvents.EventHandling;
using Ordering.SignalrHub.IntegrationEvents.Events;

namespace Ordering.SignalrHub.Controllers
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
        public async Task Event(OrderStatusChangedToAwaitingValidationIntegrationEvent @event)
        {
            var handler = _serviceProvider.GetRequiredService<OrderStatusChangedToAwaitingValidationIntegrationEventHandler>();
            await handler.Handle(@event);
        }

        [HttpPost("OrderStatusChangedToCancelled")]
        [Topic(DaprPubSubName, "OrderStatusChangedToCancelledIntegrationEvent")]
        public async Task Event(OrderStatusChangedToCancelledIntegrationEvent @event)
        {
            var handler = _serviceProvider.GetRequiredService<OrderStatusChangedToCancelledIntegrationEventHandler>();
            await handler.Handle(@event);
        }

        [HttpPost("OrderStatusChangedToPaid")]
        [Topic(DaprPubSubName, "OrderStatusChangedToPaidIntegrationEvent")]
        public async Task Event(OrderStatusChangedToPaidIntegrationEvent @event)
        {
            var handler = _serviceProvider.GetRequiredService<OrderStatusChangedToPaidIntegrationEventHandler>();
            await handler.Handle(@event);
        }

        [HttpPost("OrderStatusChangedToShipped")]
        [Topic(DaprPubSubName, "OrderStatusChangedToShippedIntegrationEvent")]
        public async Task Event(OrderStatusChangedToShippedIntegrationEvent @event)
        {
            var handler = _serviceProvider.GetRequiredService<OrderStatusChangedToShippedIntegrationEventHandler>();
            await handler.Handle(@event);
        }

        [HttpPost("OrderStatusChangedToStockConfirmed")]
        [Topic(DaprPubSubName, "OrderStatusChangedToStockConfirmedIntegrationEvent")]
        public async Task Event(OrderStatusChangedToStockConfirmedIntegrationEvent @event)
        {
            var handler = _serviceProvider.GetRequiredService<OrderStatusChangedToStockConfirmedIntegrationEventHandler>();
            await handler.Handle(@event);
        }

        [HttpPost("OrderStatusChangedToSubmitted")]
        [Topic(DaprPubSubName, "OrderStatusChangedToSubmittedIntegrationEvent")]
        public async Task Event(OrderStatusChangedToSubmittedIntegrationEvent @event)
        {
            var handler = _serviceProvider.GetRequiredService<OrderStatusChangedToSubmittedIntegrationEventHandler>();
            await handler.Handle(@event);
        }
    }
}

using System;
using System.Threading.Tasks;
using Dapr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Webhooks.API.IntegrationEvents;

namespace Microsoft.eShopOnContainers.Services.Ordering.API.Controllers
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

        [HttpPost("ProductPriceChanged")]
        [Topic(DaprPubSubName, "ProductPriceChangedIntegrationEvent")]
        public async Task Event(ProductPriceChangedIntegrationEvent @event)
        {
            var handler = _serviceProvider.GetRequiredService<ProductPriceChangedIntegrationEventHandler>();
            await handler.Handle(@event);
        }
    }
}

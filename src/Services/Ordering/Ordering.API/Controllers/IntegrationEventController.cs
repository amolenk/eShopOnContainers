using System;
using System.Threading.Tasks;
using Dapr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Ordering.API.Application.IntegrationEvents.EventHandling;
using Ordering.API.Application.IntegrationEvents.Events;

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

        [HttpPost("GracePeriodConfirmed")]
        [Topic(DaprPubSubName, "GracePeriodConfirmedIntegrationEvent")]
        public async Task Event(GracePeriodConfirmedIntegrationEvent @event)
        {
            var handler = _serviceProvider.GetRequiredService<GracePeriodConfirmedIntegrationEventHandler>();
            await handler.Handle(@event);
        }

        [HttpPost("OrderPaymentFailed")]
        [Topic(DaprPubSubName, "OrderPaymentFailedIntegrationEvent")]
        public async Task Event(OrderPaymentFailedIntegrationEvent @event)
        {
            var handler = _serviceProvider.GetRequiredService<OrderPaymentFailedIntegrationEventHandler>();
            await handler.Handle(@event);
        }

        [HttpPost("OrderPaymentSucceeded")]
        [Topic(DaprPubSubName, "OrderPaymentSucceededIntegrationEvent")]
        public async Task Event(OrderPaymentSucceededIntegrationEvent @event)
        {
            var handler = _serviceProvider.GetRequiredService<OrderPaymentSucceededIntegrationEventHandler>();
            await handler.Handle(@event);
        }

        [HttpPost("OrderStockConfirmed")]
        [Topic(DaprPubSubName, "OrderStockConfirmedIntegrationEvent")]
        public async Task Event(OrderStockConfirmedIntegrationEvent @event)
        {
            var handler = _serviceProvider.GetRequiredService<OrderStockConfirmedIntegrationEventHandler>();
            await handler.Handle(@event);
        }

        [HttpPost("OrderStockRejected")]
        [Topic(DaprPubSubName, "OrderStockRejectedIntegrationEvent")]
        public async Task Event(OrderStockRejectedIntegrationEvent @event)
        {
            var handler = _serviceProvider.GetRequiredService<OrderStockRejectedIntegrationEventHandler>();
            await handler.Handle(@event);
        }

        [HttpPost("UserCheckoutAccepted")]
        [Topic(DaprPubSubName, "UserCheckoutAcceptedIntegrationEvent")]
        public async Task Event(UserCheckoutAcceptedIntegrationEvent @event)
        {
            var handler = _serviceProvider.GetRequiredService<UserCheckoutAcceptedIntegrationEventHandler>();
            await handler.Handle(@event);
        }
    }
}

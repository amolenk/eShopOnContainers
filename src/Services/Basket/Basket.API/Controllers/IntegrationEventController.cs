using System;
using System.Threading.Tasks;
using Basket.API.IntegrationEvents.Events;
using Dapr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.eShopOnContainers.Services.Basket.API.Model;

namespace Microsoft.eShopOnContainers.Services.Basket.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IntegrationEventController : ControllerBase
    {
        private readonly IBasketRepository _repository;

        public IntegrationEventController(IBasketRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost("OrderStarted")]
        [Topic("pubsub", "OrderStartedIntegrationEvent")]
        public Task Handle(OrderStartedIntegrationEvent @event)
        {
            return _repository.DeleteBasketAsync(@event.UserId.ToString());
        }
    }
}

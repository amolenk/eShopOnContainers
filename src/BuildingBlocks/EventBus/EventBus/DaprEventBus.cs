using System;
using Dapr.Client;
using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Abstractions;
using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;

namespace Microsoft.eShopOnContainers.BuildingBlocks.EventBus
{
    public class DaprEventBus : IEventBus
    {
        private const string PubSubName = "pubsub";

        private readonly DaprClient _daprClient;

        public DaprEventBus(DaprClient daprClient)
        {
            _daprClient = daprClient ?? throw new ArgumentNullException(nameof(daprClient));
        }

        public void Publish(IntegrationEvent @event)
        {
            var topicName = @event.GetType().Name;

            _daprClient.PublishEventAsync<object>(PubSubName, topicName, @event)
                .GetAwaiter()
                .GetResult();
        }

        public void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
        }
    }
}

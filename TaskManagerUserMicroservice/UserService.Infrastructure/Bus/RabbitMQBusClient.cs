using System;
namespace UserService.Infrastructure.Bus
{
	public class RabbitMQBusClient : IBus
	{
		public RabbitMQBusClient()
		{
		}

        public void Publish(object message, Type messageType)
        {
            throw new NotImplementedException();
        }

        public void Publish<T>(T message)
        {
            throw new NotImplementedException();
        }
    }
}


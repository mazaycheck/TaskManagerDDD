using System;
namespace UserService.Infrastructure.Bus
{
	public interface IBus
	{
		public void Publish(object message, Type messageType);
        public void Publish<T>(T message);
    }
}


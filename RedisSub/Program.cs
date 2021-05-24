using ServiceStack.Redis;
using System;

/// <summary>
/// 创建一个RedisSub项目用来模拟订阅客户端
/// </summary>
namespace RedisSub
{
    class Program
    {
        static void Main(string[] args)
        {
			try
			{
				using (RedisClient consumer = new RedisClient("127.0.0.1", 6379))
				{

					Console.WriteLine($"这是订阅客户端");
					var subscription = consumer.CreateSubscription();
					//接受到消息时
					subscription.OnMessage = (channel, msg) =>
					{
						if (msg != "CTRL:PULSE")
						{
							//此处可以写入日志记录

						}

					};
					//订阅频道时
					subscription.OnSubscribe = (channel) =>
					{
						Console.WriteLine("订阅客户端：开始订阅" + channel);
					};
					//取消订阅频道时
					subscription.OnUnSubscribe = (a) => { Console.WriteLine("订阅客户端：取消订阅"); };
					//订阅频道
					string topicname = "Tom is a good cat";
					subscription.SubscribeToChannels(topicname);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

		}
    }
}

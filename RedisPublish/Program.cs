using ServiceStack.Redis;
using System;

/// <summary>
/// 1.首先创建一个RedisPublish项目用来模拟发布服务器
/// </summary>
namespace RedisPublish
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //创建一个公众号--创建一个主题
                Console.WriteLine("SendMessage");
                IRedisClientsManager redisClientManager = new PooledRedisClientManager("127.0.0.1:6379");
                string topicname = "Tom is a good cat";
                RedisPubSubServer pubSubServer = new RedisPubSubServer(redisClientManager, topicname)
                {
                    OnMessage = (channel, msg) =>
                    {
                        //此处可以写入日志记录
                        Console.WriteLine("___________________________________________________________________");
                    },
                    OnStart = () =>
                    {
                        Console.WriteLine("发布服务已启动");
                        Console.WriteLine("___________________________________________________________________");
                    },
                    OnStop = () => { Console.WriteLine("发布服务停止"); },
                    OnUnSubscribe = channel => { Console.WriteLine(channel); },
                    OnError = e => { Console.WriteLine(e.Message); },
                    OnFailover = s => { Console.WriteLine(s); },
                };
                //接收消息
                pubSubServer.Start();
                while (true)
                {
                    Console.WriteLine("请输入推送内容");
                    string message = Console.ReadLine();
                    redisClientManager.GetClient().PublishMessage(topicname, message);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}

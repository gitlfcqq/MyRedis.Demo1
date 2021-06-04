using MyRedisPubSubSms.Sms;
using RedisLibrary;
using System;

namespace MyRedisPubSubSms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("消息微服务开始订阅数据库消息!");

            //订阅数据库主题
            RedisPubSub redisPubSub = new RedisPubSub();

            //订阅主题和处理消息
            redisPubSub.Sub("database", message =>
            {
                //获取数据库主题消息
                string databaseEnv = message.Message;

                //逻辑处理，数据库更换
                RmSms rmSms = new RmSms();
                rmSms.UpdateDataBase(databaseEnv);

            });

            Console.ReadKey();
        }
    }
}

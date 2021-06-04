using MyRedisPubSubUser.User;
using RedisLibrary;
using System;

namespace MyRedisPubSubUser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("人员微服务开始订阅数据库消息!");

            //订阅数据库主题
            RedisPubSub redisPubSub = new RedisPubSub();

            //订阅主题和处理消息
            redisPubSub.Sub("database", message =>
            {
                //获取数据库主题消息
                string databaseEnv = message.Message;

                //逻辑处理，数据库更换
                RmUser rmSms = new RmUser();
                rmSms.UpdateDataBase(databaseEnv);

            });
        }
    }
}

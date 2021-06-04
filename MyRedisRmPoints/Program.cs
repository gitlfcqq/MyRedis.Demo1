using MyRedisRmPoints.Async;
using RedisLibrary;
using System;

namespace MyRedisRmPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var messageQueue = new RedisMessageQueue("localhost:6379"))
            {
                while (true)
                {
                    //获取积分消息
                    string order_sn = messageQueue.BDeQueue("rm_points", TimeSpan.FromSeconds(60));
                    if (!string.IsNullOrEmpty(order_sn))
                    {
                        //消费积分消息
                        RmOrderPoints rmOrderPoints = new RmOrderPoints();
                        rmOrderPoints.AddPoint(order_sn);
                    }
                }
            }
        }
    }
}

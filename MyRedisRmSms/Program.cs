using MyRedisRmSms.Async;
using RedisLibrary;
using System;

namespace MyRedisRmSms
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var messageQueue = new RedisMessageQueue("localhost:6379"))
            {
                while (true)
                {
                    //获取发送短信消息
                    string order_sn = messageQueue.BDeQueue("rm_sms", TimeSpan.FromSeconds(60));

                    if (!string.IsNullOrEmpty(order_sn))
                    {
                        //消费发送短信消息
                        RmOrderSms rmOrderSms = new RmOrderSms();
                        rmOrderSms.SendSms(order_sn);
                    }

                }
            }
        }
    }
}

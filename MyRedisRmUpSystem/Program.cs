using MyRedisRmUpSystem.FlowLimit;
using MyRedisRmUpSystem.MQ;
using System;

namespace MyRedisRmUpSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var messageQueue = new RedisMessageQueue("localhost:6379"))
            {
                Console.WriteLine("秒杀上游消息.......");
                //获取积分消息
                while (true)
                {
                    //消息秒杀上游消息
                    string order_sn = messageQueue.BDeQueue("rm_skills", TimeSpan.FromSeconds(60));

                    if (!string.IsNullOrEmpty(order_sn))
                    {
                        //下游业务逻辑
                        Console.WriteLine($"开始秒杀业务处理");
                        RmSkillsDownStream rmSkillsDownStream = new RmSkillsDownStream();
                        
                        //秒杀业务处理
                        rmSkillsDownStream.HandleRequest(order_sn);
                        Console.WriteLine($"完成秒杀业务处理");
                    }

                }
            }
        }
    }
}

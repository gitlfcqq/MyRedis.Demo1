
using RedisLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRedisMq.FlowLimit
{
    class RmSkillsUpstream
    {
        /// <summary>
        /// 处理最大流量请求数
        /// </summary>
        private int HandleRequestCount = 1000;
        /// <summary>
        /// 所有流量请求入口
        /// </summary>
        /// <param name="requestCount"></param>
        public void CreateSkillOrder(int requestCount)
        {

            Console.WriteLine($"秒杀请求数量:{requestCount}");

            //系统宕机
            //if (HandleRequestCount < requestCount)
            //{
            //}
            //使用redis消息队列优化流量请求
            using (var messageQueue = new RedisMessageQueue("localhost:6379"))
            {
                for (int i = 0; i < requestCount; i++)
                {
                    long counts = messageQueue.GetQueueCount("rm_skills");
                    if (counts > HandleRequestCount)
                    {
                        Console.WriteLine($"系统正在系统繁忙，{i}请稍候！");
                    }
                    else
                    {
                        //写入队列，rm_skills 用户编号
                        Console.WriteLine($"{i}:入队成功!");
                        messageQueue.EnQueue("rm_skills", i + "");
                    }
                }
            }

            #region 直接调用下游业务消费
            //Console.WriteLine($"开始调用下游秒杀业务");
            //RmSkillsDownStream rmSkillsDownStream = new RmSkillsDownStream();

            //rmSkillsDownStream.HandleRequest(requestCount);
            //Console.WriteLine($"完成调用下游秒杀业务"); 
            #endregion

            #region 拆分解耦消费
            //通过MyRedisRmUpSystem调用上游服务进行
            #endregion
        }
    }
}

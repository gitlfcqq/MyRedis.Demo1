using MyRedisMq.Async;
using MyRedisMq.FlowLimit;
using System;

namespace MyRedisMq
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            #region 异步处理
            //{
            //    RmOrder rmOrder = new RmOrder();
            //    rmOrder.CreateOder();
            //}

            #endregion

            #region 解耦优化
            /**
             * 将MyRedisMq拆分为以下几部分
             * MyRedisRmPoints
             * MyRedisRmSms
             * RedisLibrary
             */
            #endregion

            #region 流量削峰
            {
                //流量请求上游封装处理
                RmSkillsUpstream rmSkillsUpstream = new RmSkillsUpstream();
                rmSkillsUpstream.CreateSkillOrder(2000);
            }
            #endregion


            Console.ReadKey();
        }
    }
}

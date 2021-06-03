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

            #endregion

            #region 流量削峰
            {
                RmSkillsUpstream rmSkillsUpstream = new RmSkillsUpstream();
                rmSkillsUpstream.CreateSkillOrder(2000);
            }
            #endregion


            Console.ReadKey();
        }
    }
}

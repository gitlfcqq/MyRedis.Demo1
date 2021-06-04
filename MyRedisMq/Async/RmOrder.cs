using RedisLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRedisMq.Async
{
    /// <summary>
    /// 订单服务
    /// </summary>
    class RmOrder
    {
        public string CreateOder()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //订单生成
            string order_sn = Guid.NewGuid().ToString();

            //存储到数据库
            Thread.Sleep(1000);
            Console.WriteLine($"order_sn:{order_sn},存储到数据库成功！");

            #region 常规做法
            //添加积分
            //Console.WriteLine($"开始调用积分服务！");
            //RmOrderPoints rmOrderPoints = new RmOrderPoints();
            //rmOrderPoints.AddPoint(order_sn);
            //Console.WriteLine($"完成调用积分服务！");

            ////发送短信
            //Console.WriteLine($"开始调用发送短信服务！");
            //RmOrderSms rmOrderSms = new RmOrderSms();
            //rmOrderSms.SendSms(order_sn);
            //Console.WriteLine($"完成发送短信服务！");
            #endregion

            #region redis优化
            using (var messageQueue = new RedisMessageQueue("localhost:6379"))
            {
                //发送积分
                messageQueue.EnQueue("rm_points", order_sn);

                //发送短信
                messageQueue.EnQueue("rm_sms", order_sn);
            }
            #endregion

            stopwatch.Stop();
            Console.WriteLine($"订单完成耗时:{stopwatch.ElapsedMilliseconds}ms！");

            return order_sn;
        }
    }
}

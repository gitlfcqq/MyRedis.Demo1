using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRedisRmPoints.Async
{
    /// <summary>
    /// 订单积分服务
    /// </summary>
    class RmOrderPoints
    {
        public void AddPoint(string order_sn)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"增加积分成功，order_sn:{order_sn}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRedisRmSms.Async
{
    /// <summary>
    /// 订单短信服务
    /// </summary>
    class RmOrderSms
    {
        public void SendSms(string order_sn)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"order_sn:{order_sn}，发送短信成功！");
        }
    }
}

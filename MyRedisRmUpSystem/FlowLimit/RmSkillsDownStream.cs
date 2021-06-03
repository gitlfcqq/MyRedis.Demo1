
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRedisRmUpSystem.FlowLimit
{
    class RmSkillsDownStream
    {
        /// <summary>
        /// 处理最大请求数
        /// </summary>
        private int HandleRequestCount = 1000;
        public void HandleRequest(string requestCount)
        {
            Thread.Sleep(10);

            Console.WriteLine($"秒杀订单创建成功！");

            Console.WriteLine($"秒杀订单库存扣减生成！");

            Console.WriteLine($"用户余额扣减成功！");

            Console.WriteLine($"秒杀请求数量:{requestCount}");
          
        }
    }
}

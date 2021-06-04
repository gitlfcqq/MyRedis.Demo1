using MyRedisPubSub.Config;
using System;

namespace MyRedisPubSub
{
    /// <summary>
    /// 订阅发布后台入口
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("订阅发布!");

            //开发环境
            string dev = "dev";

            //测试环境
            string test = "test";

            //生产环境
            string pro = "pro";

            //开始调用配置中心
            RmConfig rmConfig = new RmConfig();
            rmConfig.UpdateDataBase(dev);

            Console.ReadKey();
        }
    }
}

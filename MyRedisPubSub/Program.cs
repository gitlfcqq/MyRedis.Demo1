using MyRedisPubSub.Config;
using System.Configuration;
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
            Console.WriteLine("订阅发布后台!");

            ////开发环境
            //string dev = "dev";
            ////测试环境
            //string test = "test";
            ////生产环境
            //string pro = "pro";

            //y
            string dataBaseEvn = ConfigurationManager.AppSettings["DataBaseEvn"];
            //开始调用配置中心
            RmConfig rmConfig = new RmConfig();
            rmConfig.UpdateDataBase(dataBaseEvn);

            Console.ReadKey();
        }
    }
}

using RedisLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRedisPubSub.Config
{
    /// <summary>
    /// 配置中心微服务
    /// </summary>
    class RmConfig
    {
        public void UpdateDataBase(string dataBaseEvn)
        {
            Console.WriteLine($"配置中心开始更新数据库环境:{dataBaseEvn}");

            //开始发布
            RedisPubSub redisPubSub = new RedisPubSub();
            redisPubSub.Pub("database", dataBaseEvn);

            Console.WriteLine($"更新数据库环境成功:{dataBaseEvn}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRedisPubSubUser.User
{
    class RmUser
    {
        public void UpdateDataBase(string dataBaseEvn)
        {
            Console.WriteLine($"RmUser配置中心开始更新数据库环境,{dataBaseEvn}");

            //获取数据库连接进行实际数据库环境更新 

            Console.WriteLine($"RmUser更新数据库环境成功:{dataBaseEvn}");
        }
    }
}

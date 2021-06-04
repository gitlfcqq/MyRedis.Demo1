using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRedisPubSubActivity.Activity
{
    class RmActivity
    {
        public void UpdateDataBase(string dataBaseEvn)
        {
            Console.WriteLine($"RmActivity配置中心开始更新数据库环境,{dataBaseEvn}");

            //获取数据库连接进行实际数据库环境更新 


            Console.WriteLine($"RmActivity更新数据库环境成功:{dataBaseEvn}");
        }
    }
}

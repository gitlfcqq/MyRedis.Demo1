
using MyRedisEntity;
using RedisLibrary;
using System;

namespace MyRedisDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //调用Redis方法

            RedisBaseHelp redis = new RedisBaseHelp();
            redis.StringSet("keyname", "1234567", new TimeSpan(0, 10, 0));

            #region 操作String
            string key1 = redis.StringGet("keyname");
            Console.WriteLine($"key1:{key1}");
            #endregion


            #region 操作对象
            var yangUser = new User { Id = 1, Name = "Eric Yang" };
            var zhangUser = new User { Id = 2, Name = "Fish Zhang" };
            bool result1 = redis.StringSet<User>("yangUser", yangUser);
            bool result2 = redis.StringSet<User>("zhangUser", zhangUser);
            var yangUser2 = redis.StringGet<User>("yangUser");
            var zhangUser2 = redis.StringGet<User>("zhangUser");
            Console.WriteLine($"yangUser:{result1}");
            Console.WriteLine($"zhangUser:{result2}"); 
            #endregion


        }
    }
}

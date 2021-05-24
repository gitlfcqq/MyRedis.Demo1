
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
            string key1=redis.StringGet("keyname");
            Console.WriteLine($"key1:{key1}");
        }
    }
}

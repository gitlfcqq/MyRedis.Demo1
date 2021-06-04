
using MyRedisEntity;
using RedisLibrary;
using System;
using System.Collections.Generic;

namespace MyRedisDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //调用Redis方法
            RedisBaseHelp redis = new RedisBaseHelp();
            //TestObj(redis);

            TetListObj();
        }
        #region 操作String
        private static void TestString(RedisBaseHelp redis)
        {
            redis.StringSet("keyname", "1234567", new TimeSpan(0, 10, 0));
            string key1 = redis.StringGet("keyname");
            Console.WriteLine($"key1:{key1}");
        }
        #endregion

        #region 操作对象
        public static void TestObj(RedisBaseHelp redis)
        {
            List<long> blogIdsList = new List<long>();
            blogIdsList.Add(111111111111);
            blogIdsList.Add(222222222222);
            blogIdsList.Add(333333333333);
            blogIdsList.Add(444444444444);
            blogIdsList.Add(555555555555);

            var yangUser = new User { Id = 1, Name = "Eric Yang" };
            var zhangUser = new User
            {
                Id = 2,
                Name = "Fish Zhang",
                BlogIds = blogIdsList
            };
            bool result1 = redis.StringSet<User>("yangUser", yangUser);
            bool result2 = redis.StringSet<User>("zhangUser", zhangUser);
            var yangUser2 = redis.StringGet<User>("yangUser");
            var zhangUser2 = redis.StringGet<User>("zhangUser");
            Console.WriteLine($"yangUser:{result1}");
            Console.WriteLine($"zhangUser:{result2}");
            Console.ReadLine();
        }
        public static void TetListObj()
        {
            List<long> blogIdsList = new List<long>();
            blogIdsList.Add(111111111111);
            blogIdsList.Add(222222222222);
            blogIdsList.Add(333333333333);
            blogIdsList.Add(444444444444);
            blogIdsList.Add(555555555555);

            var yangUser = new User { Id = 1, Name = "Eric Yang" };
            var zhangUser = new User
            {
                Id = 2,
                Name = "Fish Zhang",
                BlogIds = blogIdsList
            };
            var zhangUser3 = new User
            {
                Id = 3,
                Name = "Fish Zhang3",
                BlogIds = blogIdsList
            };
            var zhangUser4 = new User
            {
                Id = 4,
                Name = "Fish Zhang4",
                BlogIds = blogIdsList
            };
            var zhangUser5 = new User
            {
                Id = 5,
                Name = "Fish Zhang5",
                BlogIds = blogIdsList
            };
            RedisClientHelp client = new RedisClientHelp();
            IList<User> userList = new List<User>();
            userList.Add(yangUser);
            userList.Add(zhangUser);
            userList.Add(zhangUser3);
            userList.Add(zhangUser4);
            userList.Add(zhangUser5);

            bool result1 = client.AddList<User>("userList", userList);
            //bool result2 = redis.StringSet<User>("zhangUser", zhangUser);
            var userList2 = client.GetList<User>("userList");
            Console.WriteLine($"userList:{result1}");
            Console.ReadLine();
        }
        #endregion
    }
}

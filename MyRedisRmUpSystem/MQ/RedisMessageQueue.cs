using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRedisRmUpSystem.MQ
{
    class RedisMessageQueue : IDisposable
    {
        public RedisClient redisClient { get; }

        public RedisMessageQueue(string redisHost)
        {
            redisClient = new RedisClient(redisHost);
        }
        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="qKey"></param>
        /// <param name="qMsg"></param>
        /// <returns></returns>
        public long EnQueue(string qKey, string qMsg)
        {
            byte[] data = Encoding.UTF8.GetBytes(qMsg);
            long counts = redisClient.LPush(qKey, data);

            return counts;
        }
        /// <summary>
        /// 出队--非阻塞
        /// </summary>
        /// <param name="qKey"></param>
        /// <returns></returns>
        public string DeQueue(string qKey)
        {
            byte[] data = redisClient.RPop(qKey);
            string qMsg = "";
            if (data != null)
            {
                qMsg = Encoding.UTF8.GetString(data);
            }
            else
            {
                Console.WriteLine("队列中数据为空!");
            }

            return qMsg;
        }
        /// <summary>
        /// 出队--阻塞
        /// </summary>
        /// <param name="qKey"></param>
        /// <returns></returns>
        public string BDeQueue(string qKey, TimeSpan? timeSpan)
        {
            string qMsg = redisClient.BlockingDequeueItemFromList(qKey, timeSpan);

            return qMsg;
        }
        public long GetQueueCount(string qKey)
        {
            return redisClient.GetListCount(qKey);
        }

        void IDisposable.Dispose()
        {
            redisClient.Dispose();
        }
    }
}

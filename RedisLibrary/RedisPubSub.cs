using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisLibrary
{
    /// <summary>
    /// Redis 订阅与发布
    /// 订阅者
    /// 发布者
    /// 主题（事件）
    /// 主题消息
    /// </summary>
    public class RedisPubSub
    {
        //1.连接字符串（redis数据库默认端口为：6379）
        private readonly string ConnectionString = "127.0.0.1:6379";

        private ConnectionMultiplexer connectionMultiplexer;

        public RedisPubSub()
        {
            connectionMultiplexer = ConnectionMultiplexer.Connect(ConnectionString);
        }

        /// <summary>
        /// 订阅
        /// </summary>
        /// <param name="messageTopic"></param>
        public void Sub(string messageTopic, Action<ChannelMessage> handle)
        {
            //获取消息
            var sub = connectionMultiplexer.GetSubscriber();

            //订阅消息
            ChannelMessageQueue channelMessageQueue = sub.Subscribe(messageTopic);

            //如何处理消息
            channelMessageQueue.OnMessage(message =>
            {
                //获取消息
                string topic = message.Message;

                //开始做业务逻辑封装

            });

            channelMessageQueue.OnMessage(handle);

        }

        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="messageTopic"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public long Pub(string messageTopic, RedisValue message)
        {
            var sub = connectionMultiplexer.GetSubscriber();
            return sub.Publish(messageTopic, message);
        }
    }
}

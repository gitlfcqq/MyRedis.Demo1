# MyRedis.Demo1 
需要安装Redis

## RedisLibrary
公共类库

## MyRedisMq
### MyRedisRmPoints
### MyRedisRmSms
### MyRedisRmUpSystem
消息队列，流量削峰

## PubSub MyRedisPubSub
Redis 订阅发布 微服务 demo 

## 分布式锁 demo 

```C#
RedisBaseHelp redisBase=new RedisBaseHelp();
//加锁
redisBase.Lock(key,10);
//解锁
redisBase.UnLock(key);
```


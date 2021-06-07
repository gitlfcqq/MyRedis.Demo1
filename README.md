# MyRedis.Demo1 
## 分布式锁 demo 

```C#
RedisBaseHelp redisBase=new RedisBaseHelp();
//加锁
redisBase.Lock(key,10);
//解锁
redisBase.UnLock(key);
```


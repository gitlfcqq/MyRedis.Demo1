using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RedisLibrary
{


    public class RedisClient
    {
        static ConnectionMultiplexer redis = null;
        IDatabase db = null;

        public void InitConnect(string configuration)
        {
            try
            {
                var connectionWriteString = "127.0.0.1:6379";
                IConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connectionWriteString);
                db = redis.GetDatabase(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                redis = null;
                db = null;
            }
        }
        public RedisClient()
        {
            if (redis == null || db == null) InitConnect("");
        }
        #region String 
        /// <summary>
        /// 保存单个key value
        /// </summary>
        /// <param name="value">保存的值</param>
        /// <param name="expiry">过期时间</param>
        public bool SetStringKey(string key, string value, TimeSpan? expiry = default(TimeSpan?))
        {
            return db.StringSet(key, value, expiry);
        }

        /// <summary>
        /// 获取单个key的值
        /// </summary>
        public RedisValue GetStringKey(string key)
        {
            return db.StringGet(key);
        }


        /// <summary>
        /// 获取一个key的对象
        /// </summary>
        public T GetStringKey<T>(string key)
        {
            if (db == null)
            {
                return default;
            }
            var value = db.StringGet(key);
            if (value.IsNullOrEmpty)
            {
                return default;
            }
            return JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>
        /// 保存一个对象
        /// </summary>
        /// <param name="obj"></param>
        public bool SetStringKey<T>(string key, T obj, TimeSpan? expiry = default(TimeSpan?))
        {
            if (db == null)
            {
                return false;
            }
            string json = JsonConvert.SerializeObject(obj);
            return db.StringSet(key, json, expiry);
        }

        #endregion
        /// <summary>
        /// 将一个泛型List添加到缓存中
        /// </summary>
        /// <typeparam name="T">泛型T</typeparam>
        /// <param name="listkey">Key</param>
        /// <param name="list">list</param>
        /// <param name="db_index">数据库序号，不传默认为0</param>
        /// <returns></returns>
        public bool AddList<T>(string listkey, IList<T> list, int db_index = 0)
        {
            if (db == null)
            {
                return false;
            }
            var value = JsonConvert.SerializeObject(list);
            return db.StringSet(listkey, value);

        }

        /// <summary>
        /// 通过指定Key值获取泛型List
        /// </summary>
        /// <typeparam name="T">泛型T</typeparam>
        /// <param name="listkey">Key</param>
        /// <param name="db_index">数据库序号，不传默认为0</param>
        /// <returns></returns>
        public IList<T> GetList<T>(string listkey, int db_index = 0)
        {
            //var db = redis.GetDatabase(db_index);
            if (db == null)
            {
                return new List<T>();
            }
            if (db.KeyExists(listkey))
            {
                var value = db.StringGet(listkey);
                if (!string.IsNullOrEmpty(value))
                {
                    var list = JsonConvert.DeserializeObject<List<T>>(value);
                    return list;
                }
                else
                {
                    return new List<T>();
                }
            }
            else
            {
                return new List<T>();
            }
        }
        public bool getKeyExists(string listkey, int db_index = 0)
        {
            if (db == null)
            {
                return false;
            }
            if (db.KeyExists(listkey))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除指定List<T>中满足条件的元素
        /// </summary>
        /// <param name="listkey">Key</param>
        /// <param name="func">lamdba表达式</param>
        /// <param name="db_index">数据库序号，不传默认为0</param>
        /// <returns></returns>
        public bool delListByLambda<T>(string listkey, Func<T, bool> func, int db_index = 0)
        {
            if (db == null)
            {
                return false;
            }
            if (db.KeyExists(listkey))
            {
                var value = db.StringGet(listkey);
                if (!string.IsNullOrEmpty(value))
                {
                    var list = JsonConvert.DeserializeObject<List<T>>(value);
                    if (list.Count > 0)
                    {
                        list = list.SkipWhile<T>(func).ToList();
                        value = JsonConvert.SerializeObject(list);
                        return db.StringSet(listkey, value);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取指定List<T>中满足条件的元素
        /// </summary>
        /// <param name="listkey">Key</param>
        /// <param name="func">lamdba表达式</param>
        /// <param name="db_index">数据库序号，不传默认为0</param>
        /// <returns></returns>
        public List<T> getListByLambda<T>(string listkey, Func<T, bool> func, int db_index = 0)
        {
            if (db == null)
            {
                return new List<T>();
            }
            if (db.KeyExists(listkey))
            {
                var value = db.StringGet(listkey);
                if (!string.IsNullOrEmpty(value))
                {
                    var list = JsonConvert.DeserializeObject<List<T>>(value);
                    if (list.Count > 0)
                    {
                        list = list.Where(func).ToList();
                        return list;
                    }
                    else
                    {
                        return new List<T>();
                    }
                }
                else
                {
                    return new List<T>();
                }
            }
            else
            {
                return new List<T>();
            }
        }
    }

}

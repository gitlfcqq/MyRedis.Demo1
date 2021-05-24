using System;
using System.Collections.Generic;

namespace MyRedisEntity
{
    public class User
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public List<long> BlogIds { get; set; }

        public User()
        {
            this.BlogIds = new List<long>();
        }
    }
}

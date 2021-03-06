﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory;

namespace Pstoh.OA.Commons.Cache
{
    public class CacheHelper
    {
       // Spring.Net直接注入一个Cache的实现过来。

        public static ICacheWriter CacheWriter { get; set; }

        static CacheHelper()
        {
            //通过容器创建一个对象。
            IApplicationContext ctx = ContextRegistry.GetContext();
            //ctx.GetObject("CacheHelper");

            CacheHelper.CacheWriter = ctx.GetObject("CacheWriter") as ICacheWriter;
        }


        public static void AddCache(string key, object value,DateTime expDate)
        {
            //往缓存写：单机，分布式   观察者模式可以。修改一下配置，就能切换。

            //Unity3D->2D

            //游戏：互联网，浪费时间。
            //ICacheWriter cacheWriter =new MemcacheWriter();
            CacheWriter.AddCache(key, value, expDate);

        }


        public static void AddCache(string key, object value)
        {
             CacheWriter.AddCache(key,value);
        }

        public static object GetCache(string key)
        {
            return CacheWriter.GetCache(key);
        }

        public static void SetCache(string key,object value,DateTime extTime)
        {
            CacheWriter.SetCache(key,value,extTime);
        }

        public static void SetCache(string key, object value)
        {
            CacheWriter.SetCache(key,value);
        }
    }
}

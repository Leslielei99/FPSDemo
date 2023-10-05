using System;
using UnityEngine;
using System.Collections.Generic;
using Object = UnityEngine.Object;

public class AssetsManager : Singlton<AssetsManager>
{

    //私有构造
    private AssetsManager()
    {
        assetsCache = new Dictionary<string, Object>();
    }

    /// <summary>
    /// 资源缓存
    /// </summary>
    private Dictionary<string, Object> assetsCache;

    /// <summary>
    /// 获取资源
    /// </summary>
    /// <param name="path">资源路径</param>
    /// <returns>资源对象</returns>
    [Obsolete("过时方法，有新方法替代GetAsset")]
    public Object OldGetAsset(string path)
    {
        //要返回的资源
        Object assetObj = null;
        //如果缓存中没有该资源
        if (!assetsCache.ContainsKey(path))
        {
            //通过Resource加载资源
            assetObj = Resources.Load(path);
            //将资源存进缓存
            assetsCache.Add(path, assetObj);
        }
        else
        {
            //如果缓存中有，则直接从缓存中拿
            assetObj = assetsCache[path];
        }

        return assetObj;
    }

    /// <summary>
    /// 获取资源
    /// </summary>
    /// <param name="path">资源路径</param>
    /// <returns>资源对象</returns>
    public Object GetAsset(string path)
    {
        //要返回的资源
        Object assetObj = null;
        //尝试从字典中获取该路径所对应的资源
        if (!assetsCache.TryGetValue(path, out assetObj))
        {
            //通过Resource加载资源
            assetObj = Resources.Load(path);
            //将资源存进缓存
            assetsCache.Add(path, assetObj);
        }
        return assetObj;
    }

    private Object TryGetValueTest(string key)
    {
        Object assetObj = null;

        //尝试获取资源
        //如果获取到了则isGet==True,assetObj的到这个值
        //如果没有获取到则isGet==False,assetObj就没有获取到值
        bool isGet = assetsCache.TryGetValue(key, out assetObj);

        if (isGet)
        {
            //assetObj已经获取到值了
            return assetObj;
        }
        else
        {
            //Resource加载该资源
            assetObj = Resources.Load(key);
            //放入缓存
            assetsCache.Add(key, assetObj);
            //返回他
            return assetObj;
        }
    }
}
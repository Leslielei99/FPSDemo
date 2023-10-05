using System;
using UnityEngine;
using System.Collections.Generic;
using Object = UnityEngine.Object;

public class GameObjectPool
{

    #region Singleton

    //单例
    public readonly static GameObjectPool Instance = new GameObjectPool();

    private GameObjectPool()
    {
        pool = new Dictionary<string, List<GameObject>>();
    }

    #endregion

    #region Object Pool

    /// <summary>
    /// 对象池
    /// </summary>
    private Dictionary<string, List<GameObject>> pool;

    /// <summary>
    /// 从对象池取对象 
    /// </summary>
    /// <param name="objName"></param>
    /// <returns></returns>
    public GameObject GetGameObject(string objName, Vector3 pos, Quaternion rotation)
    {
        //要返回的游戏对象
        GameObject obj;
        //没有对应的子对象池，或有对应的对象池但池子为空
        if (!pool.ContainsKey(objName) || pool[objName].Count == 0)
        {
            //先拿到预设体
            Object prefab = AssetsManager.Instance.GetAsset(objName);
            //再生成
            obj = GameObject.Instantiate(prefab, pos, rotation) as GameObject;
            //改名字
            obj.name = objName;
        }
        else
        {
            //从池子中获取
            obj = pool[objName][0];
            //删除池中对象
            pool[objName].RemoveAt(0);
            //设置位置
            obj.transform.position = pos;
            //设置旋转
            obj.transform.rotation = rotation;
        }
        //激活对象
        obj.SetActive(true);
        try
        {
            //获取对象脚本
            obj.GetComponent<PoolObject>().OnSpawn();
        }
        catch (Exception e)
        {
            Debug.LogWarning(e);
        }
        //返回对象
        return obj;
    }

    /// <summary>
    /// 将对象存入对象池
    /// </summary>
    /// <param name="obj"></param>
    public void SetGameObject(GameObject obj)
    {
        try
        {
            //获取对象脚本
            obj.GetComponent<PoolObject>().OnPause();
        }
        catch (Exception e)
        {
            Debug.LogWarning(e);
        }

        //存入之前，先取消激活
        obj.SetActive(false);
        //判断有没有对应的子对象池
        if (!pool.ContainsKey(obj.name))
        {
            //新建子对象池，并将当前对象存入
            pool.Add(obj.name, new List<GameObject>() { obj });
        }
        else
        {
            //将当前对象存入对象池
            pool[obj.name].Add(obj);
        }
    }
    public void SetGameObject(GameObject obj, Vector3 pos)
    {
        try
        {
            //获取对象脚本
            obj.GetComponent<PoolObject>().OnPause();
        }
        catch (Exception e)
        {
            Debug.LogWarning(e);
        }
        obj.transform.position = pos;
        //存入之前，先取消激活
        obj.SetActive(false);
        //判断有没有对应的子对象池
        if (!pool.ContainsKey(obj.name))
        {
            //新建子对象池，并将当前对象存入
            pool.Add(obj.name, new List<GameObject>() { obj });
        }
        else
        {
            //将当前对象存入对象池
            pool[obj.name].Add(obj);
        }
    }

    #endregion
}
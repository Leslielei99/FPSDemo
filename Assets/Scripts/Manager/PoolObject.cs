using System.Collections;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [Header("对象的生命周期")] public float lifeTime = 3f;

    public virtual void OnEnable()
    {
        // 启动协程
        StartCoroutine(DelayEnterPool());
    }

    /// <summary>
    /// 延迟进入对象池
    /// </summary>
    /// <returns></returns>
    private IEnumerator DelayEnterPool()
    {
        yield return new WaitForSeconds(lifeTime);
        //进入对象池
        GameObjectPool.Instance.SetGameObject(gameObject);
    }

    /// <summary>
    /// 对象出生后要做的事情【初始化操作】
    /// </summary>
    public virtual void OnSpawn()
    {
    }

    /// <summary>
    /// 对象进入对象池之前要做的事情
    /// </summary>
    public virtual void OnPause()
    {
    }
}
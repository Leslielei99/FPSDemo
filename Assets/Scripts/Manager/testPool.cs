using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPool : MonoBehaviour
{
    public GameObject prefab;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //PoolManagerSinglton._Getinstance().GetGameObjectFromBulletQuene(new Vector3(0, 0, 0), Quaternion.identity);
            //var obj = PoolManager.Instance.GetObject(prefab);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            //var obj = PoolManagerSinglton.Instance.GetGameObjectFromBulletQuene(new Vector3(0, 0, 0), Quaternion.identity);
            // var obj = PoolManager.Instance.GetObject(prefab);
            GameObjectPool.Instance.GetGameObject(prefab.name, new Vector3(0, 0, 0), Quaternion.identity);
            // Invoke("lateDestory", 2);
        }

    }

}

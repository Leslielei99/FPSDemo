using UnityEngine;

public class UITool
{
    private static UITool instance;

    public static UITool GetInstance()
    {
        if (instance == null)
        {
            instance = new UITool();
        }
        return instance;
    }

    /// <summary>
    /// 获得当前场景中的Canvas
    /// </summary>
    /// <returns></returns>
    public GameObject FindCanvas()
    {
        GameObject gameObject = GameObject.FindObjectOfType<Canvas>().gameObject;
        if (gameObject == null)
        {
            Debug.Log("没有找到Canvas");
            return null;
        }
        return gameObject;
    }

    /// <summary>
    /// 根据名字找到子物体
    /// </summary>
    /// <param name="parentobj">父物体</param>
    /// <param name="childName">目标子物体名</param>
    /// <returns></returns>
    public GameObject FindObjectInChild(GameObject parentobj, string childName)
    {
        Transform[] transforms = parentobj.GetComponentsInChildren<Transform>();
        foreach (Transform t in transforms)
        {
            if (t.gameObject.name == childName)
            {
                return t.gameObject;
            }
            else
            {
                Debug.Log("未找到子物体");
            }
        }
        return null;
    }

    /// <summary>
    /// 获取该物体的组件
    /// </summary>
    /// <typeparam name="T">组件名</typeparam>
    /// <param name="gameObject">物体名</param>
    /// <returns></returns>
    public T GetOrAddComponent<T>(GameObject gameObject) where T : Component
    {
        T t;
        bool isget = gameObject.TryGetComponent<T>(out t);
        if (isget)
        {
            return t;
        }
        else
        {
            Debug.Log("无法获取物体上的组件");
            return null;
        }
    }

    /// <summary>
    /// 通过子物体的名字获取子物体上的组件
    /// </summary>
    /// <typeparam name="T">子物体的Component</typeparam>
    /// <param name="parentObj">父物体</param>
    /// <param name="ChildName">子物体名字</param>
    /// <returns></returns>
    public T GetOrAddSingleComponetInChild<T>(GameObject parentObj, string ChildName) where T : Component
    {
        Transform[] transforms = parentObj.GetComponentsInChildren<Transform>();
        foreach (Transform trans in transforms)
        {
            if (trans.gameObject.name == ChildName)
            {
                T t;
                bool isget = trans.TryGetComponent<T>(out t);
                if (isget)
                {
                    return t;
                }
                else
                {
                    Debug.Log("无法获取物体上的组件");
                }
            }
        }
        return null;
    }
}
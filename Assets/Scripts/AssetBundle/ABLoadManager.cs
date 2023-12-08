using UnityEngine;

public class ABLoadManager : MonoBehaviour
{
    private AssetBundle ab;
    public static readonly ABLoadManager instance = new ABLoadManager();
    // private static ABLoadManager instance;
    // public static ABLoadManager GetInstance()
    // {
    //     if (instance != null)
    //     {
    //         return instance;
    //     }
    //     else
    //     {
    //         return new ABLoadManager();
    //     }
    // }

    // private void Awake()
    // {
    //     instance = this;
    // }

    /// <summary>
    /// 根据AB包名字加载AB包
    /// </summary>
    public void LoadAB(string packageName)
    {
        //加载指定AB包
        ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + packageName);
        //加载主包
        AssetBundle abMain = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + "StandaloneWindows");
        //加载主包中的固定文件
        AssetBundleManifest abManifest = abMain.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        //从固定文件中得到依赖信息
        string[] strs = abManifest.GetAllDependencies(packageName);
        //得到依赖包的名字并加载
        foreach (var s in strs)
        {
            AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + s);
        }
        Debug.Log(ab);
        Debug.Log("ab包加载完成！");
    }

    /// <summary>
    /// 根据预制体名称获取对象
    /// </summary>
    /// <param name="objName"></param>
    /// <returns></returns>
    public GameObject GetABGameObject(string objName)
    {
        Debug.Log(ab);
        Debug.Log("开始加载gameobject");
        //GameObject abGO = ab.LoadAsset(objName, typeof(GameObject)) as GameObject;
        GameObject abGO = ab.LoadAsset<GameObject>(objName);
        Debug.Log("加载gameobject完成");
        return abGO;
    }
}
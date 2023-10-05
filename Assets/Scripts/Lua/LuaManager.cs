using System.IO;
using UnityEngine;
using XLua;
public class LuaManager : MonoBehaviour
{
    public readonly static LuaManager instance = new LuaManager();
    // public static LuaManager _instance;
    // public static LuaManager Instance
    // {
    //     get
    //     {
    //         return _instance;
    //     }
    // }
    [CSharpCallLua]
    public delegate void LuaDelegate(string paras);
    /// <summary>
    /// 定义一个Delegate，Lua结果将传参回调给该Delegate
    /// </summary>
    public static LuaDelegate LuaFunc;
    /// <summary>
    /// 定义一个Lua虚拟机，建议全局唯一
    /// </summary>
    public static LuaEnv luaEnv;
    public LuaEnv GetLuaEnv()
    {
        return luaEnv;
    }
    void Awake()
    {
        //_instance = this;
        LuaEnvInit();
    }
    public void LuaEnvInit()
    {
        luaEnv = new LuaEnv();
        luaEnv.AddLoader(MyLoader);
        ///lua脚本的主入口
        luaEnv.DoString("require 'updateInfo'");
        //获取Lua中全局function，然后映射到delegate
        luaEnv.Global.Get("LuaFunc", out LuaFunc);
    }
    private byte[] MyLoader(ref string filepath)
    {
        string abspath = Application.dataPath + "/Resources/lua/" + filepath + ".lua.txt";
        Debug.Log(abspath);
        return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(abspath));
    }
}

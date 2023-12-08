using UnityEngine;
using XLua;

[Hotfix]
public class HotfixTest : MonoBehaviour
{
    public LuaEnv luaEnv;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        luaEnv = new LuaEnv();
        luaEnv.DoString("CS.UnityEngine.Debug.Log('hello world lua')");
        Debug.Log("Unity_Hello World!");
        luaEnv.Dispose();
    }
}
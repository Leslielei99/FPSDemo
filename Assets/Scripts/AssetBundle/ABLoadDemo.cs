using UnityEngine;
using UnityEngine.UI;
using XLua;

[Hotfix]
public class ABLoadDemo : MonoBehaviour
{
    public Button load_BtnUI;

    private Transform canvas;
    public Button load_BtnEnemy;
    private string LoadPath;
    private AssetBundle bundle;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Transform>();
        LoadPath = Application.streamingAssetsPath;
        load_BtnUI.onClick.AddListener(startConUI);
        load_BtnEnemy.onClick.AddListener(startConEnemy);
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        //StartCoroutine(loadab());
        //LuaManager.instance.GetLuaEnv().DoString("require 'hello'");
        //LuaManager._instance.GetLuaEnv().DoString("require 'hello'");
        Test();
    }

    private void startConUI()
    {
        ABLoadManager.instance.LoadAB("ui");
        Instantiate(ABLoadManager.instance.GetABGameObject("UI"), canvas.position, Quaternion.identity, canvas);
    }

    private void startConEnemy()
    {
        ABLoadManager.instance.LoadAB("enemy");
        Instantiate(ABLoadManager.instance.GetABGameObject("turtle"));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Instantiate(ABLoadManager.instance.GetABGameObject("Turtle"));
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Instantiate(ABLoadManager.instance.GetABGameObject("turtle"));
        }
    }

    // IEnumerator loadab()
    // {
    // }
    private void Test()
    {
        Debug.Log("Hello World");
    }
}
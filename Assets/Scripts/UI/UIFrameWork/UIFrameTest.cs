using UnityEngine;
using UnityEngine.UI;

public class UIFrameTest : MonoBehaviour
{
    private Button button1;
    private Button button2;

    private void Awake()
    {
        button1 = UITool.GetInstance().GetOrAddSingleComponetInChild<Button>(this.gameObject, "Button1");
        button2 = UITool.GetInstance().GetOrAddSingleComponetInChild<Button>(this.gameObject, "Button2");
    }

    private void Start()
    {
        //transform = GetComponentsInChildren<Transform>();
        //UIManager.Instance().Push(new MainPanel());
        button1.onClick.AddListener(OpenMainPanel);
        button2.onClick.AddListener(OpenSettingPanel);
    }

    private void OpenMainPanel()
    {
        UIManager.Instance.Push(new MainPanel());
    }

    private void OpenSettingPanel()
    {
        UIManager.Instance.Push(new SettingPanel());
    }

    // Update is called once per frame
    private void Update()
    {
    }
}
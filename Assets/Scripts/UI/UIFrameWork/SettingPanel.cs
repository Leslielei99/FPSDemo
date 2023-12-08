using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : BasePanel
{
    private static string name = "SettingPanel";
    private static string path = "UIPanel/SettingPanel";
    public static readonly UIType Type = new UIType(name, path);

    private Toggle T1;
    private Toggle T2;
    private Dropdown dropdown;

    private int language_index;

    public SettingPanel() : base(Type)
    {
    }

    public override void OnEnter()
    {
        dropdown = UITool.GetInstance().GetOrAddSingleComponetInChild<Dropdown>(ActiveObj, "Dropdown");
        dropdown.ClearOptions();
        dropdown.AddOptions(new List<string> { "中文", "Englich" });
        UITool.GetInstance().GetOrAddSingleComponetInChild<Button>(ActiveObj, "Back").onClick.AddListener(Back);
        T1 = UITool.GetInstance().GetOrAddSingleComponetInChild<Toggle>(ActiveObj, "1080");
        if (T1.isOn)
        {
            ChangeScreen(0);
        }
        else
        {
            ChangeScreen(1);
        }

        dropdown.value = language_index;
        dropdown.onValueChanged.AddListener(LanguageChange);
        base.OnEnter();
    }

    private void Back()
    {
        UIManager.Instance.Pop(false);
    }

    private void LanguageChange(int v)
    {
        switch (v)
        {
            case 0:
                LocaManager.GetInstance().languageType = LanguageType.Chinese;
                PlayerPrefs.SetInt("Language", (int)LanguageType.Chinese);
                break;

            case 1:
                LocaManager.GetInstance().languageType = LanguageType.English;
                PlayerPrefs.SetInt("Language", (int)LanguageType.English);
                break;

            case 2:
                LocaManager.GetInstance().languageType = LanguageType.Chinese;
                PlayerPrefs.SetInt("Language", (int)LanguageType.Chinese);
                break;

            default:
                break;
        }
        EventManager.GetInstance.EventTrigger("LanguageChange");
        language_index = v;
    }

    private void ChangeScreen(int n)
    {
        if (n == 0)
        {
            Screen.SetResolution(1920, 1080, Screen.fullScreen);
        }
        else if (n == 1)
        {
            Screen.SetResolution(1280, 720, Screen.fullScreen);
        }
    }
}
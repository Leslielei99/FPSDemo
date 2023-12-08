using UnityEngine;
using UnityEngine.UI;

public class setting02 : MonoBehaviour
{
    private Text title;
    private Text LanguageText;
    private Text MusicText;
    private Text BackText;
    private Text FenBianText;

    private void Start()
    {
        title = UITool.GetInstance().GetOrAddSingleComponetInChild<Text>(this.gameObject, "Title");
        LanguageText = UITool.GetInstance().GetOrAddSingleComponetInChild<Text>(this.gameObject, "LanguageText");
        MusicText = UITool.GetInstance().GetOrAddSingleComponetInChild<Text>(this.gameObject, "MusicText");
        BackText = UITool.GetInstance().GetOrAddSingleComponetInChild<Text>(this.gameObject, "BackText");
        FenBianText = UITool.GetInstance().GetOrAddSingleComponetInChild<Text>(this.gameObject, "FenBianText");
        EventManager.GetInstance.AddEventListener("LanguageChange", TextChange);
    }

    private void TextChange()
    {
        title.text = LocaManager.GetInstance().GetLoactionText(1);
        LanguageText.text = LocaManager.GetInstance().GetLoactionText(6);
        MusicText.text = LocaManager.GetInstance().GetLoactionText(2);
        BackText.text = LocaManager.GetInstance().GetLoactionText(7);
        FenBianText.text = LocaManager.GetInstance().GetLoactionText(3);
    }
}
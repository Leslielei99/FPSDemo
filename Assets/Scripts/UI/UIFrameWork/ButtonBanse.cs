using UnityEngine;
using UnityEngine.UI;

public class ButtonBanse : MonoBehaviour
{
    private Text shop;
    private Text setting;

    private void Start()
    {
        shop = UITool.GetInstance().GetOrAddSingleComponetInChild<Text>(this.gameObject, "shop");
        setting = UITool.GetInstance().GetOrAddSingleComponetInChild<Text>(this.gameObject, "setting");
        shop.text = LocaManager.GetInstance().GetLoactionText(4);
        setting.text = LocaManager.GetInstance().GetLoactionText(1);
        EventManager.GetInstance.AddEventListener("LanguageChange", OnLanguageChange);
    }

    private void OnLanguageChange()
    {
        shop.text = LocaManager.GetInstance().GetLoactionText(4);
        setting.text = LocaManager.GetInstance().GetLoactionText(1);
    }
}
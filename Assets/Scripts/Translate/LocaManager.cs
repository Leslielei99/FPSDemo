using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T mInstance;

    public static T GetInstance()
    {
        if (null == mInstance)
        {
            mInstance = FindObjectOfType(typeof(T)) as T; // 获得场景中有T组件的the first active loaded gameobject of this type
            //Debug.Log(FindObjectsOfType(typeof(T)).Length);
            if (null == mInstance)
            {
                GameObject singleton = new GameObject("(singleton)" + typeof(T).ToString());
                mInstance = singleton.AddComponent<T>(); // 实例化T的对象
                DontDestroyOnLoad(singleton);
            }
        }
        return mInstance;
    }
}

public class TextCon
{
    public string key;
    public int id;
    public string Chinese;
    public string English;
}

public enum LanguageType
{
    Chinese,
    English
}

public class LocaManager : Singleton<LocaManager>
{
    private Dictionary<int, TextCon> Dic_TextCon = new Dictionary<int, TextCon>();
    private List<TextCon> lists = new List<TextCon>();
    private List<Text> TextList = new List<Text>();
    private Dictionary<string, BasePanel> dic_languagePanel = new Dictionary<string, BasePanel>();
    public LanguageType languageType;

    private void Awake()
    {
        languageType = LanguageType.Chinese;
        TextAsset jsontext = Resources.Load<TextAsset>("json/translate");
        lists = JsonConvert.DeserializeObject<List<TextCon>>(jsontext.ToString());
        for (int i = 0; i < lists.Count; i++)
        {
            Dic_TextCon[lists[i].id] = lists[i];
        }
    }

    private void Start()
    {
        EventManager.GetInstance.EventTrigger("LanguageChange");
    }

    /// <summary>
    /// 通过id返回文字
    /// </summary>
    /// <param name="id">唯一id</param>
    /// <returns></returns>
    public string GetLoactionText(int id)
    {
        languageType = (LanguageType)PlayerPrefs.GetInt("Language");
        if (Dic_TextCon.ContainsKey(id))
        {
            switch (languageType)
            {
                case LanguageType.Chinese:
                    return Dic_TextCon[id].Chinese;

                case LanguageType.English:
                    return Dic_TextCon[id].English;

                default:
                    return Dic_TextCon[id].Chinese;
            }
        }
        else
        {
            return "无此词";
        }
    }

    public void AddDiclanguagePanel(string name, BasePanel basePanel)
    {
        dic_languagePanel[name] = basePanel;
    }

    public void AddTextList(Text text)
    {
        TextList.Add(text);
    }
}
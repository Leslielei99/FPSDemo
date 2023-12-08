using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UIManager();
            }
            return instance;
        }
    }

    private Transform Canvas = GameObject.Find("Canvas").transform;

    private Dictionary<string, GameObject> Dic_UI = new Dictionary<string, GameObject>();
    private Stack<BasePanel> Stack_UI = new Stack<BasePanel>();

    public GameObject GetSingleObject(UIType type)
    {
        if (Dic_UI.ContainsKey(type.Name)) return Dic_UI[type.Name];
        GameObject gameObject = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(type.Path), Canvas);
        Dic_UI[type.Name] = gameObject;
        return gameObject;
    }

    public void Push(BasePanel panel)
    {
        if (Stack_UI.Contains(panel)) { return; }
        GameObject currentUI = GetSingleObject(panel.uiType);
        panel.ActiveObj = currentUI;
        if (Stack_UI.Count > 0)
        {
            Stack_UI.Peek().OnDisable();
        }
        if (Stack_UI.Count == 0)
        {
            Stack_UI.Push(panel);
        }
        else
        {
            if (Stack_UI.Peek().uiType.Name != panel.uiType.Name)
            {
                Stack_UI.Push(panel);
            }
        }
        panel.OnEnter();
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="isload">是否清除所有面板</param>
    public void Pop(bool isload)
    {
        if (isload)
        {
            Stack_UI.Peek().OnDisable();
            Stack_UI.Peek().OnExit();
            GameObject.Destroy(Dic_UI[Stack_UI.Peek().uiType.Name]);
            Dic_UI.Remove(Stack_UI.Peek().uiType.Name);
            Stack_UI.Pop();
            Pop(true);
        }
        else
        {
            Debug.Log("当前面板数量：" + Stack_UI.Count);
            Stack_UI.Peek().OnDisable();
            Stack_UI.Peek().OnExit();
            GameObject.Destroy(Dic_UI[Stack_UI.Peek().uiType.Name]);
            Dic_UI.Remove(Stack_UI.Peek().uiType.Name);
            Stack_UI.Pop();
            if (Stack_UI.Count > 0)
            {
                Stack_UI.Peek().OnEnable();
            }
            Debug.Log("出栈后面板数量：" + Stack_UI.Count);
            return;
        }
    }
}
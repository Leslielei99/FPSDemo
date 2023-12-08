using UnityEngine;

public class BasePanel
{
    public GameObject ActiveObj;
    public UIType uiType;
    //public UIType uiType { get { return type; } set { type = value; } }

    public BasePanel(UIType uIType)
    {
        uiType = uIType;
    }

    public virtual void OnEnter()
    {
        UITool.GetInstance().GetOrAddComponent<CanvasGroup>(ActiveObj).interactable = true;
    }

    public virtual void OnExit()
    {
        UITool.GetInstance().GetOrAddComponent<CanvasGroup>(ActiveObj).interactable = false;
    }

    public virtual void OnDisable()
    {
        UITool.GetInstance().GetOrAddComponent<CanvasGroup>(ActiveObj).interactable = false;
    }

    public virtual void OnEnable()
    {
        UITool.GetInstance().GetOrAddComponent<CanvasGroup>(ActiveObj).interactable = true;
    }
}
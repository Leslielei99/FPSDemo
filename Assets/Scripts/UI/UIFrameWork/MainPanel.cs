using UnityEngine.UI;

public class MainPanel : BasePanel
{
    private static string name = "MainPanel";
    private static string path = "UIPanel/MainPanel";
    public static readonly UIType Type = new UIType(name, path);

    public MainPanel() : base(Type)
    {
    }

    public override void OnEnter()
    {
        UITool.GetInstance().GetOrAddSingleComponetInChild<Button>(ActiveObj, "Back").onClick.AddListener(Back);
        base.OnEnter();
    }

    private void Back()
    {
        UIManager.Instance.Pop(false);
    }
}
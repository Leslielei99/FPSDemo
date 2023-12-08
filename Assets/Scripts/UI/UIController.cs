using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject BagPanel;
    private bool isView;

    private void Start()
    {
        BagPanel.SetActive(false);
        isView = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isView)
            {
                Cursor.visible = false;
                isView = false;
            }
            else
            {
                Cursor.visible = true;
                isView = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (isView)
            {
                ColseBag();
            }
            else
            {
                OpenBag();
            }
        }
    }

    public void OpenBag()
    {
        BagPanel.SetActive(true);
        Cursor.visible = true;
        isView = true;
    }

    public void ColseBag()
    {
        BagPanel.SetActive(false);
        Cursor.visible = false;
        isView = false;
    }
}
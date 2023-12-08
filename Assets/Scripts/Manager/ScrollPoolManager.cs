using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollPoolManager : Singleton<ScrollPoolManager>, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private GameObject scrollprefab = null;
    private List<GameObject> lists_prefab = new List<GameObject>();
    private Stack<GameObject> prefab_stack = new Stack<GameObject>();

    private void Start()
    {
        scrollprefab = Resources.Load<GameObject>("ScrollCon");
        for (int i = 0; i < 30; i++)
        {
            GameObject go = Instantiate(scrollprefab, this.transform);
            prefab_stack.Push(go);
            lists_prefab.Add(go);
        }
    }

    public void PushToFirst(GameObject obj)
    {
        obj.transform.SetAsFirstSibling();
        obj.SetActive(false);
        prefab_stack.Push((GameObject)obj);
    }

    public void PushToLast(GameObject obj)
    {
        obj.transform.SetAsLastSibling();
        obj.SetActive(false);
        prefab_stack.Push((GameObject)obj);
    }

    public void PopToLast()
    {
        GameObject go = prefab_stack.Pop();
        go.transform.SetAsLastSibling();
        go.SetActive(true);
    }

    public void PopToFirst()
    {
        GameObject go = prefab_stack.Pop();
        go.transform.SetAsFirstSibling();
        go.SetActive(true);
    }

    public void DesFromHead(GameObject obj)
    {
        Destroy(obj);
    }

    public void InsToHead()
    {
        GameObject go = Instantiate(scrollprefab, this.transform);
        go.transform.SetAsFirstSibling();
    }

    public void InsToLast()
    {
        GameObject go = Instantiate(scrollprefab, this.transform);
        go.transform.SetAsLastSibling();
    }

    ///////////////////////////////////////////////////////////////////////////////////////
    private Vector2 beginPos;

    private Vector2 newPos;
    public int isUpOrNot;

    public void OnDrag(PointerEventData eventData)
    {
        newPos = eventData.position;
        Vector3 vector3 = newPos - beginPos;
        if (vector3.y > 0)
        {
            isUpOrNot = 5;
        }
        else if (vector3.y < 0)
        {
            isUpOrNot = -5;
        }
        else
        {
            isUpOrNot = 0;
        }
        //foreach (var item in lists_prefab)
        //{
        //    item.transform.position += new Vector3(0, vector2.y / 100, 0);
        //}
        foreach (var item in lists_prefab)
        {
            Vector3 newp = new Vector3(item.transform.position.x, item.transform.position.y + vector3.y, item.transform.position.z);
            item.transform.position = Vector3.Lerp(item.transform.position, newp, Time.deltaTime * 100);
        }
        beginPos = eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        beginPos = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }
}
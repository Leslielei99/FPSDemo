
using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections.Generic;

public class Slot : MonoBehaviour, IDropHandler
{
    public static bool isinSlop;
    public GameObject scope_01;
    public GameObject scope_02;
    public GameObject scope_03;
    public GameObject scope_04;
    private Transform currentgameobject;
    private bool droped;
    private string tmp_name;
    private int count, tmp_count;
    public Stack<GameObject> stack;
    public static Dictionary<string, GameObject> SlotDictionary = new Dictionary<string, GameObject>() { };
    private void Start()
    {
        SlotDictionary.Add("scope_01", scope_01);
        SlotDictionary.Add("scope_02", scope_02);
        SlotDictionary.Add("scope_03", scope_03);
        SlotDictionary.Add("scope_04", scope_04);

        int count = transform.childCount;
        // currentgameobject = GetComponentsInChildren<Transform>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropppppppp");
        eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
        eventData.pointerDrag.GetComponent<DragByInterface>().isInSlot = true;
        tmp_name = eventData.pointerDrag.GetComponent<RectTransform>().name;
        isinSlop = true;
        eventData.pointerDrag.GetComponent<RectTransform>().transform.SetParent(this.transform);
        Debug.Log(tmp_name);
        SlotDictionary[tmp_name].SetActive(true);
        Debug.Log(isinSlop);
        //eventData.pointerDrag.GetComponent<RectTransform>().SetParent(this.gameObject.transform);
    }
    public void SetGameObjectActive()
    {

    }
    private void Update()
    {

    }
}

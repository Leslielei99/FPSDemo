using UnityEngine.EventSystems;
using UnityEngine;
[RequireComponent(typeof(CanvasGroup))]
public class DragByInterface : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private Transform parentGO;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 startPosition;
    public bool isInSlot;
    private void Update()
    {
        Slot.isinSlop = isInSlot;
        isInSlot = Slot.isinSlop;
    }
    private void Start()
    {
        parentGO = this.transform.parent;
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        startPosition = rectTransform.anchoredPosition;
        isInSlot = false;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        isInSlot = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //transform.position = Input.mousePosition;
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        if (!isInSlot)
        {
            this.transform.SetParent(parentGO);
            this.transform.localPosition = startPosition;
            Debug.Log(this.name + ": wei false");
            Slot.SlotDictionary[this.name].SetActive(false);
            
        }
    }
}

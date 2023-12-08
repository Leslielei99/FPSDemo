using UnityEngine;
using UnityEngine.UI;

public class ScrollCon : MonoBehaviour
{
    private Image image;
    private imageScriptableOnject imageScriptableOnject;
    private bool isup;
    private bool isdown;

    private void Start()
    {
        image = GetComponent<Image>();
        imageScriptableOnject = Resources.Load<imageScriptableOnject>("Sprites");
        int a = Random.Range(0, imageScriptableOnject.sprites.Count);
        image.sprite = imageScriptableOnject.sprites[a];
    }

    private void Update()
    {
        if (this.transform.position.y > 1341 && ScrollPoolManager.GetInstance().isUpOrNot == 5)
        {
            ScrollPoolManager.GetInstance().PushToLast(this.gameObject);
            ScrollPoolManager.GetInstance().PopToLast();
        }
        else if (this.transform.position.y < -109 && ScrollPoolManager.GetInstance().isUpOrNot == -5)
        {
            ScrollPoolManager.GetInstance().PushToFirst(this.gameObject);
            ScrollPoolManager.GetInstance().PopToFirst();
        }
        //if (this.transform.position.y > 1200)
        //{
        //    ScrollPoolManager.GetInstance().DesFromHead(this.gameObject);
        //    ScrollPoolManager.GetInstance().InsToLast();
        //}
        //if (this.transform.position.y < -100)
        //{
        //    ScrollPoolManager.GetInstance().DesFromHead(this.gameObject);
        //    ScrollPoolManager.GetInstance().InsToHead();
        //}
    }
}
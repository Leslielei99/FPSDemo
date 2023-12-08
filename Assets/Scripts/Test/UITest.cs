using System.Collections.Generic;
using UnityEngine;

public class UITest : MonoBehaviour
{
    private Dictionary<string, string> m_dic = new Dictionary<string, string>();

    private void Start()
    {
        m_dic = new Dictionary<string, string>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Vector3 newPos = Camera.main.WorldToScreenPoint(this.transform.position);
        //Debug.Log("*******X:" + newPos.x + "*******Y:" + newPos.y + "*******Z:" + newPos.z);
        Debug.Log("Loacl:  " + this.transform.localPosition);
        Debug.Log("world:  " + this.transform.position);
    }
}
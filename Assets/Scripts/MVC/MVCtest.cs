using UnityEngine;

public class MVCtest : MonoBehaviour
{
    public GameObject prefab;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(prefab);
            Controller.Instance().CreatEnemy();
        }
    }
}
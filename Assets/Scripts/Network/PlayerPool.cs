using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPool : MonoBehaviour
{
    public GameObject prefab;
    Dictionary<string, GameObject> Models = new Dictionary<string, GameObject>();
    public void UpdatePlayer(List<PlayerInfo> list)
    {
        foreach (PlayerInfo p in list)
        {
            if (Models.ContainsKey(p.name))
            {
                Models[p.name].transform.position = new Vector3(p.x, p.y, p.z);
            }
            else
            {
                Models[p.name] = Instantiate(prefab, new Vector3(p.x, p.y, p.z), Quaternion.identity);
            }
        }
    }
    public static PlayerPool ins;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        ins = this;
    }
}

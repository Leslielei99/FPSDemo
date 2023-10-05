using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPositoion : MonoBehaviour
{
    public Transform MashPosition;
    void Update()
    {
        this.transform.position += MashPosition.transform.position;
    }
}

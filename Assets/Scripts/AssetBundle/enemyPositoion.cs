using UnityEngine;

public class enemyPositoion : MonoBehaviour
{
    public Transform MashPosition;

    private void Update()
    {
        this.transform.position += MashPosition.transform.position;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterPlayer : MonoBehaviour
{
    public int Health;
    public bool isGetHit = false;
    private float tmp_time;
    CapsuleCollider capsuleCollider;
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if (isGetHit)
        {
            tmp_time += Time.deltaTime;
            if (tmp_time > 1)
            {
                isGetHit = false;
            }
        }
    }
    private void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && !isGetHit)
        {
            isGetHit = true;
            Health -= 10;
        }
    }
}

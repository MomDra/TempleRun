using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(transform.parent.parent.gameObject, 10f);
        }
    }
}

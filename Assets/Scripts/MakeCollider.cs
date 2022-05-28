using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.GroundManager.SpawnGround();
            GameManager.Instance.GroundManager.SpawnCoin();
            GameManager.Instance.GroundManager.SpawnFense();
            GameManager.Instance.GroundManager.SpawnStraightItem();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fense : MonoBehaviour
{
    [SerializeField]
    bool canEnd;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (canEnd)
            {
                GameManager.Instance.EndGame();
            }
            else
            {
                collision.gameObject.GetComponent<PlayerController>().SlowSpeed();
                GameManager.Instance.SoundManager.PlayFenseSound();

                Destroy(gameObject);
            }
        }
    }
}

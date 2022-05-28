using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightItem : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up, 60f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.GroundManager.InCreaseStraightGround();

            GameManager.Instance.SoundManager.PlayStraightItemSound();

            Destroy(gameObject);
        }
    }
}

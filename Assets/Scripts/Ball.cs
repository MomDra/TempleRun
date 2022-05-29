using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    int power;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 force = (collision.transform.position - transform.position);
            force.y = 0f;
            rb.AddForce(force * power, ForceMode.Impulse);

            GameManager.Instance.SoundManager.PlayPendulumSound();
            GameManager.Instance.EffectManager.PlaySparkEffect(collision.GetContact(0).point);

            Debug.Log("Ãæµ¹!");
        }
    }
}

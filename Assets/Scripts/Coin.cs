using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int score;

    private void Awake()
    {
        Destroy(gameObject, 35f);
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up, 60f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.Score += score;
            GameManager.Instance.UIManager.UpdateUI(GameManager.Instance.Score);

            GameManager.Instance.SoundManager.PlayCoinSound();
            GameManager.Instance.EffectManager.PlayCoinEffect(transform.position);

            Destroy(gameObject);
        }
    }
}

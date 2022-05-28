using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] AudioClip walkClip;
    [SerializeField] AudioClip coinClip;
    [SerializeField] AudioClip straightItemClip;
    [SerializeField] AudioClip pendulumClip;
    [SerializeField] AudioClip fenseClip;

    private void Awake()
    {
        GameManager.Instance.SoundManager = this;
        GameManager.Instance.PlayAudio();

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWalkSound()
    {
        StartCoroutine(PlayWalkSoundCoroutine());
    }

    IEnumerator PlayWalkSoundCoroutine()
    {
        while (true)
        {
            audioSource.PlayOneShot(walkClip);

            yield return new WaitForSeconds(0.6f);
        }
    }

    public void PlayCoinSound()
    {
        audioSource.PlayOneShot(coinClip);
    }

    public void PlayPendulumSound()
    {
        audioSource.PlayOneShot(pendulumClip);
    }

    public void PlayFenseSound()
    {
        audioSource.PlayOneShot(fenseClip);
    }

    public void PlayStraightItemSound()
    {
        audioSource.PlayOneShot(straightItemClip);
    }

}

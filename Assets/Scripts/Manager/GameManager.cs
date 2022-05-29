using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager singleTon;

    public static GameManager Instance { get => singleTon; }

    GroundManager groundManager;
    public GroundManager GroundManager { get => groundManager; set => groundManager = value; }

    UIManager uiManager;
    public UIManager UIManager { get => uiManager; set => uiManager = value; }

    SoundManager soundManager;
    public SoundManager SoundManager { get => soundManager; set => soundManager = value; }

    EffectManager effectManager;
    public EffectManager EffectManager { get => effectManager; set => effectManager = value; }

    int score;
    public int Score { get => score; set => score = value; }

    AudioSource[] audioSource;
    [SerializeField]
    AudioClip gameEndClip;

    GameObject player;
    public GameObject Player { get => player; set => player = value; }

    private void Awake() {
        if (singleTon != null)
        {
            GameManager.singleTon.score = 0;

            Destroy(gameObject);
            Debug.Log("You Make 2 GameManagers");
        }
        else
        {
            singleTon = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponents<AudioSource>();
        }
    }

    public void EndGame()
    {
        audioSource[1].PlayOneShot(gameEndClip);
        audioSource[0].Pause();
        
        SceneManager.LoadScene(2);
    }

    public void PlayAudio()
    {
        audioSource[0].Play();
    }

    public void PauseAudio()
    {
        audioSource[0].Pause();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerEndScene : MonoBehaviour
{
    [SerializeField] Text score;

    private void Awake()
    {
        score.text = $"Score: {GameManager.Instance.Score}";
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitApplicaiton()
    {
        Application.Quit();
    }
}

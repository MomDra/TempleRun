using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerStartScene : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("FinalExam");
    }
}
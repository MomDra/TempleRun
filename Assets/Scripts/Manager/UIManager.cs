using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text score;

    private void Awake()
    {
        GameManager.Instance.UIManager = this;
    }

    public void UpdateUI(int n)
    {
        score.text = $"Score: {n}";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField]
    GameObject coinEffect;
    [SerializeField]
    GameObject destroyEffect;

    GameObject[] coinEffectArray = new GameObject[3];
    GameObject[] destroyEffectArray = new GameObject[3];

    int coinIndex;
    int destoryIndex;

    private void Awake()
    {
        GameManager.Instance.EffectManager = this;

        for(int i = 0; i < 3; i++)
        {
            coinEffectArray[i] = Instantiate(coinEffect, Vector3.zero, Quaternion.identity);
            destroyEffectArray[i] = Instantiate(destroyEffect, Vector3.zero, Quaternion.identity);

            coinEffectArray[i].SetActive(false);
            destroyEffectArray[i].SetActive(false);
        }
    }

    public void PlayCoinEffect(Vector3 pos)
    {
        coinEffectArray[coinIndex].transform.position = pos;
        coinEffectArray[coinIndex].SetActive(false);
        coinEffectArray[coinIndex].SetActive(true);

        coinIndex = (coinIndex + 1 >= coinEffectArray.Length) ? 0 : coinIndex + 1;
    }

    public void PlayDestoryEffect(Vector3 pos)
    {
        destroyEffectArray[destoryIndex].transform.position = pos;
        destroyEffectArray[destoryIndex].SetActive(false);
        destroyEffectArray[destoryIndex].SetActive(true);

        destoryIndex = (destoryIndex + 1 >= destroyEffectArray.Length) ? 0 : destoryIndex + 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GroundManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject groundPrefab;
    [SerializeField]
    GameObject coinPrefab;
    [SerializeField]
    GameObject CanEndFense;
    [SerializeField]
    GameObject CanNotEndFense;
    [SerializeField]
    GameObject StraightItem;

    [SerializeField]
    GameObject lastSpawnedGround;

    int leftBound = 2;
    int rightBound = 4;

    private void Awake()
    {
        GameManager.Instance.GroundManager = this;
    }

    public void SpawnGround()
    {
        int n = Random.Range(1, 11);

        if(n <= leftBound)
        {
            SpawnLeft();
            Debug.Log("왼쪽이요!");
        }
        else if(n <= rightBound)
        {
            SpawnRight();
            Debug.Log("오른쪽이요!");
        }
        else
        {
            SpawnStraight();
            Debug.Log("직진이요!");
        }
    }

    void SpawnStraight()
    {
        lastSpawnedGround = Instantiate(groundPrefab, lastSpawnedGround.transform.position + lastSpawnedGround.transform.forward * 60, lastSpawnedGround.transform.rotation);
    }

    void SpawnRight()
    {
        Vector3 spawnPoint = lastSpawnedGround.transform.position;
        spawnPoint += lastSpawnedGround.transform.right * 22.5f;
        spawnPoint += lastSpawnedGround.transform.forward * 37.5f;
        lastSpawnedGround = Instantiate(groundPrefab, spawnPoint, lastSpawnedGround.transform.rotation * Quaternion.AngleAxis(90f, Vector3.up));
    }

    void SpawnLeft()
    {
        Vector3 spawnPoint = lastSpawnedGround.transform.position;
        spawnPoint += lastSpawnedGround.transform.right * -22.5f;
        spawnPoint += lastSpawnedGround.transform.forward * 37.5f;
        lastSpawnedGround = Instantiate(groundPrefab, spawnPoint, lastSpawnedGround.transform.rotation * Quaternion.AngleAxis(-90f, Vector3.up));
    }

    public void SpawnCoin()
    {
        for(int i = 0; i < 5; i++)
        {
            float z = Random.Range(-30f, 30f);
            float x = Random.Range(-7.5f, 7.5f);
            Vector3 tmp = lastSpawnedGround.transform.forward.normalized * z + lastSpawnedGround.transform.right.normalized * x + Vector3.up;
            Instantiate(coinPrefab, lastSpawnedGround.transform.position + tmp , Quaternion.identity, lastSpawnedGround.transform);
        }
    }

    public void SpawnFense()
    {
        for (int i = 0; i < 2; i++)
        {
            float z = Random.Range(-30f, 30f);
            float x = Random.Range(-7.5f, 7.5f);
            Vector3 tmp = lastSpawnedGround.transform.forward.normalized * z + lastSpawnedGround.transform.right.normalized * x;
            Instantiate(CanEndFense, lastSpawnedGround.transform.position + tmp, lastSpawnedGround.transform.rotation, lastSpawnedGround.transform);
        }

        for (int i = 0; i < 6; i++)
        {
            float z = Random.Range(-30f, 30f);
            float x = Random.Range(-7.5f, 7.5f);
            Vector3 tmp = lastSpawnedGround.transform.forward.normalized * z + lastSpawnedGround.transform.right.normalized * x;
            Instantiate(CanNotEndFense, lastSpawnedGround.transform.position + tmp, lastSpawnedGround.transform.rotation, lastSpawnedGround.transform);
        }
    }

    public void SpawnStraightItem()
    {
        float z = Random.Range(-30f, 30f);
        float x = Random.Range(-7.5f, 7.5f);
        Vector3 tmp = lastSpawnedGround.transform.forward.normalized * z + lastSpawnedGround.transform.right.normalized * x + Vector3.up;
        Instantiate(StraightItem, lastSpawnedGround.transform.position + tmp, Quaternion.identity, lastSpawnedGround.transform);
    }

    public void BakeNavMesh()
    {
        lastSpawnedGround.GetComponent<NavMeshSurface>().BuildNavMesh();
    }

    public void InCreaseStraightGround()
    {
        StopAllCoroutines();
        StartCoroutine(InCreaseStraightGroundCoroutine());
    }

    IEnumerator InCreaseStraightGroundCoroutine()
    {
        leftBound = 1;
        rightBound = 2;

        yield return new WaitForSeconds(10f);

        leftBound = 2;
        rightBound = 4;
    }
}

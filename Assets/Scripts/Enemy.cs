using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField]
    Transform player;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = GameManager.Instance.Player.transform.position;


        Debug.Log(Vector3.Distance(player.position, transform.position));

        if(Vector3.Distance(player.position, transform.position) < 1f)
        {
            GameManager.Instance.EndGame();
        }
    }
}

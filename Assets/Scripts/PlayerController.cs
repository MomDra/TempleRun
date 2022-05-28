using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigid;

    [SerializeField]
    float speed;
    float applySpeed;
    [SerializeField]
    float sideSpeed;
    float applySideSpeed;

    float mouseX;
    float mouseY;

    private void Awake() {
        rigid = GetComponent<Rigidbody>();

        applySpeed = speed;
        applySideSpeed = sideSpeed;

        GameManager.Instance.Player = gameObject;
        GameManager.Instance.SoundManager.PlayWalkSound();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.A)){
            rigid.MoveRotation(rigid.rotation * Quaternion.AngleAxis(-90f, Vector3.up));
        }
        else if(Input.GetKeyDown(KeyCode.D)){
            rigid.MoveRotation(rigid.rotation * Quaternion.AngleAxis(90f, Vector3.up));
        }

        mouseX = Input.GetAxisRaw("Mouse X");

        if (transform.position.y <= -5f) GameManager.Instance.EndGame();
    }

    private void FixedUpdate()
    {
        Vector3 nextPos = rigid.position + transform.forward.normalized * applySpeed * Time.deltaTime;
        nextPos += transform.right.normalized * mouseX * applySideSpeed * Time.deltaTime;

        rigid.MovePosition(nextPos);
    }

    public void SlowSpeed()
    {
        StartCoroutine(SlowSpeedCoroutine());
    }

    IEnumerator SlowSpeedCoroutine()
    {
        applySpeed -= 5f;
        applySideSpeed -= 5f;

        yield return new WaitForSeconds(1f);

        applySpeed = speed;
        applySideSpeed = sideSpeed;
    }
}

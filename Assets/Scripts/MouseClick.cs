using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{ 
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(GameManager.Instance.Score > 0)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, float.MaxValue))
                {
                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Obstacle") || hit.transform.gameObject.layer == LayerMask.NameToLayer("Pendulum"))
                    {
                        GameManager.Instance.EffectManager.PlayDestoryEffect(hit.transform.position);
                        Destroy(hit.transform.gameObject);

                        GameManager.Instance.Score--;
                        GameManager.Instance.UIManager.UpdateUI(GameManager.Instance.Score);
                    }
                }
            }
        }
    }
}

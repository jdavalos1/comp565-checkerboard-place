using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserShapeControl : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo);

            if (hit)
            {
                if(hitInfo.collider.transform == this.transform)
                    StartCoroutine(gameObject.GetComponent<Explosion>().SplitMesh(true));
            }
        }
    }
}

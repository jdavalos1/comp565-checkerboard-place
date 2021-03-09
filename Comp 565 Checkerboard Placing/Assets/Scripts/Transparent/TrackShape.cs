using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackShape : MonoBehaviour
{
    Renderer goRenderer;
    private readonly Color tranparentYellow = new Color(1, 0.912f, 0.016f, 0.3f);
    private readonly Color tranparentGreen = new Color(0, 1, 0, 0.3f);


    void Start()
    {
        goRenderer = gameObject.GetComponent<Renderer>();
        goRenderer.material.color = tranparentYellow;
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Input.mousePosition;
        if (gameObject.activeSelf)
        {
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(mousePos), out RaycastHit hitInfo);
            if(hit)
            {
                if (hitInfo.transform.CompareTag("Base"))
                {
                    // Use the position of the ray to and change the color
                    gameObject.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y + (0.5f), hitInfo.point.z);
                    goRenderer.material.color = tranparentYellow;
                }
                else
                {
                    // Change color before we move shape anywhere
                    goRenderer.material.color = tranparentGreen;
                    if (hitInfo.normal == new Vector3(0, 0, 1)) // z+
                    {
                        gameObject.transform.position = new Vector3(hitInfo.transform.position.x, hitInfo.transform.position.y, hitInfo.point.z + (0.5f));
                    }
                    if (hitInfo.normal == new Vector3(1, 0, 0)) // x+
                    {
                        gameObject.transform.position = new Vector3(hitInfo.point.x + (0.5f), hitInfo.transform.position.y, hitInfo.transform.position.z);
                    }
                    if (hitInfo.normal == new Vector3(0, 1, 0)) // y+
                    {
                        gameObject.transform.position = new Vector3(hitInfo.transform.position.x, hitInfo.point.y + (0.5f), hitInfo.transform.position.z);
                    }
                    if (hitInfo.normal == new Vector3(0, 0, -1)) // z-
                    {
                        gameObject.transform.position = new Vector3(hitInfo.transform.position.x, hitInfo.transform.position.y, hitInfo.point.z - (0.5f));
                    }
                    if (hitInfo.normal == new Vector3(-1, 0, 0)) // x-
                    {
                        gameObject.transform.position = new Vector3(hitInfo.point.x - (0.5f), hitInfo.transform.position.y, hitInfo.transform.position.z);
                    }
                    if (hitInfo.normal == new Vector3(0, -1, 0)) // y-
                    {
                        gameObject.transform.position = new Vector3(hitInfo.transform.position.x, hitInfo.point.y - (0.5f), hitInfo.transform.position.z);
                    }

                }
            }
        }
    }
}

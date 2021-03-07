using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{ 
    public List<GameObject> gameObjects;

    // Caching the current object to place
    GameObject currentObject;

    // Start is called before the first frame update
    void Start()
    {
        currentObject = gameObjects[0];
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0))  // check if left button is pressed
        {
            if (!currentObject.activeSelf)
            {
                SwapCurrentObject();
            }
            // take mouse position, convert from screen space to world space, do a raycast, store output of raycast into 
            // hitInfo object ...

            #region Screen To World
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo);
            if (hit)
            {

                #region HIDE
                var userShape = CreateClone();

                //cube.GetComponent<BoxCollider>().isTrigger = true;
                //cube.GetComponent<Renderer>().material = blockMaterial;
                #endregion

                //cube.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y + 0.5f, hitInfo.point.z);
                #region HIDE
                if (hitInfo.transform.CompareTag("Base"))
                {
                    userShape.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y + (0.5f), hitInfo.point.z);
                }
                #region HIDE
                else
                {
                    if (hitInfo.normal == new Vector3(0, 0, 1)) // z+
                    {
                        userShape.transform.position = new Vector3(hitInfo.transform.position.x, hitInfo.transform.position.y, hitInfo.point.z + (0.5f));
                    }
                    #region HIDE
                    if (hitInfo.normal == new Vector3(1, 0, 0)) // x+
                    {
                        userShape.transform.position = new Vector3(hitInfo.point.x + (0.5f), hitInfo.transform.position.y, hitInfo.transform.position.z);
                    }
                    if (hitInfo.normal == new Vector3(0, 1, 0)) // y+
                    {
                        userShape.transform.position = new Vector3(hitInfo.transform.position.x, hitInfo.point.y + (0.5f), hitInfo.transform.position.z);
                    }
                    if (hitInfo.normal == new Vector3(0, 0, -1)) // z-
                    {
                        userShape.transform.position = new Vector3(hitInfo.transform.position.x, hitInfo.transform.position.y, hitInfo.point.z - (0.5f));
                    }
                    if (hitInfo.normal == new Vector3(-1, 0, 0)) // x-
                    {
                        userShape.transform.position = new Vector3(hitInfo.point.x - (0.5f), hitInfo.transform.position.y, hitInfo.transform.position.z);
                    }
                    if (hitInfo.normal == new Vector3(0, -1, 0)) // y-
                    {
                        userShape.transform.position = new Vector3(hitInfo.transform.position.x, hitInfo.point.y - (0.5f), hitInfo.transform.position.z);
                    }
                    #endregion
                }
                #endregion

                //Debug.DrawRay(hitInfo.point, hitInfo.normal, Color.red, 2, false);
                //Debug.Log(hitInfo.normal);
                #endregion


            }
            else
            {
                Debug.Log(":p");
            }
            #endregion
        }
    }
    
    private void SwapCurrentObject()
    {
        // Iterate through the GOs and find the active one
        foreach(var go in gameObjects)
        {
            if(go.activeSelf)
            {
                currentObject = go;
                break;
            }
        }
    }

    private GameObject CreateClone()
    {
        GameObject go;
        if (currentObject.CompareTag("Cube"))
        {
            go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        }
        else if (currentObject.CompareTag("Sphere"))
        {
            go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        }
        else
        {
            go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        }

        go.tag = "UserShape";
        return go;
    }
}

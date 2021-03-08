using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{ 
    public List<GameObject> gameObjects;

    // Caching the current object in use
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

            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo);
            if (hit)
            {

                var userShape = CreateClone();

                //cube.GetComponent<BoxCollider>().isTrigger = true;
                //cube.GetComponent<Renderer>().material = blockMaterial;

                //cube.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y + 0.5f, hitInfo.point.z);
                if (hitInfo.transform.CompareTag("Base"))
                {
                    userShape.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y + (0.5f), hitInfo.point.z);
                }
                else
                {
                    if (hitInfo.normal == new Vector3(0, 0, 1)) // z+
                    {
                        userShape.transform.position = new Vector3(hitInfo.transform.position.x, hitInfo.transform.position.y, hitInfo.point.z + (0.5f));
                    }
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
                }
            }
            else
            {
                Debug.Log(":p");
            }
        }
    }
    
    // Swap the current object reference in the board
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
    
    // Create a primitive based on the transparents information
    private GameObject CreateClone()
    {
        PrimitiveType currentPrimitive = currentObject.GetComponent<Properties>().type;
        Material currentMat = currentObject.GetComponent<Properties>().GetMaterial();

        GameObject go = GameObject.CreatePrimitive(currentPrimitive);
        go.tag = "UserShape";

        go.GetComponent<MeshRenderer>().material = currentMat;

        go.AddComponent<Explosion>();
        go.AddComponent<UserShapeControl>();
        return go;
    }
}

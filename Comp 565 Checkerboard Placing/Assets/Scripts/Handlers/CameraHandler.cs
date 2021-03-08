using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public float speed;

    static readonly Vector3 basePos = new Vector3(0, 0, 0);
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(basePos, Vector3.up, speed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(basePos, Vector3.down, speed * Time.deltaTime);
        }
/*        else if (Input.GetKey(KeyCode.W))
        {
            transform.RotateAround(basePos, Vector3.left, speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.RotateAround(basePos, Vector3.right, speed * Time.deltaTime);
        }
*/    }
}

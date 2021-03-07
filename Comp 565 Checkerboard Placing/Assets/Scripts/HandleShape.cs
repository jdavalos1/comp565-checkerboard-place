using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleShape : MonoBehaviour
{
    GameObject transparent;
    Vector3 hiddenPosition;
    
    
    public GameObject cubeTransparent;
    public GameObject sphereTransparent;
    public GameObject capsuleTransparent;

    public List<Button> buttons;

    void Start()
    {
        // Create base and hidden positions
        hiddenPosition = new Vector3(0, -100, 0);

        // Set current positions
        transparent = cubeTransparent;
        transparent.transform.position = new Vector3(0, 0.55f, 0);

        // Set other transparent trackers as inactive
        sphereTransparent.SetActive(false);
        capsuleTransparent.SetActive(false);

        // Set listeners when swap buttons detected
        buttons[0].onClick.AddListener(() => Swapper(cubeTransparent));
        buttons[1].onClick.AddListener(() => Swapper(sphereTransparent));
        buttons[2].onClick.AddListener(() => Swapper(capsuleTransparent));
    }

    private void Swapper(GameObject go)
    {
        // Obtain last position of the transparent
        var lastPos = transparent.transform.position;
        
        // Deactivate and hide the last shape
        transparent.SetActive(false);
        transparent.transform.position = hiddenPosition;
        
        // New transparent set w/last pos
        transparent = go;
        transparent.SetActive(true);
        transparent.transform.position = lastPos;
    }
 }

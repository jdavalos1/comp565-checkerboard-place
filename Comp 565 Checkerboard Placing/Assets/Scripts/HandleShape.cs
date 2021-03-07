using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleShape : MonoBehaviour
{
    GameObject transparent;
    Vector3 basePosition;
    Vector3 hiddenPosition;
    
    
    public GameObject cubeTransparent;
    public GameObject sphereTransparent;
    public GameObject capsuleTransparent;

    public List<Button> buttons;

    void Start()
    {
        // Create base and hidden positions
        basePosition = new Vector3(0, 0.55f, 0);
        hiddenPosition = new Vector3(0, -100, 0);

        // Set current positions
        transparent = cubeTransparent;
        transparent.transform.position = basePosition;

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
        transparent.SetActive(false);
        transparent.transform.position = hiddenPosition;
        transparent = go;
        transparent.SetActive(true);
        transparent.transform.position = basePosition;
    }
 }

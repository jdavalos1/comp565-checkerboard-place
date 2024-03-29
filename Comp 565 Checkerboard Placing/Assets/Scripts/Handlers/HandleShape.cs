﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Handle the current controlled shape by activating and hiding
public class HandleShape : MonoBehaviour
{
    GameObject transparent;
    Vector3 hiddenPosition;
    
    public List<GameObject> gos;
    public List<Button> buttons;

    void Start()
    {
        // Create base and hidden positions
        hiddenPosition = new Vector3(0, -100, 0);

        // Set current positions
        transparent = gos[0];
        transparent.transform.position = new Vector3(0, 0.55f, 0);

        // Set other transparent trackers as inactive
        gos[1].SetActive(false);
        gos[2].SetActive(false);

        // Set listeners when swap buttons detected
        buttons[0].onClick.AddListener(() => Swapper(0));
        buttons[1].onClick.AddListener(() => Swapper(1));
        buttons[2].onClick.AddListener(() => Swapper(2));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Swapper(0);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Swapper(1);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Swapper(2);
        }
    }

    private void Swapper(int index)
    {
        // Obtain last position of the transparent
        var lastPos = transparent.transform.position;
        
        // Deactivate and hide the last shape
        transparent.SetActive(false);
        transparent.transform.position = hiddenPosition;
        
        // New transparent set w/last pos
        transparent = gos[index];
        transparent.SetActive(true);
        transparent.transform.position = lastPos;
    }
 }

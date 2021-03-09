using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Handle the texture of every shape
public class HandleTextures : MonoBehaviour
{
    public List<GameObject> gos;
    public List<Button> buttons;

    public List<Material> mats;

    // Start is called before the first frame update
    void Start()
    {
        Swapper(0);
        // Set all button listeners in panel
        buttons[0].onClick.AddListener(() => Swapper(0));
        buttons[1].onClick.AddListener(() => Swapper(1));
        buttons[2].onClick.AddListener(() => Swapper(2));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Swapper(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Swapper(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Swapper(2);
        }
    }
    // Swap all materials
    void Swapper(int index)
    {
        gos.ForEach(go => go.GetComponent<Properties>().SwapCurrentMaterial(mats[index]));
    }
}

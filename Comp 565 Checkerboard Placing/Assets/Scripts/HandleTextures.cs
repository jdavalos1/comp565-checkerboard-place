using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleTextures : MonoBehaviour
{
    public List<Button> buttons;

    // Start is called before the first frame update
    void Start()
    {
        buttons[0].onClick.AddListener(null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

}

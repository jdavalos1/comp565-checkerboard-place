using UnityEngine;

// A class to house some important properties of each shape
public class Properties : MonoBehaviour
{
    public PrimitiveType type;

    private Material CurrentMat;

    public void SwapCurrentMaterial(Material newMat)
    {
        CurrentMat = newMat;
    }

    public Material GetMaterial()
    {
        return CurrentMat;
    }

}

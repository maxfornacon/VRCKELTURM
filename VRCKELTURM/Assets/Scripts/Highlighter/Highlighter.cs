using System.Collections;
using UnityEngine;

public class Highlighter : MonoBehaviour
{
    //Referenz zum Outline Material
    private Material _outlineMaterial;

    //Konstanten zum Referenzieren auf Breite des Outline Materials im Shader
    private const string OutlineWidthKey = "_Outline";
    private const float OutlineWidthValue = 1.5f;

    void Start()
    {
        _outlineMaterial = GetComponent<Renderer>().materials[1];
        _outlineMaterial.SetFloat(OutlineWidthKey, 0);
    }

    // Shows the outline by setting the width to be a fixed avalue when we are 
    // pointing at it.
    public void ShowOutlineMaterial()
    {
        _outlineMaterial.SetFloat(OutlineWidthKey, OutlineWidthValue);
    }

    // Hides the outline by making the width 0 when we are no longer 
    // pointing at it.
    public void HideOutlineMaterial()
    {
        _outlineMaterial.SetFloat(OutlineWidthKey, 0);
    }

    public void ClickOutlineMaterial()
    {

        _outlineMaterial.SetFloat(OutlineWidthKey, OutlineWidthValue);
    }
}
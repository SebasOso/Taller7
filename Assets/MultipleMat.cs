using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleMat : MonoBehaviour
{
    public Material[] materiales;

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.materials = materiales;
    }
}

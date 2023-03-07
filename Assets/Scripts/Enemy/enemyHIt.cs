using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHIt : MonoBehaviour
{
    public int valor;
    [SerializeField]
    private GameObject obj;
    Material material;
    // Start is called before the first frame update
    void Start()
    {
        valor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (valor == 0)
        {
            material = obj.GetComponent<Renderer>().material;
            material.color = Color.green;
        }
        if (valor==1)
        {
            material = obj.GetComponent<Renderer>().material;
            material.color = Color.yellow;
        }
        if (valor == 2)
        {
            material = obj.GetComponent<Renderer>().material;
            material.color = Color.red;
        }
        if (valor == 3)
        {
            Destroy(obj);
        }

    }

    public void incrementarvalor()
    {
        valor++;
    }
}

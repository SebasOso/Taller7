using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public int valor;
    [SerializeField] private GameObject obj;
    [SerializeField ]private GameObject healthBar;
    Material material;
    void Start()
    {
        valor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (valor == 0)
        {
            material = healthBar.GetComponent<Renderer>().material;
            material.color = Color.green;
        }
        if (valor==1)
        {
            material = healthBar.GetComponent<Renderer>().material;
            material.color = Color.yellow;
        }
        if (valor == 2)
        {
            material = healthBar.GetComponent<Renderer>().material;
            material.color = Color.red;
        }
        if (valor == 3)
        {
            Destroy(healthBar);
            Destroy(obj);
        }

    }

    public void IncrementarValor()
    {
        valor++;
    }
}

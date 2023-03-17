using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
   // public DoorScript abrirpuerta;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           // abrirpuerta.desbloqueada = true;
        }
        Destroy(gameObject);
    }
}

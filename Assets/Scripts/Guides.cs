using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guides : MonoBehaviour
{
    public GameObject[] checkpoints; // Array de checkpoints
    private int currentCheckpoint = 0; // Índice del checkpoint actual

    void Start()
    {
        // Apagar todos los checkpoints excepto el primero
        for (int i = 1; i < checkpoints.Length; i++)
        {
            checkpoints[i].SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el jugador colisiona con un objeto con el tag "Guides"
        if (other.CompareTag("Guides"))
        {
            Debug.Log("aaaaaaaaaaaaaaaaaaaa");
            // Verificar si el objeto con el tag "Guides" es el checkpoint actual
            if (other.gameObject == checkpoints[currentCheckpoint])
            {
                // Apagar el checkpoint actual
                checkpoints[currentCheckpoint].SetActive(false);

                // Incrementar el índice del checkpoint actual
                currentCheckpoint++;

                // Verificar si se alcanzaron todos los checkpoints
                if (currentCheckpoint >= checkpoints.Length)
                {
                    Debug.Log("¡Has completado todos los checkpoints!");
                    return;
                }

                // Encender el siguiente checkpoint
                checkpoints[currentCheckpoint].SetActive(true);
            }
        }
    }
}
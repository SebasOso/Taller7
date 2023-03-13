using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] private GameObject key;
    void Update()
    {
        if (Jugador.instance.enemyIsDead == true)
        {
            key.SetActive(true);
        }
    }
}

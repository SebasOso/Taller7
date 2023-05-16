using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] GameObject enemyOne;
    [SerializeField] GameObject enemyTwo;
    [SerializeField] private bool stopOne;
    [SerializeField] private bool stopTwo;
    void Update()
    {
        if (!enemyOne.activeSelf)
        {
            if(!stopOne)
            {
                StartCoroutine(HoldOne());
            }
        }
        if (!enemyTwo.activeSelf)
        {
            if (!stopTwo)
            {
                StartCoroutine(HoldTwo());
            }
        }
    }
    IEnumerator HoldOne()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("DESACTIVADO");
        stopOne = true;
        Player.Instance.onDesesperation = false;
    }
    IEnumerator HoldTwo()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("DESACTIVADO");
        stopTwo = true;
        Player.Instance.onDesesperation = false;
    }
}

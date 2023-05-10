using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemiesManager : MonoBehaviour
{
    [SerializeField] GameObject enemyOne;
    [SerializeField] private bool stopOne;
    void Update()
    {
        if(UITutorialManager.Instance.isMeleeSpawned)
        {
            if (!enemyOne.activeSelf)
            {
                if (!stopOne)
                {
                    StartCoroutine(HoldOne());
                }
            }
        }
    }
    IEnumerator HoldOne()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("DESACTIVADO");
        stopOne = true;
        TutorialMovement.Instance.onDesesperation = false;
    }
}

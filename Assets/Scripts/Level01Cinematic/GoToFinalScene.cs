using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToFinalScene : MonoBehaviour, IDataPersistence
{
    public void LoadData(GameData data)
    {
    }
    public void SaveData(GameData data)
    {
        data.collectablesIndexes[0] = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("FinalCinematic");
        }
    }
}

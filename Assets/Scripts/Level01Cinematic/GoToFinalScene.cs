using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToFinalScene : MonoBehaviour, IDataPersistence
{
    [SerializeField] private bool levelCompleted;
    public void LoadData(GameData data)
    {
    }
    public void SaveData(GameData data)
    {
        if (levelCompleted)
        {
            data.collectablesIndexes[0] = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            levelCompleted = true;
            DataPersistenceManager.instance.SaveGame();
            SceneManager.LoadScene("Lobby");  
        }
    }
}

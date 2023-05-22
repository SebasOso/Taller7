using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level02Scene : MonoBehaviour, IDataPersistence
{
    private int level2 = 0; 
    public void LoadData(GameData data)
    {
    }

    public void SaveData(GameData data)
    {
        data.firstTimeLvl2 = level2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level02Cinematic");
            level2 = 1;
            DataPersistenceManager.instance.SaveGame();
        }
    }
}

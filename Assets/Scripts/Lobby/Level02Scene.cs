using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level02Scene : MonoBehaviour, IDataPersistence
{
    private int level2; 
    public void LoadData(GameData data)
    {
        level2 = data.firstTimeLvl2;
    }

    public void SaveData(GameData data)
    {
        data.firstTimeLvl2 = level2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            level2 = 1;
            DataPersistenceManager.instance.SaveGame();
            SceneManager.LoadScene("Level02Cinematic");
        }
    }
}

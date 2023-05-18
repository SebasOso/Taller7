using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLevel02Manager : MonoBehaviour,IDataPersistence
{
    [SerializeField] private GameObject level02TP;
    [SerializeField] private GameObject level02Partycles;
    [SerializeField] private GameObject level02Door;
    [SerializeField] private GameObject particlesLevel01;
    public void LoadData(GameData data)
    {
        if (data.collectablesIndexes[0] == 1)
        {
            level02Partycles.SetActive(true);
            level02TP.SetActive(true);
            level02Door.SetActive(true);
            particlesLevel01.SetActive(false);
        }
        else
        {
            level02Partycles.SetActive(false);
            level02TP.SetActive(false);
            level02Door.SetActive(false);
            particlesLevel01.SetActive(true);
        }
    }

    public void SaveData(GameData data)
    {
        
    }
}

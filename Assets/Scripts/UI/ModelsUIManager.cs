using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelsUIManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] private GameObject keyModel;
    [SerializeField] private int keyCollected;
    private void Update()
    {
        ShowKey();
    }
    public void LoadData(GameData data)
    {
        keyCollected = data.keyCollected;
    }

    public void SaveData(GameData data)
    {
        //data.keyCollected = keyCollected;
    }       
    private void ShowKey()
    {
        if (keyCollected == 1)
        {
            keyModel.SetActive(true);
        }
        else if (keyCollected == 0)
        {
            keyModel.SetActive(false);
        }
    }
}

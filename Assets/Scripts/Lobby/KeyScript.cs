using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour, IDataPersistence
{
    [SerializeField] private GameObject keyImage;
    [SerializeField] private int keyIndex;
    public void LoadData(GameData data)
    {
       
    }
    public void SaveData(GameData data)
    {
        data.keyCollected = keyIndex;
    }

    // public DoorScript abrirpuerta;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // abrirpuerta.desbloqueada = true;
            keyIndex = 1;
            DataPersistenceManager.instance.SaveGame();
            //DataPersistenceManager.instance.LoadGame();
            keyImage.SetActive(true);
        }
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour, IDataPersistence
{
    [SerializeField] private int keyIndex;
    [SerializeField] private GameObject pointerGuide;
    [SerializeField] private GameObject guideKey;
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
            pointerGuide.SetActive(false);
            guideKey.SetActive(false);
            DataPersistenceManager.instance.SaveGame();
            DataPersistenceManager.instance.LoadGame();
        }
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour, IDataPersistence
{
    [SerializeField] private bool collected;
    public void LoadData(GameData data) 
    {
    }

    public void SaveData(GameData data) 
    {
        if (collected)
        {
            if (!data.checkPositions.Contains(this.transform.position))
            {
                data.checkPositions.Add(this.transform.position);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("TRIGER");
            collected = true;
            DataPersistenceManager.instance.SaveGame();
        }
    }
}

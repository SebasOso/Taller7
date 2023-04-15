using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid() 
    {
        id = System.Guid.NewGuid().ToString();
    }

    [SerializeField]private GameObject visual;
    [SerializeField]private bool collected = false;

    public void LoadData(GameData data) 
    {
        data.checksCollected.TryGetValue(id, out collected);
        if (collected) 
        {
            visual.SetActive(false);
        }
    }

    public void SaveData(GameData data) 
    {
        if (data.checksCollected.ContainsKey(id))
        {
            data.checksCollected.Remove(id);
        }
        data.checksCollected.Add(id, collected);
        if (collected)
        {
            data.playerPosition = this.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("TRIGER");
            if (!collected)
            {
                CollectCoin();
            }
        }
    }
    private void CollectCoin() 
    {
        collected = true;
        visual.SetActive(false);
    }

}

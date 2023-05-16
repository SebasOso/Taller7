using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour, IDataPersistence
{
    public int[] collectablesIndexes;
    public List<GameObject> collectables;

    public void LoadData(GameData data)
    {
        this.collectablesIndexes = data.collectablesIndexes;
    }

    public void SaveData(GameData data)
    {
    }
    private void Update()
    {
        UpdateCollectables();
    }
    private void UpdateCollectables()
    {
        if (collectablesIndexes[0] == 1)
        {
            collectables[0].SetActive(true);
        }
        else if (collectablesIndexes[0] == 0)
        {
            collectables[0].SetActive(false);
        }
        if (collectablesIndexes[1] == 1)
        {
            collectables[1].SetActive(true);
        }
        else if (collectablesIndexes[1] == 0)
        {
            collectables[1].SetActive(false);
        }
        if (collectablesIndexes[2] == 1)
        {
            collectables[2].SetActive(true);
        }
        else if (collectablesIndexes[2] == 0)
        {
            collectables[2].SetActive(false);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowFolderManager : MonoBehaviour, IDataPersistence
{
    private int folderShow;
    private int folderDone;
    [SerializeField] private RawImage folderImage;
    private void Update()
    {
        if(Guides.Instance.counter >= 10)
        {
            folderShow = 1;
            folderDone = 1;
            DataPersistenceManager.instance.SaveGame();
        }
        if(folderShow == 1)
        {
            folderImage.gameObject.SetActive(true);
        }
        if(folderShow == 0)
        {
            folderImage.gameObject.SetActive(false);
        }
    }
    public void LoadData(GameData data)
    {
        folderShow = data.folderCollected;
        folderDone = data.collectablesIndexes[1];
    }

    public void SaveData(GameData data)
    {
        data.folderCollected = folderShow;
        data.collectablesIndexes[1] = folderDone;
    }
}

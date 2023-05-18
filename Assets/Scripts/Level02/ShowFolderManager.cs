using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowFolderManager : MonoBehaviour, IDataPersistence
{
    private int folderShow;
    [SerializeField] private RawImage folderImage;
    private void Update()
    {
        if(Guides.Instance.counter >= 10)
        {
            folderShow = 1;
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
    }

    public void SaveData(GameData data)
    {
        data.folderCollected = folderShow;
    }
}

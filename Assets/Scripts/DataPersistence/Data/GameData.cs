using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int lifes;
    public List<Vector3> checkPositions;
    public int[] collectablesIndexes;
    public float soundVolume;
    public float musicVolume;
    public int keyCollected;
    public int folderCollected;
    public int firstTimeLvl2;
    public GameData() 
    {
        collectablesIndexes = new int[3] {0,0,0};
        this.lifes = 5;
        checkPositions = new List<Vector3>();
        musicVolume = 1;
        soundVolume = 1;
        keyCollected = 0;
        folderCollected = 0;
        firstTimeLvl2 = 0;
    }
}

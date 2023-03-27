using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int lifes;
    public List<Vector3> checkPositions;
    public int[] collectablesIndexes;
    public GameData() 
    {
        collectablesIndexes = new int[3] {0,0,0};
        this.lifes = 5;
        checkPositions = new List<Vector3>();
    }
}

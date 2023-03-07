using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int lifes;
    public List<Vector3> checkPositions;
    public GameData() 
    {
        this.lifes = 5;
        checkPositions = new List<Vector3>();
    }
}

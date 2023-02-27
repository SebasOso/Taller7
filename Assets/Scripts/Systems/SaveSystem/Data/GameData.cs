using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int lifes;
    public GameData()
    {
        this.lifes = 5;
    }
}

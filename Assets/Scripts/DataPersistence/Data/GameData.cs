using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int lifes;
    public Vector3 playerPosition;
    public SerializableDictionary<string, bool> checksCollected;

    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to load
    public GameData() 
    {
        this.lifes = 5;
        playerPosition = new Vector3(-12.05f,0.29f,-8.04316f);
        checksCollected = new SerializableDictionary<string, bool>();
    }
}

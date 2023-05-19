using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> otherCharacters;
    [SerializeField] private GameObject defaultCharacter;
    public void CharactersDefault()
    {
        for (int i = 0; i < otherCharacters.Count; i++)
        {
            otherCharacters[i].SetActive(false);
        }
        defaultCharacter.SetActive(true);
    }
}

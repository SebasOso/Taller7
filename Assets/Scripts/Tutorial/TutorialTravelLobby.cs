using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialTravelLobby : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DataPersistenceManager.instance.SaveGame();
            SceneManager.LoadScene("Lobby");
        }
    }
}

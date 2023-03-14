using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Configurations : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public void CloseGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        Jugador.instance.canJump = false;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        Jugador.instance.canJump = true;
    }
    public void StopMusic()
    {
        audioSource.mute = true;
    }
    public void PlayMusic()
    {
        audioSource.mute = false;
    }
    public void GoLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialConfigurationsManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject gameplay;
    [SerializeField] private GameObject checkMute;
    private bool isPaused;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    private void Start()
    {
        pauseMenu.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void CloseGame()
    {
        Application.Quit();
    }
    private void PauseGame()
    {
        gameplay.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        TutorialMovement.Instance.canJump = false;
        isPaused = true;
    }
    public void ResumeGame()
    {
        gameplay.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        TutorialMovement.Instance.canJump = true;
        isPaused = false;
    }
    public void StopMusic()
    {
        if (audioSource.mute == false)
        {
            audioSource.mute = true;
            checkMute.SetActive(true);
        }
        else
        {
            audioSource.mute = false;
            checkMute.SetActive(false);
        }
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

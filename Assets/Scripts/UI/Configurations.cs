using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Configurations : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject gameplay;
    [SerializeField] private GameObject checkMute;
    [SerializeField] private List<GameObject> otherMenuOptions;
    [SerializeField] private GameObject defaultMenuOption;
    [SerializeField] private bool menuOpened = false;
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
    public void Pause()
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
    public void CloseGame()
    {
        Application.Quit();
    }
    private void PauseGame()
    {
        menuOpened = true;
        if (menuOpened)
        {
            for(int i = 0; i < otherMenuOptions.Count; i++)
            {
                otherMenuOptions[i].SetActive(false);
            }
            defaultMenuOption.SetActive(true);
        }
        gameplay.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Player.Instance.canJump = false;
        isPaused = true;
    }
    public void ResumeGame()
    {
        gameplay.SetActive(true );
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        Player.Instance.canJump = true;
        isPaused = false;
        menuOpened = false;
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

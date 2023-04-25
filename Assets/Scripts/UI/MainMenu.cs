using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [Header("MenuButtoms")]
    [SerializeField] private Button newGameButtom;
    [SerializeField] private Button continueGameButtom;
    private void Start()
    {
        if (!DataPersistenceManager.instance.HasBeenGameData())
        {
            continueGameButtom.interactable = false;
        }
    }
    public void OnNewGameClicked()
    {
        DisableMenuButtoms();
        Debug.Log("New Game Clicked");
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadSceneAsync("IntroCinematic");
    }
    public void OnContinueGameClicked()
    {
        DisableMenuButtoms();
        Debug.Log("Continue Game Clicked");
        SceneManager.LoadSceneAsync("IntroCinematic");
    }
    private void DisableMenuButtoms()
    {
        newGameButtom.interactable = false;
        continueGameButtom.interactable = false;
    }
}

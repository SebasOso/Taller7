using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class TutorialEvents : MonoBehaviour
{
    private bool hasShownLoock = false;
    public bool meleeEnemyIsDead;
    [SerializeField] private GameObject rangedEnemy;
    private bool hasShowRanged = false;
    private bool hasShownRange;
    public bool keyCollected = false;
    public bool enemyRangeIsDead = false;
    private bool keyHasShow = false;
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject keyImage;
    [SerializeField] private GameObject travelLobby;
    [SerializeField] private GameObject guideKey;
    [SerializeField] private GameObject lobbyGuide;
    private bool pauseHasShown;

    public static TutorialEvents Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasShownLoock)
        {
            ShowLoock();
        }
        if(meleeEnemyIsDead && !hasShowRanged) 
        {
            ShowRangedEnemy();
        }
        ShowKey();
        Key();
        Travel();
    }
    private void ShowLoock()
    {
        if (UITutorialManager.Instance.welcomeHint.activeSelf == false)
        {
            UITutorialManager.Instance.LoockAround();
            hasShownLoock = true;
        }
    }
    private void ShowRangedEnemy()
    {
        if(!hasShownRange)
        {
            UITutorialManager.Instance.RangedEnemy();
            rangedEnemy.SetActive(true);
            hasShownRange = true;
        }
    }
    private void Key()
    {
        if(keyCollected)
        {
            key.SetActive(false);
            keyImage.SetActive(true);
            guideKey.SetActive(false);
        }
    }
    private void ShowKey()
    {
        if(!keyHasShow && enemyRangeIsDead)
        {
            key.SetActive(true);
            guideKey.SetActive(true);
            if (!pauseHasShown)
            {
                UITutorialManager.Instance.Pause();
                pauseHasShown = true;
            }
            keyHasShow = true;
        }
    }
    private void Travel()
    {
        if(keyCollected)
        {
            travelLobby.SetActive(true);
            lobbyGuide.SetActive(true);
        }
    }
}

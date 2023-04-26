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
        UITutorialManager.Instance.RangedEnemy();
        rangedEnemy.SetActive(true);
    }
}

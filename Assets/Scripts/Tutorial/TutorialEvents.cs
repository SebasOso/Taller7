using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class TutorialEvents : MonoBehaviour
{
    private bool hasShownLoock = false;
    public bool meleeEnemyIsDead;
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
    }
    private void ShowLoock()
    {
        if (UITutorialManager.Instance.welcomeHint.activeSelf == false)
        {
            UITutorialManager.Instance.LoockAround();
            hasShownLoock = true;
        }
    }
}

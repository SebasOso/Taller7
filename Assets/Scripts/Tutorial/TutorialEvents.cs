using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEvents : MonoBehaviour
{
    private bool hasShownLoock = false;
    [SerializeField] GameObject meleeEnemy;
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
    private void MeleeEnemy()
    {
        StartCoroutine(ShowMelee());
        meleeEnemy.SetActive(true);
    }
    private IEnumerator ShowMelee()
    {
        yield return new WaitForSeconds(5);
        UITutorialManager.Instance.Melee();
    }
}

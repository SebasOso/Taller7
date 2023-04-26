using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITutorialManager : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] public GameObject welcomeHint;
    [SerializeField] public GameObject loockAroundHint;
    [SerializeField] public GameObject movementHint;
    [SerializeField] public GameObject meleeHint;
    public bool mouse = false;
    public bool movement = false;
    public bool enemyPrepare = false;
    public static UITutorialManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Welcome();
    }
    public void Welcome()
    {
        welcomeHint.SetActive(true);
        StartCoroutine(DontShowWelcome());
    }
    private IEnumerator DontShowWelcome()
    {
        yield return new WaitForSeconds(6);
        welcomeHint.SetActive(false);
    }
    public void LoockAround()
    {
        loockAroundHint.SetActive(true);
        StartCoroutine(DontShowLoock());
    }
    public void Movement()
    {
        movementHint.SetActive(true);
        StartCoroutine(DontShowMovement());
    }
    private IEnumerator DontShowLoock()
    {
        yield return new WaitForSeconds(6);
        loockAroundHint.SetActive(false);
        mouse = true;
    }
    private IEnumerator DontShowMovement()
    {
        yield return new WaitForSeconds(6);
        movementHint.SetActive(false);
        movement = true;    
    }
    public void Melee()
    {
        meleeHint.SetActive(true);
    }
    private IEnumerator DontShowMelee()
    {
        yield return new WaitForSeconds(6);
        meleeHint.SetActive(false);
    }
}

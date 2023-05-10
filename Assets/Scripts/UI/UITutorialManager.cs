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
    [SerializeField] public GameObject meleePrepare;
    [SerializeField] public GameObject meleeEnemy;
    [SerializeField] public GameObject rangedEnemy;
    [SerializeField] public GameObject pause;
    [SerializeField] public bool isMeleeSpawned;
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
        yield return new WaitForSeconds(3);
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
    public void MeleeSpawn()
    {
        meleeHint.SetActive(true);
        StartCoroutine(DontShowMelee());
    }
    private IEnumerator DontShowMelee()
    {
        yield return new WaitForSeconds(6);
        meleeHint.SetActive(false);
    }
    public void MeleePrepare()
    {
        meleePrepare.SetActive(true);
        StartCoroutine(DontShowMeleePrepare());
    }
    private IEnumerator DontShowMeleePrepare()
    {
        yield return new WaitForSeconds(6);
        meleePrepare.SetActive(false);
        enemyPrepare = true;
        StartCoroutine(SpawnEnemy());
    }
    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(3);
        meleeEnemy.SetActive(true);
        isMeleeSpawned = true;
    }
    public void RangedEnemy()
    {
        rangedEnemy.SetActive(true);
        StartCoroutine(DontShowRanged());
    }
    private IEnumerator DontShowRanged()
    {
        yield return new WaitForSeconds(8);
        rangedEnemy.SetActive(false);
    }
    public void Pause()
    {
        pause.SetActive(true);
        StartCoroutine(DontShowPause());
    }
    private IEnumerator DontShowPause()
    {
        yield return new WaitForSeconds(6);
        pause.SetActive(false);
    }
}

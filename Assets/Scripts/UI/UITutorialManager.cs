using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITutorialManager : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] GameObject cameraMovement;
    [SerializeField] public GameObject welcomeHint;
    [SerializeField] public GameObject loockAroundHint;
    [SerializeField] public GameObject movementHint;
    [SerializeField] public GameObject jumpHint;
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
        cameraMovement.SetActive(true);
    }
    private IEnumerator DontShowMovement()
    {
        yield return new WaitForSeconds(6);
        movementHint.SetActive(false);
    }
    public void Jump()
    {
        jumpHint.SetActive(true);
        StartCoroutine(DontShowJump());
    }
    private IEnumerator DontShowJump()
    {
        yield return new WaitForSeconds(6);
        jumpHint.SetActive(false);
    }
}

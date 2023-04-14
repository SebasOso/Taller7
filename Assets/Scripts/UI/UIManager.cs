using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] public GameObject LevelHint;
    [SerializeField] public GameObject MeleeHint;
    [SerializeField] public GameObject EnemyRangeHint;
    public static UIManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        ShowLevelHint();
    }
    public void ShowHint()
    {
        EnemyRangeHint.SetActive(true);
        StartCoroutine(DontShowHint());
    }
    private IEnumerator DontShowHint()
    {
        yield return new WaitForSeconds(3);
        EnemyRangeHint.SetActive(false);
    }
    public void ShowMeleeHint()
    {
        MeleeHint.SetActive(true);
        StartCoroutine(DontShowHintMelee());
    }
    private void ShowLevelHint()
    {
        LevelHint.SetActive(true);
        StartCoroutine (DontShowLevelHint());
    }
    private IEnumerator DontShowHintMelee()
    {
        yield return new WaitForSeconds(3);
        MeleeHint.SetActive(false);
    }
    private IEnumerator DontShowLevelHint()
    {
        yield return new WaitForSeconds(6);
        LevelHint.SetActive(false);
    }
}

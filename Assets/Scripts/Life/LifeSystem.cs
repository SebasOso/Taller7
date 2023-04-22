using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using CodeMonkey.Utils;


public class LifeSystem : MonoBehaviour, IDataPersistence
{
    private bool isDied = false;
    [Header("Player Health")]
    public float health;
    public float playerHealth = 10;
    public static bool isAlive = true;
    public int playerLifes = 0;
    public GameObject[] lifesIcons;

    [Header("Invincibility parameters")]
    public float invincibilityLength;
    private float invincibilityCounter;


    [Header("UI Elements")]
    public Image frontHealth;
    public Image backHealth;
    private float lerpTimer;
    public float chipSpeed = 2f;
    private Color32 DamageHealthColor = new Color32(219, 49, 49, 255);


    [Header("Invincibility Flash Mesh Renderer")]
    public Renderer[] playerParts;
    public GameObject Player;
    public Renderer PlayerBody;
    public float flashLength;
    private float flashCounter = 0.1f;
    [SerializeField]private Color32 defaultSkinColor = new Color32(255, 255, 255, 255);
    private Color32 DamageSkinColor = new Color32(255, 175, 175, 255);
    private bool noLifes;
    //[SerializeField] private TextMeshProUGUI lifes;
    public static LifeSystem Instance { get; private set; }
    private void Awake()
    {
        //SaveSystem.Instance.Load();
        isAlive = true;
        health = playerHealth;
        Instance = this;             
    }

    void Start()
    {
        UpdateLifes();
        isAlive = true;
    }
    void Update()
    {
        //lifes.text = "" + playerLifes;
        HealthBarColor();
        health = Mathf.Clamp(health, 0, playerHealth);
        UpdateHealthUI();
        if (health <= 0 && !isDied)
        {
            if (noLifes == true)
            {
                Die();
            }
            else
            {
                RestLifes();
                health = 10;
            }
        }
        Invulnerability();
    }
    public void UpdateLifes()
    {
        int iconsToActivate = playerLifes;
        int iconsToDeactivate = lifesIcons.Length - playerLifes;

        for (int i = 0; i < lifesIcons.Length; i++)
        {
            if (i < iconsToActivate)
            {
                lifesIcons[i].SetActive(true);
            }
            else if (i < iconsToActivate + iconsToDeactivate)
            {
                lifesIcons[i].SetActive(false);
            }
        }
    }
    private void RestLifes()
    {
        playerLifes--;
        UpdateLifes();
        DataPersistenceManager.instance.SaveGame();
        DataPersistenceManager.instance.LoadGame();
        if (playerLifes == 0)
        {
            noLifes = true;
        }
    }

    public void HurtPlayer(int playerDamaged)
    {
        if (invincibilityCounter <= 0)
        {
            health -= playerDamaged;
            lerpTimer = 0f;
            invincibilityCounter = invincibilityLength;
            PlayerBody.material.color = DamageSkinColor;
            Physics.IgnoreLayerCollision(10, 11, true);
            flashCounter = flashLength;
        }
    }

    private void HealthBarColor()
    {
        if (health <= 10 && health >= 6)
        {
            frontHealth.color = UtilsClass.GetColorFromString("2BFF00");
        }

        if (health <= 5 && health >= 3)
        {
            frontHealth.color = UtilsClass.GetColorFromString("FFE312");
        }

        if (health <= 2 && health >= 0)
        {
            frontHealth.color = UtilsClass.GetColorFromString("FF2613");
        }

    }
    public void UpdateHealthUI()
    {
        float fillF = frontHealth.fillAmount;
        float fillB = backHealth.fillAmount;
        float hFraction = health / playerHealth;
        if (fillB > hFraction)
        {
            frontHealth.fillAmount = hFraction;
            backHealth.color = DamageHealthColor;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealth.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if (fillF < hFraction)
        {
            backHealth.color = Color.white;
            backHealth.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealth.fillAmount = Mathf.Lerp(fillF, backHealth.fillAmount, percentComplete);
        }
    }
    private void Die()
    {
        isDied = true;
        SetDefault();
        DataPersistenceManager.instance.LoadGame();
        SceneManager.LoadSceneAsync("Level01");
    }
    private void Invulnerability()
    {
        if (invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                for (int i = 0; i < playerParts.Length; i++)
                {
                    playerParts[i].enabled = !playerParts[i].enabled;
                }

                flashCounter = flashLength;
            }
            if (invincibilityCounter <= 0)
            {
                for (int i = 0; i < playerParts.Length; i++)
                {

                    playerParts[i].enabled = true;
                }
                PlayerBody.material.color = defaultSkinColor;
                Physics.IgnoreLayerCollision(10, 11, false);
            }
        }
    }

    public void LoadData(GameData data)
    {
        this.playerLifes = data.lifes;
        if (data.checkPositions.Count > 0)
        {
            Vector3 lastCheckPosition = data.checkPositions[data.checkPositions.Count - 1];
            this.transform.position = lastCheckPosition;
        }
    }

    public void SaveData(GameData data)
    {
        data.lifes = this.playerLifes;
    }
    private void SetDefault()
    {
        this.playerLifes = 5;
    }
}

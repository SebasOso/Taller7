using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;


public class LifeSystem : MonoBehaviour
{
    private bool isDied = false;
    [Header("Player Health")]
    public float health;
    public float playerHealth = 10;
    public static bool isAlive = true;

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
    private Color32 defaultSkinColor = new Color32(255, 255, 255, 255);
    private Color32 DamageSkinColor = new Color32(255, 175, 175, 255);

    public static LifeSystem Instance { get; private set; }

    private void Awake()
    {
        isAlive = true;
        health = playerHealth;
        Instance = this;             
    }
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HurtPlayer(int playerDamaged)
    {
        if (invincibilityCounter <= 0)
        {
            health -= playerDamaged;
            invincibilityCounter = invincibilityLength;
            PlayerBody.material.color = DamageSkinColor;
            Physics.IgnoreLayerCollision(10, 11, true);
            flashCounter = flashLength;
        }
    }
}

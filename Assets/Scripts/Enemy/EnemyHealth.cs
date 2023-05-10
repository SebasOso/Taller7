using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    [SerializeField] private GameObject healthBar;
    private Renderer healthBarMaterial;
    public EnemyHealth instance { get; private set; }
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        healthBarMaterial = healthBar.GetComponent<Renderer>();
    }
    private void Update()
    {
        if (health > 0f)
        {
            if (health >= 50f)
            {
                healthBarMaterial.material.color = Color.green;
            }
            else if (health >= 25f)
            {
                healthBarMaterial.material.color = Color.yellow;
            }
            else
            {
                healthBarMaterial.material.color = Color.red;
            }
        }
        else
        {
            Player.Instance.enemyIsDead = true;
            MeleeEnemy.Instance.isDesesperation = false;
            gameObject.SetActive(false);
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
